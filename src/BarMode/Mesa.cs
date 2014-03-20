using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace BarMode
{
    [DataContract]
    public class Mesa
    {
        [DataMember(Name = "nome")]
        public string Nome { get; private set; }
        [DataMember(Name = "clientes")]
        public IList<Cliente> Clientes { get; private set; }
        
        [IgnoreDataMember]
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