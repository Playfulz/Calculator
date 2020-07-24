using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.WebSocket;
using stuf.Commands;
using stuf.Core.UserAccounts;

namespace stuf.Core.UserAccounts
{
    public static class UserAccounts
    {
        private static List<UserAccount> accounts;

        private static string accountsFile = "Resources/accounts.json";

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
                Cherries = 100,
                XP = 0,
                Baguette = 0, 
                ChallengesCompleted = new List<Commands.Challenges.Challenge>(),
            };

            accounts.Add(newAccount);
            return newAccount;
        }
        public static List<uint> GetAllCherries()
        {
            List<uint> cherries = new List<uint>();
            foreach (var user in accounts)
            {
                cherries.Add(user.Cherries);
            }
            return cherries;
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
        public static List<uint> GetAllXP()
        {
            List<uint> cherries = new List<uint>();
            foreach (var user in accounts)
            {
                cherries.Add(user.XP);
            }
            return cherries;
        }
    }
}
