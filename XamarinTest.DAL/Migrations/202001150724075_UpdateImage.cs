namespace XamarinTest.DAL.Migrations {
    using System.Data.Entity.Migrations;

    public partial class UpdateImage : DbMigration {
        public override void Up() {
            AddColumn("dbo.Images", "ImageBytes", c => c.Binary());
            AddColumn("dbo.Images", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Images", "Longitude", c => c.Double(nullable: false));
            DropColumn("dbo.Images", "Coordinates");
        }

        public override void Down() {
            AddColumn("dbo.Images", "Coordinates", c => c.String());
            DropColumn("dbo.Images", "Longitude");
            DropColumn("dbo.Images", "Latitude");
            DropColumn("dbo.Images", "ImageBytes");
        }
    }
}
