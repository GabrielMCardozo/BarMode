using BarMode.Api.Raven;
using Raven.Client;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        [Route("{id}")]
        public Mesa Get(string id)
        {

            var mesa = _ravenSession.Load<Mesa>(id);
            return mesa;
        }
        
        [Route("")]
        public HttpResponseMessage Post(Mesa mesa)
        {
            var id = mesa.Id;

            var storedMesa = Get(id);

            if (storedMesa != null)
                return Request.CreateErrorResponse(HttpStatusCode.Conflict, "Já existe uma mesa com o nome: " + mesa.Nome);

            _ravenSession.Store(mesa);
            _ravenSession.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, mesa, "application/json");
        }

        [Route("")]
        public HttpResponseMessage Put(Mesa mesa)
        {
            var id = mesa.Id;

            var storedMesa = Get(id);

            if (storedMesa != null)
                return Request.CreateResponse(HttpStatusCode.OK, mesa, "application/json");

            _ravenSession.Store(mesa);
            _ravenSession.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, mesa, "application/json");
        }

        [Route("{id}/cliente/{nomeCliente}")]
        public Cliente GetCliente(string id,string nomeCliente)
        {

            var mesa = _ravenSession.Load<Mesa>(id);

            var cliente = mesa.Clientes.FirstOrDefault(x => x.Nome == nomeCliente);

            return cliente;
        }
        
    }
}
