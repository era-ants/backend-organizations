using FluentMigrator;

namespace Organizations.Migrations
{
    [Migration(1)]
    public sealed class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("Contacts")
                .WithColumn("Guid").AsGuid().PrimaryKey()
                .WithColumn("Email").AsString().Nullable()
                .WithColumn("PhoneNumber").AsString().Nullable()
                .WithColumn("Site").AsString().Nullable()
                .WithColumn("Vk").AsString().Nullable()
                .WithColumn("Telegram").AsString().Nullable()
                .WithColumn("Instagram").AsString().Nullable()
                ;

            Create.Table("UserScore")
                .WithColumn("OrganizationGuid").AsGuid().PrimaryKey()
                .WithColumn("ClientGuid").AsGuid().PrimaryKey()
                .WithColumn("Score").AsInt32().NotNullable()
                ;

            Create.Table("OrganizationLogo")
                .WithColumn("Guid").AsGuid().PrimaryKey()
                .WithColumn("Content").AsBinary().NotNullable()
                ;

            Create.Table("Organization")
                .WithColumn("Guid").AsGuid().PrimaryKey()
                .WithColumn("OrganizationTypeId").AsInt32()
                .WithColumn("ContactsGuid").AsGuid().ForeignKey("Contacts", "Guid")
                .WithColumn("LegalName").AsString().NotNullable()
                .WithColumn("LegalAddress").AsString().NotNullable()
                .WithColumn("ActualName").AsString().NotNullable()
                .WithColumn("TIN").AsString().NotNullable()
                .WithColumn("OrganizationLogoGuid").AsGuid().Nullable().ForeignKey("OrganizationLogo", "Guid")
                ;

            Create.Table("JOrganizationImage")
                .WithColumn("OrganizationGuid").AsGuid().PrimaryKey().ForeignKey("Organization", "Guid")
                .WithColumn("OrganizationImageGuid").AsGuid().Unique().ForeignKey("OrganizationImage", "Guid")
                ;
            
            Create.Table("OrganizationImage")
                .WithColumn("Guid").AsGuid().PrimaryKey()
                .WithColumn("Content").AsBinary().NotNullable()
                ;
        }

        public override void Down()
        {
        }
    }
}