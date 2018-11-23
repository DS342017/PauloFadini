using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data;


namespace PauloFadiniAPI.Models
{
    public class Pedido
    {
        [Key]
        public int idPedido { get; set; }
        public string nomeMedicamento { get; set; }
        public int qtdMedicamento { get; set; }
        public int codCliente { get; set; }
        public DateTime dataEntrega { get; set; }
    }
}