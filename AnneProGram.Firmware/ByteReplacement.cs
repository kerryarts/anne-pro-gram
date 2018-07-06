using System;
using Util;

namespace AnneProGram.Firmware
{
	public class ByteReplacement
	{
		public readonly byte[] From;
		public readonly byte[] To;

		public ByteReplacement(byte[] from, byte[] to)
		{
			if (from.Length != to.Length)
				throw new ArgumentException("Arrays must be same length", nameof(from));

			From = from;
			To = to;
		}

		public static ByteReplacement For(byte from, byte to)
		{
			return new ByteReplacement(new[] { from }, new[] { to });
		}

		public static ByteReplacement For(ushort from, ushort to)
		{
			return new ByteReplacement(from.GetBytes(), to.GetBytes());
		}

		public static ByteReplacement For(uint from, uint to)
		{
			return new ByteReplacement(from.GetBytes(), to.GetBytes());
		}
	}
}
