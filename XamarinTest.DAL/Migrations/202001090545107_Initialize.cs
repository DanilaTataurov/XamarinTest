namespace XamarinTest.DAL.Migrations {
    using System.Data.Entity.Migrations;

    public partial class Initialize : DbMigration {
        public override void Up() {
            CreateTable(
                    "dbo.Images",
                    c => new {
                        Id = c.Guid(nullable: false),
                        Path = c.String(),
                        Coordinates = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);

            CreateTable(
                    "dbo.Users",
                    c => new {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                    "dbo.UserClaims",
                    c => new {
                        Id = c.Int(nullable: false, identity: true), UserId = c.Guid(nullable: false), ClaimType = c.String(), ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                    "dbo.UserLogins",
                    c => new {
                        UserId = c.Guid(nullable: false), LoginProvider = c.String(nullable: false, maxLength: 128), ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new {
                    t.UserId, t.LoginProvider, t.ProviderKey
                })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                    "dbo.UserRoles",
                    c => new {
                        UserId = c.Guid(nullable: false), RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new {
                    t.UserId, t.RoleId
                })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                    "dbo.Roles",
                    c => new {
                        Id = c.Guid(nullable: false), Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
        }

        public override void Down() {
            DropForeignKey("dbo.Images", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] {
                "RoleId"
            });
            DropIndex("dbo.UserRoles", new[] {
                "UserId"
            });
            DropIndex("dbo.UserLogins", new[] {
                "UserId"
            });
            DropIndex("dbo.UserClaims", new[] {
                "UserId"
            });
            DropIndex("dbo.Images", new[] {
                "User_Id"
            });
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Images");
        }
    }
}
