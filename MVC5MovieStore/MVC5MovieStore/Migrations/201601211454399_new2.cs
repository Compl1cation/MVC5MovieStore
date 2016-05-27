namespace MVC5MovieStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Description", c => c.String(nullable: false, maxLength: 1500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Description", c => c.String(nullable: false, maxLength: 4000));
        }
    }
}
