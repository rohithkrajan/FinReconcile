using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FinConcile.Tests.TestUtils
{
    public class Utilities
    {
        public static HttpPostedFileBase GetMockHttpPostedFile(string fileContent,string fileName)
        {
            Mock<HttpPostedFileBase> file = new Mock<HttpPostedFileBase>();
            file.Setup(x => x.InputStream).Returns(GenerateStreamFromString(fileContent));
            file.Setup(x => x.ContentLength).Returns(fileContent.Length);
            file.Setup(x => x.FileName).Returns(fileName);
            return file.Object;            
        }
        public static Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
