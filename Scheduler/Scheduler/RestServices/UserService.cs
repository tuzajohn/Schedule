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
    public class UserService
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        public UserService(bool online = true)
        {
            _restClient = new RestClient(new AppSettings(online).BaseURl);
        }
        public Response<UserResponse> GetUserByAccountId(string id)
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "users/account/{id}";
            _restRequest.AddParameter("id", id);

            var _response = _restClient.Execute<Response<UserResponse>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
        public Response<UserResponse> GetUserByUserId(string id)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "user/getuserbyuserid";
            _restRequest.AddParameter("id", id);

            var _response = _restClient.Execute<Response<UserResponse>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
        public Response<UserResponse> SendUser(UserBody user)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "user/adduser";
            _restRequest.AddJsonBody(user);

            var _response = _restClient.Execute<Response<UserResponse>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
        public Response<List<UserResponse>> GetUsers()
        {
            _restRequest = new RestRequest(Method.GET);
            _restRequest.Resource = "users";

            var _response = _restClient.Execute<Response<List<UserResponse>>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
    }
}
