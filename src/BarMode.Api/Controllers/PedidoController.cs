using System;
using System.Web.Http;
using BarMode.Api.Raven;
using Raven.Client;

namespace BarMode.Api.Controllers
{
    [RoutePrefix("api/mesa/{mesaId:guid}")]
    public class PedidoController : ApiController
    {
        private readonly IDocumentSession _ravenSession;

        public PedidoController()
        {
            _ravenSession = RavenManager.CurrentSession;
        }

        [Route("pedido")]
        public Guid PostPedido(Guid mesaId, Pedido pedido)
        {
            var mesa = _ravenSession.Load<Mesa>(mesaId);

            mesa.AdicionarPedido(pedido);

            return pedido.Id;
        }
    }
}