using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using SalesWebMVC.Services;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        //Primeiro é declarada um dependência para o SellerService
        private readonly SellerService _sellerService;

        //Construtor, que vai injetar a dependência
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }
        
        //OBS: IActionResult é o tipo de retorno de todas as ações

        //Esse método Index irá chamar a operação FindAll que está no SellerService
        public IActionResult Index()
        {
            //Retorna uma lista de Seller
            var list = _sellerService.FindAll();
            
            /*A list é passada como argumento no método View, para que ele gere um IActionResult contendo a lista
            MVC: O controlador foi chamado, ele acessou o Model, pegou os dados na lista e encaminhou para a View*/
            return View(list);

            //Em seguida à essa implementação será implementada na página Index um código de template para mostrar os vendedores na tela
        }

        public IActionResult Create()
        {
            return View();
        }

        /*Essa operação vai receber um objeto vendedor que veio na requisição. 
        Basta inseri-lo como parâmetro, o framework irá entender e o fará automaticamente.*/
        
        [HttpPost] //Indica que essa operação será de Post, e não de Get
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller); //Uma vez inserido o seller no banco de dados, a requisição será redirecionada para a ação Index, implementação abaixo
            return RedirectToAction(nameof(Index));
        }
    }
}
