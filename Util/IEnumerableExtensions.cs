using System.Collections.Generic;

namespace Util
{
	public static class IEnumerableExtensions
	{
		public static string Join<T>(this IEnumerable<T> source, string seperator = "")
		{
			return string.Join(seperator, source);
		}
	}
}
