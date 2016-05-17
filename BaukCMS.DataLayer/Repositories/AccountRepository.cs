using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BaukCMS.DataLayer.Context;
using BaukCMS.DataLayer.Context;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using WebMatrix.WebData;

namespace BaukCMS.DataLayer.Repositories
{
    public class AccountRepository
    {
        private readonly BaukCMSContext _db = new BaukCMSContext();
        public bool Login(LoginModel model)
        {
            return WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe);
        }

        public void Logout()
        {
            WebSecurity.Logout();
        }

        public void CreateUser(RegisterModel model)
        {
            WebSecurity.CreateUserAndAccount(model.UserName, model.Password);
        }

        public List<UserProfile> GetUsers()
        {
            return _db.UserProfiles.ToList();
                //Where(p => p.CompanyId == p.Company.CompanyId).Include(p => p.Company).ToList();
        }

        public UserProfile GetUser(int userId)
        {
            return _db.UserProfiles.FirstOrDefault(p => p.UserId == userId);
        }

        public void EditUser(AccountViewModel accountViewModel)
        {
            var userToEdit = GetUser(accountViewModel.UserProfile.UserId);
            if (userToEdit != null)
            {
                userToEdit.FirstName = accountViewModel.UserProfile.FirstName;
                userToEdit.LastName = accountViewModel.UserProfile.LastName;
                userToEdit.CompanyId = accountViewModel.UserProfile.CompanyId;
                _db.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _db.UserProfiles.FirstOrDefault(p => p.UserId == userId);
            _db.UserProfiles.Remove(userToDelete);
            _db.SaveChanges();
        }

        public void Activate(int userId)
        {
            var userToActivate = GetUser(userId);
            if (userToActivate == null) return;
            userToActivate.Active = true;
            _db.SaveChanges();
        }

        public void Deactivate(int userId)
        {
            var userToActivate = GetUser(userId);
            if (userToActivate == null) return;
            userToActivate.Active = false;
            _db.SaveChanges();
        }

        public int GetLastSiteId(int userId)
        {
            var user = _db.UserProfiles.FirstOrDefault(p => p.UserId == userId);
            return user == null ? 0 : user.LastSiteId;
        }

        public List<UserProperty> GetUserProperty(int userId)
        {
            return _db.UserProperty.Where(p => p.UserId == userId).ToList(); 
        }

        public void SetUserLastSiteId(int userId, int siteId)
        {
            var userToEdit = GetUser(userId);
            if (userToEdit != null)
            {
                userToEdit.LastSiteId = siteId;
                _db.SaveChanges();
            }
        }

        public UserProfile GetUserByName(string userName)
        {
            return _db.UserProfiles.AsNoTracking().FirstOrDefault(p => p.UserName == userName);
        }
    }
}
