using System;
using System.IO;

namespace Hashify.Crypto.HashFunctions
{
    public class Sha384ToolBox
    {
        public static string GetFileHashAsString(string fileName, Func<byte[], string> bytesToHex)
        {
            using (var sha3 = System.Security.Cryptography.SHA384.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    var hashBytes = sha3.ComputeHash(stream);
                    return bytesToHex(hashBytes);
                }
            }
        }
    }
}