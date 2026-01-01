using Microsoft.EntityFrameworkCore.Migrations;

namespace Fepa.Infrastructure.Migrations
{
    /*
    public partial class EnhanceAuthService : Migration
    {
        // protected override void Up(MigrationBuilder migrationBuilder)
        // {
        //     // Add new columns to Users table
        //     migrationBuilder.AddColumn<bool>(
        //         name: "IsEmailVerified",
        //         table: "Users",
        //         type: "boolean",
        //         nullable: false,
        //         defaultValue: false);

        //     migrationBuilder.AddColumn<DateTime>(
        //         name: "EmailVerifiedAt",
        //         table: "Users",
        //         type: "timestamp with time zone",
        //         nullable: true);

        //     migrationBuilder.AddColumn<bool>(
        //         name: "IsTwoFactorEnabled",
        //         table: "Users",
        //         type: "boolean",
        //         nullable: false,
        //         defaultValue: false);

        //     migrationBuilder.AddColumn<string>(
        //         name: "TwoFactorSecret",
        //         table: "Users",
        //         type: "text",
        //         nullable: true);

        //     migrationBuilder.AddColumn<string>(
        //         name: "PhoneNumber",
        //         table: "Users",
        //         type: "character varying(20)",
        //         nullable: true);

        //     migrationBuilder.AddColumn<bool>(
        //         name: "IsPhoneVerified",
        //         table: "Users",
        //         type: "boolean",
        //         nullable: false,
        //         defaultValue: false);

        //     migrationBuilder.AddColumn<string>(
        //         name: "GoogleId",
        //         table: "Users",
        //         type: "text",
        //         nullable: true);

        //     migrationBuilder.AddColumn<string>(
        //         name: "FacebookId",
        //         table: "Users",
        //         type: "text",
        //         nullable: true);

        //     migrationBuilder.AddColumn<DateTime>(
        //         name: "LastLoginAt",
        //         table: "Users",
        //         type: "timestamp with time zone",
        //         nullable: true);

        //     migrationBuilder.AddColumn<DateTime>(
        //         name: "PasswordChangedAt",
        //         table: "Users",
        //         type: "timestamp with time zone",
        //         nullable: true);

        //     migrationBuilder.AddColumn<bool>(
        //         name: "IsActive",
        //         table: "Users",
        //         type: "boolean",
        //         nullable: false,
        //         defaultValue: true);

        //     migrationBuilder.AddColumn<DateTime>(
        //         name: "DeactivatedAt",
        //         table: "Users",
        //         type: "timestamp with time zone",
        //         nullable: true);

        //     // Create RefreshTokens table
        //     migrationBuilder.CreateTable(
        //         name: "RefreshTokens",
        //         columns: table => new
        //         {
        //             Id = table.Column<Guid>(type: "uuid", nullable: false),
        //             UserId = table.Column<Guid>(type: "uuid", nullable: false),
        //             Token = table.Column<string>(type: "text", nullable: false),
        //             RefreshTokenValue = table.Column<string>(type: "text", nullable: true),
        //             ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        //             CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        //             RevokedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_RefreshTokens", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_RefreshTokens_Users_UserId",
        //                 column: x => x.UserId,
        //                 principalTable: "Users",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });

        //     // Create VerificationTokens table
        //     migrationBuilder.CreateTable(
        //         name: "VerificationTokens",
        //         columns: table => new
        //         {
        //             Id = table.Column<Guid>(type: "uuid", nullable: false),
        //             UserId = table.Column<Guid>(type: "uuid", nullable: false),
        //             Token = table.Column<string>(type: "text", nullable: false),
        //             Type = table.Column<string>(type: "character varying(50)", nullable: false),
        //             ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        //             CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
        //             UsedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_VerificationTokens", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_VerificationTokens_Users_UserId",
        //                 column: x => x.UserId,
        //                 principalTable: "Users",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });

        //     // Add indexes for performance
        //     migrationBuilder.CreateIndex(
        //         name: "IX_RefreshTokens_UserId",
        //         table: "RefreshTokens",
        //         column: "UserId");

        //     migrationBuilder.CreateIndex(
        //         name: "IX_RefreshTokens_Token",
        //         table: "RefreshTokens",
        //         column: "Token",
        //         unique: true);

        //     migrationBuilder.CreateIndex(
        //         name: "IX_VerificationTokens_UserId",
        //         table: "VerificationTokens",
        //         column: "UserId");

        //     migrationBuilder.CreateIndex(
        //         name: "IX_VerificationTokens_Token",
        //         table: "VerificationTokens",
        //         column: "Token",
        //         unique: true);

        //     migrationBuilder.CreateIndex(
        //         name: "IX_Users_GoogleId",
        //         table: "Users",
        //         column: "GoogleId",
        //         unique: true);

        //     migrationBuilder.CreateIndex(
        //         name: "IX_Users_FacebookId",
        //         table: "Users",
        //         column: "FacebookId",
        //         unique: true);
        // }

        // protected override void Down(MigrationBuilder migrationBuilder)
        // {
        //     migrationBuilder.DropTable(name: "RefreshTokens");
        //     migrationBuilder.DropTable(name: "VerificationTokens");
        //     migrationBuilder.DropColumn(name: "IsEmailVerified", table: "Users");
        //     migrationBuilder.DropColumn(name: "EmailVerifiedAt", table: "Users");
        //     // ... drop other columns added in Up()
        // }
    }
    */
}
        // - ExpiresAt (DateTime)
        // - CreatedAt (DateTime)
        // - RevokedAt (DateTime?)

        // Migration: CreateVerificationTokenTable
        // - Id (Guid, PK)
        // - UserId (Guid, FK)
        // - Token (string)
        // - Type (string) - EmailVerification, PasswordReset, PhoneVerification
        // - ExpiresAt (DateTime)
        // - CreatedAt (DateTime)
        // - UsedAt (DateTime?)
    }
}
