namespace Exam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comptes",
                c => new
                    {
                        RIB = c.Int(nullable: false, identity: true),
                        DateOuverture = c.DateTime(nullable: false),
                        Solde = c.Single(nullable: false),
                        DecouvertMax = c.Single(),
                        Taux = c.Single(),
                        Agence_AgenceKey = c.Int(),
                        Client_CIN = c.String(maxLength: 128),
                        Type = c.Int(),
                    })
                .PrimaryKey(t => t.RIB)
                .ForeignKey("dbo.Agences", t => t.Agence_AgenceKey)
                .ForeignKey("dbo.Clients", t => t.Client_CIN)
                .Index(t => t.Agence_AgenceKey)
                .Index(t => t.Client_CIN);
            
            CreateTable(
                "dbo.Agences",
                c => new
                    {
                        AgenceKey = c.Int(nullable: false, identity: true),
                        NomAgence = c.String(),
                        AddressAgence_Rue = c.String(),
                        AddressAgence_Ville = c.String(),
                        NombreEmploye = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgenceKey);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        CIN = c.String(nullable: false, maxLength: 128),
                        FullName_FirstName = c.String(),
                        FullName_LastName = c.String(),
                        DateNaissance = c.DateTime(nullable: false),
                        Profession = c.String(),
                        Address_Rue = c.String(),
                        Address_Ville = c.String(),
                        Salaire = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.CIN);
            
            CreateTable(
                "dbo.Credits",
                c => new
                    {
                        CreditKey = c.Int(nullable: false, identity: true),
                        SommeCredit = c.Single(nullable: false),
                        DateCredit = c.DateTime(nullable: false),
                        TauxInteret = c.Single(nullable: false),
                        TypeCredit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CreditKey);
            
            CreateTable(
                "dbo.CompteCredit",
                c => new
                    {
                        Compte_RIB = c.Int(nullable: false),
                        Credit_CreditKey = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Compte_RIB, t.Credit_CreditKey })
                .ForeignKey("dbo.Comptes", t => t.Compte_RIB, cascadeDelete: true)
                .ForeignKey("dbo.Credits", t => t.Credit_CreditKey, cascadeDelete: true)
                .Index(t => t.Compte_RIB)
                .Index(t => t.Credit_CreditKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompteCredit", "Credit_CreditKey", "dbo.Credits");
            DropForeignKey("dbo.CompteCredit", "Compte_RIB", "dbo.Comptes");
            DropForeignKey("dbo.Comptes", "Client_CIN", "dbo.Clients");
            DropForeignKey("dbo.Comptes", "Agence_AgenceKey", "dbo.Agences");
            DropIndex("dbo.CompteCredit", new[] { "Credit_CreditKey" });
            DropIndex("dbo.CompteCredit", new[] { "Compte_RIB" });
            DropIndex("dbo.Comptes", new[] { "Client_CIN" });
            DropIndex("dbo.Comptes", new[] { "Agence_AgenceKey" });
            DropTable("dbo.CompteCredit");
            DropTable("dbo.Credits");
            DropTable("dbo.Clients");
            DropTable("dbo.Agences");
            DropTable("dbo.Comptes");
        }
    }
}
