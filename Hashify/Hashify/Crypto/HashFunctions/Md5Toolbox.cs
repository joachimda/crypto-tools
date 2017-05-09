using System;
using System.IO;

namespace Hashify.Crypto.HashFunctions
{
    public static class Md5Toolbox
    {
        public static string GetFileHashAsString(string fileName, Func<byte[], string> bytesToHex)
        {
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    var hashBytes = md5.ComputeHash(stream);
                    return bytesToHex(hashBytes);
                }
            }
        }
    }
}
