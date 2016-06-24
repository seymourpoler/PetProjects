using System;

namespace Notis.Infrastructure
{
	public interface ILogger
	{
		void Log (string msg, params object[] args);
	}
}

