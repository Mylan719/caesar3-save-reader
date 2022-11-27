/**
* Input stream for PKWare-compressed data
*/
namespace CeasarSaveReader.File
{
    public class PkwareInputStream : Stream
    {
        private Stream input;
        private int dictSize;
        private byte[] buffer;
        private int bufOffset;
        private int bufBit;
        private int dictionaryBits;
        private Dictionary dictionary;

        // For the reading of bytes:
        private int readOffset;
        private int readLength;
        private bool readCopying;
        private int dataLength;

        // For detecting end of stream:
        private bool eofReached;
        private int eofPosition;

        private bool atEnd;
        private bool hasError;

        private const int BUFFER_SIZE = 4096;

        public override bool CanRead => input.CanRead;

        public override bool CanSeek { get; } = false;

        public override bool CanWrite { get; } = false;

        public override long Length => throw new NotSupportedException("Lenght is not supported for compressed stream.");

        public override long Position
        {
            get => throw new NotSupportedException("Position is not supported for compressed stream.");
            set => throw new NotSupportedException("Position is not supported for compressed stream.");
        }

        /**
         * Creates a new input stream that reads a pkware-compressed stream.
         * 
         * @param input
         *            Input stream to read from, this is kept open!
         * @param length
         *            Length of the compressed data to read
         * @throws IOException
         *             On IO failure
         */
        public PkwareInputStream(Stream input, int length)
        {
            this.input = input;
            dataLength = length;
            init();
        }

        public int Read()
        {
            if (hasError)
            {
                return -1;
            }

            if (readCopying)
            {
                readLength--;
                if (readLength <= 0)
                {
                    readCopying = false;
                }
                return dictionary.get(readOffset);
            }
            else
            {
                if (readBit() == 0)
                {
                    // Copy byte verbatim
                    int result = readBits(8);
                    dictionary.put(result);
                    return result;
                }
                // Needs to copy stuff from the dictionary
                readLength = getCopyLength();
                if (readLength >= 519)
                {
                    hasError = atEnd = true;
                    return -1;
                }

                readOffset = getCopyOffset(readLength);
                readLength--;
                readCopying = true;
                return dictionary.get(readOffset);
            }
        }

        /**
         * Reads from the stream (and discards) until EOF is encountered
         */
        private void emptyStream()
        {
            if (hasError)
            {
                return;
            }
            while (!atEnd)
            {
                Read();
            }
        }

        /**
         * Initialises the stream
         */
        private void init()
        {
            if (dataLength <= 2)
            {
                throw new Exception("File too small");
            }

            readHeader();
            fillBuffer();
        }

        /**
         * Reads the 2-byte header and initialises the dictionary
         */
        private void readHeader()
        {
            // Read the header to decide on the encoding type
            int c = input.ReadByte();
            if (c != 0)
            {
                throw new Exception("Static dictionary not supported");
            }

            c = input.ReadByte();
            dictionaryBits = c;
            switch (dictionaryBits)
            {
                case 4:
                    dictSize = 1024;
                    break;
                case 5:
                    dictSize = 2048;
                    break;
                case 6:
                    dictSize = 4096;
                    break;
                default:
                    throw new Exception("Unknown dictionary size");
                    return;
            }
            dictionary = new Dictionary(dictSize);
            buffer = new byte[BUFFER_SIZE];
            dataLength -= 2; // Subtract two header bytes from total data length
        }

        /**
         * Gets the amount of bytes to copy from the dictionary
         */
        private int getCopyLength()
        {
            int bits;

            bits = readBits(2);
            if (bits == 3)
            { // 11
                return 3;
            }
            else if (bits == 1)
            { // 10x
                return 4 - 2 * readBit();
            }
            else if (bits == 2)
            { // 01
                if (readBit() == 1)
                { // 011
                    return 5;
                }
                else
                { // 010x
                    return 7 - readBit();
                }
            }
            else if (bits == 0)
            { // 00
                bits = readBits(2);
                if (bits == 3)
                { // 0011
                    return 8;
                }
                else if (bits == 1)
                { // 0010
                    if (readBit() == 1)
                    { // 00101
                        return 9;
                    }
                    else
                    { // 00100x
                        return 10 + readBit();
                    }
                }
                else if (bits == 2)
                { // 0001
                    if (readBit() == 1)
                    { // 00011xx
                        return 12 + readBits(2);
                    }
                    else
                    { // 00010xxx
                        return 16 + readBits(3);
                    }
                }
                else if (bits == 0)
                { // 0000
                    bits = readBits(2);
                    switch (bits)
                    {
                        case 3:
                            return 24 + readBits(4); // 000011xxxx
                        case 1:
                            return 40 + readBits(5); // 000010xxxxx
                        case 2:
                            return 72 + readBits(6); // 000001xxxxxx
                        case 0:
                            if (readBit() != 0)
                            {
                                return 136 + readBits(7); // 0000001xxxxxxx
                            }
                            else
                            {
                                return 264 + readBits(8); // 0000000xxxxxxxx
                            }
                    }
                }
            }
            // Cannot happen
            return -1;
        }

        /**
         * Gets the offset at which to start copying bytes from the dictionary
         */
        private int getCopyOffset(int length)
        {
            int lower_bits, result;
            if (length == 2)
            {
                lower_bits = 2;
            }
            else
            {
                lower_bits = dictionaryBits;
            }

            result = getCopyOffsetHigh() << lower_bits;
            result |= readBits(lower_bits);
            return result;
        }

