using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;

namespace PicPay.Mondels
{
    public class Transacao
    {
        [Key]
        public int Id { get; set; }
        public float valorDaTransacao { get; set; }

        [ForeignKey("Remetente")]
         public int RemetenteId { get; set; }
         [NotMapped]
        public Usuario? remetente { get; set; }

        [ForeignKey("Destinatario")]
        public int DestinatarioId { get; set; }
        [NotMapped]
        public Usuario? destinatario {get; set;}

        public DateTime dataTransacao { get; set; }
    }
}