using System;
using System.Collections.Generic;

namespace PlataformaITB.API.Models
{
    public partial class PedaAlunos
    {
        public PedaAlunos()
        {
            PedaMatriculas = new HashSet<PedaMatriculas>();
        }

        public int IdAluno { get; set; }
        public int IdFrqaOrigem { get; set; }
        public int IdFrqaAtual { get; set; }
        public string LoginAluno { get; set; }
        public string Cpf { get; set; }
        public string CpfNovo { get; set; }
        public string Rg { get; set; }
        public string OrgaoExpedidor { get; set; }
        public string NomeAluno { get; set; }
        public byte Sexo { get; set; }
        public DateTime Nascimento { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionaliadde { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public DateTime DataCadastro { get; set; }
        public string UsuarioCadastrou { get; set; }
        public string Indicação { get; set; }
        public string Fixo { get; set; }
        public string Movel { get; set; }
        public string Email { get; set; }
        public string EscolaEnsinoMedio { get; set; }
        public string CidadeEnsinoMedio { get; set; }
        public int? AnoConclusao { get; set; }
        public bool IsInadimplente { get; set; }
        public bool? IsAtivo { get; set; }
        public bool IsBloqueado { get; set; }
        public bool IsEmCobranca { get; set; }
        public bool? IsBonusLiberado { get; set; }
        public bool IsMigracaoAvaNovo { get; set; }
        public string InfoMigracao { get; set; }

        public virtual ICollection<PedaMatriculas> PedaMatriculas { get; set; }
    }
}
