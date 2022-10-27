using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Core.Entities
{
    public class Agendamento : BaseEntity
    {
        public Agendamento(int idOficina, int idServico,int idUsuario, DateTime dataAgendamento)
        {
            IdOficina = idOficina;
            IdServico = idServico;
            IdUsuario = idUsuario;
            DataAgendamento = dataAgendamento;

        }
        public int IdOficina { get; set; }
        public Oficina Oficina { get; set; }
        public int IdServico { get; set; }
        public Servico Servico { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataAgendamento { get; set; }
        public void Update(int idServico, DateTime dataAgendamento)
        {
            IdServico = idServico;
            DataAgendamento = dataAgendamento;
        }
    }
}
