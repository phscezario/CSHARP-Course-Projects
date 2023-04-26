using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PadraoMVC.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo drescrição é obrigatório")]
        public string Descricao { get; set; }
    }
}
