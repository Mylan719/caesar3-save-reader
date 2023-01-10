using CeasarSaveReader.Buildings.Model;

namespace CeasarSaveReader.Buildings
{
    public static class BuildingExtensions
    {
        public static bool IsProgressComplete(this Building building)
        {
            var maxProgress = GetMaxProgress(building);

            return building.data is Industry industry &&  industry.progress >= maxProgress;
        }

        public static int GetMaxProgress(this Building building) =>
            building.subtype.workshop_type == WorkshopType.NONE
            ? Industry.MAX_PROGRESS_RAW
            : Industry.MAX_PROGRESS_WORKSHOP;
    }
}
