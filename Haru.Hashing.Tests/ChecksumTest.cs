using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Haru.Hashing;

namespace Haru.Hashing.Tests.Units
{
    [TestClass]
    public class ChecksumTest
    {
        private const int _bufferSize = 4096;
        private readonly int _checksum;
        private readonly string _text;
        private readonly byte[] _data;

        public ChecksumTest()
        {
            _checksum = 1161;
            _text = "Hello, world!";
            _data = Encoding.UTF8.GetBytes(_text);
        }

        [TestMethod]
        public void TestCompute()
        {
            using (var ms = new MemoryStream(_data))
            {
                var checksum = EftChecksum.Compute(ms, _bufferSize);
                var result = (checksum == _checksum);
                Assert.IsTrue(result);
            }
        }
    }
}