using System.ComponentModel.DataAnnotations;

namespace Tintas.net.Models
{
    public class ComodoModel
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
    
        public int QtdJanela { get; set; }
        public int QtdPorta { get; set; }

        /// <summary>
        /// consumo total de tinda no comodo.
        /// </summary>
        ///

        [Display(Name= "Consumo")]
        public int ConsumoTinta { get; set; }
    }
}
