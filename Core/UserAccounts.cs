using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace Calculator.Core
{
    public static class UserAccounts
    {
        private static List<UserAccount> accounts;

        private static string accountsFile = "";

        static UserAccounts()
        {
            if (data.SavedExists(accountsFile))
            {
                accounts = data.LoadUserAccounts(accountsFile).ToList();
            }
            else
            {
                accounts = new List<UserAccount>();
                SaveAccounts();
            }
        }

        public static void SaveAccounts()
        {
            data.SaveUserAccounts(accounts, accountsFile);
        }
        public static UserAccount GetAccount(SocketUser user)
        {
            return GetOrCreateAccount(user.Id);
        }

        public static UserAccount GetOrCreateAccount(ulong id)
        {
            var result = from a in accounts
                         where a.ID == id
                         select a;

            var account = result.FirstOrDefault();
            if (account == null) account = CreateUserAccount(id);
            SaveAccounts();
            return account;
        }
        private static UserAccount CreateUserAccount(ulong id)
        {
            var newAccount = new UserAccount()
            {
                ID = id,
            };

            accounts.Add(newAccount);
            return newAccount;
        }
        public static List<UserAccount> GetAllUsers()
        {
            List<UserAccount> cherries = new List<UserAccount>();
            foreach (var user in accounts)
            {
                cherries.Add(user);
            }
            return cherries;
        }
    }
}
