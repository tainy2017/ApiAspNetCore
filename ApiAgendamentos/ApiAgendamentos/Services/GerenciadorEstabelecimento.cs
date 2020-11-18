using ApiAgendamentos.Models;
using ApiAgendamentos.Persistence;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public class GerenciadorEstabelecimento : IGerenciadorEstabelecimento
    {
        private readonly bancoagendamentoContext _context;

        public GerenciadorEstabelecimento(bancoagendamentoContext context)
        {
            _context = context;
        }
        public void Editar(Models.Estabelecimento estabelecimentoModel)
        {
            try
            {
                Persistence.Estabelecimento tbestabelecimento = new Persistence.Estabelecimento();
                Atribuir(estabelecimentoModel, tbestabelecimento);
                _context.Update(tbestabelecimento);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Estabelecimento não atualizado. Erro de {e.Message}");
            }
        }

        private void Atribuir(Models.Estabelecimento estabelecimentoModel, Persistence.Estabelecimento tbestabelecimento)
        {
            try
            {
                tbestabelecimento.Id = estabelecimentoModel.Id;
                tbestabelecimento.Nome = estabelecimentoModel.Nome; 
            }
            catch (Exception e)
            {
                throw new Exception($"Dados de estabelecimento não atribuidos. Erro {e.Message}");
            }
        }

        public void Inserir(Models.Estabelecimento estabelecimentoModel)
        {
            Persistence.Estabelecimento _tbestabelecimento = new Persistence.Estabelecimento();
            _tbestabelecimento.Id = estabelecimentoModel.Id;
            _tbestabelecimento.Nome = estabelecimentoModel.Nome;
           
            _context.Add(_tbestabelecimento);
            _context.SaveChanges();
        }

        public Models.Estabelecimento Obter(int idEstabelecimento)
        {
            IEnumerable<Models.Estabelecimento> estabelecimentos = GetQuery().Where(estabelecimentoModel => estabelecimentoModel.Id.Equals(idEstabelecimento));
            return estabelecimentos.ElementAtOrDefault(0);
        }

        private IEnumerable<Models.Estabelecimento> GetQuery()
        {
            IQueryable<Persistence.Estabelecimento> tbEstabelecimento = _context.Estabelecimento;
            var query = from estabelecimentoModel in tbEstabelecimento
                        select new Models.Estabelecimento
                        {
                            Id = estabelecimentoModel.Id,
                            Nome = estabelecimentoModel.Nome
                        };
            return query;
        }

        public IEnumerable<Models.Estabelecimento> ObterPorNome(string nome)
        {
            IEnumerable<Models.Estabelecimento> estabelecimentos = GetQuery().Where(estabelecimentoModel => estabelecimentoModel.Nome.StartsWith(nome));
            return estabelecimentos;
        }

        public IEnumerable<Models.Estabelecimento> ObterTodos()
        {
            return GetQuery();
        }
        public bool EstabelecimentoExiste(int id)
        {
            return _context.Estabelecimento.Any(item => item.Id == id);
        }

        public void Remover(int idEstabelecimento)
        {
            var estabelecimento = _context.Estabelecimento.Find(idEstabelecimento);
            _context.Estabelecimento.Remove(estabelecimento);
            _context.SaveChanges();
        }
    }
}
