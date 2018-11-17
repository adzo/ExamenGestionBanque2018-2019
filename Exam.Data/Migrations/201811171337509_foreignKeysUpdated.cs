namespace Exam.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeysUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comptes", "Agence_AgenceKey", "dbo.Agences");
            DropIndex("dbo.Comptes", new[] { "Agence_AgenceKey" });
            RenameColumn(table: "dbo.Comptes", name: "Agence_AgenceKey", newName: "AgenceKey");
            RenameColumn(table: "dbo.Comptes", name: "Client_CIN", newName: "CIN");
            RenameIndex(table: "dbo.Comptes", name: "IX_Client_CIN", newName: "IX_CIN");
            AlterColumn("dbo.Comptes", "AgenceKey", c => c.Int(nullable: false));
            CreateIndex("dbo.Comptes", "AgenceKey");
            AddForeignKey("dbo.Comptes", "AgenceKey", "dbo.Agences", "AgenceKey", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comptes", "AgenceKey", "dbo.Agences");
            DropIndex("dbo.Comptes", new[] { "AgenceKey" });
            AlterColumn("dbo.Comptes", "AgenceKey", c => c.Int());
            RenameIndex(table: "dbo.Comptes", name: "IX_CIN", newName: "IX_Client_CIN");
            RenameColumn(table: "dbo.Comptes", name: "CIN", newName: "Client_CIN");
            RenameColumn(table: "dbo.Comptes", name: "AgenceKey", newName: "Agence_AgenceKey");
            CreateIndex("dbo.Comptes", "Agence_AgenceKey");
            AddForeignKey("dbo.Comptes", "Agence_AgenceKey", "dbo.Agences", "AgenceKey");
        }
    }
}
