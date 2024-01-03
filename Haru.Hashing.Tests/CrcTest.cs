using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Haru.Hashing;

namespace Haru.Hashing.Tests.Units
{
    [TestClass]
    public class CrcTest
    {
        private readonly uint _hash;
        private readonly string _text;
        private readonly byte[] _data;

        public CrcTest()
        {
            _hash = 0xEBE6C6E6;
            _text = "Hello, world!";
            _data = Encoding.UTF8.GetBytes(_text);
        }

        [TestMethod]
        public void TestComputeBytes()
        {
            var hash = Crc32.Compute(_data);
            var result = (hash == _hash);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestComputeText()
        {
            var bytes = Encoding.UTF8.GetBytes(_text);
            var hash = Crc32.Compute(bytes);
            var result = (hash == _hash);
            Assert.IsTrue(result);
        }
    }
}