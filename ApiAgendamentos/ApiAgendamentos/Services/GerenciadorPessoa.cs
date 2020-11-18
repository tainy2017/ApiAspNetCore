using ApiAgendamentos.Models;
using ApiAgendamentos.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public class GerenciadorPessoa : IGerenciadorPessoa
    {
        private readonly bancoagendamentoContext _context;

        public GerenciadorPessoa(bancoagendamentoContext context)
        {
            _context = context;
        }
        public void Editar(Models.Pessoa pessoaModel)
        {
            try
            {
                Persistence.Pessoa tbpessoa = new Persistence.Pessoa();
                Atribuir(pessoaModel, tbpessoa);
                _context.Update(tbpessoa);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception($"Dados de pessoa não atualizados. Erro de {e.Message}");
            }
        }

        private void Atribuir(Models.Pessoa pessoaModel, Persistence.Pessoa tbpessoa)
        {
            try
            {
                tbpessoa.Id = pessoaModel.Id;
                tbpessoa.Nome = pessoaModel.Nome;
                tbpessoa.Cpf = pessoaModel.Cpf;
                tbpessoa.DataNascimento = pessoaModel.Data_Nascimento;
                tbpessoa.Cargo = pessoaModel.Cargo;
                tbpessoa.IdEstabelecimento = pessoaModel.Id_Estabelecimento;
                tbpessoa.IdFuncionario = pessoaModel.Id_Funcionario;
                tbpessoa.Rua = pessoaModel.Rua;
                tbpessoa.Bairro = pessoaModel.Bairro;
                tbpessoa.Numero = pessoaModel.Numero;
                tbpessoa.Complemento = pessoaModel.Complemento; 
                tbpessoa.Estado = pessoaModel.Estado;
                tbpessoa.Telefone1 = pessoaModel.Telefone1;
                tbpessoa.Telefone2 = pessoaModel.Telefone2;
            }
            catch (Exception e)
            {
                throw new Exception($"Dados de pessoa não atribuidos. Erro {e.Message}");
            }
        }

        public void Inserir(Models.Pessoa pessoaModel)
        {
            Persistence.Pessoa _tbpessoa = new Persistence.Pessoa();
            _tbpessoa.Id = pessoaModel.Id;
            _tbpessoa.Nome = pessoaModel.Nome;
            _tbpessoa.Cpf = pessoaModel.Cpf;
            _tbpessoa.DataNascimento = pessoaModel.Data_Nascimento;
            _tbpessoa.Cargo = pessoaModel.Cargo;
            _tbpessoa.IdEstabelecimento = pessoaModel.Id_Estabelecimento;
            _tbpessoa.IdFuncionario = pessoaModel.Id_Funcionario;
            _tbpessoa.Rua = pessoaModel.Rua;
            _tbpessoa.Bairro = pessoaModel.Bairro;
            _tbpessoa.Numero = pessoaModel.Numero;
            _tbpessoa.Complemento = pessoaModel.Complemento;
            _tbpessoa.Estado = pessoaModel.Estado;
            _tbpessoa.Telefone1 = pessoaModel.Telefone1;
            _tbpessoa.Telefone2 = pessoaModel.Telefone2;

            _context.Add(_tbpessoa);
            _context.SaveChanges();
        }

        public Models.Pessoa Obter(int idPessoa)
        {
            IEnumerable<Models.Pessoa> pessoas = GetQuery().Where(pessoaModel => pessoaModel.Id.Equals(idPessoa));
            return pessoas.ElementAtOrDefault(0);
        }

        private IEnumerable<Models.Pessoa> GetQuery()
        {
            IQueryable<Persistence.Pessoa> tbpessoa = _context.Pessoa;
            var query = from pessoaModel in tbpessoa
                        select new Models.Pessoa
                        {
                            Id = pessoaModel.Id,
                            Nome = pessoaModel.Nome,
                            Cpf = pessoaModel.Cpf,
                            Data_Nascimento = pessoaModel.DataNascimento,
                            Cargo = pessoaModel.Cargo,
                            Id_Estabelecimento = pessoaModel.IdEstabelecimento,
                            Id_Funcionario = pessoaModel.IdFuncionario,
                            Rua = pessoaModel.Rua,
                            Bairro = pessoaModel.Bairro,
                            Numero = pessoaModel.Numero,
                            Complemento = pessoaModel.Complemento,
                            Estado = pessoaModel.Estado,
                            Telefone1 = pessoaModel.Telefone1,
                            Telefone2 = pessoaModel.Telefone2
        };
            return query;
        }

        public IEnumerable<Models.Pessoa> ObterPorNome(string nome)
        {
            IEnumerable<Models.Pessoa> pessoas = GetQuery().Where(pessoaModel => pessoaModel.Nome.StartsWith(nome));
            return pessoas;
        }

        public IEnumerable<Models.Pessoa> ObterTodos()
        {
            return GetQuery();
        }
        public bool PessoaExiste(int id)
        {
            return _context.Pessoa.Any(item => item.Id == id);
        }
        public void Remover(int idPessoa)
        {
            var pessoa = _context.Pessoa.Find(idPessoa);
            _context.Pessoa.Remove(pessoa);
            _context.SaveChanges();
        }
    }
}
