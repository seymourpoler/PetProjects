
using System;

namespace Gambon.Core
{
	public static class StringExtensions
	{
		public static bool IsNullOrWhiteSpace(this string text)
		{
			return String.IsNullOrWhiteSpace(text);
		}
		
		public static string FormatWith(this string text, params object[] parameters)
		{
			if(String.IsNullOrWhiteSpace(text)){
				return String.Empty;
			}
			if(parameters.IsNull()){
				return String.Empty;
			}
			return String.Format(text, parameters);
		}
	}
}
