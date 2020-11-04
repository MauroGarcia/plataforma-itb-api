using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PlataformaITB.API.Models
{
    public partial class ItbDadosContext : DbContext
    {
        public ItbDadosContext()
        {
        }

        public ItbDadosContext(DbContextOptions<ItbDadosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcadDocumentosAlunosPostados> AcadDocumentosAlunosPostados { get; set; }
        public virtual DbSet<AvapMensagemTutoria> AvapMensagemTutoria { get; set; }
        public virtual DbSet<AvapTiraDuvidas> AvapTiraDuvidas { get; set; }
        public virtual DbSet<FinaParcelasAlunos> FinaParcelasAlunos { get; set; }
        public virtual DbSet<FinaParcelasControle> FinaParcelasControle { get; set; }
        public virtual DbSet<MktgBonusAlunos> MktgBonusAlunos { get; set; }
        public virtual DbSet<PedaAlunos> PedaAlunos { get; set; }
        public virtual DbSet<PedaCursos> PedaCursos { get; set; }
        public virtual DbSet<PedaCursosTurmas> PedaCursosTurmas { get; set; }
        public virtual DbSet<PedaMatriculas> PedaMatriculas { get; set; }
        public virtual DbSet<PedaMatriculasAnotacoes> PedaMatriculasAnotacoes { get; set; }
        public virtual DbSet<PedaMatriculasAnotacoesAulas> PedaMatriculasAnotacoesAulas { get; set; }
        public virtual DbSet<PedaMatriculasExcluidas> PedaMatriculasExcluidas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionApplicationData");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcadDocumentosAlunosPostados>(entity =>
            {
                entity.HasKey(e => e.IdPostagem);

                entity.ToTable("Acad_DocumentosAlunosPostados");

                entity.HasIndex(e => e.IdMatricula)
                    .HasName("IX_Acad_DocumentosAlunosPostados_1");

                entity.HasIndex(e => e.IdTipo)
                    .HasName("IX_Acad_DocumentosAlunosPostados");

                entity.Property(e => e.IdPostagem).HasColumnName("idPostagem");

                entity.Property(e => e.ComplementoTipo)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.ConferidoPor)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.DataPostado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMatricula).HasColumnName("idMatricula");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.IsConferidoSecretariaCentral).HasColumnName("isConferidoSecretariaCentral");

                entity.Property(e => e.IsDocumentoOk).HasColumnName("isDocumentoOk");

                entity.Property(e => e.IsDocumentoRejeitado).HasColumnName("isDocumentoRejeitado");

                entity.Property(e => e.NomeSistema)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.PostadoPor)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.AcadDocumentosAlunosPostados)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acad_DocumentosAlunosPostados_Peda_Matriculas");
            });

            modelBuilder.Entity<AvapMensagemTutoria>(entity =>
            {
                entity.HasKey(e => e.IdMensagem);

                entity.ToTable("Avap_MensagemTutoria");

                entity.HasIndex(e => e.IdCurso)
                    .HasName("IX_Avap_MensagemTutoria_2");

                entity.HasIndex(e => e.IdMatricula)
                    .HasName("IX_Avap_MensagemTutoria_3");

                entity.HasIndex(e => e.LoginAutor)
                    .HasName("IX_Avap_MensagemTutoria");

                entity.HasIndex(e => e.LoginRespondidoPor)
                    .HasName("IX_Avap_MensagemTutoria_1");

                entity.Property(e => e.IdMensagem).HasColumnName("idMensagem");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataRespondido).HasColumnType("datetime");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdFrqa).HasColumnName("idFrqa");

                entity.Property(e => e.IdMatricula).HasColumnName("idMatricula");

                entity.Property(e => e.IsRespondido).HasColumnName("isRespondido");

                entity.Property(e => e.LoginAutor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginRespondidoPor).HasMaxLength(50);

                entity.Property(e => e.Mensagem)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.RespondidoPor).HasMaxLength(50);

                entity.Property(e => e.Resposta)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('SEM RESPOSTA')");

                entity.Property(e => e.TutorPreferencial).HasMaxLength(50);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.AvapMensagemTutoria)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avap_MensagemTutoria_Peda_Cursos");

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.AvapMensagemTutoria)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avap_MensagemTutoria_Peda_Matriculas");
            });

            modelBuilder.Entity<AvapTiraDuvidas>(entity =>
            {
                entity.HasKey(e => e.IdDuvida);

                entity.ToTable("Avap_TiraDuvidas");

                entity.HasIndex(e => e.IdCurso)
                    .HasName("IX_Avap_TiraDuvidas_2");

                entity.HasIndex(e => e.IdMatricula)
                    .HasName("IX_Avap_TiraDuvidas_3");

                entity.HasIndex(e => e.LoginAutor)
                    .HasName("IX_Avap_TiraDuvidas");

                entity.HasIndex(e => e.LoginRespondidoPor)
                    .HasName("IX_Avap_TiraDuvidas_1");

                entity.Property(e => e.IdDuvida).HasColumnName("idDuvida");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Data)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataRespondido).HasColumnType("datetime");

                entity.Property(e => e.Duvida)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdFrqa).HasColumnName("idFrqa");

                entity.Property(e => e.IdMatricula).HasColumnName("idMatricula");

                entity.Property(e => e.IsRespondido).HasColumnName("isRespondido");

                entity.Property(e => e.LoginAutor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoginRespondidoPor).HasMaxLength(50);

                entity.Property(e => e.RespondidoPor).HasMaxLength(50);

                entity.Property(e => e.Resposta)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('SEM RESPOSTA')");

                entity.Property(e => e.TutorPreferencial).HasMaxLength(50);

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.AvapTiraDuvidas)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avap_TiraDuvidas_Peda_Cursos");

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.AvapTiraDuvidas)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Avap_TiraDuvidas_Peda_Matriculas");
            });

            modelBuilder.Entity<FinaParcelasAlunos>(entity =>
            {
                entity.HasKey(e => e.IdParcela);

                entity.ToTable("Fina_ParcelasAlunos");

                entity.HasIndex(e => e.DataPago)
                    .HasName("IX_Fina_ParcelasAlunos_4");

                entity.HasIndex(e => e.Documento)
                    .HasName("IX_Fina_ParcelasAlunos_5")
                    .IsUnique();

                entity.HasIndex(e => e.IdCedente)
                    .HasName("IX_Fina_ParcelasAlunos_8");

                entity.HasIndex(e => e.IdCompra)
                    .HasName("IX_Fina_ParcelasAlunos_7");

                entity.HasIndex(e => e.IdLote)
                    .HasName("IX_Fina_ParcelasAlunos_6");

                entity.HasIndex(e => e.IdMatricula)
                    .HasName("IX_Fina_ParcelasAlunos");

                entity.HasIndex(e => e.TransacaoId)
                    .HasName("IX_Fina_ParcelasAlunos_10");

                entity.HasIndex(e => e.Vencimento)
                    .HasName("IX_Fina_ParcelasAlunos_2");

                entity.HasIndex(e => e.VencimentoReal)
                    .HasName("IX_Fina_ParcelasAlunos_3");

                entity.HasIndex(e => new { e.Documento, e.IdCedente })
                    .HasName("IX_Fina_ParcelasAlunos_9");

                entity.HasIndex(e => new { e.IdParcela, e.Documento, e.IdMatricula })
                    .HasName("IX_Fina_ParcelasAlunos_1");

                entity.HasIndex(e => new { e.DataPago, e.DataStatus, e.DataTransacaoCompleta, e.DescontoAntecipado, e.IdMatricula, e.IsAcordo, e.IsBonus, e.IsCampanha, e.IsDescontoAntecipado, e.IsTransacaoCompleta, e.OptAcordo, e.Parcela, e.PercentualFrqa, e.PercentualFrqaMaster, e.PercentualFrqaVendedor, e.Status, e.TipoPagamento, e.TransacaoId, e.ValorDescontoBonus, e.ValorFrqa, e.ValorFrqaCampanha, e.ValorFrqaMaster, e.ValorFrqaVendedor, e.ValorOriginal, e.ValorPago, e.IsPago })
                    .HasName("nci_wi_Fina_ParcelasAlunos_46A4D9A0362C0AB836757B7F5DF85EE6");

                entity.HasIndex(e => new { e.DataBaixado, e.DataPago, e.DataStatus, e.DataTransacaoCompleta, e.Desconto, e.DescontoAntecipado, e.DescontoBonus, e.Documento, e.Emissao, e.IdCedente, e.IdCompra, e.IdLote, e.IdMatricula, e.IsAcordo, e.IsBaixadoPorDuplicidade, e.IsBonus, e.IsCampanha, e.IsCancelado, e.IsCombo, e.IsDescontoAntecipado, e.IsDivergencia, e.IsInadimplente, e.IsPago, e.IsPagoEmDuplicidade, e.IsTransacaoCompleta, e.IsTratadoCobranca, e.IsValorFrqaRepassado, e.Juros, e.LocalPago, e.Multa, e.OptAcordo, e.PercentualFrqa, e.PercentualFrqaCampanha, e.PercentualFrqaMaster, e.PercentualFrqaVendedor, e.PercentualImpostoRetido, e.PercentualOperacional, e.Status, e.Tarifa, e.TipoPagamento, e.TransacaoId, e.Urlboleto, e.UsuarioBaixou, e.UsuarioEmitiu, e.ValoParcelaCampanha, e.Valor, e.ValorDescontoBonus, e.ValorFrqa, e.ValorFrqaCampanha, e.ValorFrqaMaster, e.ValorFrqaVendedor, e.ValorImpostoRetido, e.ValorOperacional, e.ValorOriginal, e.ValorPago, e.Vencimento, e.VencimentoReal, e.Parcela })
                    .HasName("nci_wi_Fina_ParcelasAlunos_3A788DA09FC125B1ECD18CA8F8570884");

                entity.Property(e => e.IdParcela).HasColumnName("idParcela");

                entity.Property(e => e.DataBaixado).HasColumnType("datetime");

                entity.Property(e => e.DataPago).HasColumnType("datetime");

                entity.Property(e => e.DataStatus).HasColumnType("datetime");

                entity.Property(e => e.DataTransacaoCompleta).HasColumnType("datetime");

                entity.Property(e => e.Desconto).HasColumnType("money");

                entity.Property(e => e.DescontoAntecipado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DescontoBonus)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Emissao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCedente)
                    .HasColumnName("idCedente")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdCompra).HasColumnName("idCompra");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.IdMatricula).HasColumnName("idMatricula");

                entity.Property(e => e.IsAcordo).HasColumnName("isAcordo");

                entity.Property(e => e.IsBaixadoPorDuplicidade).HasColumnName("isBaixadoPorDuplicidade");

                entity.Property(e => e.IsBonus).HasColumnName("isBonus");

                entity.Property(e => e.IsCampanha).HasColumnName("isCampanha");

                entity.Property(e => e.IsCancelado).HasColumnName("isCancelado");

                entity.Property(e => e.IsCombo).HasColumnName("isCombo");

                entity.Property(e => e.IsDescontoAntecipado).HasColumnName("isDescontoAntecipado");

                entity.Property(e => e.IsDivergencia).HasColumnName("isDivergencia");

                entity.Property(e => e.IsInadimplente).HasColumnName("isInadimplente");

                entity.Property(e => e.IsPago).HasColumnName("isPago");

                entity.Property(e => e.IsPagoEmDuplicidade).HasColumnName("isPagoEmDuplicidade");

                entity.Property(e => e.IsTransacaoCompleta)
                    .HasColumnName("isTransacaoCompleta")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsTratadoCobranca).HasColumnName("isTratadoCobranca");

                entity.Property(e => e.IsValorFrqaRepassado).HasColumnName("isValorFrqaRepassado");

                entity.Property(e => e.Juros).HasColumnType("money");

                entity.Property(e => e.LocalPago).HasMaxLength(50);

                entity.Property(e => e.Multa).HasColumnType("money");

                entity.Property(e => e.PercentualFrqa).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PercentualFrqaCampanha).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PercentualFrqaMaster)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PercentualFrqaVendedor)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PercentualImpostoRetido)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PercentualOperacional).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Tarifa).HasColumnType("money");

                entity.Property(e => e.TipoPagamento).HasMaxLength(50);

                entity.Property(e => e.Urlboleto)
                    .HasColumnName("URLBoleto")
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.UsuarioBaixou).HasMaxLength(100);

                entity.Property(e => e.UsuarioEmitiu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ValoParcelaCampanha).HasColumnType("money");

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.Property(e => e.ValorDescontoBonus)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorFrqa).HasColumnType("money");

                entity.Property(e => e.ValorFrqaCampanha).HasColumnType("money");

                entity.Property(e => e.ValorFrqaMaster)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorFrqaVendedor)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorImpostoRetido)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ValorOperacional).HasColumnType("money");

                entity.Property(e => e.ValorOriginal).HasColumnType("money");

                entity.Property(e => e.ValorPago).HasColumnType("money");

                entity.Property(e => e.Vencimento).HasColumnType("datetime");

                entity.Property(e => e.VencimentoReal).HasColumnType("datetime");

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.FinaParcelasAlunos)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fina_ParcelasAlunos_Peda_Matriculas");
            });

            modelBuilder.Entity<FinaParcelasControle>(entity =>
            {
                entity.HasKey(e => e.IdEmissao);

                entity.ToTable("Fina_ParcelasControle");

                entity.HasIndex(e => e.Documento)
                    .HasName("IX_Fina_ParcelasControle")
                    .IsUnique();

                entity.HasIndex(e => e.IdCedente)
                    .HasName("IX_Fina_ParcelasControle_2");

                entity.HasIndex(e => e.IdLote)
                    .HasName("IX_Fina_ParcelasControle_1");

                entity.Property(e => e.IdEmissao).HasColumnName("idEmissao");

                entity.Property(e => e.DataProcessado).HasColumnType("datetime");

                entity.Property(e => e.Emissao).HasColumnType("datetime");

                entity.Property(e => e.IdCedente)
                    .HasColumnName("idCedente")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdLote).HasColumnName("idLote");

                entity.Property(e => e.IsPago).HasColumnName("isPago");

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.Property(e => e.Vencimento).HasColumnType("datetime");
            });

            modelBuilder.Entity<MktgBonusAlunos>(entity =>
            {
                entity.HasKey(e => e.IdBonus);

                entity.ToTable("Mktg_BonusAlunos");

                entity.HasIndex(e => e.IdMatriculaDestino)
                    .HasName("IX_Mktg_BonusAlunos_1");

                entity.HasIndex(e => e.IdMatriculaOrigem)
                    .HasName("IX_Mktg_BonusAlunos");

                entity.Property(e => e.IdBonus).HasColumnName("idBonus");

                entity.Property(e => e.DataSolicitado).HasColumnType("datetime");

                entity.Property(e => e.DataUtilizado).HasColumnType("datetime");

                entity.Property(e => e.DescontoDestino).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.DescontoOrigem).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IdCampanhaBonus).HasColumnName("idCampanhaBonus");

                entity.Property(e => e.IdMatriculaDestino).HasColumnName("idMatriculaDestino");

                entity.Property(e => e.IdMatriculaOrigem).HasColumnName("idMatriculaOrigem");

                entity.Property(e => e.IsUtilizado).HasColumnName("isUtilizado");

                entity.Property(e => e.UsuarioLancou)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.IdMatriculaDestinoNavigation)
                    .WithMany(p => p.MktgBonusAlunosIdMatriculaDestinoNavigation)
                    .HasForeignKey(d => d.IdMatriculaDestino)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Mktg_BonusAlunos_Peda_Matriculas1");

                entity.HasOne(d => d.IdMatriculaOrigemNavigation)
                    .WithMany(p => p.MktgBonusAlunosIdMatriculaOrigemNavigation)
                    .HasForeignKey(d => d.IdMatriculaOrigem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Mktg_BonusAlunos_Peda_Matriculas");
            });

            modelBuilder.Entity<PedaAlunos>(entity =>
            {
                entity.HasKey(e => e.IdAluno);

                entity.ToTable("Peda_Alunos");

                entity.HasIndex(e => e.Cpf)
                    .HasName("IX_Peda_Alunos_cpf")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("IX_Peda_Alunos_email")
                    .IsUnique();

                entity.HasIndex(e => e.LoginAluno)
                    .HasName("IX_Peda_Alunos_login");

                entity.HasIndex(e => e.Nascimento)
                    .HasName("IX_Peda_Alunos_nascimento");

                entity.HasIndex(e => e.NomeAluno)
                    .HasName("IX_Peda_Alunos_nome");

                entity.HasIndex(e => new { e.Cpf, e.Nascimento, e.NomeAluno, e.IdFrqaOrigem })
                    .HasName("IX_Peda_Alunos_cpf_nascimento_nome");

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CidadeEnsinoMedio)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CpfNovo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EscolaEnsinoMedio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fixo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdFrqaAtual).HasColumnName("idFrqaAtual");

                entity.Property(e => e.IdFrqaOrigem).HasColumnName("idFrqaOrigem");

                entity.Property(e => e.Indicação)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InfoMigracao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsAtivo)
                    .IsRequired()
                    .HasColumnName("isAtivo")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsBloqueado).HasColumnName("isBloqueado");

                entity.Property(e => e.IsBonusLiberado)
                    .IsRequired()
                    .HasColumnName("isBonusLiberado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsEmCobranca).HasColumnName("isEmCobranca");

                entity.Property(e => e.IsInadimplente).HasColumnName("isInadimplente");

                entity.Property(e => e.IsMigracaoAvaNovo).HasColumnName("isMigracaoAvaNovo");

                entity.Property(e => e.LoginAluno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Mae)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Movel)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionaliadde)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nascimento).HasColumnType("datetime");

                entity.Property(e => e.Naturalidade)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomeAluno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OrgaoExpedidor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sexo).HasDefaultValueSql("((1))");

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.UsuarioCadastrou)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PedaCursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso);

                entity.ToTable("Peda_Cursos");

                entity.HasIndex(e => new { e.NomeCurso, e.IdTipo, e.IsAtivo })
                    .HasName("nci_wi_Peda_Cursos_767B1F75D04DC742E303290BC151B8F0");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.Certificacao).IsUnicode(false);

                entity.Property(e => e.CertificadoAutorizacaoInstituicao)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CertificadoCriacaoCurso)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CertificadoLocalCertificacao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CertificadoNomeInstituicao)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CertificadoVersoColunaCen).IsUnicode(false);

                entity.Property(e => e.CertificadoVersoColunaDir).IsUnicode(false);

                entity.Property(e => e.CertificadoVersoColunaEsq).IsUnicode(false);

                entity.Property(e => e.CorBgAva).HasMaxLength(10);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Duracao)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((15))");

                entity.Property(e => e.Ementa)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.FaltasMaximo).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.FequenciaMinima).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IconePublico)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdBlocoAcolhimento).HasColumnName("idBlocoAcolhimento");

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.ImagemBgAva)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ImagemPublico)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.InfoCargaHoraria).HasColumnType("text");

                entity.Property(e => e.InfoInvestimento).HasColumnType("text");

                entity.Property(e => e.IsAtivo).HasColumnName("isAtivo");

                entity.Property(e => e.ItinerarioFormativo).HasColumnType("text");

                entity.Property(e => e.MediaAprovacao).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MediaRecuperacao).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Metodologia).HasColumnType("text");

                entity.Property(e => e.NomeCurso)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCursoFormacaoTecnica)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Objetivos).HasColumnType("text");

                entity.Property(e => e.PerfilProfissional).HasColumnType("text");

                entity.Property(e => e.PrecoSugerido)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjetoPedagogico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Publico)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Slug)
                    .HasColumnName("SLUG")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCurso)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCursoFormacaoTecnica)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VideoDeApresentacao)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PedaCursosTurmas>(entity =>
            {
                entity.HasKey(e => e.IdTurma)
                    .HasName("PK_Peda_Turmas");

                entity.ToTable("Peda_CursosTurmas");

                entity.HasIndex(e => e.IdFrqa)
                    .HasName("IX_Peda_CursosTurmas_1");

                entity.HasIndex(e => e.IdTransmissao)
                    .HasName("IX_Peda_CursosTurmas");

                entity.HasIndex(e => e.IdTurno)
                    .HasName("IX_Peda_CursosTurmas_2");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Horario)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IdFrqa).HasColumnName("idFrqa");

                entity.Property(e => e.IdTransmissao).HasColumnName("idTransmissao");

                entity.Property(e => e.IdTurno)
                    .HasColumnName("idTurno")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsAberta).HasColumnName("isAberta");

                entity.Property(e => e.IsEncerrada).HasColumnName("isEncerrada");

                entity.Property(e => e.IsSuspensa).HasColumnName("isSuspensa");

                entity.Property(e => e.Local)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UsuarioCadastrou)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PedaMatriculas>(entity =>
            {
                entity.HasKey(e => e.IdMatricula);

                entity.ToTable("Peda_Matriculas");

                entity.HasIndex(e => e.CodigoBolsa)
                    .HasName("IX_Peda_Matriculas_7");

                entity.HasIndex(e => e.CodigoMatricula)
                    .HasName("nci_wi_Peda_Matriculas_D83776CD759E4F8677EC5624D1E4B04C");

                entity.HasIndex(e => e.CodigoNossoTransacaoPs)
                    .HasName("nci_wi_Peda_Matriculas_08D793A6A8B7E63DE009B33BFC7F3237");

                entity.HasIndex(e => e.CodigoTransacaoPs)
                    .HasName("IX_Peda_Matriculas_5");

                entity.HasIndex(e => e.IdAluno)
                    .HasName("IX_Peda_Matriculas");

                entity.HasIndex(e => e.IdFrqa)
                    .HasName("IX_Peda_Matriculas_3");

                entity.HasIndex(e => e.IdFrqaMaster)
                    .HasName("IX_Peda_Matriculas_6");

                entity.HasIndex(e => e.IdFrqaVendedor)
                    .HasName("IX_Peda_Matriculas_4");

                entity.HasIndex(e => e.IdTurma)
                    .HasName("IX_Peda_Matriculas_1");

                entity.HasIndex(e => e.LoginAluno)
                    .HasName("IX_Peda_Matriculas_2");

                entity.HasIndex(e => new { e.LoginAluno, e.IdCurso })
                    .HasName("nci_wi_Peda_Matriculas_0FA20B9A817A38F4AD68E39114AAACCF");

                entity.HasIndex(e => new { e.IdCurso, e.IdFrqa, e.IsConcluso, e.IsPagoMatricula, e.IsTesteInterno, e.DataCertificado })
                    .HasName("nci_wi_Peda_Matriculas_1BDE27FDADE4DF73A7DDE0DD143BAB5D");

                entity.HasIndex(e => new { e.IdTutorVirtual, e.IdFrqa, e.IsCancelada, e.IsPagoMatricula, e.IsConcluso, e.IsTesteInterno, e.IdCurso })
                    .HasName("nci_wi_Peda_Matriculas_58019E819B0F17B79033B1D0FBFC81DB");

                entity.HasIndex(e => new { e.PercentualCursado, e.DataFimContrato, e.DataUltimoAcesso, e.IdAluno, e.IdTutorLocal, e.IsMatriculaNova, e.IsPrimeiroAcesso, e.IsCancelada, e.IsPagoMatricula, e.IdFrqa, e.IsConcluso, e.IsDocumentacaoPostada, e.IdCurso })
                    .HasName("nci_wi_Peda_Matriculas_F58051BC595E10447EB0BE9A6ED9871B");

                entity.HasIndex(e => new { e.CodigoBolsa, e.CodigoMatricula, e.TutorCentralPreferencial, e.TutorLocalPreferencial, e.UsuarioCadastrou, e.UsuarioCancelou, e.ValorMatricula, e.ValorParcela, e.ObsDocumentacao, e.PercentualCursado, e.QtdParcelas, e.QtdParcelasInad, e.StatusPs, e.TipoCurso, e.LoginAluno, e.LoteNewsletter, e.ModulosaCursar, e.ModulosCursados, e.MotivoCancelamento, e.NomeCurso, e.IsPagseguro, e.IsPendente, e.IsPrimeiroAcesso, e.IsTesteInterno, e.IsTrancada, e.IsTransacaoCompleta, e.IsFormacaoTecnica, e.IsFornecerCertificado, e.IsImpressoCertificado, e.IsInadimplente, e.IsMatriculaNova, e.IsMatriculaQuitada, e.IsBolsaConvenio, e.IsCombo, e.IsConcluso, e.IsDocumentacaoOk, e.IsDocumentacaoPostada, e.IsEvadiu, e.IdTurma, e.IdTutorLocal, e.ImpressoPor, e.InformacoesPostagem, e.IsAprovado, e.IsBloqueada, e.Identificacao01, e.IdFrqa, e.IdFrqaMaster, e.IdFrqaVendedor, e.IdOpcaoCertificado, e.IdPrecificacaoFrqa, e.DocumentacaoConferidaPor, e.DocumentacaoPostadaPor, e.IdAluno, e.IdBlocoAtual, e.IdBlocoEntrada, e.Identificacaio02, e.DataPrimeiroAcesso, e.DataStatusPs, e.DataTransacaoCompleta, e.DataTransacaoPs, e.DataUltimoAcesso, e.DescontoDePontualidade, e.DataDocumantacaoPostada, e.DataFimAtividades, e.DataFimContrato, e.DataInicioAtividades, e.DataLimitePagoMatricula, e.DataNewsletter, e.CodigoNossoTransacaoPs, e.CodigoTransacaoPs, e.DataCadastrado, e.DataCalculoInad, e.DataCancelou, e.DataCertificado, e.IdTutorVirtual, e.IdCurso, e.IsCancelada, e.IsPagoMatricula })
                    .HasName("nci_wi_Peda_Matriculas_1855A447CF31DF4B06D670111202F1DC");

                entity.HasIndex(e => new { e.IdMatricula, e.TipoCurso, e.NomeCurso, e.IsFormacaoTecnica, e.IdAluno, e.IdCurso, e.IdBlocoAtual, e.IdBlocoEntrada, e.DataInicioAtividades, e.DataFimAtividades, e.DataFimContrato, e.IsPrimeiroAcesso, e.DataPrimeiroAcesso, e.DataUltimoAcesso, e.IdTurma, e.IdTutorLocal, e.IdTutorVirtual, e.IsBolsaConvenio, e.CodigoBolsa, e.IsPagseguro, e.CodigoNossoTransacaoPs, e.CodigoTransacaoPs, e.DataTransacaoPs, e.StatusPs, e.DataStatusPs, e.IsTransacaoCompleta, e.DataTransacaoCompleta, e.IdPrecificacaoFrqa, e.ValorMatricula, e.ValorParcela, e.QtdParcelas, e.DescontoDePontualidade, e.IsCombo, e.IdFrqa, e.IdFrqaMaster, e.IdFrqaVendedor, e.IdOpcaoCertificado, e.LoginAluno, e.DataCertificado, e.IsImpressoCertificado, e.ImpressoPor, e.InformacoesPostagem, e.InformacoesRegistro, e.CodigoAutenticacaoExterno, e.SiteAutenticacaoExterno, e.IsMatriculaNova, e.IsBloqueada, e.IsPendente, e.IsFornecerCertificado, e.IsPagoMatricula, e.DataLimitePagoMatricula, e.IsMatriculaQuitada, e.IsInadimplente, e.QtdParcelasInad, e.DataCalculoInad, e.IsAprovado, e.IsConcluso, e.IsEvadiu, e.IsTrancada, e.IsCancelada, e.MotivoCancelamento, e.DataCancelou, e.UsuarioCancelou, e.DataCadastrado, e.UsuarioCadastrou, e.LoteNewsletter, e.DataNewsletter, e.IsDocumentacaoPostada, e.DataDocumantacaoPostada, e.DocumentacaoPostadaPor, e.IsDocumentacaoOk, e.DocumentacaoConferidaPor, e.ObsDocumentacao, e.Identificacao01, e.Identificacaio02, e.ModulosaCursar, e.ModulosCursados, e.PercentualCursado, e.IsTesteInterno, e.TutorLocalPreferencial, e.TutorCentralPreferencial, e.IsLiberaTutoria, e.IsLiberaAvPresencial, e.CodigoMatricula })
                    .HasName("siltech_idx_Peda_Matriculas1");

                entity.Property(e => e.IdMatricula).HasColumnName("idMatricula");

                entity.Property(e => e.CodigoAutenticacaoExterno).HasMaxLength(50);

                entity.Property(e => e.CodigoMatricula)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoNossoTransacaoPs)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoTransacaoPs)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataCadastrado)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataCalculoInad).HasColumnType("datetime");

                entity.Property(e => e.DataCancelou).HasColumnType("datetime");

                entity.Property(e => e.DataCertificado).HasColumnType("datetime");

                entity.Property(e => e.DataDocumantacaoPostada).HasColumnType("datetime");

                entity.Property(e => e.DataFimAtividades).HasColumnType("datetime");

                entity.Property(e => e.DataFimContrato).HasColumnType("datetime");

                entity.Property(e => e.DataInicioAtividades).HasColumnType("datetime");

                entity.Property(e => e.DataLimitePagoMatricula)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataNewsletter).HasColumnType("datetime");

                entity.Property(e => e.DataPrimeiroAcesso).HasColumnType("datetime");

                entity.Property(e => e.DataStatusPs).HasColumnType("datetime");

                entity.Property(e => e.DataTransacaoCompleta).HasColumnType("datetime");

                entity.Property(e => e.DataTransacaoPs).HasColumnType("datetime");

                entity.Property(e => e.DataUltimoAcesso).HasColumnType("datetime");

                entity.Property(e => e.DescontoDePontualidade)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((20))");

                entity.Property(e => e.DocumentacaoConferidaPor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentacaoPostadaPor)
                    .HasMaxLength(40)
                    .IsFixedLength();

                entity.Property(e => e.IdAluno).HasColumnName("idAluno");

                entity.Property(e => e.IdBlocoAtual).HasColumnName("idBlocoAtual");

                entity.Property(e => e.IdBlocoEntrada).HasColumnName("idBlocoEntrada");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdFrqa).HasColumnName("idFrqa");

                entity.Property(e => e.IdFrqaMaster).HasColumnName("idFrqaMaster");

                entity.Property(e => e.IdFrqaVendedor).HasColumnName("idFrqaVendedor");

                entity.Property(e => e.IdOpcaoCertificado)
                    .HasColumnName("idOpcaoCertificado")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdPrecificacaoFrqa).HasColumnName("idPrecificacaoFrqa");

                entity.Property(e => e.IdTurma).HasColumnName("idTurma");

                entity.Property(e => e.IdTutorLocal).HasColumnName("idTutorLocal");

                entity.Property(e => e.IdTutorVirtual).HasColumnName("idTutorVirtual");

                entity.Property(e => e.Identificacaio02)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Identificacao01)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImpressoPor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InformacoesPostagem)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InformacoesRegistro)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsAprovado).HasColumnName("isAprovado");

                entity.Property(e => e.IsBloqueada).HasColumnName("isBloqueada");

                entity.Property(e => e.IsBolsaConvenio).HasColumnName("isBolsaConvenio");

                entity.Property(e => e.IsCancelada).HasColumnName("isCancelada");

                entity.Property(e => e.IsCombo).HasColumnName("isCombo");

                entity.Property(e => e.IsConcluso).HasColumnName("isConcluso");

                entity.Property(e => e.IsDocumentacaoOk).HasColumnName("isDocumentacaoOk");

                entity.Property(e => e.IsDocumentacaoPostada).HasColumnName("isDocumentacaoPostada");

                entity.Property(e => e.IsEvadiu).HasColumnName("isEvadiu");

                entity.Property(e => e.IsFormacaoTecnica)
                    .HasColumnName("isFormacaoTecnica")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsFornecerCertificado).HasColumnName("isFornecerCertificado");

                entity.Property(e => e.IsImpressoCertificado).HasColumnName("isImpressoCertificado");

                entity.Property(e => e.IsInadimplente).HasColumnName("isInadimplente");

                entity.Property(e => e.IsLiberaAvPresencial)
                    .HasColumnName("isLiberaAvPresencial")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLiberaTutoria)
                    .HasColumnName("isLiberaTutoria")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMatriculaNova).HasColumnName("isMatriculaNova");

                entity.Property(e => e.IsMatriculaQuitada).HasColumnName("isMatriculaQuitada");

                entity.Property(e => e.IsOficinaConcluida)
                    .HasColumnName("isOficinaConcluida")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsPagoMatricula).HasColumnName("isPagoMatricula");

                entity.Property(e => e.IsPagseguro).HasColumnName("isPagseguro");

                entity.Property(e => e.IsPendente)
                    .IsRequired()
                    .HasColumnName("isPendente")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsPrimeiroAcesso)
                    .IsRequired()
                    .HasColumnName("isPrimeiroAcesso")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsTesteInterno).HasColumnName("isTesteInterno");

                entity.Property(e => e.IsTrancada).HasColumnName("isTrancada");

                entity.Property(e => e.IsTransacaoCompleta)
                    .HasColumnName("isTransacaoCompleta")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LoginAluno)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LoteNewsletter)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MotivoCancelamento).HasColumnType("varchar(max)");

                entity.Property(e => e.NomeCurso)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ObsDocumentacao)
                    .HasColumnType("varchar(max)")
                    .HasDefaultValueSql("(N'Nenhuma Observação')");

                entity.Property(e => e.PercentualCursado).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SiteAutenticacaoExterno).HasMaxLength(100);

                entity.Property(e => e.StatusPs)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCurso)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TutorCentralPreferencial).HasMaxLength(50);

                entity.Property(e => e.TutorLocalPreferencial).HasMaxLength(50);

                entity.Property(e => e.UsuarioCadastrou)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCancelou)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValorMatricula).HasColumnType("money");

                entity.Property(e => e.ValorParcela).HasColumnType("money");

                entity.HasOne(d => d.IdAlunoNavigation)
                    .WithMany(p => p.PedaMatriculas)
                    .HasForeignKey(d => d.IdAluno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peda_Matriculas_Peda_Alunos");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.PedaMatriculas)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peda_Matriculas_Peda_Cursos");

                entity.HasOne(d => d.IdTurmaNavigation)
                    .WithMany(p => p.PedaMatriculas)
                    .HasForeignKey(d => d.IdTurma)
                    .HasConstraintName("FK_Peda_Matriculas_Peda_CursosTurmas");
            });

            modelBuilder.Entity<PedaMatriculasAnotacoes>(entity =>
            {
                entity.HasKey(e => e.IdAnotacao);

                entity.ToTable("Peda_MatriculasAnotacoes");

                entity.HasIndex(e => e.IdMatricula)
                    .HasName("IX_Peda_MatriculasAnotacoes");

                entity.Property(e => e.IdAnotacao).HasColumnName("idAnotacao");

                entity.Property(e => e.DataAnotacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdMatricula).HasColumnName("idMatricula");

                entity.Property(e => e.TextoAnotacao)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.UsuarioPostou)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.PedaMatriculasAnotacoes)
                    .HasForeignKey(d => d.IdMatricula)
                    .HasConstraintName("FK_Peda_MatriculasAnotacoes_Peda_Matriculas");
            });

            modelBuilder.Entity<PedaMatriculasAnotacoesAulas>(entity =>
            {
                entity.HasKey(e => e.IdAnotacao);

                entity.ToTable("Peda_MatriculasAnotacoesAulas");

                entity.HasIndex(e => e.IdAtividade)
                    .HasName("IX_Peda_MatriculasAnotacoesAulas_1");

                entity.HasIndex(e => e.IdMatricula)
                    .HasName("IX_Peda_MatriculasAnotacoesAulas");

                entity.Property(e => e.IdAnotacao).HasColumnName("idAnotacao");

                entity.Property(e => e.DataAnotacao).HasColumnType("datetime");

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.IdMatricula).HasColumnName("idMatricula");

                entity.Property(e => e.TempodeAula)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdMatriculaNavigation)
                    .WithMany(p => p.PedaMatriculasAnotacoesAulas)
                    .HasForeignKey(d => d.IdMatricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Peda_MatriculasAnotacoesAulas_Peda_Matriculas");
            });

            modelBuilder.Entity<PedaMatriculasExcluidas>(entity =>
            {
                entity.HasKey(e => e.IdMatricula);

                entity.ToTable("Peda_MatriculasExcluidas");

                entity.Property(e => e.IdMatricula)
                    .HasColumnName("idMatricula")
                    .ValueGeneratedNever();

                entity.Property(e => e.Curso)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DataExclusao).HasColumnType("datetime");

                entity.Property(e => e.DataMatricula).HasColumnType("datetime");

                entity.Property(e => e.DataPago).HasColumnType("datetime");

                entity.Property(e => e.IdFrqa).HasColumnName("idFrqa");

                entity.Property(e => e.LoginAluno).HasMaxLength(100);

                entity.Property(e => e.NomeAluno)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioExcluiu)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Valor).HasColumnType("money");

                entity.Property(e => e.ValorPago).HasColumnType("money");

                entity.Property(e => e.Vencimento).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
