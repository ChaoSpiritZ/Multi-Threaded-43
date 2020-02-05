using System;
using System.Collections.Generic;
using System.Threading;

namespace Multi_Threaded_43
{
    class AsyncPrinter
    {
        public List<string> _queue = new List<string>();
        private object key = new object();
        public bool sayThis = false; //just testing background threads

        public void AddMessage(string message)
        {
            lock (key)
            {
                _queue.Add(message);
                Monitor.Pulse(key);
            }
        }

        public void CheckPrintMessage()
        {
            while (true)
            {
                lock (key)
                {
                    while (_queue.Count == 0)
                    {
                        Monitor.Wait(key);
                    }
                    Console.WriteLine(_queue[0]);
                    _queue.RemoveAt(0);
                }
                if (sayThis) // testing background threads
                {
                    Console.WriteLine("oh hi there!");
                }
            }
        }
    }
}
