# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [Unreleased - 2.0.0]

### Added:

* Added Name IDs to blocks and items
* Updated Biome IDs
* Updated built in BlockInfo blocks
* Updated built in ItemInfo items
* Updated Level metadata
* Nuget
* Added unit tests


### Changed:

* Entities and TileEntities have been moved to a separate library
* BlockInfo constructor now takes a nameId parameter.
* Setter functions on BlockInfo and ItemInfo have been changed to properties
* BlockInfoEx has been folded into BlockInfo, now check if TileEntityName is null instead of casting to BlockInfoEx
* Updated to .NET Standard 2.1