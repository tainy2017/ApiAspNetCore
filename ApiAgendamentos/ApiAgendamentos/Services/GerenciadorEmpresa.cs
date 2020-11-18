using ApiAgendamentos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiAgendamentos.Services
{
    public class GerenciadorEmpresa : IGerenciadorEmpresa
    {
        private readonly bancoagendamentoContext _context;

        public GerenciadorEmpresa(bancoagendamentoContext context)
        {
            _context = context;
        }
        public void Editar(Models.Empresa empresaModel)
        {
            try
            {
                Persistence.Empresa tbempresa = new Persistence.Empresa();
                Atribuir(empresaModel, tbempresa);
                _context.Update(tbempresa);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Empresa não atualizada. Erro de {e.Message}");
            }
        }

        private void Atribuir(Models.Empresa empresaModel, Persistence.Empresa tbempresa)
        {
            try
            {
                tbempresa.Id = empresaModel.Id;
                tbempresa.Nome = empresaModel.Nome;
                tbempresa.Cnpj = empresaModel.Cnpj;
            }
            catch (Exception e)
            {
                throw new Exception($"Dados de empresa não atribuidos. Erro {e.Message}");
            }
        }

        public void Inserir(Models.Empresa empresaModel)
        {
            Persistence.Empresa _tbempresa = new Persistence.Empresa();
            _tbempresa.Id = empresaModel.Id;
            _tbempresa.Nome = empresaModel.Nome;
            _tbempresa.Cnpj = empresaModel.Cnpj;

            _context.Add(_tbempresa);
            _context.SaveChanges();
        }

        public Models.Empresa Obter(int idEmpresa)
        {
            IEnumerable<Models.Empresa> empresas = GetQuery().Where(empresaModel => empresaModel.Id.Equals(idEmpresa));
            return empresas.ElementAtOrDefault(0);
        }

        private IEnumerable<Models.Empresa> GetQuery()
        {
            IQueryable<Persistence.Empresa> tbempresa = _context.Empresa;
            var query = from empresaModel in tbempresa
                        select new Models.Empresa
                        {
                            Id = empresaModel.Id,
                            Nome = empresaModel.Nome,
                            Cnpj = empresaModel.Cnpj
                        };
            return query;
        }

        public IEnumerable<Models.Empresa> ObterPorNome(string nome)
        {
            IEnumerable<Models.Empresa> empresas = GetQuery().Where(empresaModel => empresaModel.Nome.StartsWith(nome));
            return empresas;
        }

        public IEnumerable<Models.Empresa> ObterTodos()
        {
            return GetQuery();
        }
        public bool EmpresaExiste(int id)
        {
            return _context.Empresa.Any(item => item.Id == id);
        }

        public void Remover(int idEmpresa)
        {
            var empresa = _context.Empresa.Find(idEmpresa);
            _context.Empresa.Remove(empresa);
            _context.SaveChanges();
        }
    }
}
