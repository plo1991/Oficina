using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.ViewModels
{
    public class AgendamentoViewModel
    {
        public AgendamentoViewModel(int id, int idServico, string descricaoServico, int idOficina, string nomeOficina, int idUsuario, string nomeUsuario, DateTime dataAgendamento)
        {
            Id = id;
            IdServico = idServico;
            DescricaoServico = descricaoServico;
            IdOficina = idOficina;
            NomeOficina = nomeOficina;
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            DataAgendamento = dataAgendamento;
        }

        public int Id { get; private set; }
        public int IdServico { get; private set; }
        public string DescricaoServico { get; private set; }
        public int IdOficina { get; private set; }
        public string NomeOficina { get; private set; }
        public int IdUsuario { get; private set; }
        public string NomeUsuario { get; private set; }
        public DateTime DataAgendamento { get; private set; }

    }
}
