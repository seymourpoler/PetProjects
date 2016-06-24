using System;

namespace Notis.Infrastructure
{
	public class ConsoleLogger : ILogger
	{
		public void Log (string msg, params object[] args)
		{
			Console.WriteLine (msg, args);
		}
	}
}

