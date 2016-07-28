//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="PlayerController.cs" Company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Host.Controllers
{
    using System.Web.Http;
    
    [RoutePrefix("api/Player")]
    public class PlayerController : ApiController
    {
        [Authorize]
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok();
        }

        /*
         * To test it, fist get the token from the query in Startup class, then paste the token value in [Token]
            User-Agent: Fiddler
            Host: localhost:4242
            Content-Length: 55
            Accept: application/json
            Content-Type: application/json
            Authorization: Bearer [Token]

         */
    }
}