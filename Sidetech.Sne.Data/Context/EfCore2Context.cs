using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sidetech.Sne.Domain.Entities;
using System.IO;

namespace Sidetech.Sne.Data.Context
{
    public class EfCore2Context : DbContext
    {
        #region "Conexão com o Banco de Dados"

        public IConfigurationRoot Configuration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(RetornaUrlConection());
        }

        private string RetornaUrlConection()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            string conexao = Configuration.GetConnectionString("DefaultConnectionString");
            return conexao;
        }

        #endregion

        #region Mapeamento do Banco de Dados

        public virtual DbSet<AcuidadeVisual> AcuidadeVisual { get; set; }
        public virtual DbSet<Beneficiario> Beneficiario { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<CategoriaHabilitacao> CategoriaHabilitacao { get; set; }
        public virtual DbSet<Colesterol> Colesterol { get; set; }
        public virtual DbSet<Empregador> Empregador { get; set; }
        public virtual DbSet<Escolaridade> Escolaridade { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<EventoBeneficiario> EventoBeneficiario { get; set; }
        public virtual DbSet<EventoParceiroDao> EventoParceiro { get; set; }
        public virtual DbSet<EventoParticipanteDao> EventoParticipante { get; set; }
        public virtual DbSet<EventoProcedimento> EventoProcedimento { get; set; }
        public virtual DbSet<EventoProcedimentoVacinaDao> EventoProcedimentoVacina { get; set; }
        public virtual DbSet<Glicemia> Glicemia { get; set; }
        public virtual DbSet<HistoricoSenha> HistoricoSenha { get; set; }
        public virtual DbSet<Imc> Imc { get; set; }
        public virtual DbSet<LogImportacaoBalanca> LogImportacaoBalanca { get; set; }
        public virtual DbSet<Municipio> Municipio { get; set; }
        public virtual DbSet<ParametroAcuidadeVisual> ParametroAcuidadeVisual { get; set; }
        public virtual DbSet<ParametroGlicemia> ParametroGlicemia { get; set; }
        public virtual DbSet<ParametroGorduraAbdominal> ParametroGorduraAbdominal { get; set; }
        public virtual DbSet<ParametroImc> ParametroImc { get; set; }
        public virtual DbSet<ParametroPressaoArterial> ParametroPressaoArterial { get; set; }
        public virtual DbSet<ParametroTipagemSanguinea> ParametroTipagemSanguinea { get; set; }
        public virtual DbSet<Parceiro> Parceiro { get; set; }
        public virtual DbSet<Participante> Participante { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Preferencia> Preferencia { get; set; }
        public virtual DbSet<PressaoArterial> PressaoArterial { get; set; }
        public virtual DbSet<Procedimento> Procedimento { get; set; }
        public virtual DbSet<TipagemSanguinea> TipagemSanguinea { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vacina> Vacina { get; set; }
        public virtual DbSet<Vacinacao> Vacinacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcuidadeVisual>(entity =>
            {
                entity.HasKey(e => new { e.IdEventoBeneficiario, e.IdEventoProcedimento });

                entity.ToTable("AcuidadeVisual", "Ipiranga");

                entity.HasOne(d => d.IdEventoBeneficiarioNavigation)
                    .WithMany(p => p.AcuidadeVisual)
                    .HasForeignKey(d => d.IdEventoBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcuidadeVisual_EventoBeneficiario");

                entity.HasOne(d => d.IdEventoProcedimentoNavigation)
                    .WithMany(p => p.AcuidadeVisual)
                    .HasForeignKey(d => d.IdEventoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AcuidadeVisual_EventoProcedimento");
            });

            modelBuilder.Entity<Beneficiario>(entity =>
            {
                entity.ToTable("Beneficiario", "Ipiranga");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Beneficiario)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Beneficiario_Categoria");

                entity.HasOne(d => d.IdEmpregadorNavigation)
                    .WithMany(p => p.Beneficiario)
                    .HasForeignKey(d => d.IdEmpregador)
                    .HasConstraintName("FK_Beneficiario_Empregador");

                entity.HasOne(d => d.IdEscolaridadeNavigation)
                    .WithMany(p => p.Beneficiario)
                    .HasForeignKey(d => d.IdEscolaridade)
                    .HasConstraintName("FK_Beneficiario_Escolaridade");

                entity.HasOne(d => d.IdHabilitacaoNavigation)
                    .WithMany(p => p.Beneficiario)
                    .HasForeignKey(d => d.IdHabilitacao)
                    .HasConstraintName("FK_Beneficiario_CategoriaHabilitacao");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Beneficiario)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_Beneficiario_Municipio");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.ToTable("Categoria", "Ipiranga");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CategoriaHabilitacao>(entity =>
            {
                entity.ToTable("CategoriaHabilitacao", "Ipiranga");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(700)
                    .IsUnicode(false);

                entity.Property(e => e.SiglaCategoria)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Colesterol>(entity =>
            {
                entity.HasKey(e => new { e.IdEventoBeneficiario, e.IdEventoProcedimento });

                entity.ToTable("Colesterol", "Ipiranga");

                entity.HasOne(d => d.IdEventoBeneficiarioNavigation)
                    .WithMany(p => p.Colesterol)
                    .HasForeignKey(d => d.IdEventoBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colesterol_EventoBeneficiario");

                entity.HasOne(d => d.IdEventoProcedimentoNavigation)
                    .WithMany(p => p.Colesterol)
                    .HasForeignKey(d => d.IdEventoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Colesterol_EventoProcedimento");
            });

            modelBuilder.Entity<Empregador>(entity =>
            {
                entity.ToTable("Empregador", "Ipiranga");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Tipo).HasColumnType("char(1)");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Empregador)
                    .HasForeignKey(d => d.IdMunicipio)
                    .HasConstraintName("FK_Empregador_Municipio");
            });

            modelBuilder.Entity<Escolaridade>(entity =>
            {
                entity.ToTable("Escolaridade", "Ipiranga");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.ToTable("Estado", "Ipiranga");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasColumnType("char(2)");
            });

            modelBuilder.Entity<Evento>(entity =>
            {
                entity.ToTable("Evento", "Ipiranga");

                entity.Property(e => e.Cnpj)
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Local)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao).HasColumnType("text");

                entity.HasOne(d => d.IdMunicipioNavigation)
                    .WithMany(p => p.Evento)
                    .HasForeignKey(d => d.IdMunicipio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Evento_Municipio");
            });

            modelBuilder.Entity<EventoBeneficiario>(entity =>
            {
                entity.ToTable("EventoBeneficiario", "Ipiranga");

                entity.HasOne(d => d.IdBeneficiarioNavigation)
                    .WithMany(p => p.EventoBeneficiario)
                    .HasForeignKey(d => d.IdBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoBeneficiario_Beneficiario");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.EventoBeneficiario)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoBeneficiario_Evento");
            });

            modelBuilder.Entity<EventoParceiroDao>(entity =>
            {
                entity.HasKey(e => new { e.IdEvento, e.IdParceiro });

                entity.ToTable("EventoParceiro", "Ipiranga");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.EventoParceiro)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoParceiro_Evento");

                entity.HasOne(d => d.IdParceiroNavigation)
                    .WithMany(p => p.EventoParceiro)
                    .HasForeignKey(d => d.IdParceiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoParceiro_Parceiro");
            });

            modelBuilder.Entity<EventoParticipanteDao>(entity =>
            {
                entity.HasKey(e => new { e.IdEvento, e.IdParticipante });

                entity.ToTable("EventoParticipante", "Ipiranga");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.EventoParticipante)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoParticipante_Evento");

                entity.HasOne(d => d.IdParticipanteNavigation)
                    .WithMany(p => p.EventoParticipante)
                    .HasForeignKey(d => d.IdParticipante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoParticipante_Participante");
            });

            modelBuilder.Entity<EventoProcedimento>(entity =>
            {
                entity.ToTable("EventoProcedimento", "Ipiranga");

                entity.HasOne(d => d.IdEventoNavigation)
                    .WithMany(p => p.EventoProcedimento)
                    .HasForeignKey(d => d.IdEvento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoProcedimento_Evento");

                entity.HasOne(d => d.IdProcedimentoNavigation)
                    .WithMany(p => p.EventoProcedimento)
                    .HasForeignKey(d => d.IdProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoProcedimento_Procedimento");
            });

            modelBuilder.Entity<EventoProcedimentoVacinaDao>(entity =>
            {
                entity.HasKey(e => new { e.IdEventoProcedimento, e.IdVacina });

                entity.ToTable("EventoProcedimentoVacina", "Ipiranga");

                entity.HasOne(d => d.IdEventoProcedimentoNavigation)
                    .WithMany(p => p.EventoProcedimentoVacina)
                    .HasForeignKey(d => d.IdEventoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoProcedimentoVacina_EventoProcedimento");

                entity.HasOne(d => d.IdVacinaNavigation)
                    .WithMany(p => p.EventoProcedimentoVacina)
                    .HasForeignKey(d => d.IdVacina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventoProcedimentoVacina_Vacina");
            });

            modelBuilder.Entity<Glicemia>(entity =>
            {
                entity.HasKey(e => new { e.IdEventoBeneficiario, e.IdEventoProcedimento });

                entity.ToTable("Glicemia", "Ipiranga");

                entity.Property(e => e.Glicemia1).HasColumnName("Glicemia");

                entity.HasOne(d => d.IdEventoBeneficiarioNavigation)
                    .WithMany(p => p.Glicemia)
                    .HasForeignKey(d => d.IdEventoBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Glicemia_EventoBeneficiario");

                entity.HasOne(d => d.IdEventoProcedimentoNavigation)
                    .WithMany(p => p.Glicemia)
                    .HasForeignKey(d => d.IdEventoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Glicemia_EventoProcedimento");
            });

            modelBuilder.Entity<HistoricoSenha>(entity =>
            {
                entity.HasKey(e => new { e.IdUsuario, e.Data, e.Senha });

                entity.ToTable("HistoricoSenha", "Seguranca");

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.HistoricoSenha)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoricoSenha_Usuario");
            });

            modelBuilder.Entity<Imc>(entity =>
            {
                entity.HasKey(e => new { e.IdEventoBeneficiario, e.IdEventoProcedimento });

                entity.ToTable("Imc", "Ipiranga");

                entity.Property(e => e.GrauObesidadeAbdominal).HasColumnType("numeric(4, 2)");

                entity.Property(e => e.Imc1)
                    .HasColumnName("Imc")
                    .HasColumnType("numeric(5, 2)");

                entity.Property(e => e.Peso).HasColumnType("numeric(6, 3)");

                entity.Property(e => e.TaxaMetabolismoBasal).HasColumnType("numeric(6, 2)");

                entity.Property(e => e.TotalAguaCorporal).HasColumnType("numeric(5, 2)");

                entity.HasOne(d => d.IdEventoBeneficiarioNavigation)
                    .WithMany(p => p.Imc)
                    .HasForeignKey(d => d.IdEventoBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Imc_EventoBeneficiario");

                entity.HasOne(d => d.IdEventoProcedimentoNavigation)
                    .WithMany(p => p.Imc)
                    .HasForeignKey(d => d.IdEventoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Imc_EventoProcedimento");
            });

            modelBuilder.Entity<LogImportacaoBalanca>(entity =>
            {
                entity.ToTable("LogImportacaoBalanca", "Ipiranga");

                entity.Property(e => e.DataGeracao).HasColumnType("datetime");

                entity.Property(e => e.NomeArquivo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeLog)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Municipio>(entity =>
            {
                entity.ToTable("Municipio", "Ipiranga");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Municipio)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Municipio_Estado");
            });

            modelBuilder.Entity<ParametroAcuidadeVisual>(entity =>
            {
                entity.HasKey(e => e.LinhaLida);

                entity.ToTable("ParametroAcuidadeVisual", "Ipiranga");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParametroGlicemia>(entity =>
            {
                entity.ToTable("ParametroGlicemia", "Ipiranga");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParametroGorduraAbdominal>(entity =>
            {
                entity.ToTable("ParametroGorduraAbdominal", "Ipiranga");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasColumnType("char(1)");
            });

            modelBuilder.Entity<ParametroImc>(entity =>
            {
                entity.ToTable("ParametroImc", "Ipiranga");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParametroPressaoArterial>(entity =>
            {
                entity.ToTable("ParametroPressaoArterial", "Ipiranga");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParametroTipagemSanguinea>(entity =>
            {
                entity.HasKey(e => new { e.TipoSanguineo, e.FatorRh });

                entity.ToTable("ParametroTipagemSanguinea", "Ipiranga");

                entity.Property(e => e.TipoSanguineo).HasColumnType("char(2)");

                entity.Property(e => e.FatorRh).HasColumnType("char(1)");

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Parceiro>(entity =>
            {
                entity.ToTable("Parceiro", "Ipiranga");

                entity.Property(e => e.Contato)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Ddd).HasColumnName("DDD");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Observacao).HasColumnType("text");
            });

            modelBuilder.Entity<Participante>(entity =>
            {
                entity.ToTable("Participante", "Ipiranga");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdParceiroNavigation)
                    .WithMany(p => p.Participante)
                    .HasForeignKey(d => d.IdParceiro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Participante_Parceiro");
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("Perfil", "Seguranca");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProcedimentoNavigation)
                    .WithMany(p => p.Perfil)
                    .HasForeignKey(d => d.IdProcedimento)
                    .HasConstraintName("FK_Perfil_Procedimento");
            });

            modelBuilder.Entity<Preferencia>(entity =>
            {
                entity.ToTable("Preferencia", "Ipiranga");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PressaoArterial>(entity =>
            {
                entity.HasKey(e => new { e.IdEventoBeneficiario, e.IdEventoProcedimento });

                entity.ToTable("PressaoArterial", "Ipiranga");

                entity.HasOne(d => d.IdEventoBeneficiarioNavigation)
                    .WithMany(p => p.PressaoArterial)
                    .HasForeignKey(d => d.IdEventoBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PressaoArterial_EventoBeneficiario");

                entity.HasOne(d => d.IdEventoProcedimentoNavigation)
                    .WithMany(p => p.PressaoArterial)
                    .HasForeignKey(d => d.IdEventoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PressaoArterial_EventoProcedimento");
            });

            modelBuilder.Entity<Procedimento>(entity =>
            {
                entity.ToTable("Procedimento", "Ipiranga");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipagemSanguinea>(entity =>
            {
                entity.HasKey(e => new { e.IdEventoBeneficiario, e.IdEventoProcedimento });

                entity.ToTable("TipagemSanguinea", "Ipiranga");

                entity.Property(e => e.FatorRh)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.TipoSanguineo)
                    .IsRequired()
                    .HasColumnType("char(2)");

                entity.HasOne(d => d.IdEventoBeneficiarioNavigation)
                    .WithMany(p => p.TipagemSanguinea)
                    .HasForeignKey(d => d.IdEventoBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipagemSanguinea_EventoBeneficiario");

                entity.HasOne(d => d.IdEventoProcedimentoNavigation)
                    .WithMany(p => p.TipagemSanguinea)
                    .HasForeignKey(d => d.IdEventoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TipagemSanguinea_EventoProcedimento");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario", "Seguranca");

                entity.HasIndex(e => e.Login)
                    .HasName("UK_Usuario_Login")
                    .IsUnique();

                entity.Property(e => e.DataExpiracaoSenha).HasColumnType("datetime");

                entity.Property(e => e.DataNascimento).HasColumnType("datetime");

                entity.Property(e => e.DataUltimoAcesso).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FormatoEmail)
                    .IsRequired()
                    .HasColumnType("char(1)");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPerfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Perfil");
            });

            modelBuilder.Entity<Vacina>(entity =>
            {
                entity.ToTable("Vacina", "Ipiranga");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdProcedimentoNavigation)
                    .WithMany(p => p.Vacina)
                    .HasForeignKey(d => d.IdProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacina_Procedimento");
            });

            modelBuilder.Entity<Vacinacao>(entity =>
            {
                entity.HasKey(e => new { e.IdEventoBeneficiario, e.IdEventoProcedimento, e.IdVacina });

                entity.ToTable("Vacinacao", "Ipiranga");

                entity.HasOne(d => d.IdEventoBeneficiarioNavigation)
                    .WithMany(p => p.Vacinacao)
                    .HasForeignKey(d => d.IdEventoBeneficiario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacinacao_EventoBeneficiario");

                entity.HasOne(d => d.IdEventoProcedimentoNavigation)
                    .WithMany(p => p.Vacinacao)
                    .HasForeignKey(d => d.IdEventoProcedimento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacinacao_EventoProcedimento");

                entity.HasOne(d => d.IdVacinaNavigation)
                    .WithMany(p => p.Vacinacao)
                    .HasForeignKey(d => d.IdVacina)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vacinacao_Vacina");
            });
        }

        #endregion
    }
}
