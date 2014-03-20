using System.Web;
using Raven.Client;

namespace BarMode.Api.Raven
{
    public static class RavenManager
    {
        public static IDocumentSession CurrentSession { get { return (IDocumentSession)HttpContext.Current.Items["CurrentRequestRavenSession"]; } }
    }
}