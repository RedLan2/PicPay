using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PicPay.Context;
using PicPay.Mondels;


namespace PicPay.Service
{
    public class TransacaoService
    {
        private readonly Contexto _context;

          public TransacaoService(Contexto context)
    {
            _context = context;
    }

        public void RealizarTransacao(int remetenteId, int destinatarioId, float valor)
        {
          var remetente = _context.Usuarios.Find(remetenteId); 
          var destinatario = _context.Usuarios.Find(destinatarioId);

          if(remetente.userType==UserType.MERCHANT){
              throw new Exception("Lojistas não fazem transferências");
          }

          if(remetente.Saldo<valor){
              throw new Exception("Saldo insuficiente");
          } 
          if(remetente==null || destinatario==null){
              throw new Exception("Usuário não encontrado");
          }
          remetente.Saldo -= valor;
          destinatario.Saldo += valor;
          
          var transacao = new Transacao{
              remetente = remetente,
              destinatario = destinatario,
              valorDaTransacao = valor,
              dataTransacao = DateTime.Now
          };

          _context.Transacoes.Add(transacao);
          _context.SaveChanges();
        }
       
    }
}