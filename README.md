# ImageCrop

Reads a PNG image and if the width is several times greater than the height, it divides it into square images, appending 1001, 1002... 100N to the file names. This is necessary for importing this images by virtual textures into Unreal Engine. 

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