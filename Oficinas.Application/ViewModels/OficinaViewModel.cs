using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Application.ViewModels
{
    public class OficinaViewModel
    {
        public OficinaViewModel(int id, string nome, int qtdMaxUnidadeTrabralho, string cnpj)
        {
            Id = id;
            Nome = nome;
            QtdMaxUnidadeTrabralho = qtdMaxUnidadeTrabralho;
            Cnpj = cnpj;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int QtdMaxUnidadeTrabralho { get; private set; }
        public string Cnpj { get; private set; }


    }
}
