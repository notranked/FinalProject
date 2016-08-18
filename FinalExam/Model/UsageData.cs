using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Model
{
    public class UsageData
    {
        public DateTime timeStamp { get; set; }

        public int processorUsage { get; set; }

        public int memoryUsage { get; set; }
    }   
}
