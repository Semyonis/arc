#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace Arc.Database.Migrations.Migrations._2023;

/// <inheritdoc />
public partial class InitActors : Migration
{
    /// <inheritdoc />
    protected override void Up(
        MigrationBuilder migrationBuilder
    )
    {
        migrationBuilder
            .Sql(
                """
                insert into asp_net_role (id, name, normalized_name)
                values ('admin','Admin','admin'),
                       ('user','User','user');

                insert into asp_net_user(id, user_name, normalized_user_name, email, normalized_email, password_hash, security_stamp, concurrency_stamp,email_confirmed,phone_number_confirmed, two_factor_enabled, lockout_end, lockout_enabled, access_failed_count)
                values ('first_user','user@domain.com','user@domain.com','user@domain.com','user@domain.com','AQAAAAEAACcQAAAAEGyQG3jnaW0zbFnb2t9iJXkF+8fKcxMD8rs7846WsAQ3TKwffnCNzsrDD/Fvx52+Ow==','RUOAHR4WTP6GXUVNZI5LW6AZGZU4BM22','f740e66d-b985-44dc-9640-8a497172198e',1,0,0,'1970-01-01 00:00:00.000000',0,0),
                       ('first_admin','admin@domain.com','admin@domain.com','admin@domain.com','admin@domain.com','AQAAAAEAACcQAAAAEGyQG3jnaW0zbFnb2t9iJXkF+8fKcxMD8rs7846WsAQ3TKwffnCNzsrDD/Fvx52+Ow==','RUOAHR4WTP6GXUVNZI5LW6AZGZU4BM22','f740e66d-b985-44dc-9640-8a497172198e',1,0,0,'1970-01-01 00:00:00.000000',0,0);

                insert into asp_net_user_role(user_id, role_id)
                values ('first_user','user'),
                       ('first_admin','admin');

                insert into actor(id, discriminator, email, first_name, last_name)
                values (1,'Admin', 'admin@domain.com','First','Last'),
                       (2,'User', 'user@domain.com','First','Last');
                """
            );
    }
}