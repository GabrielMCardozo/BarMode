using System.Runtime.Serialization;

namespace BarMode
{
    [DataContract]
    public class Produto
    {
        [DataMember(Name = "nome")]
        public string Nome { get; private set; }

        [DataMember(Name = "preco")]
        public decimal Preco { get; private set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
       
    }
}