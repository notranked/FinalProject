using FinalExam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Logic
{
    public interface IDataManager
    {
        UsageData getReport();
    }
}
