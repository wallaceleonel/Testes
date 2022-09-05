using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Calculadora.Models
{
    public class ComodoViewModel
    {
        [Required]
        [Display(Name = "Parede Fundo")]
        public float AlturaParedeFundo { get; set; }
        public float LarguraParedeFundo { get; set; }
        [Required]
        [Display(Name = "Parede Frente")]
        public float AltruaParedeFrente { get; set; }
        public float LarguraParedeFrente { get; set; }
        [Required]
        [Display(Name = "Parede Esquerda")]
        public float AlturaParedeEsquerda { get; set; }
        public float LarguraParedeEsquerda { get; set; }
        [Required]
        [Display(Name = "Parede Direita")]
        public float AlturaParedeDireita { get; set; }
        public float LarguraParedeDireita { get; set; }

        [Display(Name = "Janela")]
        public int? QtdJanela { get; set; }
        [Display(Name = "Porta")]
        public int? QtdPorta { get; set; }

        /// <summary>
        /// consumo total de tinda no comodo.
        /// </summary>
        ///
        public string ?Operador { get; set; }

        [Display(Name = "Seu consumo é de :")]
        public List<float>? ConsumoTinta { get; set; }
    }
}
