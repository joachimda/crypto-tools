using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashify.Crypto.HashFunctions
{
    public class Sha256ToolBox
    {
        public static string GetFileHashAsString(string fileName, Func<byte[], string> bytesToHex)
        {
            using (var sha2 = System.Security.Cryptography.SHA256.Create())
            {
                using (var stream = File.OpenRead(fileName))
                {
                    var hashBytes = sha2.ComputeHash(stream);
                    return bytesToHex(hashBytes);
                }
            }
        }
    }
}
