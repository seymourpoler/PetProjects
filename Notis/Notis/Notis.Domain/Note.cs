using System;

namespace Notis.Domain
{
	public class Note
	{
		public string Title{ get; private set;}
		public string Body{ get; private set;}
		public DateTime CreationDate{ get; private set;}

		private Note (string title, string body)
		{
			CreationDate = DateTime.Now;
		}

		public static Note CreaTe(string title, string body){
			if (String.IsNullOrWhiteSpace (title)) {
				throw new TitleNoteCanNotBeEmptyException ();
			}
			if (String.IsNullOrWhiteSpace (body)) {
				throw new BodyNoteCanNotBeEmptyException ();
			}
			return new Note (title, body);
		}
	}

	public class TitleNoteCanNotBeEmptyException:Exception{}
	public class BodyNoteCanNotBeEmptyException:Exception{}
}

