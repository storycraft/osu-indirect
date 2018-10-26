using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osu_indirect.Main.Util
{
    public static class FileUtil
    {
        public static void WriteStream(Stream stream, string filePath, FileMode mode)
        {
            using (FileStream fs = new FileStream(filePath, mode))
            {
                byte[] buffer = new byte[65535];
                int size;
                while ((size = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fs.Write(buffer, 0, size);
                }

                fs.Close();
            }
        }

        public static Task WriteStreamAsync(Stream stream, string filePath, FileMode mode)
        {
            return new Task(() => WriteStream(stream, filePath, mode));
        }
    }
}
