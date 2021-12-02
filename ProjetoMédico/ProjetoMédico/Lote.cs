using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMédico
{
    class Lote
    {
        private int id;
        private int qtde;
        private DateTime venc;

        public DateTime Venc { get => venc; set => venc = value; }
        public int Qtde { get => qtde; set => qtde = value; }
        public int Id { get => id; set => id = value; }

        public Lote()
        {
            this.id = 0;
            this.qtde = 0;
            this.venc = DateTime.MinValue;
        }
        public Lote(int id, int qtde, DateTime venc)
        {
            this.id = id;
            this.qtde = qtde;
            this.venc = venc;
        }

        public override string ToString()
        {
            return id + " - " + qtde + " - " + venc.ToString("d");
        }
    }
}
