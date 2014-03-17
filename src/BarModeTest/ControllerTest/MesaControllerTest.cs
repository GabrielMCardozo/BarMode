using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BarModeTest.ControllerTest
{

    [TestFixture]
   public class MesaControllerTest
    {
        [Test]
        public void PostMesa()
        {
            var mesaController = new MesaController();

            var mesa = new Mesa("minhaMesa", new List<Cliente> { new Cliente("Gabriel") });

            mesaController.Post(mesa);
        }

    }

    public class MesaController
    {
        public void Post(Mesa mesa)
        {
            
        }
    }
}
