using System;

namespace Notis.Infrastructure
{
	public static class Logger
	{
		static ILogger instance = new ConsoleLogger ();

		public static ILogger Instance
		{
			get { return instance; }
			set { instance = value; }
		}

		public static void Log (string msg, params object[] args)
		{
			instance.Log (msg, args);
		}

		public static void Mute ()
		{
			instance = new NullLogger ();
		}

		public static void Unmute ()
		{
			instance = new ConsoleLogger ();
		}
	}
}

