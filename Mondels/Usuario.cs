using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace PicPay.Mondels
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF {get; set;}
        public string Email { get; set; }
        public string Password { get; set; }
        public float Saldo { get; set; }
        [EnumDataType(typeof(UserType))]
        public UserType userType { get; set; }

        [NotMapped]
         public ICollection<Transacao>? TransacoesComoRemetente { get; set; }   
          [NotMapped]
         public ICollection<Transacao>? TransacoesComoDestinatario { get; set; }
    }
    }
