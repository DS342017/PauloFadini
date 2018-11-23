using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PauloFadiniMVC.Models;

namespace PauloFadiniMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //Instanciando PedidoList que é uma lista do Modelo <Pedido>
            List<Pedido> PedidoList = new List<Pedido>();
            //Instanciando a conexão com o controlador Pediod do Projeto API
            HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Pedidoes").Result;
            //Passando os resultados do modelo do Projeto API para o TicketList
            PedidoList.AddRange(response.Content.ReadAsAsync<List<Pedido>>().Result);
            //Retornando Valores
            return View(PedidoList);
        }

        //Criamos um item para receber id = 0
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                //Retornamos o MVC
                return View(new Pedido());
            }
            else
            {
                //diferente do método de inserçao que é por POST, vamos usar o GET para solicitar os dados atuais 
                HttpResponseMessage response = GlobalVariable.WebApiClient.GetAsync("Pedidoes/" + id.ToString()).Result;
                //retorna para view os resultados
                return View(response.Content.ReadAsAsync<Pedido>().Result);
            }


        }

        //Neste debaixo declamos que pode ser requistado por POST
        [HttpPost]
        public ActionResult AddOrEdit(Models.Pedido pedido)
        {
            //Nesse segundo método é onde modifica os dados, verificamos agora se o IdTicket é 0(Ou seja vazio para a criação)
            if (pedido.idPedido == 0)
            {
                //insere os dados
                HttpResponseMessage response = GlobalVariable.WebApiClient.PostAsJsonAsync("Pedidoes", pedido).Result;
                //Chama a index
                return RedirectToAction("Index");
            }
            else
            {
                //Atualiza os dados quando houver um IdTicket diferente de zero
                HttpResponseMessage response = GlobalVariable.WebApiClient.PutAsJsonAsync("Pedidoes/" + pedido.idPedido, pedido).Result;
                //chama a index
                return RedirectToAction("Index");
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariable.WebApiClient.DeleteAsync("Pedidoes/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

    }
}
