using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Raven.Client;
using Raven.Client.Document;

namespace BarMode.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IDocumentStore DocumentStore { get; private set; }
        
        public WebApiApplication()
        {
            BeginRequest += Application_BeginRequest;
            EndRequest += Application_EndRequest;
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Items["CurrentRequestRavenSession"] = DocumentStore.OpenSession();
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
            using (var session = (IDocumentSession)HttpContext.Current.Items["CurrentRequestRavenSession"])
            {
                if (session == null)
                    return;

                if (Server.GetLastError() != null)
                    return;

                session.SaveChanges();
            }
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            InitializeDocumentStore();
        }

        private static void InitializeDocumentStore()
        {
            if (DocumentStore != null) return; // prevent misuse

            DocumentStore = new DocumentStore
            {
                ConnectionStringName = "RAVENHQ_CONNECTION_STRING"
            }.Initialize();

        }


    }
}
