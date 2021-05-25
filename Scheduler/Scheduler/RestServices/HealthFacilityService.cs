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
    public class HealthFacilityService
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        public HealthFacilityService(bool online = true)
        {
            _restClient = new RestClient(new AppSettings(online).BaseURl);
        }
        public Response<HealthFacilityResponse> GetByDirector(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = $"healthfacility/director/{id}";

            try
            {
                var _response = _restClient.Execute<Response<HealthFacilityResponse>>(_restRequest);
                if (!_response.IsSuccessful) { return new Response<HealthFacilityResponse>(); }
                return _response.Data;
            }
            catch (Exception) { return new Response<HealthFacilityResponse>(); }
        }
        public Response<HealthFacilityResponse> Get(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "healthfacility/{id}";
            _restRequest.AddUrlSegment("id", id);

            try
            {
                var _response = _restClient.Execute<Response<HealthFacilityResponse>>(_restRequest);
                if (!_response.IsSuccessful) { return new Response<HealthFacilityResponse>(); }
                return _response.Data;
            }
            catch (Exception) { return new Response<HealthFacilityResponse>(); }
        }
        public List<HealthFacilityResponse> Get()
        {
            
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "healthfacility";

            try
            {
                var _response = _restClient.Execute<Response<List<HealthFacilityResponse>>>(_restRequest);
                if (!_response.IsSuccessful) { return new List<HealthFacilityResponse>(); }
                return _response.Data.Data;
            }
            catch (Exception)
            {
                return new List<HealthFacilityResponse>();
            }
        }
        public Response<HealthFacilityResponse> CreateCenter(string name, string address, string director)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "healthfacility";
            _restRequest.AddHeader("xlog", "my api");
            _restRequest.AddJsonBody(new HealthFacilityResponse
            {
                Address = address,
                Director = director,
                Name = name
            });

            try
            {
                var _response = _restClient.Execute<Response<HealthFacilityResponse>>(_restRequest);
                if (!_response.IsSuccessful) { return new Response<HealthFacilityResponse>(); }
                return _response.Data;
            }
            catch (Exception) { return new Response<HealthFacilityResponse>(); }
        }
    }
}
