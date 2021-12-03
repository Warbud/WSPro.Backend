using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WSPro.Backend.Application.Dto;
using WSPro.Backend.Application.Interfaces;

namespace WSPro.Backend.Application.Services
{
    public class UserService : IUserService
    {
        private const string BaseUrl = "https://localhost:6001/api/";
        private const string LoginPath = "User/Login";
        private const string MePath = "User/Me";
        private const string GetUserPath = "User/GetUser";
        private const string AddUserPath = "User/AddUser";


        private readonly HttpClient _client = new();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _client.BaseAddress = new Uri(BaseUrl);
        }

        private string ExtractTokenFromHeader()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            return authorizationHeader.ToString().Replace("Bearer ", "");
        }

        public async Task<LoginPayload> Login(LoginInput input)
        {
            var response = await _client.PostAsync(LoginPath,
                new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json"));
            if (response.StatusCode != (HttpStatusCode)200)
            {
                var invalidReponse =
                    JsonConvert.DeserializeObject<InvalidLoginPayload>(await response.Content.ReadAsStringAsync());
                throw new Exception(invalidReponse.Message);
            }

            var validResponse =
                JsonConvert.DeserializeObject<LoginPayload>(await response.Content.ReadAsStringAsync());
            return validResponse;
        }


        public async Task<T> GetMe<T>()
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, BaseUrl + MePath))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", ExtractTokenFromHeader());
                var responseMessage = await _client.SendAsync(requestMessage);

                if (responseMessage.StatusCode != (HttpStatusCode)200) throw new Exception("Invalid token");

                return JsonConvert.DeserializeObject<T>(await responseMessage.Content.ReadAsStringAsync());
            }
        }

        public async Task<UserPayload> GetUser(UserInput input)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, BaseUrl + GetUserPath))
            {
                requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", ExtractTokenFromHeader());
                requestMessage.Content =
                    new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                var responseMessage = await _client.SendAsync(requestMessage);

                if (responseMessage.StatusCode != (HttpStatusCode)200) throw new Exception("Cannot get user");

                return JsonConvert.DeserializeObject<UserPayload>(await responseMessage.Content.ReadAsStringAsync());
            }
        }

        public async Task<RegisterPayload> Register(RegisterInput input)
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, BaseUrl + AddUserPath))
            {
                requestMessage.Content =
                    new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                var responseMessage = await _client.SendAsync(requestMessage);

                if (responseMessage.StatusCode != (HttpStatusCode)200)
                {
                    var errorMessage = JsonConvert.DeserializeObject<ErrorMessagePayload>(
                        await responseMessage.Content.ReadAsStringAsync());
                    var exceptions = new List<Exception>();
                    foreach (var (key, value) in errorMessage.Errors)
                    foreach (var val in value)
                        exceptions.Add(new Exception(val));
                    throw new AggregateException("Exceptions", exceptions);
                }

                var outputPayload =
                    JsonConvert.DeserializeObject<bool>(await responseMessage.Content.ReadAsStringAsync());
                return new RegisterPayload(outputPayload);
            }
        }
    }
}