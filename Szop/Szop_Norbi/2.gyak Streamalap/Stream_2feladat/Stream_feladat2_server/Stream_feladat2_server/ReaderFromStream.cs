using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stream_feladat2_server
{
    internal class ReaderFromStream
    {
        private StreamReader reader;
        private string line = null;


        private void DoRead()
        {

            line = reader.ReadLine();
        }              

        public string ReadLine(StreamReader reader, int timeOutMsc)
        {

            this.reader = reader;
            this.line = null;
            Thread t = new Thread(DoRead);
            t.Start();
            if (t.Join(timeOutMsc) == false)
                t.Abort();
            return line;
        }

    }
}
