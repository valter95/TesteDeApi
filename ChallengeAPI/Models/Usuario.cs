using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAPI.Models
{
    public class Usuario
    {
        
        [Key]
        [Required]
        public int IdUsuario { get; set; }
        [Required (ErrorMessage = "Um nome deve ser informado")]
        public string Nome { get; set; }
        [Required (ErrorMessage = "A data de nascimento deve ser informado")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
