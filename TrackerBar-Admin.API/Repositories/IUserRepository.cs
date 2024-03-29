﻿using Microsoft.AspNetCore.Identity;
using TrackerBar_Admin.API.DataModels;

namespace TrackerBar_Admin.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(string UserId);

        Task<IdentityResult> UpdateProfileAsync(UpdateProfile model);

        Task<string> GetUserId(string userId);
        bool userExist(string userId);

    }
}
