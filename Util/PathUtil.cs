using System.IO;

namespace Util
{
	public static class PathUtil
	{
		public static string AppendFileName(string filePath, string append)
		{
			var folder = Path.GetDirectoryName(filePath);
			var fileName = Path.GetFileNameWithoutExtension(filePath);
			var fileExtension = Path.GetExtension(filePath);

			return Path.Combine(folder, fileName + append + fileExtension);
		}
	}
}
