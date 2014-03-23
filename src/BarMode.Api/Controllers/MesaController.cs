using BarMode.Api.Raven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Raven.Client;

namespace BarMode.Api.Controllers
{
    public class MesaController : ApiController
    {
        private readonly IDocumentSession _ravenSession;

        public MesaController()
        {
            _ravenSession = RavenManager.CurrentSession;
        }

        public IList<Mesa> Get()
        {
            var mesas = _ravenSession.Query<Mesa>().ToList();
            return mesas;
        }

        public Mesa Get(Guid id)
        {
            var mesa = _ravenSession.Load<Mesa>(id);
            return mesa;
        }

        public Guid Post(Mesa mesa)
        {
            _ravenSession.Store(mesa);
            _ravenSession.SaveChanges();

            return mesa.Id;
        }
    }
}
