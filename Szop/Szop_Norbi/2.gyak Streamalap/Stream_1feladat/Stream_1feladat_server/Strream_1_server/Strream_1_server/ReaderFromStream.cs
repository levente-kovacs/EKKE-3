using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Strream_1_server
{
    internal class ReaderFromStream
    {
        private StreamReader r;
        private string line = null;

        private void DoRead()
        {
            try
            {
                line = r.ReadLine();
            }
            catch
            {
                Console.WriteLine("A kapcsolat váratlanul megszakadt");
            }
        }
        public string ReadLine(StreamReader r, int timeOutMsc)
        {
            this.r = r;
            this.line = null;
            Thread t = new Thread(DoRead);
            t.Start();
            if(t.Join(timeOutMsc)== false)
            {
                t.Abort();
                return "A kapcsolat megszakadt";
            }
            return line;
        }

    }
}
