
﻿using TrackerBar_Admin.API.Controllers;
﻿using Microsoft.EntityFrameworkCore;

using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DB;
using Microsoft.AspNetCore.Identity;

namespace TrackerBar_Admin.API.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ApplicationDBContext context;
        private readonly UserManager<User> _userManager;

        public SQLUserRepository(
            ApplicationDBContext context,
            UserManager<User> userManager)
        {
            _userManager = userManager;
            this.context = context;
        }

        //get's user from database
        public async Task<User> GetUserByIdAsync(string userId)
        {
            try
            {

             var result = new User();
            //validates if user exist or not
            if(userExist(userId))
            {
                result = (from X in context.Users
                        where X.Id == userId
                        select X).First();

                return result;
            }
            return null;
            }

            catch (Exception ex)
            {
                context.Dispose();
                return null;
            }
          
        }

        //get's only the userId from database
        public async Task<string> GetUserId(string userId)
        {

            try
            {
            var result = (from X in context.Users
                         where X.Id == userId
                         select X.Id).First();
            return result;
            }
            catch (Exception ex)
            {
                context.Dispose();
                throw ex;
            }
           
        }
        //asks if user already exists or not in database
        public bool userExist(string userId)
        {
            try
            { 
                var result = (from X in context.Users
                          where X.Id == userId
                          select X.Id).FirstOrDefault();
            
            if(result != null)
            {
                return true;
            }
                return false;
            }
            catch (Exception ex)
            {
                context.Dispose();
                return false;
            }
           
        }

        public async Task<IdentityResult> UpdateProfileAsync(UpdateProfile model)
        {

            try
            {
                if (userExist(model.Id))
                {
                    var userInfo = await GetUserByIdAsync(model.Id);

                    if (userInfo != null) { 
                        userInfo.Name = model.Name;
                        userInfo.Last = model.Last;
                        userInfo.UserName = model.Username;
                        userInfo.Password = model.Password;
                        userInfo.Email = model.Email;
                        userInfo.BirthDate = model.BirthDate;
                        
                        var result = await _userManager.UpdateAsync(userInfo);
                        return result;
                    } 
                }
                return null;
            }
            catch (Exception ex)
            {
                context.Dispose();
                return null;
            }
        }
    }
}
