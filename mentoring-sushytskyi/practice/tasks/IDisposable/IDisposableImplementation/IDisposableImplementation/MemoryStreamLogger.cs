using System;
using System.IO;

namespace NetMentoring
{
    public class MemoryStreamLogger:IDisposable
    {
        private FileStream memoryStream;
        private StreamWriter streamWriter;
//        private bool _disposed=false; 

        public MemoryStreamLogger()
        {
            memoryStream = new FileStream(@"\log.txt", FileMode.OpenOrCreate);
            streamWriter = new StreamWriter(memoryStream);
        }

        public void Log(string message)
        {
   //         if (_disposed) throw new ObjectDisposedException("Object Disposed");
            if (memoryStream == null || streamWriter==null) throw new ObjectDisposedException("Object Disposed");
            
            streamWriter.Write(message);
        }


        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
//            if (_disposed) return;
            if (disposing && streamWriter != null && memoryStream!=null)
            {
                streamWriter.Dispose();
                memoryStream.Dispose();
                GC.SuppressFinalize(this);
                memoryStream = null;
                streamWriter = null;
            }
 //           _disposed = true;
        }
    }
}