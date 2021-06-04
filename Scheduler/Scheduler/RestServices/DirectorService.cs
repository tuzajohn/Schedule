using RestSharp;
using Scheduler.Models;
using Scheduler.RestServices.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.RestServices
{
    public class DirectorService
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;

        public DirectorService(bool online = true)
        {
            _restClient = new RestClient(new AppSettings(online).BaseURl);
            _restClient.Timeout = 10000;
        }
        public Director GetDirector(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = $"directors/{id}";

            var _response = _restClient.Execute<Response<Director>>(_restRequest);
            if (!_response.IsSuccessful) { return new Director(); }
            return _response.Data.Data;
        }
        public List<Director> GetAll()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "directors";

            var _response = _restClient.Execute<Response<List<Director>>>(_restRequest);
            if (!_response.IsSuccessful) { return new List<Director>(); }
            return _response.Data.Data.OrderByDescending(x=>x.CreatedOn).ToList();
        }
        public Director AddDirector(string name, string accountId)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "directors";
            _restRequest.AddJsonBody(new Director
            {
                CreatedOn = DateTime.UtcNow,
                Dob = DateTime.UtcNow.AddYears(-15),
                Id = Guid.NewGuid().ToString("N"),
                IsDeleted = false,
                Name = name,
                AccountId = accountId
            });

            var _response = _restClient.Execute<Response<Director>>(_restRequest);
            if (!_response.IsSuccessful) { return new Director(); }
            return _response.Data.Data;
        }
    }
}
