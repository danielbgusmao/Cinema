using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cinema.Domain.Entities
{
    public class Sessao : BaseEntity
    {
        [Display(Name = "Data Início")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy H:mm}", ApplyFormatInEditMode = true)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de início é obrigatório.")]
        public DateTime DataInicio { get; set; }

        [ReadOnly(true)]
        [Display(Name = "Data de Término")]
        [DataType(DataType.DateTime)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo data de término é obrigatório.")]
        public DateTime? DataFim { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo valor do ingresso é obrigatório.")]
        public float? ValorIngresso { get; set; }

        [Display(Name = "Tipo de Animação")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo tipo de animação é obrigatório.")]
        public string? TipoAnimacao { get; set; }

        [Display(Name = "Tipo de Áudio")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo tipo de áudio é obrigatório.")]
        public string? TipoAudio { get; set; }

        [Display(Name = "Filme")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo filme é obrigatório.")]
        public Guid FilmeId { get; set; }

        [Display(Name = "Sala")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "O campo sala é obrigatório.")]
        public Guid SalaId { get; set; }

        public Filme? Filme { get; set; }

        public Sala? Sala { get; set; }

    }
}
