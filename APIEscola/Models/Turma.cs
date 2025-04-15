using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEscola.Models
{
    public class Turma
    {
        public Guid TurmaId { get; set; }
        [Required(ErrorMessage = "O Campo Data de Inicio é Obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "A Data Informada não é Válida")]
        public DateOnly DataInicio { get; set; }
        [Required(ErrorMessage = "O Campo Data de FIm é Obrigatório")]
        [DataType(DataType.Date, ErrorMessage = "A Data Informada não é Válida")]
        public DateOnly DataFim { get; set; }
        [Required(ErrorMessage = "O Campo Descrição é Obrigatório")]
        [MaxLength(255, ErrorMessage = "A descrição deve ter no maximo 255 caracteres")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "O Campo Sigla é Obrigatório")]
        [MaxLength(10, ErrorMessage = "A sigla deve ter no maximo 10 caracteres")]
        public string? Sigla { get; set; }
        [Required(ErrorMessage = "O Campo Curso é Obrigatório")]
        public Guid CursoId { get; set; }
        public Curso? Curso { get; set; }
    }
}
