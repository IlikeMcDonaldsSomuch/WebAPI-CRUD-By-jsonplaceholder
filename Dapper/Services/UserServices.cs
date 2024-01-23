using System;
using Dapper.Models;
using ExampleAPI.Models;
using Newtonsoft.Json;
using RestSharp;

namespace Dapper.Services
{
    public interface IUserServices
    {
        Task<List<UserModel>> FindUsers();
        Task<UserModel> FindUserById(int id);
        string DeleteById(int id);
        string Insert(InsertModel request);
        string Update(UpdateModel request);
    }
    public class UserServices : IUserServices
    {
        public async Task<List<UserModel>> FindUsers()
        {
            string baseUrl = "https://jsonplaceholder.typicode.com";

            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest("posts", Method.Get);
            var response = client.Execute(request);
            var convertJsonToObject = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);
            return convertJsonToObject != null ? await Task.FromResult(convertJsonToObject) : new List<UserModel>();
        }

        public async Task<UserModel> FindUserById(int id)
        {
            try
            {
                if (!id.Equals(0))
                {
                    string baseUrl = $"https://jsonplaceholder.typicode.com";

                    RestClient client = new RestClient(baseUrl);
                    RestRequest request = new RestRequest($"posts/{id}", Method.Get);
                    var response = client.Execute(request);
                    var convertJsonToObject = JsonConvert.DeserializeObject<UserModel>(response.Content);
                    return convertJsonToObject != null ? await Task.FromResult(convertJsonToObject) : new UserModel();
                }
                else
                {
                    return new UserModel();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public string DeleteById(int id)
        {
            try
            {
                if (!id.Equals(null) && !id.Equals(0))
                {
                    string baseUrl = "https://jsonplaceholder.typicode.com";
                    RestClient client = new RestClient(baseUrl);
                    string endpoint = $"posts/{id}";

                    RestRequest request = new RestRequest(endpoint, Method.Delete);

                    // Execute the request and get the response
                    var response = client.Execute(request);
                    return response.StatusCode.Equals("OK") ? "Complete" : "Fail";
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
          
        }

        public string Insert(InsertModel request)
        {
            try
            {
                if (!request.Equals(null) && !string.IsNullOrEmpty(request.title) && !string.IsNullOrEmpty(request.body)
                && !request.userId.Equals(0) && !request.userId.Equals(null))
                {
                    string baseUrl = "https://jsonplaceholder.typicode.com";
                    RestClient client = new RestClient(baseUrl);
                    string endpoint = "posts";
                    RestRequest api = new RestRequest(endpoint, Method.Post);
                    string jsonPayload = JsonConvert.SerializeObject(request);

                    api.AddParameter("application/json", jsonPayload, ParameterType.RequestBody);
                    var response = client.Execute(api);
                    return response.StatusCode.Equals("OK") ? "Complete" : "Fail";
                }
                else
                {
                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string Update(UpdateModel request)
        {
            try
            {
                string baseUrl = "https://jsonplaceholder.typicode.com";

                RestClient client = new RestClient(baseUrl);

                string endpoint = $"posts/{request.userId}";

                RestRequest api = new RestRequest(endpoint, Method.Put);
                string jsonPayload = JsonConvert.SerializeObject(request);
                api.AddParameter("application/json", jsonPayload, ParameterType.RequestBody);
                var response = client.Execute(api);
                return response.StatusCode.Equals("OK") ? "Complete" : "Fail";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

