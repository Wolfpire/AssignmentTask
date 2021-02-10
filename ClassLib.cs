using RestSharp;
using System;

namespace AssignmentTask
{
    public class Pet
    {
        public ulong id { get; set; }
        public ulong petId { get; set; }
        public int quantity { get; set; }
        public string shipDate { get; set; }
        public string status { get; set; }
        public bool complete { get; set; }
    }

    public class User
    {
        public ulong id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName  { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public int userStatus { get; set; }
    }

    public class Petstore
    {
        public string baseUrl { get; set; }
        public string uriPath { get; set; }
        public RestRequest request { get; set; }
        public static IRestResponse OrderPet(Pet pet, Petstore petstore)
        {
            var client = new RestClient(petstore.baseUrl);
            var request = new RestRequest(petstore.uriPath, Method.POST);
            request.RequestFormat = DataFormat.Json; //Only POST
            request.AddBody(pet);
            return client.Execute(request);
        }

        public static IRestResponse CreateUser(User user, Petstore petstore)
        {
            var client = new RestClient(petstore.baseUrl);
            var request = new RestRequest(petstore.uriPath, Method.POST);
            request.RequestFormat = DataFormat.Json; //Only POST
            request.AddBody(user);
            return client.Execute(request);
        }

        public static IRestResponse GetUser(Petstore petstore)
        {
            var client = new RestClient(petstore.baseUrl);
            var request = new RestRequest(petstore.uriPath, Method.GET);
            return client.Execute(request);
        }

        public static IRestResponse DeleteUser(Petstore petstore, Method method)
        {
            var client = new RestClient(petstore.baseUrl);
            var request = new RestRequest(petstore.uriPath, method);
            return client.Execute(request);
        }
    }
}
