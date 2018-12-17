using System.Data.Entity;
using System.Linq;
using DBAdapter.Database;
using DBModels.Models;

namespace DBAdapter
{
    public static class EntityWrapper
    {
        public static bool UserExists(string login)
        {
            using (var context = new DirectoryBrowserContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }

        public static LabUser GetUserByLogin(string login)
        {
            using (var context = new DirectoryBrowserContext())
            {
                return context.Users.Include(u => u.Query).FirstOrDefault(u => u.Login == login);
            }
        }

        public static void AddUser(LabUser user)
        {
            using (var context = new DirectoryBrowserContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddQuery(Query query)
        {
            using (var context = new DirectoryBrowserContext())
            {
                query.DeleteDatabaseValues();
                context.Queries.Add(query);
                context.SaveChanges();
            }
        }

        public static void SaveQuery(Query query)
        {
            using (var context = new DirectoryBrowserContext())
            {
                context.Entry(query).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
