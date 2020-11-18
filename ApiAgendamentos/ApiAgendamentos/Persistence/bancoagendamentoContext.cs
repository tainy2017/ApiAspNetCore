using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiAgendamentos.Persistence
{
    public partial class bancoagendamentoContext : DbContext
    {
        public bancoagendamentoContext()
        {
        }

        public bancoagendamentoContext(DbContextOptions<bancoagendamentoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamento { get; set; }
        public virtual DbSet<Agendamentos> Agendamentos { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistory { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<Estabelecimento> Estabelecimento { get; set; }
        public virtual DbSet<Estabelecimentos> Estabelecimentos { get; set; }
        public virtual DbSet<Horario> Horario { get; set; }
        public virtual DbSet<Horarios> Horarios { get; set; }
        public virtual DbSet<Ocorrencia> Ocorrencia { get; set; }
        public virtual DbSet<Ocorrencias> Ocorrencias { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Pessoas> Pessoas { get; set; }
        public virtual DbSet<Servico> Servico { get; set; }
        public virtual DbSet<ServicoFuncionarios> ServicoFuncionarios { get; set; }
        public virtual DbSet<Servicos> Servicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {/*
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=;database=bancoagendamento");*/
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.ToTable("agendamento");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("Id_Cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("Id_Empresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("Id_Funcionario")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Agendamentos>(entity =>
            {
                entity.ToTable("agendamentos");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("IX_Agendamentos_Clienteid");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IX_Agendamentos_id_empresa");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("IX_Agendamentos_Funcionarioid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Hora).HasColumnName("hora");

                entity.Property(e => e.IdCliente)
                    .HasColumnName("id_cliente")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("id_empresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("id_funcionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MeioComunicacao)
                    .HasColumnName("meio_comunicacao")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.AgendamentosIdClienteNavigation)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamentos_Pessoas_Clienteid");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamentos_Empresas_id_empresa");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.AgendamentosIdFuncionarioNavigation)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Agendamentos_Pessoas_Funcionarioid");
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("empresa");

                entity.Property(e => e.Id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.ToTable("empresas");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cnpj)
                    .HasColumnName("cnpj")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estabelecimento>(entity =>
            {
                entity.ToTable("estabelecimento");

                entity.Property(e => e.Id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Estabelecimentos>(entity =>
            {
                entity.ToTable("estabelecimentos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.ToTable("horario");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DiaSemana).HasColumnName("Dia_Semana");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("Id_Empresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("Id_Funcionario")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Horarios>(entity =>
            {
                entity.ToTable("horarios");

                entity.HasIndex(e => e.IdEmpresa)
                    .HasName("IX_Horarios_id_empresa");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("IX_Horarios_id_funcionario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DiaSemana)
                    .HasColumnName("dia_semana")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.Fim).HasColumnName("fim");

                entity.Property(e => e.IdEmpresa)
                    .HasColumnName("id_empresa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("id_funcionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Inicio).HasColumnName("inicio");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Horarios_Empresas_id_empresa");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Horarios_Pessoas_id_funcionario");
            });

            modelBuilder.Entity<Ocorrencia>(entity =>
            {
                entity.ToTable("ocorrencia");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("Id_Funcionario")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Ocorrencias>(entity =>
            {
                entity.ToTable("ocorrencias");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("IX_Ocorrencias_id_funcionario");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Data)
                    .HasColumnName("data")
                    .HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("id_funcionario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Ocorrencias)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("FK_Ocorrencias_Pessoas_id_funcionario");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DataNascimento).HasColumnName("Data_Nascimento");

                entity.Property(e => e.IdEstabelecimento)
                    .HasColumnName("Id_Estabelecimento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("Id_Funcionario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Numero).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Pessoas>(entity =>
            {
                entity.ToTable("pessoas");

                entity.HasIndex(e => e.IdEstabelecimento)
                    .HasName("IX_Pessoas_id_estabelecimento");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bairro)
                    .HasColumnName("bairro")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Cargo)
                    .HasColumnName("cargo")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .HasColumnName("cidade")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasColumnName("complemento")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("cpf")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnName("data_nascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Estado)
                    .HasColumnName("estado")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstabelecimento)
                    .HasColumnName("id_estabelecimento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsFuncionario)
                    .HasColumnName("is_funcionario")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Rua)
                    .HasColumnName("rua")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone1)
                    .HasColumnName("telefone1")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone2)
                    .HasColumnName("telefone2")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstabelecimentoNavigation)
                    .WithMany(p => p.Pessoas)
                    .HasForeignKey(d => d.IdEstabelecimento)
                    .HasConstraintName("FK_Pessoas_Estabeleciomentos_id_estabelecimento");
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.ToTable("servico");

                entity.Property(e => e.Id).HasColumnType("int(11)");
            });

            modelBuilder.Entity<ServicoFuncionarios>(entity =>
            {
                entity.HasKey(e => new { e.IdServico, e.IdFuncionario })
                    .HasName("PRIMARY");

                entity.ToTable("servico_funcionarios");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("IX_Servico_Funcionarios_id_funcionario");

                entity.Property(e => e.IdServico)
                    .HasColumnName("id_servico")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdFuncionario)
                    .HasColumnName("id_funcionario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.ServicoFuncionarios)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servico_Funcionarios_Pessoas_id_funcionario");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.ServicoFuncionarios)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Servico_Funcionarios_Servicos_id_servico");
            });

            modelBuilder.Entity<Servicos>(entity =>
            {
                entity.ToTable("servicos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
