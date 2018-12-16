using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DBModels.Models;
using DBAdapter.Database;

namespace Managers
{
    public class DBManager
    {

        public static void CreateNewUser(User user)
        {
            using (var context = new DirectoryBrowserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new DirectoryBrowserContext())
            {
                var queryResult = from u in context.Users
                                  where u.Login == login
                                  select u;
                return queryResult.FirstOrDefault();
            }
        }

        public static void UpdateLoggedInDateToCurrent(User user)
        {
            using (var context = new DirectoryBrowserContext())
            {
                var queryResult = from u in context.Users
                                  where u.UserId == user.UserId
                                  select u;
                var foundUser = queryResult.First();
                foundUser.LastLoginDate = DateTime.Now;
                context.SaveChanges();
            }
        }

        public static void WriteQueryForUser(User user, string dirPath)
        {
            using (var context = new DirectoryBrowserContext())
            {
                var query = new Query
                {
                    UserId = user.UserId,
                    Path = dirPath
                };
                context.Queries.Add(query);
                context.SaveChanges();
            }
        }

        public static IEnumerable<Query> GetQueriesForUser(User user)
        {
            using (var context = new DirectoryBrowserContext())
            {
                var queryResult = from q in context.Queries
                                  where q.User.UserId == user.UserId
                                  select q;
                return queryResult.AsEnumerable().ToList();
            }

        }
    }
}
