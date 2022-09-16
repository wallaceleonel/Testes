using Microsoft.AspNetCore.Mvc;
using Tintas.net.Models;
namespace Tintas.net.Controllers
{

    public class CalculoController : Controller
    {
        private readonly ILogger<CalculoController> _logger;

        public CalculoController(ILogger<CalculoController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ComodoModel comodoModel)
        {
            // Janela 
            var AreaJanela = 2.00 * 1.20;
            var Janela = comodoModel.QtdJanela * AreaJanela;
            
            // Porta 
            var AreaPorta = 0.80 * 1.90;
            var Porta = comodoModel.QtdPorta * AreaPorta;

            // calculo da area de cada parede.
            var ParedeFrente = comodoModel.LarguraParedeFrente * comodoModel.AltruaParedeFrente;
            var ParedeFundo = comodoModel.LarguraParedeFundo * comodoModel.AlturaParedeFundo;
            var ParedeEsqueda = comodoModel.LarguraParedeEsquerda * comodoModel.AlturaParedeEsquerda;
            var ParedeDireita = comodoModel.LarguraParedeDireita * comodoModel.AlturaParedeDireita;

            // calculo da area do comodo.
            comodoModel.ConsumoTinta = ParedeFundo + ParedeFrente + ParedeDireita + ParedeEsqueda;
            
            ViewData["result"] = comodoModel.ConsumoTinta;
            
            return View();
        }
    }
}
