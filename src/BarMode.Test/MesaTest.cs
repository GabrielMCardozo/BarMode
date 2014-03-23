using System.Linq;
using BarMode;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BarMode.Test
{

    [TestFixture]
    public class MesaTest
    {
        [Test]
        public void NovaMesaTemNomeIdEClientes()
        {
            var clientes = new List<Cliente> {new Cliente("Gabriel")};

            var mesa = new Mesa("NossaMesa", clientes);

            Assert.AreEqual("NossaMesa",mesa.Nome,"nome");
            Assert.AreEqual("Gabriel",mesa.Clientes[0].Nome);
            Assert.IsNotNull(mesa.Id);
        }

        [Test]
        public void SePassarListaVaziaDeClientes_LevantaErro()
        {
            var clientes = new List<Cliente>();
            

            Assert.Throws<ArgumentException>(() => new Mesa("NossaMesa", clientes));
        }

        [Test]
        public void FazendoUmPedido()
        {
            var pedido = new Pedido(new Produto("Batata", 10m), new[] {new Cliente("gabriel")});

            var mesa = new Mesa("test", new[] {new Cliente("gabriel")});

            mesa.AdicionarPedido(pedido);

            Assert.AreEqual(pedido.Id,mesa.Pedidos.ToArray()[0].Id);
        }
    }
}