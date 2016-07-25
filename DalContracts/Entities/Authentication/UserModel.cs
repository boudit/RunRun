//  --------------------------------------------------------------------------------------------------------------------
//  <copyright file="UserModel.cs" company="Company">
//    Copyright (c) Company. All rights reserved.
//  </copyright>
//  --------------------------------------------------------------------------------------------------------------------
namespace DalContracts.Entities.Authentication
{
    using System.ComponentModel.DataAnnotations;

    public class UserModel
    {
        #region Properties

        public UserModel()
        {
        }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        #endregion
    }
}