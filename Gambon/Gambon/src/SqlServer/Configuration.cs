using System;
using System.Configuration;

namespace Gambon.SqlServer
{
	public class Configuration
	{
		public  string ConnectionString{
			get{
				return ConfigurationManager.ConnectionStrings["Gambon"].ConnectionString;
			}
		}
	}
}
