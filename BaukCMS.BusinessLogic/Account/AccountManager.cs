using System.Collections.Generic;
using BaukCMS.DataLayer.Filters;
using BaukCMS.DataLayer.Repositories;
using BaukCMS.Models.Models;
using BaukCMS.Models.ViewModels;

namespace BaukCMS.BusinessLogic.Account
{
    public class AccountManager
    {
        private readonly InitializeDatabaseConnection _initializeDatabaseConnection = new InitializeDatabaseConnection();
        private readonly AccountRepository _accountRepository = new AccountRepository();
        public void InitializeSimpleMembership()
        {
            _initializeDatabaseConnection.SimpleMembershipInitializer();
        }

        public bool Login(LoginModel model)
        {
            return _accountRepository.Login(model);
        }

        public void Logout()
        {
            _accountRepository.Logout();
        }

        public void CreateUser(RegisterModel model)
        {
            _accountRepository.CreateUser(model);
        }

        public List<UserProfile> GetUsers()
        {
            return _accountRepository.GetUsers();
        }

        public UserProfile GetUser(int userId)
        {
            return _accountRepository.GetUser(userId);
        }

        public void EditUser(AccountViewModel accountViewModel)
        {
            _accountRepository.EditUser(accountViewModel);
        }

        public void DeleteUser(int userId)
        {
            _accountRepository.DeleteUser(userId);
        }

        public void Activate(int userId)
        {
            _accountRepository.Activate(userId);
        }

        public void Deactivate(int userId)
        {
            _accountRepository.Deactivate(userId);
        }

        public int GetLastSiteId(int userId)
        {
            return _accountRepository.GetLastSiteId(userId);
        }

        public List<UserProperty> GetUserProperty(int userId)
        {
            return _accountRepository.GetUserProperty(userId);
        }

        public void SetUserLastSiteId(int userId, int siteId)
        {
             _accountRepository.SetUserLastSiteId(userId, siteId);
        }

        public UserProfile GetUserByName(string userName)
        {
            return _accountRepository.GetUserByName(userName);
        }

    }
}
