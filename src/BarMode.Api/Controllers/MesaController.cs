using BarMode.Api.Raven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Raven.Client;

namespace BarMode.Api.Controllers
{
    [RoutePrefix("api/mesa")]
    public class MesaController : ApiController
    {
        private readonly IDocumentSession _ravenSession;

        public MesaController()
        {
            _ravenSession = RavenManager.CurrentSession;
        }

        [Route("")]
        public IList<Mesa> Get()
        {
            var mesas = _ravenSession.Query<Mesa>().ToList();
            return mesas;
        }

        [Route("{id:string}")]
        public Mesa Get(string id)
        {
            var mesa = _ravenSession.Load<Mesa>(id);
            return mesa;
        }

        [Route("")]
        public Mesa Post(Mesa mesa)
        {
            _ravenSession.Store(mesa);
            _ravenSession.SaveChanges();

            return mesa;
        }
    }
}
