namespace XamarinTest.DAL.Migrations {
    using System.Data.Entity.Migrations;

    public partial class AddNameToImages : DbMigration {
        public override void Up() {
            AddColumn("dbo.Images", "Name", c => c.String());
        }

        public override void Down() {
            DropColumn("dbo.Images", "Name");
        }
    }
}
