namespace XamarinTest.DAL.Migrations {
    using System.Data.Entity.Migrations;

    public partial class UpdateImages : DbMigration {
        public override void Up() {
            DropForeignKey("dbo.Images", "User_Id", "dbo.Users");
            DropIndex("dbo.Images", new[] {
                "User_Id"
            });
            RenameColumn(table: "dbo.Images", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Images", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Images", "UserId");
            AddForeignKey("dbo.Images", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            DropColumn("dbo.Images", "Path");
        }

        public override void Down() {
            AddColumn("dbo.Images", "Path", c => c.String());
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropIndex("dbo.Images", new[] {
                "UserId"
            });
            AlterColumn("dbo.Images", "UserId", c => c.Guid());
            RenameColumn(table: "dbo.Images", name: "UserId", newName: "User_Id");
            CreateIndex("dbo.Images", "User_Id");
            AddForeignKey("dbo.Images", "User_Id", "dbo.Users", "Id");
        }
    }
}
