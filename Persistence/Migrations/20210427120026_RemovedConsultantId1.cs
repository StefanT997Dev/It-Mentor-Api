﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RemovedConsultantId1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ConsultantId1",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ConsultantId1",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ConsultantId1",
                table: "Reviews");

            migrationBuilder.AlterColumn<string>(
                name: "ConsultantId",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "ConsultantId",
                table: "Posts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ConsultantId",
                table: "Reviews",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ConsultantId",
                table: "Posts",
                column: "ConsultantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AspNetUsers_ConsultantId",
                table: "Posts",
                column: "ConsultantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ConsultantId",
                table: "Reviews",
                column: "ConsultantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AspNetUsers_ConsultantId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_AspNetUsers_ConsultantId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_ConsultantId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Posts_ConsultantId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ConsultantId",
                table: "Posts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultantId",
                table: "Reviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsultantId1",
                table: "Reviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ConsultantId1",
                table: "Reviews",
                column: "ConsultantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_AspNetUsers_ConsultantId1",
                table: "Reviews",
                column: "ConsultantId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}