using FinalExam.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalExam
{
    class Program
    {
        private static WebPoster poster;

        static void Main(string[] args)
        {
            /*DataManager dm = new DataManager();
            var obj = dm.getReport();

            Console.WriteLine(obj.timeStamp);
            Console.WriteLine(obj.processorUsage);
            Console.WriteLine(obj.memoryUsage);
            Console.ReadKey();*/
            
            Console.WriteLine("Application started");

            poster = new WebPoster(new DataManager());
            Timer t = new Timer(TimerCallback, null, 0, 30000);

            Console.ReadKey();
        }

        private static void TimerCallback(Object o)
        {
            poster.SendData();
        }
    }
}
