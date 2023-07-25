using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    Id_area = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.Id_area);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "arl",
                columns: table => new
                {
                    Id_arl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_arl", x => x.Id_arl);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoria",
                columns: table => new
                {
                    Id_categoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria", x => x.Id_categoria);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "componente",
                columns: table => new
                {
                    id_componente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_componente", x => x.id_componente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "eps",
                columns: table => new
                {
                    Id_arl = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eps", x => x.Id_arl);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "equipo",
                columns: table => new
                {
                    Id_equipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipo", x => x.Id_equipo);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "jornada",
                columns: table => new
                {
                    Id_jornada = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jornada", x => x.Id_jornada);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "salon",
                columns: table => new
                {
                    Id_salon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salon", x => x.Id_salon);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_documento",
                columns: table => new
                {
                    Id_tipo_documento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_documento", x => x.Id_tipo_documento);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "tipo_insidencia",
                columns: table => new
                {
                    Id_tipo_insidente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_insidencia", x => x.Id_tipo_insidente);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lugar",
                columns: table => new
                {
                    Id_lugar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_area = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lugar", x => x.Id_lugar);
                    table.ForeignKey(
                        name: "FK_lugar_area_Id_area",
                        column: x => x.Id_area,
                        principalTable: "area",
                        principalColumn: "Id_area",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "trainer",
                columns: table => new
                {
                    Id_trainer = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_arl = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainer", x => x.Id_trainer);
                    table.ForeignKey(
                        name: "FK_trainer_arl_Id_arl",
                        column: x => x.Id_arl,
                        principalTable: "arl",
                        principalColumn: "Id_arl",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "camper",
                columns: table => new
                {
                    Id_camper = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_eps = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camper", x => x.Id_camper);
                    table.ForeignKey(
                        name: "FK_camper_eps_Id_eps",
                        column: x => x.Id_eps,
                        principalTable: "eps",
                        principalColumn: "Id_arl",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "equipo_componente",
                columns: table => new
                {
                    Id_equipo_componente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_equipo = table.Column<int>(type: "int", nullable: false),
                    id_componente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipo_componente", x => x.Id_equipo_componente);
                    table.ForeignKey(
                        name: "FK_equipo_componente_componente_id_componente",
                        column: x => x.id_componente,
                        principalTable: "componente",
                        principalColumn: "id_componente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipo_componente_equipo_Id_equipo",
                        column: x => x.Id_equipo,
                        principalTable: "equipo",
                        principalColumn: "Id_equipo",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "persona",
                columns: table => new
                {
                    Id_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_tipo_documento = table.Column<int>(type: "int", nullable: false),
                    Numero_documento = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Id_salon = table.Column<int>(type: "int", nullable: false),
                    Id_jornada = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persona", x => x.Id_persona);
                    table.ForeignKey(
                        name: "FK_persona_jornada_Id_jornada",
                        column: x => x.Id_jornada,
                        principalTable: "jornada",
                        principalColumn: "Id_jornada",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_salon_Id_salon",
                        column: x => x.Id_salon,
                        principalTable: "salon",
                        principalColumn: "Id_salon",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_persona_tipo_documento_Id_tipo_documento",
                        column: x => x.Id_tipo_documento,
                        principalTable: "tipo_documento",
                        principalColumn: "Id_tipo_documento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "equipo_lugar",
                columns: table => new
                {
                    Id_equipo_lugar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_equipo = table.Column<int>(type: "int", nullable: false),
                    Id_lugar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_equipo_lugar", x => x.Id_equipo_lugar);
                    table.ForeignKey(
                        name: "FK_equipo_lugar_equipo_Id_equipo",
                        column: x => x.Id_equipo,
                        principalTable: "equipo",
                        principalColumn: "Id_equipo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_equipo_lugar_lugar_Id_lugar",
                        column: x => x.Id_lugar,
                        principalTable: "lugar",
                        principalColumn: "Id_lugar",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "camper_persona",
                columns: table => new
                {
                    Id_camper_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_camper = table.Column<int>(type: "int", nullable: false),
                    Id_persona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_camper_persona", x => x.Id_camper_persona);
                    table.ForeignKey(
                        name: "FK_camper_persona_camper_Id_camper",
                        column: x => x.Id_camper,
                        principalTable: "camper",
                        principalColumn: "Id_camper",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_camper_persona_persona_Id_persona",
                        column: x => x.Id_persona,
                        principalTable: "persona",
                        principalColumn: "Id_persona",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "insidente",
                columns: table => new
                {
                    Id_insidente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_persona = table.Column<int>(type: "int", nullable: false),
                    Id_categoria = table.Column<int>(type: "int", nullable: false),
                    Id_tipo_insidencia = table.Column<int>(type: "int", nullable: false),
                    Id_area = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insidente", x => x.Id_insidente);
                    table.ForeignKey(
                        name: "FK_insidente_area_Id_area",
                        column: x => x.Id_area,
                        principalTable: "area",
                        principalColumn: "Id_area",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insidente_categoria_Id_categoria",
                        column: x => x.Id_categoria,
                        principalTable: "categoria",
                        principalColumn: "Id_categoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insidente_persona_Id_persona",
                        column: x => x.Id_persona,
                        principalTable: "persona",
                        principalColumn: "Id_persona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insidente_tipo_insidencia_Id_tipo_insidencia",
                        column: x => x.Id_tipo_insidencia,
                        principalTable: "tipo_insidencia",
                        principalColumn: "Id_tipo_insidente",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "trainer_persona",
                columns: table => new
                {
                    Id_trainer_persona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Id_trainer = table.Column<int>(type: "int", nullable: false),
                    Id_persona = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainer_persona", x => x.Id_trainer_persona);
                    table.ForeignKey(
                        name: "FK_trainer_persona_persona_Id_persona",
                        column: x => x.Id_persona,
                        principalTable: "persona",
                        principalColumn: "Id_persona",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trainer_persona_trainer_Id_trainer",
                        column: x => x.Id_trainer,
                        principalTable: "trainer",
                        principalColumn: "Id_trainer",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_camper_Id_eps",
                table: "camper",
                column: "Id_eps");

            migrationBuilder.CreateIndex(
                name: "IX_camper_persona_Id_camper",
                table: "camper_persona",
                column: "Id_camper");

            migrationBuilder.CreateIndex(
                name: "IX_camper_persona_Id_persona",
                table: "camper_persona",
                column: "Id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_equipo_componente_id_componente",
                table: "equipo_componente",
                column: "id_componente");

            migrationBuilder.CreateIndex(
                name: "IX_equipo_componente_Id_equipo",
                table: "equipo_componente",
                column: "Id_equipo");

            migrationBuilder.CreateIndex(
                name: "IX_equipo_lugar_Id_equipo",
                table: "equipo_lugar",
                column: "Id_equipo");

            migrationBuilder.CreateIndex(
                name: "IX_equipo_lugar_Id_lugar",
                table: "equipo_lugar",
                column: "Id_lugar");

            migrationBuilder.CreateIndex(
                name: "IX_insidente_Id_area",
                table: "insidente",
                column: "Id_area");

            migrationBuilder.CreateIndex(
                name: "IX_insidente_Id_categoria",
                table: "insidente",
                column: "Id_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_insidente_Id_persona",
                table: "insidente",
                column: "Id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_insidente_Id_tipo_insidencia",
                table: "insidente",
                column: "Id_tipo_insidencia");

            migrationBuilder.CreateIndex(
                name: "IX_lugar_Id_area",
                table: "lugar",
                column: "Id_area");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_jornada",
                table: "persona",
                column: "Id_jornada");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_salon",
                table: "persona",
                column: "Id_salon");

            migrationBuilder.CreateIndex(
                name: "IX_persona_Id_tipo_documento",
                table: "persona",
                column: "Id_tipo_documento");

            migrationBuilder.CreateIndex(
                name: "IX_trainer_Id_arl",
                table: "trainer",
                column: "Id_arl");

            migrationBuilder.CreateIndex(
                name: "IX_trainer_persona_Id_persona",
                table: "trainer_persona",
                column: "Id_persona");

            migrationBuilder.CreateIndex(
                name: "IX_trainer_persona_Id_trainer",
                table: "trainer_persona",
                column: "Id_trainer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "camper_persona");

            migrationBuilder.DropTable(
                name: "equipo_componente");

            migrationBuilder.DropTable(
                name: "equipo_lugar");

            migrationBuilder.DropTable(
                name: "insidente");

            migrationBuilder.DropTable(
                name: "trainer_persona");

            migrationBuilder.DropTable(
                name: "camper");

            migrationBuilder.DropTable(
                name: "componente");

            migrationBuilder.DropTable(
                name: "equipo");

            migrationBuilder.DropTable(
                name: "lugar");

            migrationBuilder.DropTable(
                name: "categoria");

            migrationBuilder.DropTable(
                name: "tipo_insidencia");

            migrationBuilder.DropTable(
                name: "persona");

            migrationBuilder.DropTable(
                name: "trainer");

            migrationBuilder.DropTable(
                name: "eps");

            migrationBuilder.DropTable(
                name: "area");

            migrationBuilder.DropTable(
                name: "jornada");

            migrationBuilder.DropTable(
                name: "salon");

            migrationBuilder.DropTable(
                name: "tipo_documento");

            migrationBuilder.DropTable(
                name: "arl");
        }
    }
}
