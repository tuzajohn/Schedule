using RestSharp;
using Scheduler.RestServices.Models;
using Scheduler.RestServices.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.RestServices
{
    public class ShiftService
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        public ShiftService(bool online = true)
        {
            _restClient = new RestClient(new AppSettings(online).BaseURl);
        }

        public Response<List<Shift>> SetShift(ShiftRequest request)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "shifts";
            _restRequest.AddJsonBody(request);

            var _response = _restClient.Execute<Response<List<Shift>>>(_restRequest);
            if (!_response.IsSuccessful) { new Response<List<Shift>>(); }
            return _response.Data;
        }
        public Response<List<Shift>> GetShiftForUser(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = $"shifts/user/{id}";

            var _response = _restClient.Execute<Response<List<Shift>>>(_restRequest);
            if (!_response.IsSuccessful) { new Response<List<Shift>>(); }
            return _response.Data;
        }
        public Response<Shift> GetUser(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = $"shifts/{id}";

            var _response = _restClient.Execute<Response<Shift>>(_restRequest);
            if (!_response.IsSuccessful) { new Response<Shift>(); }
            return _response.Data;
        }
        public Response<Shift> GetShiftPerdayForUser(int day, string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = $"shifts/{day}/users/{id}";

            var _response = _restClient.Execute<Response<Shift>>(_restRequest);
            if (!_response.IsSuccessful) { new Response<Shift>(); }
            return _response.Data;
        }
        public Response<List<Shift>> GetShiftForWard(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = $"shifts/ward/{id}";

            var _response = _restClient.Execute<Response<List<Shift>>>(_restRequest);
            if (!_response.IsSuccessful) { new Response<List<Shift>>(); }
            return _response.Data;
        }
    }
}
