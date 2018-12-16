namespace DBAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Queries",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.Int(nullable: false),
                    Path = c.String(),
                    Date = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UsersTable", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.UsersTable",
                c => new
                {
                    UserId = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 50),
                    Surname = c.String(),
                    Email = c.String(),
                    Login = c.String(),
                    Password = c.String(),
                    LastLoginDate = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.UserId);

            CreateStoredProcedure(
                "dbo.User_Insert",
                p => new
                {
                    Name = p.String(maxLength: 50),
                    Surname = p.String(),
                    Email = p.String(),
                    Login = p.String(),
                    Password = p.String(),
                    LastLoginDate = p.DateTime(),
                },
                body:
                    @"INSERT [dbo].[UsersTable]([Name], [Surname], [Email], [Login], [Password], [LastLoginDate])
                      VALUES (@Name, @Surname, @Email, @Login, @Password, @LastLoginDate)
                      
                      DECLARE @UserId int
                      SELECT @UserId = [UserId]
                      FROM [dbo].[UsersTable]
                      WHERE @@ROWCOUNT > 0 AND [UserId] = scope_identity()
                      
                      SELECT t0.[UserId]
                      FROM [dbo].[UsersTable] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[UserId] = @UserId"
            );

            CreateStoredProcedure(
                "dbo.User_Update",
                p => new
                {
                    UserId = p.Int(),
                    Name = p.String(maxLength: 50),
                    Surname = p.String(),
                    Email = p.String(),
                    Login = p.String(),
                    Password = p.String(),
                    LastLoginDate = p.DateTime(),
                },
                body:
                    @"UPDATE [dbo].[UsersTable]
                      SET [Name] = @Name, [Surname] = @Surname, [Email] = @Email, [Login] = @Login, [Password] = @Password, [LastLoginDate] = @LastLoginDate
                      WHERE ([UserId] = @UserId)"
            );

            CreateStoredProcedure(
                "dbo.User_Delete",
                p => new
                {
                    UserId = p.Int(),
                },
                body:
                    @"DELETE [dbo].[UsersTable]
                      WHERE ([UserId] = @UserId)"
            );

        }

        public override void Down()
        {
            DropStoredProcedure("dbo.User_Delete");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Insert");
            DropForeignKey("dbo.Queries", "UserId", "dbo.UsersTable");
            DropIndex("dbo.Queries", new[] { "UserId" });
            DropTable("dbo.UsersTable");
            DropTable("dbo.Queries");
        }
    }
}
