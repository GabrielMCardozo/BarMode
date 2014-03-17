using BarMode.Old;
using NUnit.Framework;

namespace BarModeTest.Old
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
