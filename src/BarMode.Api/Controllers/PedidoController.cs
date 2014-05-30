using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BarMode.Api.Raven;
using Raven.Client;

namespace BarMode.Api.Controllers
{
    [RoutePrefix("api/mesa/{mesaId:string}/pedido")]
    public class PedidoController : ApiController
    {
        private readonly IDocumentSession _ravenSession;

        public PedidoController()
        {
            _ravenSession = RavenManager.CurrentSession;
        }

        [Route("")]
        public IEnumerable<Pedido> GetPedido(string mesaId)
        {
            var mesa = _ravenSession.Load<Mesa>(mesaId);

            return mesa.Pedidos;
        }

        [Route("{pedidoId:guid}")]
        public Pedido GetPedido(string mesaId,Guid pedidoId)
        {
            var mesa = _ravenSession.Load<Mesa>(mesaId);

            var pedido = mesa.Pedidos.First(x => x.Id == pedidoId);

            return pedido;
        }

        [Route("")]
        public Guid PostPedido(string mesaId, Pedido pedido)
        {
            var mesa = _ravenSession.Load<Mesa>(mesaId);

            mesa.AdicionarPedido(pedido);

            _ravenSession.Store(mesa);
            _ravenSession.SaveChanges();

            return pedido.Id;
        }
    }
}