using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Code4Nothing.Infrastructures.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blogs");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "blogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    normalizedname = table.Column<string>(name: "normalized_name", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    normalizedname = table.Column<string>(name: "normalized_name", type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tags", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                schema: "blogs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    slug = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    author = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    isfixedtotop = table.Column<bool>(name: "is_fixed_to_top", type: "boolean", nullable: false),
                    @abstract = table.Column<string>(name: "abstract", type: "character varying(1024)", maxLength: 1024, nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    copyrightinfo = table.Column<string>(name: "copyright_info", type: "text", nullable: true),
                    likes = table.Column<int>(type: "integer", nullable: false),
                    hits = table.Column<int>(type: "integer", nullable: false),
                    ispublished = table.Column<bool>(name: "is_published", type: "boolean", nullable: false),
                    publishedat = table.Column<DateTime>(name: "published_at", type: "timestamp", nullable: true),
                    categoryid = table.Column<Guid>(name: "category_id", type: "uuid", nullable: false),
                    createdat = table.Column<DateTime>(name: "created_at", type: "timestamp", nullable: false),
                    lastmodifiedat = table.Column<DateTime>(name: "last_modified_at", type: "timestamp", nullable: true),
                    isdeleted = table.Column<bool>(name: "is_deleted", type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_posts", x => x.id);
                    table.ForeignKey(
                        name: "fk_posts_categories_category_id",
                        column: x => x.categoryid,
                        principalSchema: "blogs",
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_tag",
                columns: table => new
                {
                    postsid = table.Column<Guid>(name: "posts_id", type: "uuid", nullable: false),
                    tagsid = table.Column<int>(name: "tags_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_post_tag", x => new { x.postsid, x.tagsid });
                    table.ForeignKey(
                        name: "fk_post_tag_posts_posts_id",
                        column: x => x.postsid,
                        principalSchema: "blogs",
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_post_tag_tags_tags_id",
                        column: x => x.tagsid,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post_tags",
                schema: "blogs",
                columns: table => new
                {
                    postid = table.Column<Guid>(name: "post_id", type: "uuid", nullable: false),
                    tagid = table.Column<int>(name: "tag_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_post_tags", x => new { x.postid, x.tagid });
                    table.ForeignKey(
                        name: "fk_post_tags_posts_post_id",
                        column: x => x.postid,
                        principalSchema: "blogs",
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_post_tags_tags_tag_id",
                        column: x => x.tagid,
                        principalTable: "tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_post_tag_tags_id",
                table: "post_tag",
                column: "tags_id");

            migrationBuilder.CreateIndex(
                name: "ix_post_tags_tag_id",
                schema: "blogs",
                table: "post_tags",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_category_id",
                schema: "blogs",
                table: "posts",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_posts_title",
                schema: "blogs",
                table: "posts",
                column: "title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "post_tag");

            migrationBuilder.DropTable(
                name: "post_tags",
                schema: "blogs");

            migrationBuilder.DropTable(
                name: "posts",
                schema: "blogs");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "blogs");
        }
    }
}
