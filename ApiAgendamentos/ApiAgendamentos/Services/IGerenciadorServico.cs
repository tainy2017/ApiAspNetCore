using ApiAgendamentos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public interface IGerenciadorServico
    {
        void Editar(Servico servicoModel);
        void Inserir(Servico servicoModel);
        bool ServicoExiste(int id);
        Servico Obter(int idServico);
        IEnumerable<Servico> ObterPorNome(string nome);
        IEnumerable<Servico> ObterTodos();
        void Remover(int idServico);
    }
}
