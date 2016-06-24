using System;

namespace Notis.Infrastructure
{
	public class NullLogger : ILogger
	{
		public void Log (string msg, params object[] args)
		{
		}
	}
}

