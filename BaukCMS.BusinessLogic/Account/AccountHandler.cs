using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaukCMS.BusinessLogic.Companies;
using BaukCMS.DataLayer.Filters;
using BaukCMS.DataLayer.Repositories;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;
using BaukCMS.Helpers.DropDownHelpers;

namespace BaukCMS.BusinessLogic.Account
{
    public class AccountHandler
    {
        private readonly AccountManager _accountManager = new AccountManager();
        private readonly DropDownHelper _dropdownHelper = new DropDownHelper();
        private readonly CompanyManager _companyManager = new CompanyManager();
        public void InitializeSimpleMembership()
        {
            _accountManager.InitializeSimpleMembership();
        }

        public bool Login(LoginModel model)
        {
            return _accountManager.Login(model);
        }

        public void Logout()
        {
            _accountManager.Logout();
        }

        public void CreateUser(RegisterModel model)
        {
            _accountManager.CreateUser(model);
        }

        public List<UserProfile> GetUsers()
        {
            return _accountManager.GetUsers();
        }

        public AccountViewModel GetUser(int userId)
        {
            return new AccountViewModel()
            {
                UserProfile = _accountManager.GetUser(userId),
                Companies = _dropdownHelper.GetCompanyListForDropDown(_companyManager.GetCompanies())
            };
        }

        public UserProfile GetUserByName(string userName)
        {
            return _accountManager.GetUserByName(userName);
        }

        public void EditUser(AccountViewModel accountViewModel)
        {
            _accountManager.EditUser(accountViewModel);
        }

        public void DeleteUser(int userId)
        {
            _accountManager.DeleteUser(userId);
        }

        public void Activate(int userId)
        {
            _accountManager.Activate(userId);
        }

        public void Deactivate(int userId)
        {
            _accountManager.Deactivate(userId);
        }

        public bool SetUserSession(int userId, int siteId, bool isAdmin)
        {
            var userProperty = _accountManager.GetUserProperty(userId).Where(p => p.SiteId == siteId);
            if (userProperty.Any() || isAdmin)
            {
                _accountManager.SetUserLastSiteId(userId, siteId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<UserProperty> GetUserProperty(int userId)
        {
            return _accountManager.GetUserProperty(userId);
        }

        public List<UserRole> MapRolesToUser(string[] roles, string[] userRoles)
        {
            var checkBoxRoles = new List<UserRole>();
            foreach(var role in roles)
            {
                var checkBoxRole = new UserRole();
                checkBoxRole.RoleName = role;
                checkBoxRole.Selected = false;
                foreach(var userRole in userRoles)
                {
                    if(userRole == role)
                    {
                        checkBoxRole.Selected = true;
                    }
                }
                checkBoxRoles.Add(checkBoxRole);
            }
            return checkBoxRoles;
        }
    }
}
