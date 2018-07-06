using System.Linq;
using Util;

namespace AnneProGram.Firmware
{
	public class FirmwareEditor
	{
		private readonly byte[] FirmwareBytes;

		public FirmwareEditor(byte[] firmwareBytes)
		{
			FirmwareBytes = firmwareBytes.ToArray();
		}

		public byte[] GetBytes()
		{
			// Return a copy
			return FirmwareBytes.ToArray();
		}

		public void ApplyMod(FirmwareMod mod)
		{
			foreach (var replacement in mod.Replacements)
			{
				var indexes = FirmwareBytes.IndexesOf(replacement.From);

				if (indexes.Length == 0)
					throw new FirmwareEditException($"No indexes found for {replacement.From.PrettyPrint()}");

				if (indexes.Length > 1)
					throw new FirmwareEditException($"More than 1 indexes found for {replacement.From.PrettyPrint()}: {string.Join(", ", indexes)}");

				var index = indexes.Single();

				for (var i = 0; i < replacement.To.Length; i++)
					FirmwareBytes[index + i] = replacement.To[i];
			}
		}
	}
}
