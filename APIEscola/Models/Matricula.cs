using System.ComponentModel.DataAnnotations;

namespace APIEscola.Models
{
    public class Matricula
    {
        public Guid MatriculaId { get; set; }
        [Required(ErrorMessage = "O Campo Aluno é obrigatório")]
        public Guid AlunoId { get; set; }
        public Aluno? Aluno { get; set; }
        [Required(ErrorMessage = "O Campo turma é obrigatório")]
        public Guid TurmaId { get; set; }
        public Turma? Turma { get; set; }
        [Required(ErrorMessage = "O Campo data Data de Matrícula é obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "O Formato da Data não é valido.")]
        public DateTime DataMatricula { get; set; } = DateTime.Now;
    }
}
