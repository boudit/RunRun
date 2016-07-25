//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AuthContext.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Dal.Authentication
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        #region Constructors and Destructors

        public AuthContext()
            : base("AuthContext")
        {
        }

        #endregion
    }
}