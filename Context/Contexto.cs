using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PicPay.Mondels;

namespace PicPay.Context
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto>options): base(options){

        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder){
                 modelBuilder.Entity<Transacao>()
            .HasOne(t => t.remetente)
            .WithMany(u => u.TransacoesComoRemetente)
            .HasForeignKey(t => t.RemetenteId)
            .OnDelete(DeleteBehavior.Restrict);

              modelBuilder.Entity<Transacao>()
            .HasOne(t => t.destinatario)
            .WithMany(u => u.TransacoesComoDestinatario)
            .HasForeignKey(t => t.DestinatarioId)
            .OnDelete(DeleteBehavior.Restrict);
         }
    }
}