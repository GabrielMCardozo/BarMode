using NUnit.Framework;
using System.Linq;

namespace BarMode.Test
{

    [TestFixture]
    public class MesaTest
    {
        [Test]
        public void NovaMesaTemNomeSenha()
        {
            var mesa = new Mesa("NossaMesa", "Senha");

            Assert.AreEqual("NossaMesa",mesa.Nome,"nome");
            Assert.AreEqual("Senha",mesa.Senha,"senha");
        }

        [Test]
        public void IdDaMesaEhFormadoDoNomeMaisSenha()
        {
            var mesa = new Mesa("NossaMesa", "Senha");

            Assert.AreEqual("NossaMesaSenha",mesa.Id);
        }

        [Test]
        public void FazendoUmPedido()
        {
            var pedido = new Pedido(new Produto("Batata", 10m), new[] {new Cliente("gabriel")});

            var mesa = new Mesa("test", "senha");

            mesa.AdicionarPedido(pedido);

            Assert.AreEqual(pedido.Id,mesa.Pedidos.ToArray()[0].Id);
        }

        [Test]
        public void OsClientesSaoAdicionadosJuntosComOPedido()
        {
            var mesa = new Mesa("test", "senha");

            var pedido = new Pedido(new Produto("Batata", 10m), new[] { new Cliente("gabriel") });
            
            mesa.AdicionarPedido(pedido);

            Assert.AreEqual("gabriel",mesa.Clientes[0].Nome);

        }

        [Test]
        public void OsClientesQueJaForamAdicionadosNãoPodemRepetir()
        {
            var mesa = new Mesa("test", "senha");

            var pedido = new Pedido(new Produto("Batata", 10m), new[] { new Cliente("gabriel") });
            var pedido2 = new Pedido(new Produto("Abobora", 15m), new[] { new Cliente("gabriel") });

            mesa.AdicionarPedido(pedido);
            mesa.AdicionarPedido(pedido2);

            Assert.IsTrue(mesa.Clientes.Count(x=>x.Nome == "gabriel") == 1,"Tem mais de um cliente");

        }
    }
}