using System;
using BarMode;
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
}