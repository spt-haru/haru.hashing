using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Haru.Hashing;

namespace Haru.Hashing.Tests.Units
{
    [TestClass]
    public class Md5Test
    {
        private const int _bufferSize = 4096;
        private readonly string _hash;
        private readonly string _text;
        private readonly byte[] _data;

        public Md5Test()
        {
            _hash = "6cd3556deb0da54bca060b4c39479839";
            _text = "Hello, world!";
            _data = Encoding.UTF8.GetBytes(_text);
        }

        [TestMethod]
        public void TestCompute()
        {
            using (var ms = new MemoryStream(_data))
            {
                var hash = Md5.Compute(ms, _bufferSize);
                var result = (hash == _hash);
                Assert.IsTrue(result);
            }
        }
    }
}