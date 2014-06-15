using System;
using System.Collections.Generic;
using System.Linq;
using BarMode;
using NUnit.Framework;

namespace BarModeTest
{
    [TestFixture]
    public class PedidoTest
    {
        [Test]
        public void PedidoTemProdutoCliente()
        {
            var clientes = new List<Cliente> { new Cliente("Gabriel") };
            var produto = new Produto("batata", 2.99m);

            var pedido = new Pedido(produto, clientes);

            Assert.AreEqual(produto, pedido.Produto);
            Assert.IsTrue(clientes.SequenceEqual(pedido.Clientes), "clientes");
        }

        [Test]
        public void SePassarListaVaziaDeClientes_LevantaErro()
        {
            var clientes = new List<Cliente>();
            var produto = new Produto("batata", 2.99m);

            Assert.Throws<ArgumentException>(() => new Pedido(produto, clientes));
        }

        [Test]
        public void TotalPorCliente()
        {
            var clientes = new List<Cliente> 
            { 
                new Cliente("Gabriel"), 
                new Cliente("Natalia") 
            };

            var produto = new Produto("batata", 3m);

            var pedido = new Pedido(produto, clientes);

            Assert.AreEqual(1.5m, pedido.Clientes[0].Total);
        }

        [Test]
        public void TotalPago()
        {
            var clientes = new List<Cliente> 
            { 
                new Cliente("Gabriel"), 
                new Cliente("Natalia") 
            };

            var produto = new Produto("batata", 3m);

            var pedido = new Pedido(produto, clientes);

            pedido.RegistrarPagamento(clientes[0]);

            Assert.AreEqual(1.5m, pedido.GetTotalPago());

        }

    }
}