        /**
         * Gets the "high" value of the copy offset, the lower N bits are stored
         * verbatim; N depends on the copy length and the dictionary size.
         */
        private int getCopyOffsetHigh()
        {
            int bits = readBits(2);
            if (bits == 3)
            { // 11
                return 0;
            }
            else if (bits == 1)
            { // 10
                bits = readBits(2);
                switch (bits)
                {
                    case 0:
                        return 0x6 - readBit(); // 1000x
                    case 1:
                        return 0x2; // 1010
                    case 2:
                        return 0x4 - readBit(); // 1001x
                    case 3:
                        return 0x1; // 1011
                }
            }
            else if (bits == 2)
            { // 01
                bits = readBits(4);
                if (bits == 0)
                {
                    return 0x17 - readBit();
                }
                else
                {
                    return 0x16 - reverse(bits, 4);
                }
            }
            else if (bits == 0)
            { // 00
                bits = readBits(2);
                switch (bits)
                {
                    case 3:
                        return 0x1f - reverse(readBits(3), 3);
                    case 1:
                        return 0x27 - reverse(readBits(3), 3);
                    case 2:
                        return 0x2f - reverse(readBits(3), 3);
                    case 0:
                        return 0x3f - reverse(readBits(4), 4);
                }
            }
            // Cannot happen
            return -1;
        }

        /**
         * Reverse the bits in `number', essentially converting it from little
         * endian to big endian or vice versa.
         */
        private int reverse(int number, int length)
        {
            if (length == 3)
            {
                switch (number)
                {
                    case 1:
                        return 4;
                    case 3:
                        return 6;
                    case 4:
                        return 1;
                    case 6:
                        return 3;
                    default:
                        return number;
                }
            }
            else if (length == 4)
            {
                switch (number)
                {
                    case 1:
                        return 8;
                    case 2:
                        return 4;
                    case 3:
                        return 12;
                    case 4:
                        return 2;
                    case 5:
                        return 10;
                    case 7:
                        return 14;
                    case 8:
                        return 1;
                    case 10:
                        return 5;
                    case 11:
                        return 13;
                    case 12:
                        return 3;
                    case 13:
                        return 11;
                    case 14:
                        return 7;
                    default:
                        return number;
                }
            }
            return number;
        }

        /**
         * Fill the internal buffer
         */
        private void fillBuffer()
        {
            if (hasError)
            {
                return;
            }
            bufOffset = 0;
            if (dataLength <= BUFFER_SIZE)
            {
                input.Read(buffer, 0, dataLength);
                eofReached = true;
                eofPosition = dataLength;
            }
            else
            {
                input.Read(buffer, 0, BUFFER_SIZE);
                dataLength -= BUFFER_SIZE;
            }
        }

        /**
         * Advances the data pointer one byte, filling the buffer if necessary
         */
        private void advanceByte()
        {
            bufOffset++;
            if (eofReached && bufOffset >= eofPosition)
            {
                throwError("Unexpected EOF");
                return;
            }
            if (bufOffset >= BUFFER_SIZE)
            {
                fillBuffer();
            }
            bufBit = 0;
        }

        /**
         * Reads one single bit
         */
        private int readBit()
        {
            if (bufBit == 8)
            {
                advanceByte();
            }
            int b = buffer[bufOffset] >> bufBit & 1;
            bufBit++;
            return b;
        }

        /**
         * Reads bits in little endian order
         * 
         * @param length
         *            Number of bits to read. Should never be more than 8.
         * @return int Value of the bits read
         */
        private int readBits(int length)
        {
            int result;
            if (bufBit == 8)
            {
                advanceByte();
            }
            // Check to see if we span multiple bytes
            if (bufBit + length > 8)
            {
                // First take last remaining bits in this byte & put them in place
                // Do "& 0xff" to prevent a negative character from filling with
                // ff's
                result = (buffer[bufOffset] & 0xff) >> bufBit;
                int length1 = 8 - bufBit;
                int length2 = length - length1;
                advanceByte();

                // Read length2 bits from the second byte & add them to the result
                result |= (buffer[bufOffset] & (1 << length2) - 1) << length1;
                bufBit = length2;
            }
            else
            {
                // Same byte, easy!
                result = buffer[bufOffset] >> bufBit & (1 << length) - 1;
                bufBit += length;
            }
            return result;
        }

        private void throwError(string message)
        {
            hasError = true;
            throw new IOException(message);
        }

        public override void Flush()
        {
            emptyStream();
            input.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (offset < 0) { throw new ArgumentOutOfRangeException(nameof(offset)); }
            if (count < 0) { throw new ArgumentOutOfRangeException(nameof(count)); }
            if (buffer is null) { throw new ArgumentNullException(nameof(buffer)); }

            for (int i = 0; i < count; i++)
            {
                var value = Read();
                if (value < 0) { return i; }
                buffer[offset + i] = (byte)value;
            }
            return count;
        }

        public override long Seek(long offset, SeekOrigin origin) => throw new NotSupportedException("Seeking is not supported for compressed stream.");

        public override void SetLength(long value) => throw new NotSupportedException("SetLength is not supported for compressed stream.");

        public override void Write(byte[] buffer, int offset, int count) => throw new NotSupportedException("Compression is not supported.");

        private class Dictionary
        {
            private int[] dictionary;
            private int size;
            private int first = -1;

            /**
             * Creates a new dictionary of size `size'
             */
            public Dictionary(int size)
            {
                dictionary = new int[size];
                this.size = size;
            }

            /**
             * Returns the byte at the specified position. Also does a PUT for this
             * byte since the compression algorithm requires it
             */
            public int get(int position)
            {
                int index = (size + first - position) % size;
                put(dictionary[index]);
                return dictionary[index];
            }

            /**
             * Adds a byte to the dictionary
             */
            public void put(int b)
            {
                first = (first + 1) % size;
                dictionary[first] = b;
            }
        }
    }
}
