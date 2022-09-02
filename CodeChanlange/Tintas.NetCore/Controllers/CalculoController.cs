using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Tintas.net.Models;
using Tintas.NetCore.Models;

namespace Tintas.net.Controllers
{
    public class CalculoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public IActionResult  Index(ComodoViewModel comodoViewModel)
        {
            // Janela 
            var AreaJanela = 2.00 * 1.20;
            var Janela = comodoViewModel.QtdJanela * AreaJanela;

            // Porta 
            var AreaPorta = 0.80 * 1.90;
            var Porta = comodoViewModel.QtdPorta * AreaPorta;

            // calculo da area de cada parede.
            var ParedeFrente =comodoViewModel.LarguraParedeFrente * comodoViewModel.AltruaParedeFrente;
            var ParedeFundo = comodoViewModel.LarguraParedeFundo * comodoViewModel.AlturaParedeFundo;
            var ParedeEsqueda = comodoViewModel.LarguraParedeEsquerda * comodoViewModel.AlturaParedeEsquerda;
            var ParedeDireita = comodoViewModel.LarguraParedeDireita * comodoViewModel.AlturaParedeDireita;

            var AreaTotal = ParedeFundo + ParedeFrente + ParedeDireita + ParedeEsqueda;
            
            // calculo da area do comodo.
            comodoViewModel.ConsumoTinta = AreaTotal;
         
            ViewData["result"] = comodoViewModel.ConsumoTinta;
            
            return View();
        }
    }
}
