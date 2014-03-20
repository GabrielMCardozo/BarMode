using System.Runtime.Serialization;

namespace BarMode
{
    [DataContract]
    public class Cliente
    {
        [DataMember(Name = "nome")]
        public string Nome { get; private set; }

        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}