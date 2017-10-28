using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinReconcile.Infra.Providers
{
    public interface IMarkOffFileProvider
    {
         string SaveMarkOffFile(Stream stream, string sessionId,string fileName);
         string GetMarkOffFile(string sessionId,string fileName);
    }
}
