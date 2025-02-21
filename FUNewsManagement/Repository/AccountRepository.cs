using System.Collections.Generic;
using System.Linq;
using FUNewsManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FUNewsManagement.Repository
{
    public class AccountRepository
    {
        private static AccountRepository _instance;  // The single instance

        private readonly FunewsManagementContext _context; // Database context

        // Private constructor so no one can create new instances
        private AccountRepository(FunewsManagementContext context)
        {
            _context = context;
        }

        public static AccountRepository GetInstance(FunewsManagementContext context)
        {
            if (_instance == null) // If no instance exists, create one
            {  
                _instance = new AccountRepository(context);
            }
            return _instance; // Return the single instance
        }



        public SystemAccount GetSystemAccountById(short id)
        {
            try
            {
                var account = _context.SystemAccounts
                    .Where(a => a.AccountId == id)  
                    .OrderBy(a => a.AccountName)    
                    .FirstOrDefault();              

                if (account == null)
                {
                    throw new KeyNotFoundException($"Account with ID {id} not found.");
                }

                return account;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching account: {ex.Message}");
                throw;
            }
        }



        public List<SystemAccount> GetAll()
        {
            return _context.SystemAccounts.ToList();
        }

        public void Add(SystemAccount account)
        {
            _context.SystemAccounts.Add(account);
            _context.SaveChanges();
        }

        public void Delete(SystemAccount account)
        {
            _context.SystemAccounts.Remove(account);
            _context.SaveChanges();
        }

        public void Update(SystemAccount account)
        {
            _context.Entry(account).State = EntityState.Modified;
            _context.SaveChanges();
        }


        public List<SystemAccount> SearchAccounts(short? accountId, string accountName, string accountEmail, int? accountRole)
        {
            var query = _context.SystemAccounts.AsQueryable();

            if (accountId.HasValue && accountId > 0)
            {
                query = query.Where(a => a.AccountId == accountId.Value);
            }
            if (!string.IsNullOrWhiteSpace(accountName))
            {
                query = query.Where(a => a.AccountName.Contains(accountName));
            }
            if (!string.IsNullOrWhiteSpace(accountEmail))
            {
                query = query.Where(a => a.AccountEmail.Contains(accountEmail));
            }
            if (accountRole.HasValue)
            {
                query = query.Where(a => a.AccountRole == accountRole.Value);
            }

            return query.ToList();
        }
    }
}

