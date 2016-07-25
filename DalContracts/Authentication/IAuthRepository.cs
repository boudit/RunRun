//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IAuthRepository.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace DalContracts.Authentication
{
    using System;
    using System.Threading.Tasks;

    using DalContracts.Entities.Authentication;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IAuthRepository : IDisposable
    {
        Task<IdentityUser> FindUser(string userName, string password);

        Task<IdentityResult> RegisterUser(UserModel userModel);
    }
}