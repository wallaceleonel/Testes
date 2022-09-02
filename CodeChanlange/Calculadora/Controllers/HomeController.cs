using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ComodoViewModel comodoViewModel)
        {
            // calculo da area de cada parede.
            var ParedeFrente = comodoViewModel.LarguraParedeFrente * comodoViewModel.AltruaParedeFrente;
            var ParedeFundo = comodoViewModel.LarguraParedeFundo * comodoViewModel.AlturaParedeFundo;
            var ParedeEsqueda = comodoViewModel.LarguraParedeEsquerda * comodoViewModel.AlturaParedeEsquerda;
            var ParedeDireita = comodoViewModel.LarguraParedeDireita * comodoViewModel.AlturaParedeDireita;
            var AreaComodo = ((ParedeDireita + ParedeEsqueda + ParedeFrente + ParedeFundo) / 4);

            // calculando o valor a retirar com janelas e portas 
            // Janela 
            var AreaJanela = 2.00 * 1.20;
            var Janela = comodoViewModel.QtdJanela * AreaJanela;

            // Porta 
            var AreaPorta = 0.80 * 1.90;
            var Porta = comodoViewModel.QtdPorta * AreaPorta;

            var TotalAreaOcupada = Janela + Porta;

            if (TotalAreaOcupada > AreaComodo/2)
            {
                Console.WriteLine("o tamanho das portas e janelas não pode ultrapassar 50% da area de parede disponivel");
            }
            else
            {
                var areaM2 = TotalAreaOcupada - AreaComodo;

                var Litros = areaM2 / 5;
                var Total = Math.Round((decimal)Litros);
                Console.WriteLine("`Sua área total a ser pintada tem: ${TotalM2} M², e será necessário ${total} Litro(s) de tinta`");

                var Latas = (18, 3.6, 2.5, 0.5);
                var result = (0);

                var rest = Total;

                for (value of Latas)
                {
                    var amount = Math.Floor(rest / value);

                    if (amount === 0) continue;
                }
            }
                                                
            ViewData["result"] = comodoViewModel.ConsumoTinta;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}