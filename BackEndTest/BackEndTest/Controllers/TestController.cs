using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Description;
using BackEndTest.Business;
using BackEndTest.Interface;
using Newtonsoft.Json;

public class TestController : ApiController
{
    #region Modular Variables

    private readonly ITestViewModel _viewModel;

    #endregion

    #region Constructors

    public TestController() : this(new TestViewModel()) { }

    public TestController(ITestViewModel viewModel)
    {
        _viewModel = viewModel;
    }

    #endregion

    #region Get Methods

    [HttpGet]
    [Route("users")]
    [ResponseType(typeof(List<User>))]
    public HttpResponseMessage GetSitelotByMapId(HttpRequestMessage requestMessage)
    {
        var response = new List<User>();
        var httpResponse = new HttpResponseMessage();

        try
        {
            response = _viewModel.GetUsers();

            var json = JsonConvert.SerializeObject(response);
            var sc = new StringContent(json);

            sc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpResponse.StatusCode = HttpStatusCode.OK;
            httpResponse.Content = sc;
        }
        catch (Exception exception)
        {
            try
            {
                // Log error
            }
            catch
            {
                // Do nothing
            }
                        
            var json = JsonConvert.SerializeObject(response);
            var sc = new StringContent(json);

            sc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpResponse.StatusCode = HttpStatusCode.NotAcceptable;
            httpResponse.Content = sc;
        }

        return httpResponse;
    }

    #endregion

    #region Put Methods

    [HttpPut]
    [Route("users/{userId}")]
    [ResponseType(typeof(User))]
    public HttpResponseMessage PutFacilityInspection(HttpRequestMessage requestMessage, int userId, [FromBody] object userJson)
    {

        var response = new User();
        var httpResponse = new HttpResponseMessage();

        try
        {
            var user = JsonConvert.DeserializeObject<User>(userJson.ToString());

            var exists = _viewModel.UserExists(userId);

            if (exists)
            {
                response = _viewModel.SaveUser(user);                
            }
            else
            {
                httpResponse.StatusCode = HttpStatusCode.ExpectationFailed;                
            }

            var json = JsonConvert.SerializeObject(response);
            var sc = new StringContent(json);

            sc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpResponse.StatusCode = HttpStatusCode.OK;
            httpResponse.Content = sc;
        }
        catch (Exception exception)
        {
            try
            {
                // Log error
            }
            catch
            {
                //Do nothing
            }

            response = default;
            
            var json = JsonConvert.SerializeObject(response);
            var sc = new StringContent(json);

            sc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpResponse.StatusCode = HttpStatusCode.NotAcceptable;
            httpResponse.Content = sc;
        }

        return httpResponse;
    }

    #endregion

    #region Post Methods

    [HttpPost]
    [Route("inspection")]
    [ResponseType(typeof(User))]
    public HttpResponseMessage CreateUser(HttpRequestMessage requestMessage, [FromBody] object userJson)
    {
        var response = new User();
        var httpResponse = new HttpResponseMessage();

        try
        {
            var user = JsonConvert.DeserializeObject<User>(userJson.ToString());

            response = _viewModel.SaveUser(user);
            
            var json = JsonConvert.SerializeObject(response);
            var sc = new StringContent(json);

            sc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpResponse.StatusCode = HttpStatusCode.OK;
            httpResponse.Content = sc;
        }
        catch (Exception exception)
        {
            try
            {
                // Log error
            }
            catch
            {
                //Do nothing
            }

            response = default;
            
            var json = JsonConvert.SerializeObject(response);
            var sc = new StringContent(json);

            sc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            httpResponse.StatusCode = HttpStatusCode.NotAcceptable;
            httpResponse.Content = sc;
        }

        return httpResponse;
    }

    #endregion
}