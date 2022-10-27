using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficinas.Core.Entities
{
    public class Oficina : BaseEntity
    {
        public Oficina(string nome, int qtdMaxUnidadeTrabralho, string cnpj)
        {
            Nome = nome;
            QtdMaxUnidadeTrabralho = qtdMaxUnidadeTrabralho;
            Cnpj = cnpj;
        }
        public string Nome { get; private set; }
        public int QtdMaxUnidadeTrabralho { get; private set; }
        public string Cnpj { get; private set; }
        public List<Agendamento> Agendamentos { get; private set; }

        public void Update(string nome, int qtdMaxUnidadeTrabralho, string cnpj)
        {
            Nome = nome;
            QtdMaxUnidadeTrabralho = qtdMaxUnidadeTrabralho;
            Cnpj = cnpj;
        }
    }
}
