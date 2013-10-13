using System;
using System.Configuration;

namespace Infraestructure
{
    public  static class Configuracion
    {
        public static string ConnectionString 
        {
            get { return ConfigurationManager.ConnectionStrings["ActiveConnection"].ConnectionString; }
        }
    }
}
