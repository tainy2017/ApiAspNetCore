using ApiAgendamentos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public interface IGerenciadorEmpresa
    {
        void Editar(Empresa empresaModel);
        void Inserir(Empresa empresaModel);
        Empresa Obter(int idEmpresa);
        bool EmpresaExiste(int id);
        IEnumerable<Empresa> ObterPorNome(string nome);
        IEnumerable<Empresa> ObterTodos();
        void Remover(int idEmpresa);
    }
}
