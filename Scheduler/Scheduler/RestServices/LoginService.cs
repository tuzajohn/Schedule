using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Scheduler.Models;
using Scheduler.RestServices.Models.Responses;

namespace Scheduler.RestServices
{
    public class LoginService
    {
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        public LoginService(bool online = true)
        {
            _restClient = new RestClient(new AppSettings(online).BaseURl);
        }
        public Response<LoginResponse> CheckLogin(string email, string password)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "accounts/signin?email={email}&password={password}";
            _restRequest.AddUrlSegment("email", email);
            _restRequest.AddUrlSegment("password", password);

            var _response = _restClient.Execute<Response<LoginResponse>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
        public Response<LoginResponse> SendLogin(Account login)
        {
            _restRequest = new RestRequest(Method.POST);
            _restRequest.Resource = "accounts?email={email}&password={password}";
            _restRequest.AddUrlSegment("email", login.Email);
            _restRequest.AddUrlSegment("password", login.Password);
            _restRequest.AddUrlSegment("isadmin", login.IsAdmin.ToString());
            _restRequest.AddHeader("xlog", "my api");

            var _response = _restClient.Execute<Response<LoginResponse>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }

        public Response<LoginResponse> ChangePassword(string id, string password)
        {
            _restRequest = new RestRequest(Method.PATCH);
            _restRequest.Resource = "accounts/{id}/changepassword?newpassword={password}";
            _restRequest.AddUrlSegment("id", id);
            _restRequest.AddUrlSegment("password", password);
            _restRequest.AddHeader("xlog", "my api");

            var _response = _restClient.Execute<Response<LoginResponse>>(_restRequest);
            if (!_response.IsSuccessful) { }
            return _response.Data;
        }
    }
}
