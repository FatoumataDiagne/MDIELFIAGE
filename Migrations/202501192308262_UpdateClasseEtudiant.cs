namespace MDIELFIAGE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateClasseEtudiant : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Etudiants", "IdClasse", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Etudiants", "IdClasse", c => c.String());
        }
    }
}
