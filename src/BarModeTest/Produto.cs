namespace BarModeTest
{
    public class Produto
    {
        public string Nome { get; private set; }

        public decimal Preco { get; private set; }

        public Produto(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
       
    }
}