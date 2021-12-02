using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoMédico
{
    class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public List<Medicamento> ListaMedicamentos { get => listaMedicamentos; set => listaMedicamentos = value; }

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }
        public void addMedicamento(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }
        public bool Deletar(Medicamento medicamento)
        {
            bool deletar = false;
            foreach (Medicamento m in listaMedicamentos.ToList())
            {
                if (m.Id.Equals(medicamento.Id))
                {
                    if(m.quantidadeDisponivel() > 0)
                    {
                        Console.WriteLine("Medicamento achado, porém possui apenas" + m.quantidadeDisponivel() + "unidades. Não poderá ser removido.");
                    }
                    else
                    {
                        listaMedicamentos.Remove(medicamento);
                        Console.WriteLine("Medicamento removido !");
                        deletar = true;
                    }
                }
            }
            return deletar;
        }
        public Medicamento Pesquisar(Medicamento medicamento)
        {
            Medicamento medicamentoe = new Medicamento();
            foreach(Medicamento m in listaMedicamentos)
            {
                if (m.Id.Equals(medicamento.Id))
                {
                    medicamentoe = m;
                }
            }
            return medicamentoe;
        }
    }

}
