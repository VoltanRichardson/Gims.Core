using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gims.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CoreBaseline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverageTypes",
                columns: table => new
                {
                    CoverageTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverageTypes", x => x.CoverageTypeId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTags",
                columns: table => new
                {
                    DocumentTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTags", x => x.DocumentTagId);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.DocumentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FunctionGroups",
                columns: table => new
                {
                    FunctionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionGroups", x => x.FunctionGroupId);
                });

            migrationBuilder.CreateTable(
                name: "InsureItems",
                columns: table => new
                {
                    InsureItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SumInsured = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Usage = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsureItems", x => x.InsureItemId);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    PartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartyType = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "Policies",
                columns: table => new
                {
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Policies", x => x.PolicyId);
                });

            migrationBuilder.CreateTable(
                name: "RiskGroups",
                columns: table => new
                {
                    RiskGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskGroups", x => x.RiskGroupId);
                });

            migrationBuilder.CreateTable(
                name: "Treaties",
                columns: table => new
                {
                    TreatyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreatyNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Retention = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Participation = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTo = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treaties", x => x.TreatyId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "DocumentTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FunctionTasks",
                columns: table => new
                {
                    FunctionTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Route = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PermissionKey = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FunctionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FunctionTasks", x => x.FunctionTaskId);
                    table.ForeignKey(
                        name: "FK_FunctionTasks_FunctionGroups_FunctionGroupId",
                        column: x => x.FunctionGroupId,
                        principalTable: "FunctionGroups",
                        principalColumn: "FunctionGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    PartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LegalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TradingName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Organizations_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartyIdentifiers",
                columns: table => new
                {
                    IdentifierValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifierType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyIdentifiers", x => new { x.PartyId, x.IdentifierValue });
                    table.ForeignKey(
                        name: "FK_PartyIdentifiers_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PartyId);
                    table.ForeignKey(
                        name: "FK_Persons_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reinsurers",
                columns: table => new
                {
                    ReinsurerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LicenseNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reinsurers", x => x.ReinsurerId);
                    table.ForeignKey(
                        name: "FK_Reinsurers_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsureItemGroups",
                columns: table => new
                {
                    InsureItemGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsureItemGroups", x => x.InsureItemGroupId);
                    table.ForeignKey(
                        name: "FK_InsureItemGroups_Policies_PolicyId",
                        column: x => x.PolicyId,
                        principalTable: "Policies",
                        principalColumn: "PolicyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RiskGroupItemLinks",
                columns: table => new
                {
                    RiskGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsureItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskGroupItemLinks", x => new { x.RiskGroupId, x.InsureItemId });
                    table.ForeignKey(
                        name: "FK_RiskGroupItemLinks_InsureItems_InsureItemId",
                        column: x => x.InsureItemId,
                        principalTable: "InsureItems",
                        principalColumn: "InsureItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RiskGroupItemLinks_RiskGroups_RiskGroupId",
                        column: x => x.RiskGroupId,
                        principalTable: "RiskGroups",
                        principalColumn: "RiskGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReinsuranceAllocations",
                columns: table => new
                {
                    AllocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreatyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CededAmount = table.Column<decimal>(type: "decimal(5,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReinsuranceAllocations", x => x.AllocationId);
                    table.ForeignKey(
                        name: "FK_ReinsuranceAllocations_Treaties_TreatyId",
                        column: x => x.TreatyId,
                        principalTable: "Treaties",
                        principalColumn: "TreatyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTagAssignments",
                columns: table => new
                {
                    DocumentsDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsDocumentTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTagAssignments", x => new { x.DocumentsDocumentId, x.TagsDocumentTagId });
                    table.ForeignKey(
                        name: "FK_DocumentTagAssignments_DocumentTags_TagsDocumentTagId",
                        column: x => x.TagsDocumentTagId,
                        principalTable: "DocumentTags",
                        principalColumn: "DocumentTagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DocumentTagAssignments_Documents_DocumentsDocumentId",
                        column: x => x.DocumentsDocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentVersions",
                columns: table => new
                {
                    DocumentVersionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    StoragePath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentVersions", x => x.DocumentVersionId);
                    table.ForeignKey(
                        name: "FK_DocumentVersions_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "DocumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreatyReinsurers",
                columns: table => new
                {
                    TreatyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReinsurerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Share = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    IsLead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatyReinsurers", x => new { x.TreatyId, x.ReinsurerId });
                    table.ForeignKey(
                        name: "FK_TreatyReinsurers_Reinsurers_ReinsurerId",
                        column: x => x.ReinsurerId,
                        principalTable: "Reinsurers",
                        principalColumn: "ReinsurerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreatyReinsurers_Treaties_TreatyId",
                        column: x => x.TreatyId,
                        principalTable: "Treaties",
                        principalColumn: "TreatyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsureItemGroupLinks",
                columns: table => new
                {
                    InsureItemGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsureItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsureItemGroupLinks", x => new { x.InsureItemGroupId, x.InsureItemId });
                    table.ForeignKey(
                        name: "FK_InsureItemGroupLinks_InsureItemGroups_InsureItemGroupId",
                        column: x => x.InsureItemGroupId,
                        principalTable: "InsureItemGroups",
                        principalColumn: "InsureItemGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InsureItemGroupLinks_InsureItems_InsureItemId",
                        column: x => x.InsureItemId,
                        principalTable: "InsureItems",
                        principalColumn: "InsureItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTagAssignments_TagsDocumentTagId",
                table: "DocumentTagAssignments",
                column: "TagsDocumentTagId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentVersions_DocumentId",
                table: "DocumentVersions",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_FunctionTasks_FunctionGroupId",
                table: "FunctionTasks",
                column: "FunctionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_InsureItemGroupLinks_InsureItemId",
                table: "InsureItemGroupLinks",
                column: "InsureItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InsureItemGroups_PolicyId",
                table: "InsureItemGroups",
                column: "PolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_ReinsuranceAllocations_TreatyId",
                table: "ReinsuranceAllocations",
                column: "TreatyId");

            migrationBuilder.CreateIndex(
                name: "IX_Reinsurers_PartyId",
                table: "Reinsurers",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskGroupItemLinks_InsureItemId",
                table: "RiskGroupItemLinks",
                column: "InsureItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TreatyReinsurers_ReinsurerId",
                table: "TreatyReinsurers",
                column: "ReinsurerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoverageTypes");

            migrationBuilder.DropTable(
                name: "DocumentTagAssignments");

            migrationBuilder.DropTable(
                name: "DocumentVersions");

            migrationBuilder.DropTable(
                name: "FunctionTasks");

            migrationBuilder.DropTable(
                name: "InsureItemGroupLinks");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "PartyIdentifiers");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "ReinsuranceAllocations");

            migrationBuilder.DropTable(
                name: "RiskGroupItemLinks");

            migrationBuilder.DropTable(
                name: "TreatyReinsurers");

            migrationBuilder.DropTable(
                name: "DocumentTags");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "FunctionGroups");

            migrationBuilder.DropTable(
                name: "InsureItemGroups");

            migrationBuilder.DropTable(
                name: "InsureItems");

            migrationBuilder.DropTable(
                name: "RiskGroups");

            migrationBuilder.DropTable(
                name: "Reinsurers");

            migrationBuilder.DropTable(
                name: "Treaties");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Policies");

            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}
