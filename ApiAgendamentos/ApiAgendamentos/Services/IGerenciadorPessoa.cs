using ApiAgendamentos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public interface IGerenciadorPessoa
    {
        void Editar(Pessoa pessoaModel);
        void Inserir(Pessoa pessoaModel);
        Pessoa Obter(int idPessoa);
        bool PessoaExiste(int id);
        IEnumerable<Pessoa> ObterPorNome(string nome);
        IEnumerable<Pessoa> ObterTodos();
        void Remover(int idPessoa);
    }
}
