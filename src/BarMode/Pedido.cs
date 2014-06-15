using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace BarMode
{
    public class Pedido
    {
        [DataMember(Name = "id")]
        public Guid Id { get; private set; }

        [DataMember(Name = "produto")]
        public Produto Produto { get; private set; }
     
        [DataMember(Name = "clientes")]
        public IList<Cliente> Clientes { get; set; }
        
        public Pedido(Produto produto, IList<Cliente> clientes)
        {
            Produto = produto;

            if (!clientes.Any())
                throw new ArgumentException("O pedido deve ter pelo menos um cliente");

            SetTotalPorCliente(clientes);

            Clientes = clientes;
                        
            Id = Guid.NewGuid();
        }

        private void SetTotalPorCliente(IList<Cliente> clientes)
        {
            var totalPorCliente = Produto.Preco/clientes.Count;

            foreach (var cliente in clientes)
            {
                cliente.Total = totalPorCliente;
            }
        }
        
        public void RegistrarPagamento(Cliente cliente)
        {
            Clientes.First(x => x.Equals(cliente)).Pago = true;
        }
        
        public decimal GetTotalPago()
        {
            var totalPago = Clientes.Where(x=> x.Pago).Sum(x=>x.Total);

            return totalPago;
        }

    }
}