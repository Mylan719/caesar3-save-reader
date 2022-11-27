using CeasarSaveReader.Buildings;
using CeasarSaveReader.File;
using CeasarSaveReader.Map;
using CeasarSaveReader.Terrain;
using CeasarSaveReader.Tools;
using Microsoft.Extensions.Logging;

using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .AddFilter("Microsoft", LogLevel.Warning)
        .AddFilter("System", LogLevel.Warning)
        .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
        .AddConsole();
});

var fileLoader = new SaveFileReader();
var save = fileLoader.ReadSave("C:\\Path\\To\\Caesar 3\\C3\\Citizen.sav", 0);

var typeGrid = save.BuildingGrid.ForGrid((coords, b) => save.Buildings[b].type == BuildingType.GARDENS ? BuildingType.NONE : save.Buildings[b].type);

DebugWriter.PrintTerrain(save.Terrain);
DebugWriter.PrintGrid(save.BuildingGrid);
DebugWriter.PrintGrid(save.EdgeGrid.ForGrid((coords, e) => e.GetBuildingSize()));
DebugWriter.PrintBuildings(typeGrid);
DebugWriter.PrintGrid(save.Sprite);

