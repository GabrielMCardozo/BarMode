using System.Runtime.Serialization;

namespace BarMode
{
    [DataContract]
    public class Cliente
    {
        protected bool Equals(Cliente other)
        {
            return string.Equals(Nome, other.Nome);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Cliente) obj);
        }

        public override int GetHashCode()
        {
            return (Nome != null ? Nome.GetHashCode() : 0);
        }

        [DataMember(Name = "nome")]
        public string Nome { get; private set; }

        public Cliente(string nome)
        {
            Nome = nome;
        }
    }
}