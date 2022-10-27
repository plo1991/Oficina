using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Core.Entities
{
    public class Servico: BaseEntity
    {
        public Servico(int unidadeTrabralho, string descricao)
        {
            UnidadeTrabralho = unidadeTrabralho;
            Descricao = descricao;
        }
        public int UnidadeTrabralho { get; private set; }
        public string Descricao { get; private set; }
        public List<Agendamento> Agendamentos { get; private set; }

        public void Update(int unidadeTrabralho, string descricao) 
        {
            UnidadeTrabralho = unidadeTrabralho;
            Descricao = descricao;
        }
    }
}
