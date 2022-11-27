# Caesar3 save game reader

Library for loading Caesar3 and Augustus saves. My intention is to support people that would like to do something interesting with the saved games in Unity or Stride game engines. So I decided to port it to C#.

Thanks to https://github.com/bvschaik for his tutorials and code base that enabled this project.

Check out https://github.com/bvschaik/julius and https://github.com/Keriew/augustus

## Code

Most of the code and data structures are migrated straight from augustus C based structs. I am slowly switching them to C# .Net 6 records introducing inheritance and generics where appropriate.

## Loader

Loads Caesar 3 or Augustus saved game into the `GameSave` object hierarchy. The `GameSave` contains grids for terrain, buildings, elevation, edge data, sprites,.. It also contains city statistics and scenario data. 

Notable are the `Buildings` and `Figure` lists that contain data of buildings and figures (characters roaming the city). They can be referenced by IDs stored in `BuildingGrid` and `FigureGrid`.

```
var fileLoader = new SaveFileReader();
var save = fileLoader.ReadSave("C:\\Path\\To\\Caesar 3\\C3\\Citizen.sav", 0);
```

## Grids

To help people manipulating map grid structures there is `Grid<TTile>` record that holds used pard of the map (maps are stored in arrays 162x162 of which nonly part is used mased on map size)

```CSharp
var grid = new Grid<TerrainType>(map.GridStart, map.Size);
//...Fill the grid with terrain data
var bridgeTiles = grid.ForTile((coords, terrain) => new { Coordinates = coords, IsBridge = terrain.IsRoad() && terrain.IsWater() });
```

There are `ForTile` and `ForGrid` extension methods that make iterating trough the grid easier.

## Coordinates

`GridOffset` is a record used to reference position within the grid. It is designed to work in conjustion with `Grid<TTile>`. It stores offset in the 1D grid array that is translated to `X` and `Y` coordinates. It supports basic operations.

This example gives building in on the position `X=10` `Y=9` of the "used" part of the map. 
```CSharp
var offset = new GridOffset(10, 10);

var building = save.BuildingGrid[offset.Down()];
```

## Pattern

`GridPattern<TTile>` is a record used to store 3x3 patter around a center point. This is usefull

This example gets neighburs of first aquaduct on the map using pattern:
```CSharp 
var aquaduct = terrain
    .ForTile((coords, tile) => (coords, tile))
    .FirstOrDefault(couple => couple.tile == TerrainType.AQUEDUCT);

var pattern = terrain.GetPattern(aquaduct.coords, TerrainType.OUTSIDE_MAP);

var neighburs = pattern.GetDirectNeighburs();
```
