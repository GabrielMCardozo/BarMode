using BarMode;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BarModeTest
{

    [TestFixture]
    public class MesaTest
    {
        [Test]
        public void NovaMesaTemNomeIdEClientes()
        {
            var clientes = new List<Cliente> {new Cliente("Gabriel")};

            var mesa = new Mesa("NossaMesa", clientes);

            Assert.AreEqual("NossaMesa",mesa.Nome,"nome");
            Assert.AreEqual("Gabriel",mesa.Clientes[0].Nome);
            Assert.IsNotNull(mesa.Id);
        }

        [Test]
        public void SePassarListaVaziaDeClientes_LevantaErro()
        {
            var clientes = new List<Cliente>();
            

            Assert.Throws<ArgumentException>(() => new Mesa("NossaMesa", clientes));
        }
    }
}