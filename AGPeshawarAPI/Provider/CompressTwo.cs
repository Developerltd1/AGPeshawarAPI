using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AGPeshawarAPI.Provider
{
    public class CompressTwo
    {

        bool success;

        string strBase64 = "VGhlIHF1aWNrIGJyb3duIGZveCBqdW1wZWQgb3ZlciB0aGUgbGF6eSBkb2cuDQpUaGUgcXVpY2sgYnJvd24gZm94IGp1bXBlZCBvdmVyIHRoZSBsYXp5IGRvZy4NClRoZSBxdWljayBicm93biBmb3gganVtcGVkIG92ZXIgdGhlIGxhenkgZG9nLg0KVGhlIHF1aWNrIGJyb3duIGZveCBqdW1wZWQgb3ZlciB0aGUgbGF6eSBkb2cuDQpUaGUgcXVpY2sgYnJvd24gZm94IGp1bXBlZCBvdmVyIHRoZSBsYXp5IGRvZy4NCg0K";

        Chilkat.Compression compress = new Chilkat.Compression();
        compress.Algorithm = "deflate";

Chilkat.BinData binDat = new Chilkat.BinData();
        // Load the base64 data into a BinData object.
        // This decodes the base64. The decoded bytes will be contained in the BinData.
        binDat.AppendEncoded(strBase64,"base64");

// Compress the BinData.
compress.CompressBd(binDat);

// Get the compressed data in base64 format:
string compressedBase64 = binDat.GetEncoded("base64");
        Debug.WriteLine("compressed base64:");
Debug.WriteLine(compressedBase64);

// The compressed base64 is: C8lIVSgszUzOVkgqyi/PU0jLr1DIKs0tSE1RyC9LLVIoAcrnJFZVKqTkp+vxcoUMYeW8XAA=

// Now decompress:
binDat.Clear();
binDat.AppendEncoded(compressedBase64,"base64");
compress.DecompressBd(binDat);

string decompressedBase64 = binDat.GetEncoded("base64");
        Debug.WriteLine("decompressed base64:");
Debug.WriteLine(decompressedBase64);

// The output is the original data:
// VGhlIHF1aWNrIGJyb3duIGZveCBqdW1wZWQgb3ZlciB0aGUgbGF6eSBkb2cuDQpUaGUgcXVpY2sgYnJvd24gZm94IGp1bXBlZCBvdmVyIHRoZSBsYXp5IGRvZy4NClRoZSBxdWljayBicm93biBmb3gganVtcGVkIG92ZXIgdGhlIGxhenkgZG9nLg0KVGhlIHF1aWNrIGJyb3duIGZveCBqdW1wZWQgb3ZlciB0aGUgbGF6eSBkb2cuDQpUaGUgcXVpY2sgYnJvd24gZm94IGp1bXBlZCBvdmVyIHRoZSBsYXp5IGRvZy4NCg0K


    }
}