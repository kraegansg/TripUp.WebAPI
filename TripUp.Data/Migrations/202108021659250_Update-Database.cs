namespace TripUp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Itinerary",
                c => new
                    {
                        ItineraryId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        ItineraryName = c.String(),
                        PitStop = c.String(),
                        TravelDistance = c.Int(nullable: false),
                        TravelTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ItineraryId)
                .ForeignKey("dbo.Trip", t => t.ItineraryId)
                .Index(t => t.ItineraryId);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        TripName = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        Destination = c.String(nullable: false),
                        StartingLocation = c.String(nullable: false),
                        TravelBuddies = c.String(),
                    })
                .PrimaryKey(t => t.TripId);
            
            CreateTable(
                "dbo.Pack",
                c => new
                    {
                        PackId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        PackName = c.String(),
                        Clothes = c.String(),
                        BathItems = c.String(),
                        Essentials = c.String(),
                        Other = c.String(),
                    })
                .PrimaryKey(t => t.PackId)
                .ForeignKey("dbo.Trip", t => t.PackId)
                .Index(t => t.PackId);
            
            CreateTable(
                "dbo.ToDoList",
                c => new
                    {
                        ToDoListId = c.Int(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        ToDoListName = c.String(),
                        ToDoListMisc = c.String(),
                        PetCareInstructions = c.String(),
                        ChildCareInstructions = c.String(),
                        HouseCareInstructions = c.String(),
                    })
                .PrimaryKey(t => t.ToDoListId)
                .ForeignKey("dbo.Trip", t => t.ToDoListId)
                .Index(t => t.ToDoListId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Itinerary", "ItineraryId", "dbo.Trip");
            DropForeignKey("dbo.ToDoList", "ToDoListId", "dbo.Trip");
            DropForeignKey("dbo.Pack", "PackId", "dbo.Trip");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.ToDoList", new[] { "ToDoListId" });
            DropIndex("dbo.Pack", new[] { "PackId" });
            DropIndex("dbo.Itinerary", new[] { "ItineraryId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ToDoList");
            DropTable("dbo.Pack");
            DropTable("dbo.Trip");
            DropTable("dbo.Itinerary");
        }
    }
}
