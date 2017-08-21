namespace ST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChanginginClasses : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Firmas", "MinimumSiparisTutari", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Firmas", "FirmaProfilFotoPath", c => c.String());
            AddColumn("dbo.Firmas", "FirmaKapakFotoPath", c => c.String());
            AddColumn("dbo.AspNetRoles", "Description", c => c.String(maxLength: 200));
            DropColumn("dbo.AspNetRoles", "Decription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetRoles", "Decription", c => c.String(maxLength: 200));
            DropColumn("dbo.AspNetRoles", "Description");
            DropColumn("dbo.Firmas", "FirmaKapakFotoPath");
            DropColumn("dbo.Firmas", "FirmaProfilFotoPath");
            DropColumn("dbo.Firmas", "MinimumSiparisTutari");
        }
    }
}
