using NUnit.Framework;

namespace BarModeTest.Old
{
    [TestFixture]
    public class IniciandoContaTest
    {
        [Test]
        public void AdicionandoClientes()
        {
            var conta = Bar.AbrirConta();

            conta.AddCliente("Cliente1");

            Assert.AreEqual("Cliente1", conta.Clientes[0]);
        }

        [Test]
        public void AdicionandoPedido()
        {
            var conta = Bar.AbrirConta();
            conta.AddPedido("Batata frita", 15.90m);

            Assert.AreEqual("Batata frita", conta.Pedidos[0].Nome);
            Assert.AreEqual(15.90, conta.Pedidos[0].Preco);
        }
    }

    [TestFixture]
    public class FechandoContaTest
    {

        [Test]
        public void UmCliente_UmPedido_PegandoTotal()
        {
            var conta = Bar.AbrirConta();
            conta.AddCliente("Cliente");
            conta.AddPedido("Misto quente", 10m);

            var contaFechada = conta.Fechar();

            Assert.AreEqual(10m, contaFechada.Total);
        }

        [Test]
        public void DoisClientes_UmPedido_PegandoTotalDoPrimeiroCliente()
        {
            var conta = Bar.AbrirConta();
            conta.Clientes.Add("Cliente1");
            conta.Clientes.Add("Cliente2");
            conta.AddPedido("Kibe",20m);

            var totalCliente1 = conta.GetTotalPorCliente();

            Assert.AreEqual(10m, totalCliente1);
        }
    }

    [TestFixture]
    public class StatusContaTest
    {
        [TestCase(20)]
        [TestCase(30)]
        [TestCase(460)]
        public void DoisClientes_UmPedido_PegandoTotalDoPrimeiroCliente(decimal valorDoPedido)
        {
            var conta = Bar.AbrirConta();
            conta.Clientes.Add("Cliente1");
            conta.Clientes.Add("Cliente2");
            conta.AddPedido("Kibe", valorDoPedido);

            var totalCliente1 = conta.GetTotalPorCliente();
            
            var valorEsperado = valorDoPedido/2;
            Assert.AreEqual(valorEsperado, totalCliente1);
        }

        public void TresClientes_so_o_primeiro_consumiu()
        {
            
        }
       
    }
}