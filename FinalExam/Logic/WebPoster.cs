using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Logic
{
    public class WebPoster
    {
        private IDataManager _dataManager;
        private string _url = "api/virtualmachines/23/usagereports";
        public WebPoster(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void SendData()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri("http://192.168.10.106/")
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            postData(client);
        }

        private async void postData(HttpClient client)
        {
            var report = _dataManager.getReport();
            Console.WriteLine("Processor usage: " + report.processorUsage);
            Console.WriteLine("Ram usage: " + report.memoryUsage);
            var response = await client.PostAsJsonAsync(_url, report);
        }
    }
}
