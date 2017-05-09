using System;
using System.IO;

namespace Hashify.Crypto.HashFunctions
{
    public static class Sha1Toolbox
    {
        public static string GetFileHashAsString(string fileName, Func<byte[],string> bytesToHex)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    var hashBytes = sha1.ComputeHash(stream);
                    return bytesToHex(hashBytes);
                }
            }
        }
    }
}
