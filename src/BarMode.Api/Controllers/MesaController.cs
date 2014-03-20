using System;
using System.Web.Http;
using BarMode.Api.Raven;

namespace BarMode.Api.Controllers
{
    public class MesaController : ApiController
    {
        public Guid Post(Mesa mesa)
        {
            var session = RavenManager.CurrentSession;

            session.Store(mesa);
            session.SaveChanges();

            return mesa.Id;
        }

        public Mesa Get(Guid mesaId)
        {
            var session = RavenManager.CurrentSession;

            var mesa = session.Load<Mesa>(mesaId);

            return mesa;
        }
    }
}
