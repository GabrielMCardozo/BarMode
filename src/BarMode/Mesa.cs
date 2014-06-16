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
        
        [DataMember(Name = "pedidos")]
        public IList<Pedido> Pedidos { get; set; }

        public Mesa(string nome, string senha)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("A mesa deve ter um nome");

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException("A mesa deve ter uma senha de acesso");

            Nome = nome;
            Senha = senha;

            Pedidos = new List<Pedido>();
        }

        public void AdicionarPedido(Pedido pedido)
        {
            Pedidos.Add(pedido);
        }

        private IList<Cliente> GetClientes()
        {
            var clientes = Pedidos
                .SelectMany(x => x.Clientes).Distinct()
                .Select(y=>new Cliente(y.Nome)).ToList();

            foreach (var cliente in clientes)
                FillCliente(cliente);

            return clientes;
        }

        private void FillCliente(Cliente cliente)
        {
            var clientesPedido = Pedidos.SelectMany(x => x.Clientes).Where(y => y.Equals(cliente));

            cliente.Total = clientesPedido.Sum(x => x.Total);
            cliente.Pago = clientesPedido.All(x => x.Pago);
        }

        public void RegistrarPagamento(Cliente cliente)
        {
            foreach (var pedido in Pedidos)
            {
                if(pedido.Clientes.Any(x=>x.Equals(cliente)))
                    pedido.RegistrarPagamento(cliente);
            }

        }
    }
}