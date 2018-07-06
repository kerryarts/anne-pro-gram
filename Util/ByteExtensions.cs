using System;
using System.Collections.Generic;

namespace Util
{
	/// <summary>
	/// Extension methods atop <see cref="byte"/> and <see cref="byte"/>[]
	/// </summary>
	public static class ByteExtensions
	{
		/// <summary>
		/// Returns all indexes at which <paramref name="value"/> appears within <paramref name="source"/>
		/// </summary>
		public static int[] IndexesOf(this byte[] source, byte[] value)
		{
			if (value.Length == 0)
				throw new ArgumentOutOfRangeException(nameof(value));

			var indexes = new List<int>();

			for (var i = 0; i + value.Length <= source.Length; i++)
			{
				if (source.ContainsAt(i, value))
					indexes.Add(i);
			}

			return indexes.ToArray();
		}

		/// <summary>
		/// Returns true if <paramref name="value"/> is contained within <paramref name="source"/> at <paramref name="startIndex"/>
		/// </summary>
		public static bool ContainsAt(this byte[] source, int startIndex, byte[] value)
		{
			if (startIndex < 0 || startIndex >= source.Length)
				throw new ArgumentOutOfRangeException(nameof(startIndex));

			if (value.Length > (source.Length - startIndex))
				return false;

			for (var i = 0; i < value.Length; i++)
			{
				if (source[startIndex + i] != value[i])
					return false;
			}

			return true;
		}
	}
}
