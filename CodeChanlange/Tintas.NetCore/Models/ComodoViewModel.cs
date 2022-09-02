using System.ComponentModel.DataAnnotations;

namespace Tintas.net.Models
{
    public class ComodoViewModel
    {
        [Required]
        [Display(Name= "Parede Fundo")]
        public int AlturaParedeFundo{ get; set; }
        public int LarguraParedeFundo { get; set; }
        [Required]
        [Display(Name = "Parede Frente")]
        public int AltruaParedeFrente { get; set; }
        public int LarguraParedeFrente { get; set; }
        [Required]
        [Display(Name = "Parede Esquerda")]
        public int AlturaParedeEsquerda { get; set; }
        public int LarguraParedeEsquerda { get; set; }
        [Required]
        [Display(Name = "Parede Direita")]
        public int AlturaParedeDireita { get; set; }
        public int LarguraParedeDireita { get; set; }

        [Display(Name = "Janela")]
        public int? QtdJanela { get; set; }
        [Display(Name = "Porta")]
        public int? QtdPorta { get; set; }

        /// <summary>
        /// consumo total de tinda no comodo.
        /// </summary>
        ///
        public string consumo { get; set; }
        [Display(Name= "Seu consumo é de :")]
        public int? ConsumoTinta { get; set; }
    }
}
