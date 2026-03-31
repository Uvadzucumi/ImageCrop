# ImageCrop

crop png texture file with size **4096 x 2048** to 2 textures **2048 x 2048** and add **_1001**, **_1002** for new file names. 
required for import to Unrel Engine aka Virtual Texture 

## usage example

```ImageCrop.exe file_name.png```

create 2 files **file_name_1001.png** & **file_name_1002.png** for import to Unreal Engine

## add requirements
```
dotnet add package SixLabors.ImageSharp
```
## build with all dependences. including all .net requirements
~16 Mb.
```
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true -p:IncludeNativeLibrariesForSelfExtract=true
```
## buid without .NET, include only ImageSharp
~2 Mb.
```
dotnet publish -c Release -r win-x64 --self-contained false -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```