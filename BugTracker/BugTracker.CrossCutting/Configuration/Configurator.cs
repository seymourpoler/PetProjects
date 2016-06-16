using System;
using System.Configuration;

namespace BugTracker.CrossCutting.Configuration
{
	public interface IConfigurator{
		string GetValue (string key);
	}
	public class Configurator : IConfigurator
	{
		public string GetValue(string key){
			return ConfigurationManager.AppSettings [key];
		}
	}
}

