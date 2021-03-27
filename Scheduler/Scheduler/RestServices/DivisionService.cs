using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Scheduler.Models;
using Scheduler.RestServices.Models;
using Scheduler.RestServices.Models.Responses;

namespace Scheduler.RestServices
{
    public class DivisionService
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        public DivisionService(bool online = true)
        {
            _restClient = new RestClient(new AppSettings(online).BaseURl);
        }
        public Response<DivisionResponse> UpdateDivision(string id, string name)
        {
            _restRequest = new RestRequest(Method.PATCH);
            _restRequest.Resource = "divisions/{id}?name={name}";
            _restRequest.AddParameter("id", id);
            _restRequest.AddParameter("name", name);

            var _response = _restClient.Execute<Response<DivisionResponse>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
        public Response<Ward> GetWardByDivisionsID(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "divisions/{id}/wards";
            _restRequest.AddUrlSegment("id", id);

            var _response = _restClient.Execute<Response<Ward>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
        public Response<Division> Get(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "divisions/{id}";
            _restRequest.AddUrlSegment("id", id);

            var _response = _restClient.Execute<Response<Division>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
        public Response<DivisionResponse> CreateDivision(string name)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "divisions?name={name}";
            _restRequest.AddUrlSegment("name", name);
            _restRequest.AddHeader("xlog", "my api");

            var _response = _restClient.Execute<Response<DivisionResponse>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
        public Response<List<DivisionResponse>> GetDivisions()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "divisions";

            var _response = _restClient.Execute<Response<List<DivisionResponse>>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
    }
}
