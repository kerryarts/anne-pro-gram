using System;
using System.Collections.Generic;

namespace Util
{
	/// <summary>
	/// Extension methods atop <see cref="IList{T}"/>
	/// </summary>
	public static class IListExtensions
	{
		/// <summary>
		/// Returns all indexes at which <paramref name="value"/> appears within <paramref name="source"/>
		/// </summary>
		public static int[] IndexesOf<T>(this IList<T> source, IList<T> value)
		{
			if (value.Count == 0)
				throw new ArgumentOutOfRangeException(nameof(value));

			var indexes = new List<int>();

			for (var i = 0; i + value.Count <= source.Count; i++)
			{
				if (source.ContainsAt(i, value))
					indexes.Add(i);
			}

			return indexes.ToArray();
		}

		/// <summary>
		/// Returns true if <paramref name="value"/> is contained within <paramref name="source"/> at <paramref name="startIndex"/>
		/// </summary>
		public static bool ContainsAt<T>(this IList<T> source, int startIndex, IList<T> value)
		{
			if (startIndex < 0 || startIndex >= source.Count)
				throw new ArgumentOutOfRangeException(nameof(startIndex));

			if (value.Count > (source.Count - startIndex))
				return false;

			for (var i = 0; i < value.Count; i++)
			{
				if (!Equals(source[startIndex + i], value[i]))
					return false;
			}

			return true;
		}
	}
}
