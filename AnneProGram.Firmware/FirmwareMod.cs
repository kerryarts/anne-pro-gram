namespace AnneProGram.Firmware
{
	public class FirmwareMod
	{
		public readonly string Name;
		public readonly ByteReplacement[] Replacements;

		public FirmwareMod(string name, params ByteReplacement[] replacements)
		{
			Name = name;
			Replacements = replacements;
		}
	}
}
