using CeasarSaveReader.Figures;

namespace CeasarSaveReader.Loader
{
    public abstract class ItemLoaderBase<TItem, TState>
        where TItem : ItemBase<TState>
        where TState : Enum
    {
        protected abstract TItem LoadItem(BinaryReader reader, int bufferSize, int saveVersion);

        public List<TItem> Load(Stream itemBuffer, Stream sequenceBuffer, bool includesListSize, int saveVersion)
        {
            var reader = new BinaryReader(itemBuffer);
            var items = new List<TItem>();

            //data.created_sequence = buffer_read_i32(seq);

            int figure_buf_size = Constants.ORIGINAL_BUFFER_SIZE;
            var buf_size = itemBuffer.Length;

            if (includesListSize)
            {
                figure_buf_size = reader.ReadInt32();
            }

            int highestId = 0;

            for (int i = 0; i < buf_size / figure_buf_size; i++)
            {
                var item = LoadItem(reader, figure_buf_size, saveVersion);
                item.id = items.Count;

                items.Add(item);
                if (Convert.ToByte(item.state) > 0)
                {
                    highestId = i;
                }
            }
            return items.GetRange(0, highestId + 1);
        }
    }
}
