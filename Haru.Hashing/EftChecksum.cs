using System.IO;
using Haru.Pools;

namespace Haru.Hashing
{
    public class EftChecksum
    {
        public static int Compute(Stream stream, int bufferSize)
        {
            int length;
            var result = 0;
            var buffer = ByteArrayPool.Rent(bufferSize);

            try
            {
                while ((length = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    for (var i = 0; i < length; ++i)
                    {
                        result += buffer[i];
                    }
                }

                return result;
            }
            finally
            {
                ByteArrayPool.Return(buffer);
            }
        }
    }
}