using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Calculator.Core {
    public static class AccountStorage {
        
        public static void SaveUserAccounts(IEnumerable<UserAccount> accoun, string filePath) {
            string json = JsonConvert.SerializeObject(accoun);
            File.WriteAllText(filePath, json);
        }

        public static IEnumerable<UserAccount> LoadUserAccounts(string filePath){
            if (!File.Exists(filePath)) return null;
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<UserAccount>>(json);
        }

        public static bool SavedExists(string filePath) {
            return File.Exists(filePath);
        }
    }
}
