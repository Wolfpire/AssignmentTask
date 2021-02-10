using System;
using TechTalk.SpecFlow;
using AssignmentTask;
using RestSharp;
using FluentAssertions;

namespace SpecFlowAssignmentTask.Specs.Features
{
    [Binding]
    public class PetstoreSteps
    {
        private readonly ScenarioContext _scenarioContext;

        private readonly Pet _pet = new Pet();
        private static Petstore _petstore = new Petstore();
        private static User _user = new User();
        private static IRestResponse _resultOrderPet;
        private static IRestResponse _resultCreateUser;
        private static IRestResponse _resultGetUser;
        private static IRestResponse _resultDeleteUser;
        private static IRestResponse _result;
        private static Method _method;

        public PetstoreSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"the base url is ""(.*)""")]
        public void GivenTheBaseUrlIs(string baseUrl)
        {
            _petstore.baseUrl = baseUrl;
        }

        [Given(@"the uri path is ""(.*)""")]
        public void GivenTheEndPointIs(string uriPath)
        {
            _petstore.uriPath = uriPath;
        }

        [Given(@"the pets id is (.*)")]
        public void GivenThePetsIdIs(ulong id)
        {
            _pet.id = id;
        }

        [Given(@"the pets petId is (.*)")]
        public void GivenThePetsPetIdIs(ulong petId)
        {
            _pet.petId = petId;
        }

        [Given(@"the pets shipDate is ""(.*)""")]
        public void GivenThePetsShipDateIs(string shipDate)
        {
            _pet.shipDate = shipDate;
        }

        [Given(@"the pets status is ""(.*)""")]
        public void GivenThePetsStatusIs(string status)
        {
            _pet.status = status;
        }

        [Given(@"the pets complete is ""(.*)""")]
        public void GivenThePetsCompleteIs(bool complete)
        {
            _pet.complete = complete;
        }


        [When(@"the order is placed")]
        public void WhenTheOrderIsPlaced()
        {
            _resultOrderPet = Petstore.OrderPet(_pet, _petstore);
            _result = _resultOrderPet;
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            ((int)_result.StatusCode).Should().Be(statusCode);
        }


        [Given(@"the partial uri path is ""(.*)""")]
        public void GivenThePartialUriPathIs(string partialUriPath)
        {
            _petstore.uriPath = partialUriPath;
        }

        [Given(@"username is ""(.*)""")]
        public void GivenUsernameIs(string username)
        {
            _petstore.uriPath += username;
        }

        [When(@"the request is made")]
        public void WhenTheRequestIsMade()
        {
            _resultGetUser = Petstore.GetUser(_petstore);
            _result = _resultGetUser;
        }


        [Given(@"the users id is (.*)")]
        public void GivenTheUsersIdIs(ulong id)
        {
            _user.id = id;
        }

        [Given(@"the users username is ""(.*)""")]
        public void GivenTheUsersUsernameIs(string username)
        {
            _user.username = username;
        }

        [Given(@"the users firstName is ""(.*)""")]
        public void GivenTheUsersFirstNameIs(string firstName)
        {
            _user.firstName = firstName;
        }

        [Given(@"the users lastName is ""(.*)""")]
        public void GivenTheUsersLastNameIs(string lastName)
        {
            _user.lastName = lastName;
        }

        [Given(@"the users email is ""(.*)""")]
        public void GivenTheUsersEmailIs(string email)
        {
            _user.email = email;
        }

        [Given(@"the users password is ""(.*)""")]
        public void GivenTheUsersPasswordIs(string password)
        {
            _user.password = password;
        }

        [Given(@"the users phone is ""(.*)""")]
        public void GivenTheUsersPhoneIs(string phone)
        {
            _user.phone = phone;
        }

        [Given(@"the users userStatus is (.*)")]
        public void GivenTheUsersUserStatusIs(int userStatus)
        {
            _user.userStatus = userStatus;
        }

        [When(@"user is created")]
        public void WhenUserIsCreated()
        {
            _resultCreateUser = Petstore.CreateUser(_user, _petstore);
            _result = _resultCreateUser;
        }

        [Then(@"the post and get response content matches")]
        public void ThenThePostAndGetResponseContentMatches()
        {
            (_resultGetUser.Content).Should().Equals(_resultCreateUser.Content);
        }

        [Given(@"request method is put")]
        public void GivenRequestMethodIsPut()
        {
            _method = Method.PUT;
        }

        [When(@"delete is requested")]
        public void WhenDeleteIsRequested()
        {
            _resultDeleteUser = Petstore.DeleteUser(_petstore, _method);
            _result = _resultDeleteUser;
        }



    }

}
