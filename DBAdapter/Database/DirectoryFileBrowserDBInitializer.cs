using DBModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DBAdapter.Database
{
    class DirectoryFileBrowserDBInitializer : CreateDatabaseIfNotExists<DirectoryBrowserContext>
    {
        protected override void Seed(DirectoryBrowserContext context)
        {
            IList<User> users = new List<User>();
            base.Seed(context);
        }
    }
}
