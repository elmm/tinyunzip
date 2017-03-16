# tinyunzip

Simple C# class for parsing and uncompressing zip archive without dependencies to ZipFile

Can be usseful for Unity3d projects limited to .NET 2.0 subset, which doesn't contain ZipFile functionality.

## Known limitations
 * supports only deflate and store compression methods
 * doesn't support ZIP64 and any other extensions
 * only one stream can be decompressed at the same time
