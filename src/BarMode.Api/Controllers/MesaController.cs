using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BarMode.Api.Controllers
{
    public class MesaController : ApiController
    {
        public Guid Post(Mesa mesa)
        {
            return Guid.NewGuid();
        }
    }
}
