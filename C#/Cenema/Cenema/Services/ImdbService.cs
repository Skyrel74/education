using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cenema.Services
{
    public interface IImdbService
    {
        ImdbMovie GetMovie(string term);
    }

    public class ImdbMovie
    {
        public string Title { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
    }

    public class ImdbService : IImdbService
    {
        private readonly string _apiKey = "d50f714d";
        private readonly RestClient _restClient;

        public ImdbService()
        {
            _restClient = new RestClient(new Uri("http://www.omdbapi.com"));
        }
        public ImdbMovie GetMovie(string term)
        {
            var request = new RestRequest(Method.GET);
            request.AddParameter("apiKey", _apiKey);
            request.AddParameter("t", term);
            var response = _restClient.Execute(request);
            var responseModel = JsonConvert.DeserializeObject<ImdbMovie>(response.Content);
            return responseModel;
        }
    }
}