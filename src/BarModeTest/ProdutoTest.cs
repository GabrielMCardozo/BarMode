using System;
using NUnit.Framework;

namespace BarModeTest
{
    [TestFixture]
    public class ProdutoTest
    {
        [Test]
        public void ProdutoTemNomeEPreco()
        {
            var produto = new Produto("batata", 5.00m);

            Assert.AreEqual("batata",produto.Nome,"nome");
            Assert.AreEqual(5.00m,produto.Preco,"preço");
        }
    }

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