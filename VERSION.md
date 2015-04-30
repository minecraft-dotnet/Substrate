
#v2.0.0

##Changes:

* Added Name IDs to blocks and items
* Updated Biome IDs
* Updated built in BlockInfo blocks
* Updated built in ItemInfo items
* Updated Level metadata
* Nuget
* Added unit tests


##Breaking Changes:

* Entities and TileEntities have been moved to a separate library
* BlockInfo constructor now takes a nameId parameter.
* Setter functions on BlockInfo and ItemInfo have been changed to properties
* BlockInfoEx has been folded into BlockInfo, now check if TileEntityName is null instead of casting to BlockInfoEx