using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace BarMode
{
    [DataContract]
    public class Mesa
    {
        [DataMember(Name = "id")]
        public string Id { get { return Nome + Senha; } }

        [DataMember(Name = "nome")]
        public string Nome { get; private set; }

        [DataMember(Name = "senha")]
        public string Senha { get; private set; }

        [DataMember(Name = "clientes")]
        public IList<Cliente> Clientes { get { return GetClientes(); } }

        private readonly List<Pedido> _pedidos;

        [DataMember(Name = "pedidos")]
        public IEnumerable<Pedido> Pedidos
        {
            get { return _pedidos; }
        }

        public Mesa(string nome, string senha)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("A mesa deve ter um nome");

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException("A mesa deve ter uma senha de acesso");

            Nome = nome;
            Senha = senha;

            _pedidos = new List<Pedido>();
        }

        public void AdicionarPedido(Pedido pedido)
        {
            _pedidos.Add(pedido);
        }

        private IList<Cliente> GetClientes()
        {
            var clientes = _pedidos.SelectMany(x => x.Clientes).Distinct().ToList();

            clientes.ForEach(x=>x.Total = Total(x.Nome));

            return clientes;
        }

        public decimal Total(string nomeCliente)
        {
            var pedidosFiltrados = Pedidos.Where(x => x.Clientes.Any(y => y.Nome == nomeCliente));

            var totalGasto = pedidosFiltrados.Sum(x => x.TotalPorCliente());

            return totalGasto;
        }
    }
}