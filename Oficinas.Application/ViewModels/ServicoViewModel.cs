using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.ViewModels
{
    public class ServicoViewModel
    {
        public ServicoViewModel(int id, int unidadeTrabralho, string descricao)
        {
            Id = id;
            UnidadeTrabralho = unidadeTrabralho;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public int UnidadeTrabralho { get; private set; }
        public string Descricao { get; private set; }
    }
}
