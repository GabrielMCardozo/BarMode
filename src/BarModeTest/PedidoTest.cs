using System;
using System.Collections.Generic;
using System.Linq;
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

            Assert.AreEqual(1.5m, pedido.TotalPorCliente());
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

    public class Pedido
    {
        public Produto Produto { get; private set; }

        public IEnumerable<Cliente> Clientes
        {
            get { return _clientesPagamentos.Select(x => x.Cliente).ToList(); }
        }

        private readonly IList<ClientePagamento> _clientesPagamentos;

        public Pedido(Produto produto, IList<Cliente> clientes)
        {
            Produto = produto;

            if (!clientes.Any())
                throw new ArgumentException("O pedido deve ter pelo menos um cliente");

            _clientesPagamentos = clientes.Select(x => new ClientePagamento(x)).ToList();

        }

        public decimal TotalPorCliente()
        {
            var totalPorCliente = Produto.Preco / _clientesPagamentos.Count;

            return totalPorCliente;

        }

        public void RegistrarPagamento(Cliente cliente)
        {
            _clientesPagamentos.First(x => x.Cliente.Equals(cliente)).pago = true;
        }


        public decimal GetTotalPago()
        {
            var totalPorCliente = TotalPorCliente();

            var qtdPagos = _clientesPagamentos.Count(x => x.pago);

            var totalPago = Produto.Preco - (qtdPagos*totalPorCliente);

            return totalPago;
        }

        internal class ClientePagamento
        {
            internal readonly Cliente Cliente;
            internal bool pago;

            public ClientePagamento(Cliente cliente)
            {
                Cliente = cliente;
            }
        }
    }
}