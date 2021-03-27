using System;
using System.Configuration;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Scheduler.RestServices;

namespace Scheduler
{
    public class Support
    {
        public static bool TryGetSession(string key, out string data)
        {
            try
            {
                var _result = ConfigurationManager.AppSettings[key].ToString();
                data = _result;
                return true;
            }
            catch (Exception)
            {
                data = default;
                return false;
            }
            
        }
        public static void CreateSession(string id, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Add(id, value);
            configuration.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static bool DestroySession(string key)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                configuration.AppSettings.Settings.Remove(key);
                configuration.Save(ConfigurationSaveMode.Full);
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool CheckInternetConnection()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AppSettings.TestUrl);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse _response = (HttpWebResponse)request.GetResponse();
                if (_response.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    public static class Extensions
    {
        public static bool IsValidNumber(this string number)
        {
            if (int.TryParse(number, out int outPut))
            {
                var reg = new Regex(@"^\d+$");
                if (reg.IsMatch(number))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public static T FromJson<T>(this string text)
        {
            var _outPut = JsonConvert.DeserializeObject<T>(text);
            return _outPut;
        }
        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value);
        }
        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
