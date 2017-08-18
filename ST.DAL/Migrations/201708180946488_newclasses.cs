namespace ST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AdresAdi = c.String(),
                        AcikAdres = c.String(),
                        EklenmeZamani = c.DateTime(nullable: false),
                        KullaniciId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.KullaniciId)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "dbo.Siparisler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiparisZamani = c.DateTime(nullable: false),
                        OnaylanmaZamani = c.DateTime(),
                        TeslimZamani = c.DateTime(),
                        OdemeTipiId = c.Int(nullable: false),
                        KullaniciId = c.String(maxLength: 128),
                        Puan = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.KullaniciId)
                .ForeignKey("dbo.OdemeTipis", t => t.OdemeTipiId, cascadeDelete: true)
                .Index(t => t.OdemeTipiId)
                .Index(t => t.KullaniciId);
            
            CreateTable(
                "dbo.OdemeTipis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OdemeTipiAdi = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FirmaUrunler",
                c => new
                    {
                        FirmaId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        UrunFiyati = c.Decimal(nullable: false, precision: 7, scale: 2),
                        SatistaMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.FirmaId, t.UrunId })
                .ForeignKey("dbo.Firmas", t => t.FirmaId, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.FirmaId)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FirmaUrunler", "UrunId", "dbo.Urunler");
            DropForeignKey("dbo.FirmaUrunler", "FirmaId", "dbo.Firmas");
            DropForeignKey("dbo.Siparisler", "OdemeTipiId", "dbo.OdemeTipis");
            DropForeignKey("dbo.Siparisler", "KullaniciId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Adresler", "KullaniciId", "dbo.AspNetUsers");
            DropIndex("dbo.FirmaUrunler", new[] { "UrunId" });
            DropIndex("dbo.FirmaUrunler", new[] { "FirmaId" });
            DropIndex("dbo.Siparisler", new[] { "KullaniciId" });
            DropIndex("dbo.Siparisler", new[] { "OdemeTipiId" });
            DropIndex("dbo.Adresler", new[] { "KullaniciId" });
            DropTable("dbo.FirmaUrunler");
            DropTable("dbo.OdemeTipis");
            DropTable("dbo.Siparisler");
            DropTable("dbo.Adresler");
        }
    }
}
