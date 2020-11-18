using ApiAgendamentos.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamentos.Services
{
    public interface IGerenciadorOcorrencia
    {
        void Editar(Ocorrencia ocorrenciaModel);
        void Inserir(Ocorrencia ocorrenciaModel);
        Ocorrencia Obter(int idOcorrencia);
        bool OcorrenciaExiste(int id);
        IEnumerable<Ocorrencia> ObterTodos();
        void Remover(int idOcorrencia);
    }
}
