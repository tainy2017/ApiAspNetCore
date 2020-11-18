using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ApiAgendamentos.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicoId",
                table: "Pessoa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaId",
                table: "Ocorrencia",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Agendamento",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EstabelecimentosPessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    EstabelecimentoId = table.Column<int>(nullable: true),
                    PessoaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstabelecimentosPessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstabelecimentosPessoas_Estabelecimento_EstabelecimentoId",
                        column: x => x.EstabelecimentoId,
                        principalTable: "Estabelecimento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstabelecimentosPessoas_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorarioEmpresas",
                columns: table => new
                {
                    IdHorario = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdEmpresa = table.Column<int>(nullable: false),
                    IdHorarioNavigationId = table.Column<int>(nullable: true),
                    IdEmpresaNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioEmpresas", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_HorarioEmpresas_Empresa_IdEmpresaNavigationId",
                        column: x => x.IdEmpresaNavigationId,
                        principalTable: "Empresa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioEmpresas_Horario_IdHorarioNavigationId",
                        column: x => x.IdHorarioNavigationId,
                        principalTable: "Horario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorarioPessoas",
                columns: table => new
                {
                    IdHorario = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPessoa = table.Column<int>(nullable: false),
                    IdHorarioNavigationId = table.Column<int>(nullable: true),
                    IdPessoaNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioPessoas", x => x.IdHorario);
                    table.ForeignKey(
                        name: "FK_HorarioPessoas_Horario_IdHorarioNavigationId",
                        column: x => x.IdHorarioNavigationId,
                        principalTable: "Horario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorarioPessoas_Pessoa_IdPessoaNavigationId",
                        column: x => x.IdPessoaNavigationId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServicoFuncionarios",
                columns: table => new
                {
                    IdServico = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdPessoa_IdFuncionario = table.Column<int>(nullable: false),
                    IdPessoaNavigationId = table.Column<int>(nullable: true),
                    ServicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicoFuncionarios", x => x.IdServico);
                    table.ForeignKey(
                        name: "FK_ServicoFuncionarios_Pessoa_IdPessoaNavigationId",
                        column: x => x.IdPessoaNavigationId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicoFuncionarios_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_ServicoId",
                table: "Pessoa",
                column: "ServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencia_PessoaId",
                table: "Ocorrencia",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_EmpresaId",
                table: "Agendamento",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentosPessoas_EstabelecimentoId",
                table: "EstabelecimentosPessoas",
                column: "EstabelecimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_EstabelecimentosPessoas_PessoaId",
                table: "EstabelecimentosPessoas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioEmpresas_IdEmpresaNavigationId",
                table: "HorarioEmpresas",
                column: "IdEmpresaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioEmpresas_IdHorarioNavigationId",
                table: "HorarioEmpresas",
                column: "IdHorarioNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioPessoas_IdHorarioNavigationId",
                table: "HorarioPessoas",
                column: "IdHorarioNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioPessoas_IdPessoaNavigationId",
                table: "HorarioPessoas",
                column: "IdPessoaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoFuncionarios_IdPessoaNavigationId",
                table: "ServicoFuncionarios",
                column: "IdPessoaNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicoFuncionarios_ServicoId",
                table: "ServicoFuncionarios",
                column: "ServicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Empresa_EmpresaId",
                table: "Agendamento",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencia_Pessoa_PessoaId",
                table: "Ocorrencia",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Servico_ServicoId",
                table: "Pessoa",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Empresa_EmpresaId",
                table: "Agendamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencia_Pessoa_PessoaId",
                table: "Ocorrencia");

            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Servico_ServicoId",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "EstabelecimentosPessoas");

            migrationBuilder.DropTable(
                name: "HorarioEmpresas");

            migrationBuilder.DropTable(
                name: "HorarioPessoas");

            migrationBuilder.DropTable(
                name: "ServicoFuncionarios");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_ServicoId",
                table: "Pessoa");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencia_PessoaId",
                table: "Ocorrencia");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_EmpresaId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "ServicoId",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "PessoaId",
                table: "Ocorrencia");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Agendamento");
        }
    }
}
