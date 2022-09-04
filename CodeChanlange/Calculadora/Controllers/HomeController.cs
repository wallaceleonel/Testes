using Calculadora.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using System.Linq;
using System.Text.RegularExpressions;
using System;

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

            if (TotalAreaOcupada > AreaComodo / 2)
            {
                Console.WriteLine("o tamanho das portas e janelas não pode ultrapassar 50% da area de parede disponivel");
            }
            else
            {
                var areaM2 = TotalAreaOcupada - AreaComodo;

                var litros = areaM2 / 5;
                var total = litros;
                Console.WriteLine("`Sua área total a ser pintada tem: ${TotalM2} M², e será necessário ${total} Litro(s) de tinta`");

                List<float> result = new List<float>();
                float[] Latas = { 18.0F, 3.5F, 2.5F, 0.5F };

                if (total > Latas.Min())
                {
                    foreach (var Tamanho in Latas)
                    {
                        var quantidadeLatas = Math.Floor((float)(total / Tamanho));
                        total = total % Tamanho;
                        for (int i = 1; i <= quantidadeLatas; i++)
                        {
                            result.Add(Tamanho);
                        }
                    }

                    if (total > 0)
                    {
                        result.Add(Latas.Min());
                    }
                }
                var resultadoFinal = $" para pintar  a área informada sugerimos que compre {result} ";
                result = comodoViewModel.ConsumoTinta;

                ViewData["result"] = comodoViewModel.ConsumoTinta;
            }
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