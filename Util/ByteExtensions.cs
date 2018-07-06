using System;

namespace Util
{
	public static class ByteExtensions
	{
		public static byte[] GetBytes(this ushort uShort)
		{
			var bytes = BitConverter.GetBytes(uShort);

			Array.Reverse(bytes);

			return bytes;
		}

		public static byte[] GetBytes(this uint uInteger)
		{
			var bytes = BitConverter.GetBytes(uInteger);

			Array.Reverse(bytes);

			return bytes;
		}

		public static string PrettyPrint(this byte[] bytes)
		{
			return BitConverter.ToString(bytes);
		}
	}
}
