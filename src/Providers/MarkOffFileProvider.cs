using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace FinReconcile.Providers
{
    public class MarkOffFileProvider : IMarkOffFileProvider
    {
        public string GetMarkOffFile(string sessionId, string fileName)
        {
            var clientMarkOffFilePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), sessionId, fileName);

            return File.ReadAllText(clientMarkOffFilePath);
        }

        public string SaveMarkOffFile(Stream stream,string sessionId,string fileName)
        {
            var sessionDirectory = Path.Combine(HttpContext.Current.Server.MapPath("~/Uploads"), sessionId);
            DirectoryInfo di = Directory.CreateDirectory(sessionDirectory);
            var clientMarkOffFilePath = Path.Combine(sessionDirectory, fileName);

            using (FileStream fileStream = File.Create(clientMarkOffFilePath, (int)stream.Length))
            {
                byte[] bytesInStream = new byte[stream.Length];
                stream.Read(bytesInStream, 0, (int)bytesInStream.Length);
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            }
            return sessionId;

        }
       
    }
}