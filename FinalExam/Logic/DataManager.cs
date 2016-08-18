using FinalExam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Logic
{
    public class DataManager : IDataManager
    {
        private DateTime getTimeStamp()
        {
            return DateTime.Now;
        }

        private int getProcessorUsage()
        {
            var value = "";
            var managementObjectCollection1 = Searcher("Win32_PerfFormattedData_PerfOS_Processor");
            foreach (var obj in managementObjectCollection1)
            {
                value = obj["PercentProcessorTime"].ToString();
            }
            var vl = Int32.Parse(value);
            return vl;
        }

        public int getMemoryUsage()
        {
            var value = "";
            var managementObjectCollection2 = Searcher("Win32_OperatingSystem");
            
            foreach (var obj in managementObjectCollection2)
            {
                var freeMemory = Convert.ToDouble(obj["FreePhysicalMemory"]);
                var totalMemory = Convert.ToDouble(obj["TotalVisibleMemorySize"]);
                value = Math.Round((totalMemory - freeMemory) / totalMemory * 100, 0).ToString();
            }
            var vl = Int32.Parse(value);
            return vl;
        }


        private ManagementObjectCollection Searcher(String query)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                "select * from " + query);
            var collection = searcher.Get();
            return collection;
        }

        public UsageData getReport()
        {
            var usageData = new UsageData()
            {
                timeStamp = getTimeStamp(),
                processorUsage = Convert.ToInt16(getProcessorUsage()),
                memoryUsage = Convert.ToInt16(getMemoryUsage())
            };

            return usageData;
        }
    }
}
