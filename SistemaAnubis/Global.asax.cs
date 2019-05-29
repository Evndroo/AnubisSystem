using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SistemaAnubis
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        
        public sealed class Session
        {

            private static volatile Session instance;
            private static object sync = new Object();

            private Session() { }

            public static Session Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (sync)
                        {
                            if (instance == null)
                            {
                                instance = new Session();
                            }
                        }
                    }
                    return instance;
                }

            }
            public  string User { get; set; }

            public string Senha { get; set; }

            public string Codigo { get; set; }

            public string CodUser { get; set; }

            public string Nome { get; set; }

            public string Cpf { get; set; }

            public string Email { get; set; }

            public string Telefone { get; set; }

            public string Celular { get; set; }

            public string Cep { get; set; }

            public string Num { get; set; }

            public string Nvl { get; set; }

            public string erro;


        }
    }
}
