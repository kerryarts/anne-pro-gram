using AnneProGram.Firmware;
using System;
using System.IO;
using System.Linq;

namespace AnneProGram
{
	public class Program
	{
		public static int Main(string[] args)
		{
			if (args.Length == 0)
				return ShowUsage();

			switch (args[0])
			{
				case "-fw" when (args.Length == 2):
					return Firmware(args[1]);

				default:
					return ShowUsage();
			}
		}

		private static int Firmware(string inputFilePath)
		{
			try
			{
				var inputBytes = File.ReadAllBytes(inputFilePath);
				var editor = new FirmwareEditor(inputBytes);
				var mods = FirmwareMods.Values;

				foreach (var mod in mods)
					editor.ApplyMod(mod);

				var outputBytes = editor.GetBytes();

				var inputFolder = Path.GetDirectoryName(inputFilePath);
				var inputFileName = Path.GetFileNameWithoutExtension(inputFilePath);
				var inputFileExtension = Path.GetExtension(inputFilePath);
				var outputFileName = $"{inputFileName}_{string.Join("_", mods.Select(m => m.Name))}{inputFileExtension}";
				var outputFilePath = Path.Combine(inputFolder, outputFileName);

				File.WriteAllBytes(outputFilePath, outputBytes);

				Console.WriteLine("Done.");
				return 0;
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine(ex);
				return -1;
			}
		}

		private static int ShowUsage()
		{
			Console.WriteLine("Usage:");
			Console.WriteLine("\t-fw inputFilePath");
			return -1;
		}
	}
}
