using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ProjetoMédico
{
    class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public string Laboratorio { get => laboratorio; set => laboratorio = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Id { get => id; set => id = value; }
        internal Queue<Lote> Lotes { get => lotes; set => lotes = value; }

        public Medicamento()
        {
            this.id = 0;
            this.nome = "";
            this.laboratorio = "";
            this.lotes = new Queue<Lote>();
        }
        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            this.lotes = new Queue<Lote>();
        }
        public void Comprar(Lote lote)
        {
            this.lotes.Enqueue(lote);
        }
        public int quantidadeDisponivel()
        {
            int qtde = 0;
            foreach (Lote lote in lotes)
            {
                qtde += lote.Qtde;
            }
            return qtde;
        }
        public bool Vender(int qtde)
        {
            bool vender = false;
            int restante = qtde;

            if (quantidadeDisponivel() < qtde)
            {
                Console.WriteLine("O medicamento veficidado possui apenas" + quantidadeDisponivel() + "unidades, porém possui uma necessidade de venda de" + qtde + "unidades.");
            }
            else
            {
                while (restante > 0)
                {
                    foreach (Lote l in lotes.ToList())
                    {
                        if (l.Qtde > restante)
                        {
                            l.Qtde -= restante;
                            restante = 0;
                        }
                        else
                        {
                            restante -= l.Qtde;
                            l.Qtde = 0;
                            lotes.Dequeue();
                        }
                    }
                }
                vender = true;
            }
            return vender;
        }
        public override string ToString()
        {
            return id + " - " + nome + " - " + laboratorio + " - " + quantidadeDisponivel().ToString();
        }
        public override bool Equals(object obj)
        {
            return this.id.Equals(((Medicamento)obj).id);
        }
        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
