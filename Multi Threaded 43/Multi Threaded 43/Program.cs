using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Multi_Threaded_43
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncPrinter AP = new AsyncPrinter();
            Thread[] threads = new Thread[10];
            for (int i = 0; i < 10; i++)
            {
                threads[i] = new Thread(AP.CheckPrintMessage);
                threads[i].IsBackground = true;
                threads[i].Start();
            }

            for (int i = 0; i < 100; i++)
            {
                AP.AddMessage($"message {i + 1}");
                Thread.Sleep(100);
            }
            AP.sayThis = true; //testing background threads
        }
    }
}
