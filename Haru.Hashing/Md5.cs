using System.IO;
using System.Security.Cryptography;
using Haru.Pools;
using Haru.Converters;

namespace Haru.Hashing
{
    public class Md5
    {
        public static string Compute(Stream stream, int bufferSize)
        {
            using (var md5 = MD5.Create())
            {
                using (var cs = new CryptoStream(stream, md5, CryptoStreamMode.Read))
                {
                    var buffer = ByteArrayPool.Rent(bufferSize);

                    try
                    {
                        // read all bytes to calculate hash
                        while (cs.Read(buffer, 0, buffer.Length) != 0);
                    }
                    finally
                    {
                        ByteArrayPool.Return(buffer);
                    }

                    // convert hash to string
                    return ByteArray.ToString(md5.Hash);
                }
            }
        }
    }
}