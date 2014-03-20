using System;
using System.Collections.Generic;
using System.Linq;

namespace BarModeTest
{
    public class Mesa
    {
        public string Nome { get; private set; }
        public IList<Cliente> Clientes { get; private set; }
        public Guid Id { get; private set; }

        public Mesa(string nome, IList<Cliente> clientes)
        {
            Id = Guid.NewGuid();
            Nome = nome;

            if (!clientes.Any())
                throw new ArgumentException("A mesa deve ter pelo menos um cliente");


            Clientes = clientes;
        }

        
    }
}