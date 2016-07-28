//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AccountController.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Host.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Dal.Authentication;

    using DalContracts.Authentication;
    using DalContracts.Entities.Authentication;

    using Microsoft.AspNet.Identity;

    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private readonly IAuthRepository repository;

        public AccountController()
        {
            this.repository = new AuthRepository(new UserManager(new AuthContext()));
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = await this.repository.RegisterUser(userModel);

            var errorResult = this.GetErrorResult(result);

            return errorResult ?? this.Ok();
        }

        /*
         * To test the register :
            POST http://localhost:4242/api/account/register HTTP/1.1
            User-Agent: Fiddler
            Host: localhost:4242
            Content-Length: 92
            Accept: application/json

            {
              "userName": "Taiseer",
              "password": "SuperPass",
              "confirmPassword": "SuperPass"
            }
         */

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.repository.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return this.InternalServerError();
            }

            if (result.Succeeded)
            {
                return null;
            }

            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error);
                }
            }

            if (this.ModelState.IsValid)
            {
                // No ModelState errors are available to send, so just return an empty BadRequest.
                return this.BadRequest();
            }

            return this.BadRequest(this.ModelState);
        }
    }
}