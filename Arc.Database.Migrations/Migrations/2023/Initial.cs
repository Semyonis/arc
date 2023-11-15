#nullable disable

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Arc.Database.Migrations.Migrations._2023;

/// <inheritdoc />
public partial class Initial : Migration
{
    /// <inheritdoc />
    protected override void Up(
        MigrationBuilder migrationBuilder
    )
    {
        migrationBuilder.AlterDatabase()
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "actor",
                table => new
                {
                    id = table.Column<int>(
                            "int(8)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    discriminator = table.Column<string>(
                            "varchar(64)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    email = table.Column<string>(
                            "varchar(256)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    firstname = table.Column<string>(
                            name: "first_name",
                            type: "varchar(128)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    lastname = table.Column<string>(
                            name: "last_name",
                            type: "varchar(128)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_actor",
                        x => x.id
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "asp_net_role",
                table => new
                {
                    id = table.Column<string>(
                            "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    name = table.Column<string>(
                            "varchar(256)",
                            maxLength: 256,
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    normalizedname = table.Column<string>(
                            name: "normalized_name",
                            type: "varchar(256)",
                            maxLength: 256,
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    concurrencystamp = table.Column<string>(
                            name: "concurrency_stamp",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_role",
                        x => x.id
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "asp_net_user",
                table => new
                {
                    id = table.Column<string>(
                            "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    username = table.Column<string>(
                            name: "user_name",
                            type: "varchar(256)",
                            maxLength: 256,
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    normalizedusername = table.Column<string>(
                            name: "normalized_user_name",
                            type: "varchar(256)",
                            maxLength: 256,
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    email = table.Column<string>(
                            "varchar(256)",
                            maxLength: 256,
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    normalizedemail = table.Column<string>(
                            name: "normalized_email",
                            type: "varchar(256)",
                            maxLength: 256,
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    emailconfirmed = table.Column<bool>(
                        name: "email_confirmed",
                        type: "bit(1)",
                        nullable: false
                    ),
                    passwordhash = table.Column<string>(
                            name: "password_hash",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    securitystamp = table.Column<string>(
                            name: "security_stamp",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    concurrencystamp = table.Column<string>(
                            name: "concurrency_stamp",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    phonenumber = table.Column<string>(
                            name: "phone_number",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    phonenumberconfirmed = table.Column<bool>(
                        name: "phone_number_confirmed",
                        type: "bit(1)",
                        nullable: false
                    ),
                    twofactorenabled = table.Column<bool>(
                        name: "two_factor_enabled",
                        type: "bit(1)",
                        nullable: false
                    ),
                    lockoutend = table.Column<DateTimeOffset>(
                        name: "lockout_end",
                        type: "datetime(6)",
                        nullable: true
                    ),
                    lockoutenabled = table.Column<bool>(
                        name: "lockout_enabled",
                        type: "bit(1)",
                        nullable: false
                    ),
                    accessfailedcount = table.Column<int>(
                        name: "access_failed_count",
                        type: "int",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_user",
                        x => x.id
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "base_description",
                table => new
                {
                    id = table.Column<int>(
                            "int(8)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    value = table.Column<string>(
                            "varchar(128)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    discriminator = table.Column<string>(
                            "longtext",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    complexpropertyid = table.Column<int>(
                        name: "complex_property_id",
                        type: "int",
                        nullable: true
                    ),
                    groupid = table.Column<int>(
                        name: "group_id",
                        type: "int",
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_base_description",
                        x => x.id
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "data_protection_keys",
                table => new
                {
                    id = table.Column<int>(
                            "int",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    friendlyname = table.Column<string>(
                            name: "friendly_name",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    xml = table.Column<string>(
                            "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_data_protection_keys",
                        x => x.id
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "simple_property",
                table => new
                {
                    id = table.Column<int>(
                            "int(8)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    value = table.Column<string>(
                            "varchar(128)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_simple_property",
                        x => x.id
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "item",
                table => new
                {
                    id = table.Column<int>(
                            "int(8)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    datecreated = table.Column<DateTime>(
                        name: "date_created",
                        type: "timestamp",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    name = table.Column<string>(
                            "varchar(128)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    userid = table.Column<int>(
                        name: "user_id",
                        type: "int(8)",
                        nullable: true
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_item",
                        x => x.id
                    );

                    table.ForeignKey(
                        "fk_item_actor_user_id",
                        x => x.userid,
                        "actor",
                        "id"
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "service_mode",
                table => new
                {
                    id = table.Column<int>(
                            "int(8)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    mode = table.Column<string>(
                            "enum('On','Off')",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    updatedatetime = table.Column<DateTime>(
                        name: "update_date_time",
                        type: "timestamp",
                        nullable: false,
                        defaultValueSql: "CURRENT_TIMESTAMP"
                    ),
                    updatedbyid = table.Column<int>(
                        name: "updated_by_id",
                        type: "int(8)",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_service_mode",
                        x => x.id
                    );

                    table.ForeignKey(
                        "fk_service_mode_actor_updated_by_id",
                        x => x.updatedbyid,
                        "actor",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "asp_net_role_claim",
                table => new
                {
                    id = table.Column<int>(
                            "int",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    roleid = table.Column<string>(
                            name: "role_id",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    claimtype = table.Column<string>(
                            name: "claim_type",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    claimvalue = table.Column<string>(
                            name: "claim_value",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_role_claim",
                        x => x.id
                    );

                    table.ForeignKey(
                        "fk_asp_net_role_claim_asp_net_role_role_id",
                        x => x.roleid,
                        "asp_net_role",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "asp_net_user_claim",
                table => new
                {
                    id = table.Column<int>(
                            "int",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    userid = table.Column<string>(
                            name: "user_id",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    claimtype = table.Column<string>(
                            name: "claim_type",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    claimvalue = table.Column<string>(
                            name: "claim_value",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_user_claim",
                        x => x.id
                    );

                    table.ForeignKey(
                        "fk_asp_net_user_claim_asp_net_user_user_id",
                        x => x.userid,
                        "asp_net_user",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "asp_net_user_login",
                table => new
                {
                    loginprovider = table.Column<string>(
                            name: "login_provider",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    providerkey = table.Column<string>(
                            name: "provider_key",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    providerdisplayname = table.Column<string>(
                            name: "provider_display_name",
                            type: "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    userid = table.Column<string>(
                            name: "user_id",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_user_login",
                        x => new
                        {
                            x.loginprovider,
                            x.providerkey,
                        }
                    );

                    table.ForeignKey(
                        "fk_asp_net_user_login_asp_net_user_user_id",
                        x => x.userid,
                        "asp_net_user",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "asp_net_user_role",
                table => new
                {
                    userid = table.Column<string>(
                            name: "user_id",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    roleid = table.Column<string>(
                            name: "role_id",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_user_role",
                        x => new
                        {
                            x.userid,
                            x.roleid,
                        }
                    );

                    table.ForeignKey(
                        "fk_asp_net_user_role_asp_net_role_role_id",
                        x => x.roleid,
                        "asp_net_role",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );

                    table.ForeignKey(
                        "fk_asp_net_user_role_asp_net_user_user_id",
                        x => x.userid,
                        "asp_net_user",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "asp_net_user_token",
                table => new
                {
                    userid = table.Column<string>(
                            name: "user_id",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    loginprovider = table.Column<string>(
                            name: "login_provider",
                            type: "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    name = table.Column<string>(
                            "varchar(255)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    value = table.Column<string>(
                            "longtext",
                            nullable: true
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_asp_net_user_token",
                        x => new
                        {
                            x.userid,
                            x.loginprovider,
                            x.name,
                        }
                    );

                    table.ForeignKey(
                        "fk_asp_net_user_token_asp_net_user_user_id",
                        x => x.userid,
                        "asp_net_user",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "group",
                table => new
                {
                    id = table.Column<int>(
                            "int(8)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    descriptionid = table.Column<int>(
                        name: "description_id",
                        type: "int(8)",
                        nullable: false
                    ),
                    name = table.Column<string>(
                            "varchar(256)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_group",
                        x => x.id
                    );

                    table.ForeignKey(
                        "fk_group_base_description_description_id1",
                        x => x.descriptionid,
                        "base_description",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "items_simple_properties",
                table => new
                {
                    id = table.Column<int>(
                            "int(8)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    itemid = table.Column<int>(
                        name: "item_id",
                        type: "int(8)",
                        nullable: false
                    ),
                    simplepropertyid = table.Column<int>(
                        name: "simple_property_id",
                        type: "int(8)",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_items_simple_properties",
                        x => x.id
                    );

                    table.ForeignKey(
                        "fk_items_simple_properties_item_item_id",
                        x => x.itemid,
                        "item",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );

                    table.ForeignKey(
                        "fk_items_simple_properties_simple_property_simple_property_id",
                        x => x.simplepropertyid,
                        "simple_property",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "complex_property",
                table => new
                {
                    id = table.Column<int>(
                            "int(8)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    value = table.Column<string>(
                            "varchar(128)",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:CharSet",
                            "utf8mb4"
                        ),
                    descriptionid = table.Column<int>(
                        name: "description_id",
                        type: "int(8)",
                        nullable: false
                    ),
                    groupid = table.Column<int>(
                        name: "group_id",
                        type: "int(8)",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_complex_property",
                        x => x.id
                    );

                    table.ForeignKey(
                        "fk_complex_property_base_description_description_id1",
                        x => x.descriptionid,
                        "base_description",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );

                    table.ForeignKey(
                        "fk_complex_property_group_group_id",
                        x => x.groupid,
                        "group",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateTable(
                "items_complex_properties",
                table => new
                {
                    id = table.Column<int>(
                            "int",
                            nullable: false
                        )
                        .Annotation(
                            "MySql:ValueGenerationStrategy",
                            MySqlValueGenerationStrategy.IdentityColumn
                        ),
                    itemid = table.Column<int>(
                        name: "item_id",
                        type: "int(8)",
                        nullable: false
                    ),
                    complexpropertyid = table.Column<int>(
                        name: "complex_property_id",
                        type: "int(8)",
                        nullable: false
                    ),
                },
                constraints: table =>
                {
                    table.PrimaryKey(
                        "pk_items_complex_properties",
                        x => x.id
                    );

                    table.ForeignKey(
                        "fk_items_complex_properties_complex_property_complex_property_id",
                        x => x.complexpropertyid,
                        "complex_property",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );

                    table.ForeignKey(
                        "fk_items_complex_properties_item_item_id",
                        x => x.itemid,
                        "item",
                        "id",
                        onDelete: ReferentialAction.Cascade
                    );
                }
            )
            .Annotation(
                "MySql:CharSet",
                "utf8mb4"
            );

        migrationBuilder.CreateIndex(
            "ix_actor_email",
            "actor",
            "email",
            unique: true
        );

        migrationBuilder.CreateIndex(
            "RoleNameIndex",
            "asp_net_role",
            "normalized_name",
            unique: true
        );

        migrationBuilder.CreateIndex(
            "ix_asp_net_role_claim_role_id",
            "asp_net_role_claim",
            "role_id"
        );

        migrationBuilder.CreateIndex(
            "EmailIndex",
            "asp_net_user",
            "normalized_email"
        );

        migrationBuilder.CreateIndex(
            "UserNameIndex",
            "asp_net_user",
            "normalized_user_name",
            unique: true
        );

        migrationBuilder.CreateIndex(
            "ix_asp_net_user_claim_user_id",
            "asp_net_user_claim",
            "user_id"
        );

        migrationBuilder.CreateIndex(
            "ix_asp_net_user_login_user_id",
            "asp_net_user_login",
            "user_id"
        );

        migrationBuilder.CreateIndex(
            "ix_asp_net_user_role_role_id",
            "asp_net_user_role",
            "role_id"
        );

        migrationBuilder.CreateIndex(
            "ix_complex_property_description_id",
            "complex_property",
            "description_id",
            unique: true
        );

        migrationBuilder.CreateIndex(
            "ix_complex_property_group_id",
            "complex_property",
            "group_id",
            unique: true
        );

        migrationBuilder.CreateIndex(
            "ix_complex_property_value",
            "complex_property",
            "value",
            unique: true
        );

        migrationBuilder.CreateIndex(
            "ix_group_description_id",
            "group",
            "description_id",
            unique: true
        );

        migrationBuilder.CreateIndex(
            "ix_item_name",
            "item",
            "name"
        );

        migrationBuilder.CreateIndex(
            "ix_item_user_id",
            "item",
            "user_id"
        );

        migrationBuilder.CreateIndex(
            "ix_items_complex_properties_complex_property_id",
            "items_complex_properties",
            "complex_property_id"
        );

        migrationBuilder.CreateIndex(
            "ix_items_complex_properties_item_id",
            "items_complex_properties",
            "item_id"
        );

        migrationBuilder.CreateIndex(
            "ix_items_simple_properties_item_id",
            "items_simple_properties",
            "item_id"
        );

        migrationBuilder.CreateIndex(
            "ix_items_simple_properties_item_id_simple_property_id",
            "items_simple_properties",
            new[]
            {
                "item_id",
                "simple_property_id",
            },
            unique: true
        );

        migrationBuilder.CreateIndex(
            "ix_items_simple_properties_simple_property_id",
            "items_simple_properties",
            "simple_property_id"
        );

        migrationBuilder.CreateIndex(
            "ix_service_mode_updated_by_id",
            "service_mode",
            "updated_by_id"
        );

        migrationBuilder.CreateIndex(
            "ix_simple_property_value",
            "simple_property",
            "value",
            unique: true
        );
    }

    /// <inheritdoc />
    protected override void Down(
        MigrationBuilder migrationBuilder
    )
    {
        migrationBuilder.DropTable(
            name: "asp_net_role_claim"
        );

        migrationBuilder.DropTable(
            name: "asp_net_user_claim"
        );

        migrationBuilder.DropTable(
            name: "asp_net_user_login"
        );

        migrationBuilder.DropTable(
            name: "asp_net_user_role"
        );

        migrationBuilder.DropTable(
            name: "asp_net_user_token"
        );

        migrationBuilder.DropTable(
            name: "data_protection_keys"
        );

        migrationBuilder.DropTable(
            name: "items_complex_properties"
        );

        migrationBuilder.DropTable(
            name: "items_simple_properties"
        );

        migrationBuilder.DropTable(
            name: "service_mode"
        );

        migrationBuilder.DropTable(
            name: "asp_net_role"
        );

        migrationBuilder.DropTable(
            name: "asp_net_user"
        );

        migrationBuilder.DropTable(
            name: "complex_property"
        );

        migrationBuilder.DropTable(
            name: "item"
        );

        migrationBuilder.DropTable(
            name: "simple_property"
        );

        migrationBuilder.DropTable(
            name: "group"
        );

        migrationBuilder.DropTable(
            name: "actor"
        );

        migrationBuilder.DropTable(
            name: "base_description"
        );
    }
}