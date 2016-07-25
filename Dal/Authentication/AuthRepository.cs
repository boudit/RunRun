//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AuthRepository.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Dal.Authentication
{
    using System.Threading.Tasks;

    using DalContracts.Authentication;
    using DalContracts.Entities.Authentication;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuthRepository : IAuthRepository
    {
        #region Fields and Constants

        private readonly UserManager userManager;

        #endregion

        #region Constructors and Destructors

        public AuthRepository(UserManager userManager)
        {
            this.userManager = userManager;
        }

        #endregion

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new IdentityUser { UserName = userModel.UserName };

            var result = await this.userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            var user = await this.userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            this.userManager.Dispose();
        }
    }
}