using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using RestSharp;
using HelloWinService.data.Service;

namespace HelloWinService.data.Jobs
{
    [DisallowConcurrentExecution]
    public class SimpleCronJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            SimpleService.TestCode();
        }

        //private void SaveOrder()
        //{
        //    string baseUrl = "http://10.202.101.43:81";
        //    var client = new RestClient(baseUrl);
        //    var request = new RestRequest("api/orders", Method.POST);
        //    request.RequestFormat = DataFormat.Json;
        //    OrderDto dto = new OrderDto
        //    {
        //        Name = "liu1",
        //        Id = count++
        //    };
        //    List<OrderDto> dtoList = new List<OrderDto> { dto};
        //    //var jsonDto = JsonConvert.SerializeObject(dto);
        //    request.AddBody(dtoList);

        //    try
        //    {
        //        // execute the request
        //        IRestResponse response = client.Execute(request);

        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //}


    }
}
