using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarMode;
using NUnit.Framework;

namespace BarModeTest
{
    [TestFixture]
    public class BarTest
    {
        [Test]
        public void AbrindoUmaConta()
        {
            var conta = Bar.AbrirConta();

            Assert.IsNotNull(conta);
        }
    }

    public class Bar
    {
        public static Conta AbrirConta()
        {
            return new Conta();
        }
    }
}
