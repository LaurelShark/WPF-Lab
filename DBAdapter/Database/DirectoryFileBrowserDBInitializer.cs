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
            IList<LabUser> users = new List<LabUser>();
            base.Seed(context);
        }
    }
}
