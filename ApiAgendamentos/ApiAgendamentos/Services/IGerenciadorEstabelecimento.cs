using ApiAgendamentos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public interface IGerenciadorEstabelecimento
    {
        void Editar(Estabelecimento estabelecimentoModel);
        void Inserir(Estabelecimento estabelecimentoModel);
        Estabelecimento Obter(int idEstabelecimento);
        bool EstabelecimentoExiste(int id);
        IEnumerable<Estabelecimento> ObterPorNome(string nome);
        IEnumerable<Estabelecimento> ObterTodos();
        void Remover(int idEstabelecimento);
    }
}
