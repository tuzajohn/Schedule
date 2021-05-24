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
    public class WardService
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;

        public WardService(bool online = true)
        {
            _restClient = new RestClient(new AppSettings(online).BaseURl);
        }

        public Response<Ward> GetWardById(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "wards/{id}";
            _restRequest.AddUrlSegment("id", id);


            var _response = _restClient.Execute<Response<Ward>>(_restRequest);
            if (!_response.IsSuccessful) { _response.Data = new Response<Ward>(); }
            return _response.Data;

        }
        public Response<List<Ward>> GetWards()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "wards";


            var _response = _restClient.Execute<Response<List<Ward>>>(_restRequest);
            if (!_response.IsSuccessful) { _response.Data = new Response<List<Ward>> { Data = new List<Ward>() }; }

            return _response.Data;

        }

        public Response<Ward> Add(Ward ward)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "wards";
            _restRequest.AddHeader("xlog", "my api");

            _restRequest.AddJsonBody(ward);

            var _response = _restClient.Execute<Response<Ward>>(_restRequest);
            if (!_response.IsSuccessful) return new Response<Ward> { Check = false, Data = new Ward(), Message = "Something wrong happened!" };
            return _response.Data;
        }
        public Response<Ward> Update(string id, Ward ward)
        {
            _restRequest = new RestRequest(Method.PUT);
            _restRequest.Resource = "wards/{id}";
            _restRequest.AddUrlSegment("id", id);
            _restRequest.AddHeader("xlog", "my api");
            _restRequest.AddJsonBody(ward);

            var _response = _restClient.Execute<Response<Ward>>(_restRequest);
            if (!_response.IsSuccessful) return new Response<Ward> { Check = false, Data = new Ward(), Message = "Something wrong happened!" };
            return _response.Data;
        }
        public Response<List<UserResponse>> GetUsers(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "wards/{id}/users";
            _restRequest.AddUrlSegment("id", id);
            _restRequest.AddHeader("xlog", "my api");

            var _response = _restClient.Execute<Response<List<UserResponse>>>(_restRequest);
            if (!_response.IsSuccessful) return new Response<List<UserResponse>> { Check = false, Data = new List<UserResponse>(), Message = "Something wrong happened!" };
            return _response.Data;
        }
    }
}
