using NUnit.Framework;

namespace BarModeTest
{
    [TestFixture]
    public class ClienteTest
    {
        [Test]
        public void PessoaTemNome()
        {
            var cliente = new Cliente("Gabriel");

            Assert.AreEqual("Gabriel",cliente.Nome);
        }

    }

    public class Cliente
    {
        public string Nome { get; private set; }

        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}