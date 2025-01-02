using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PicPay.Service;
using PicPay.Context;
using PicPay.Mondels;

namespace PicPay.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PicPayController: ControllerBase
    {
        private readonly Contexto _context;
        private readonly TransacaoService _transacaoService; 
        public PicPayController(Contexto context, TransacaoService transacaoService)
        {
            _context = context;
            _transacaoService = transacaoService;
        }

         [HttpPost]
        public IActionResult RealizarPagamento(int remetenteId, int destinatarioId, float valor){
        _transacaoService.RealizarTransacao(remetenteId, destinatarioId, valor);
        return Ok("Pagamento realizado com sucesso!");
        }

        [HttpPost("CriarUsuario")]
        public IActionResult CriarUsuario(Usuario usuario){
            _context.Add(usuario);
            _context.SaveChanges();
            return Ok("Usuário criado com sucesso!");

        }

        [HttpGet]
            public IActionResult VeSaldo(int id){
                var usuario = _context.Usuarios.Find(id);
                return Ok("Saldo é "+usuario.Saldo);
            }
}
}

   
