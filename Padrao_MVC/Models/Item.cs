using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Padrao_MVC.Models
{
    public class Item
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }   

    }
}
