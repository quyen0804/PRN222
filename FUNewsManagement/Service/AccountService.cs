using FUNewsManagement.Models;
using FUNewsManagement.Repository;

namespace FUNewsManagement.Service
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public SystemAccount GetAccountById(short id)
        {
            return _accountRepository.GetSystemAccountById(id);
        }

        public void CreateAccount(SystemAccount account)
        {
            _accountRepository.Add(account);
        }

        public void DeleteAccount(short id)
        {
            _accountRepository.Delete(_accountRepository.GetSystemAccountById(id));
        }

        public void UpdateAccount(SystemAccount account)
        {
            _accountRepository.Update(account);
        }
    }
}
