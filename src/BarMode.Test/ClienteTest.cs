using BarMode;
using NUnit.Framework;

namespace BarModeTest
{
    [TestFixture]
    public class ClienteTest
    {
        [Test]
        public void ClienteTemNome()
        {
            var cliente = new Cliente("Gabriel");

            Assert.AreEqual("Gabriel",cliente.Nome);
        }

    }
}