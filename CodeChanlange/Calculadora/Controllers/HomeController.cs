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

                var resultadoFinal = ("o tamanho das portas e janelas não pode ultrapassar 50% da area de parede disponivel");
                ViewData["result"] = resultadoFinal;
            }
            else
            {
                var areaM2 = TotalAreaOcupada - AreaComodo;
                var litros = areaM2 / 5;

                var AreaTotalM2 = ($"Área total a ser pintada tem:{areaM2} M², e será necessário {litros} Litro(s) de tinta");
                ViewData["areaTotalM2"] = AreaTotalM2;

                List<float> result = new();
                float[] latas = { 18.0F, 3.5F, 2.5F, 0.5F };

                if (litros > latas.Min())
                {
                    foreach (var Tamanho in latas)
                    {
                        var quantidadeLatas = Math.Floor((float)(litros / Tamanho));
                        litros %= Tamanho;
                        for (int i = 1; i <= quantidadeLatas; i++)
                        {
                            result.Add(Tamanho);
                        }
                    }
                    if (litros > 0)
                    {
                        result.Add(latas.Min());
                    }
                }
                var resultadoFinal = $" Para pintar a área informada sugerimos que compre {result}latas. ";
                ViewData["result"] = resultadoFinal;
                Console.WriteLine(resultadoFinal);
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