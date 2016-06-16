using System.IO;
using System.Web.Mvc;

namespace BugTracker.Web.ASP.Net.MVC
{
	public class BugTrackerView : IView
	{
		private readonly string physicalPath;

		public BugTrackerView(string physicalPath)
		{
			this.physicalPath = physicalPath;
		}

		public void Render(ViewContext viewContext, TextWriter writer)
		{
			var rawcontents = File.ReadAllText(physicalPath);
			writer.Write(rawcontents);
		}
	}
}

