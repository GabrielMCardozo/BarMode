using System;
using System.Collections.Generic;
using System.Linq;

namespace BarMode.Old
{
    public class Conta
    {

        public IList<string> Clientes { get; private set; }

        public IList<PedidoOld> Pedidos { get; private set; }

        public Conta()
        {
            Clientes = new List<string>();
            Pedidos = new List<PedidoOld>();
        }

        public void AddCliente(string cliente)
        {
            Clientes.Add(cliente);
        }

        public void AddPedido(string nome, decimal preco)
        {
            Pedidos.Add(new PedidoOld { Nome = nome, Preco = preco });
        }

        public ContaFechada Fechar()
        {
            var contaFechada = new ContaFechada();

            contaFechada.Total = Pedidos[0].Preco;

            return contaFechada;
        }

        public decimal GetTotalPorCliente()
        {
            var total = Pedidos.Sum(x => x.Preco);

            return total / Clientes.Count;
        }
    }

    public class ContaFechada
    {

        public Dictionary<string, decimal> ClienteTotal { get; set; }
        public decimal Total { get; set; }

        public decimal PegarTotalPorCliente(string cliente)
        {
            throw new NotImplementedException();
        }
    }
}