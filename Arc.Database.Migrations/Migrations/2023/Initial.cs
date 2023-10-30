using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arc.Database.Migrations.Migrations._2023
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "actor",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(8)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    discriminator = table.Column<string>(type: "varchar(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    firstname = table.Column<string>(name: "first_name", type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastname = table.Column<string>(name: "last_name", type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_actor", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asp_net_role",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    normalizedname = table.Column<string>(name: "normalized_name", type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    concurrencystamp = table.Column<string>(name: "concurrency_stamp", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asp_net_user",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    username = table.Column<string>(name: "user_name", type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    normalizedusername = table.Column<string>(name: "normalized_user_name", type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    normalizedemail = table.Column<string>(name: "normalized_email", type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    emailconfirmed = table.Column<bool>(name: "email_confirmed", type: "bit(1)", nullable: false),
                    passwordhash = table.Column<string>(name: "password_hash", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    securitystamp = table.Column<string>(name: "security_stamp", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    concurrencystamp = table.Column<string>(name: "concurrency_stamp", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phonenumber = table.Column<string>(name: "phone_number", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    phonenumberconfirmed = table.Column<bool>(name: "phone_number_confirmed", type: "bit(1)", nullable: false),
                    twofactorenabled = table.Column<bool>(name: "two_factor_enabled", type: "bit(1)", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(name: "lockout_end", type: "datetime(6)", nullable: true),
                    lockoutenabled = table.Column<bool>(name: "lockout_enabled", type: "bit(1)", nullable: false),
                    accessfailedcount = table.Column<int>(name: "access_failed_count", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "base_description",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(8)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    value = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    complexpropertyid = table.Column<int>(name: "complex_property_id", type: "int", nullable: true),
                    groupid = table.Column<int>(name: "group_id", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_base_description", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "data_protection_keys",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    friendlyname = table.Column<string>(name: "friendly_name", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    xml = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_data_protection_keys", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "simple_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(8)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    value = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_simple_property", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "item",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(8)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    datecreated = table.Column<DateTime>(name: "date_created", type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    name = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userid = table.Column<int>(name: "user_id", type: "int(8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item", x => x.id);
                    table.ForeignKey(
                        name: "fk_item_actor_user_id",
                        column: x => x.userid,
                        principalTable: "actor",
                        principalColumn: "id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "service_mode",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(8)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    mode = table.Column<string>(type: "enum('On','Off')", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    updatedatetime = table.Column<DateTime>(name: "update_date_time", type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    updatedbyid = table.Column<int>(name: "updated_by_id", type: "int(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_service_mode", x => x.id);
                    table.ForeignKey(
                        name: "fk_service_mode_actor_updated_by_id",
                        column: x => x.updatedbyid,
                        principalTable: "actor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asp_net_role_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roleid = table.Column<string>(name: "role_id", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    claimtype = table.Column<string>(name: "claim_type", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    claimvalue = table.Column<string>(name: "claim_value", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claim_asp_net_role_role_id",
                        column: x => x.roleid,
                        principalTable: "asp_net_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asp_net_user_claim",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    userid = table.Column<string>(name: "user_id", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    claimtype = table.Column<string>(name: "claim_type", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    claimvalue = table.Column<string>(name: "claim_value", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claim", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claim_asp_net_user_user_id",
                        column: x => x.userid,
                        principalTable: "asp_net_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asp_net_user_login",
                columns: table => new
                {
                    loginprovider = table.Column<string>(name: "login_provider", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    providerkey = table.Column<string>(name: "provider_key", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    providerdisplayname = table.Column<string>(name: "provider_display_name", type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    userid = table.Column<string>(name: "user_id", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_login", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "fk_asp_net_user_login_asp_net_user_user_id",
                        column: x => x.userid,
                        principalTable: "asp_net_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asp_net_user_role",
                columns: table => new
                {
                    userid = table.Column<string>(name: "user_id", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    roleid = table.Column<string>(name: "role_id", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_role", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "fk_asp_net_user_role_asp_net_role_role_id",
                        column: x => x.roleid,
                        principalTable: "asp_net_role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_role_asp_net_user_user_id",
                        column: x => x.userid,
                        principalTable: "asp_net_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "asp_net_user_token",
                columns: table => new
                {
                    userid = table.Column<string>(name: "user_id", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    loginprovider = table.Column<string>(name: "login_provider", type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_token", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_token_asp_net_user_user_id",
                        column: x => x.userid,
                        principalTable: "asp_net_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "group",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(8)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    descriptionid = table.Column<int>(name: "description_id", type: "int(8)", nullable: false),
                    name = table.Column<string>(type: "varchar(256)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_group", x => x.id);
                    table.ForeignKey(
                        name: "fk_group_base_description_description_id1",
                        column: x => x.descriptionid,
                        principalTable: "base_description",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "items_simple_properties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(8)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    itemid = table.Column<int>(name: "item_id", type: "int(8)", nullable: false),
                    simplepropertyid = table.Column<int>(name: "simple_property_id", type: "int(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items_simple_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_items_simple_properties_item_item_id",
                        column: x => x.itemid,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_items_simple_properties_simple_property_simple_property_id",
                        column: x => x.simplepropertyid,
                        principalTable: "simple_property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "complex_property",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(8)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    value = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descriptionid = table.Column<int>(name: "description_id", type: "int(8)", nullable: false),
                    groupid = table.Column<int>(name: "group_id", type: "int(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_complex_property", x => x.id);
                    table.ForeignKey(
                        name: "fk_complex_property_base_description_description_id1",
                        column: x => x.descriptionid,
                        principalTable: "base_description",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_complex_property_group_group_id",
                        column: x => x.groupid,
                        principalTable: "group",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "items_complex_properties",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    itemid = table.Column<int>(name: "item_id", type: "int(8)", nullable: false),
                    complexpropertyid = table.Column<int>(name: "complex_property_id", type: "int(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items_complex_properties", x => x.id);
                    table.ForeignKey(
                        name: "fk_items_complex_properties_complex_property_complex_property_id",
                        column: x => x.complexpropertyid,
                        principalTable: "complex_property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_items_complex_properties_item_item_id",
                        column: x => x.itemid,
                        principalTable: "item",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "ix_actor_email",
                table: "actor",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "asp_net_role",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_role_claim_role_id",
                table: "asp_net_role_claim",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "asp_net_user",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "asp_net_user",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claim_user_id",
                table: "asp_net_user_claim",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_login_user_id",
                table: "asp_net_user_login",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_role_role_id",
                table: "asp_net_user_role",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "ix_complex_property_description_id",
                table: "complex_property",
                column: "description_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_complex_property_group_id",
                table: "complex_property",
                column: "group_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_complex_property_value",
                table: "complex_property",
                column: "value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_group_description_id",
                table: "group",
                column: "description_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_item_name",
                table: "item",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_item_user_id",
                table: "item",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_complex_properties_complex_property_id",
                table: "items_complex_properties",
                column: "complex_property_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_complex_properties_item_id",
                table: "items_complex_properties",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_simple_properties_item_id",
                table: "items_simple_properties",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_simple_properties_item_id_simple_property_id",
                table: "items_simple_properties",
                columns: new[] { "item_id", "simple_property_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_items_simple_properties_simple_property_id",
                table: "items_simple_properties",
                column: "simple_property_id");

            migrationBuilder.CreateIndex(
                name: "ix_service_mode_updated_by_id",
                table: "service_mode",
                column: "updated_by_id");

            migrationBuilder.CreateIndex(
                name: "ix_simple_property_value",
                table: "simple_property",
                column: "value",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asp_net_role_claim");

            migrationBuilder.DropTable(
                name: "asp_net_user_claim");

            migrationBuilder.DropTable(
                name: "asp_net_user_login");

            migrationBuilder.DropTable(
                name: "asp_net_user_role");

            migrationBuilder.DropTable(
                name: "asp_net_user_token");

            migrationBuilder.DropTable(
                name: "data_protection_keys");

            migrationBuilder.DropTable(
                name: "items_complex_properties");

            migrationBuilder.DropTable(
                name: "items_simple_properties");

            migrationBuilder.DropTable(
                name: "service_mode");

            migrationBuilder.DropTable(
                name: "asp_net_role");

            migrationBuilder.DropTable(
                name: "asp_net_user");

            migrationBuilder.DropTable(
                name: "complex_property");

            migrationBuilder.DropTable(
                name: "item");

            migrationBuilder.DropTable(
                name: "simple_property");

            migrationBuilder.DropTable(
                name: "group");

            migrationBuilder.DropTable(
                name: "actor");

            migrationBuilder.DropTable(
                name: "base_description");
        }
    }
}
