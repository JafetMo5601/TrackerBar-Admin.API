using TrackerBar_Admin.API.Controllers;
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

        public async Task<User> GetUserByIdAsync(string UserId)
        {
            var user = (from x in context.Users
                        where x.Id == UserId
                        select x).First();

            return user;
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
