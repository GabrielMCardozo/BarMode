using System;
using System.Web.Http;

namespace BarMode.Api.Controllers
{
    public class MesaController : ApiController
    {
        public Guid Post(Mesa mesa)
        {
            return mesa.Id;
        }

        public Mesa Get(Guid mesaId)
        {
            return null;
        }
    }
}
