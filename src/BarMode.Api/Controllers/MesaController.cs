using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BarMode.Api.Raven;
using Newtonsoft.Json;

namespace BarMode.Api.Controllers
{
    public class MesaController : ApiController
    {
        public IList<Mesa> Get()
        {
            var session = RavenManager.CurrentSession;

            var mesas = session.Query<Mesa>().ToList();

            return mesas;
        }

        public Mesa Get(Guid id)
        {
            var session = RavenManager.CurrentSession;

            var mesa = session.Load<Mesa>(id);

            return mesa;
        }

        public Guid Post(Mesa mesa)
        {
            var session = RavenManager.CurrentSession;

            session.Store(mesa);
            session.SaveChanges();

            return mesa.Id;
        }

       
    }
}
