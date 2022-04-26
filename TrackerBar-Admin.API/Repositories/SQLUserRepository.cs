
﻿using TrackerBar_Admin.API.Controllers;
﻿using Microsoft.EntityFrameworkCore;

using TrackerBar_Admin.API.DataModels;
using TrackerBar_Admin.API.DB;

namespace TrackerBar_Admin.API.Repositories
{
    public class SQLUserRepository : IUserRepository
    {
        private readonly ApplicationDBContext context;
        private readonly AuthController _userManager;

        public SQLUserRepository(ApplicationDBContext context)
        {
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

        public async Task<UpdateProfile> UpdatedProfileAsync(UpdateProfile user, UpdateProfile model)
        {

            try
            {
                if (user != null)
                {
                    user.Id = model.Id;
                    user.Name = model.Name;
                    user.Last = model.Last;
                    user.Username = model.Username;
                    user.Password = model.Password;
                    user.Email = model.Email;
                    user.BirthDate = model.BirthDate;

                    var result = await _userManager.UpdateProfile(user);
                    return (UpdateProfile)result;
                }
                return null;
            }
            catch (Exception ex)
            {
                context.Dispose();
                return null;
            }

            /* if (user == null)
             {

                 return StatusCode(StatusCodes.Status400BadRequest, new Response { Status = "Error", Message = "User ID does not exists.", Error = model.Id });
             }
             else
             {
                 user.Id = model.Id;
                 user.Name = model.Name;
                 user.Last = model.Last;
                 user.Username = model.Username;
                 user.Password = model.Password;
                 user.Email = model.Email;
                 user.BirthDate = model.BirthDate;

                 var result = await _userManager.UpdateProfile(user);               
                 return (UpdateProfile)result;
             }           */
        }
    }
}
