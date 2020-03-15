using System.IO;
using System.Threading.Tasks;

namespace Microsoft.Extensions.FileProviders
{
    public static class FileRepositoryExtensions
    {
        public static async Task<string> ReadAsync(this IFileInfo file)
        {
            if (!file.Exists || file.IsDirectory)
                return null;
            using var fs = file.CreateReadStream();
            using var sw = new StreamReader(fs);
            return await sw.ReadToEndAsync();
        }

        public static async Task<byte[]> ReadBinaryAsync(this IFileInfo file)
        {
            if (!file.Exists || file.IsDirectory)
                return null;
            using var fs = file.CreateReadStream();
            var result = new byte[file.Length];
            await fs.ReadAsync(result, 0, result.Length);
            return result;
        }
    }
}
