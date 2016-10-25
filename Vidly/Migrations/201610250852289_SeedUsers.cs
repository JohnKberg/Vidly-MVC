namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7799f220-bb9e-495f-a35f-fec51dd1c9ef', N'admin@vidly.com', 0, N'AJP9r5Bu1mgOwNoMl0E4XBoXpxVT9zpzZUoijFrJ0KhHhbi11V/oBhRwCEmz5y1Tew==', N'5da559e0-3377-4ab4-8423-9e39f706c420', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7d173b56-acbd-499a-b865-914ce80b66d8', N'guest@vidly.com', 0, N'ACFAZxWlCCDv897/Dp16SRBCepWGQCZ7190cwryxy/vgYSOxNKFE4qmGQHehhO1zqg==', N'c3d5ce13-3211-4e1d-a2e4-d9c6f9030464', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a225a770-c750-4628-bb2f-8d06e5d5ed35', N'CanManageMovies')            
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7799f220-bb9e-495f-a35f-fec51dd1c9ef', N'a225a770-c750-4628-bb2f-8d06e5d5ed35')
            ");

        }
        
        public override void Down()
        {

        }
    }
}
