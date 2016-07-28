//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UserManager.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace Dal.Authentication
{
    using System;
    using System.Data.Entity;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class UserManager : UserManager<IdentityUser>
    {
        private readonly DbContext context;

        public UserManager(DbContext context)
            : base(new UserStore<IdentityUser>(context))
        {
            this.context = context;
        }
    }
}