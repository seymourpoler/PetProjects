using FluentMigrator;

namespace WiMi.Migrations.SQLite.Migrations
{
    [Migration(201807261444147, nameof(CreatePagesTable))]
    public class CreatePagesTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("Pages")
                .WithColumn("Id").AsString(256).PrimaryKey().NotNullable()
                .WithColumn("Title").AsString(256).NotNullable()
                .WithColumn("Body").AsString(1000).NotNullable()
                .WithColumn("CreationDate").AsDateTime2().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Pages");
        }
    }
}
