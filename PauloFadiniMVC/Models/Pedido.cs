using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PauloFadiniMVC.Models
{
    public class Pedido
    {

        [Key]
        [Display(Name = "Código do Pedido")]
        public int idPedido { get; set; }

        [Display(Name = "Nome do Medicamento")]
        [Required(ErrorMessage = "O nome do medicamento é obrigatório.", AllowEmptyStrings = false)]
        public string nomeMedicamento { get; set; }

        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "A quantidade do medicamento é obrigatória.")]
        public int qtdMedicamento { get; set; }

        [Display(Name = "Código do Cliente")]
        [Required(ErrorMessage = "O código do cliente é obrigatório.")]
        public int codCliente { get; set; }

        [Display(Name = "Data de Entrega")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A data de entrega é obrigatória.")]
        public DateTime dataEntrega { get; set; }

    }
}