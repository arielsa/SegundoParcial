using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administradorDeCobros
{
    public class Cliente : ICloneable
    {
        List<Cobro> lc ;
        public string Nombre { get; set; }
        public string Legajo { get; set; } //formato:  B00074791

        public Cliente()
        {
            lc = new List<Cobro>();
        }

        public Cliente(string nombre, string legajo):this()
        {
            Nombre = nombre;
            Legajo = legajo;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public Cliente ClonCliente()
        {
            return RecuCliente(this);
        }

        private Cliente RecuCliente(Cliente pCliente)
        {
            Cliente aux = (Cliente)pCliente.Clone();
            return aux;
        }
        public void AgregarCobro(Cobro pcobro)
        {
            lc.Add(pcobro);
        }
        public List<Cobro> RetornaListaCobro()
        {
            return (
                from c in lc
                select new Cobro(this,c.Codigo,c.Vencimiento,c.Monto,c.Tipo,c.Pendiente,c.PagoAtrasado)
                ).ToList();
        }
        public List<Cobro> RetornaListaCobroOrd(int n )
        {
            //calcular el monto total de los cobros
            lc.ForEach(c => c.CalcularMontoTotal());

            if (n == 1) 
            {
                List<Cobro> aux = lc;
                aux.Sort(new Cobro.MontoDesc());
                return (
                    from c in aux
                    select new Cobro(this, c.Codigo, c.Vencimiento, c.Monto, c.Tipo, c.Pendiente, c.PagoAtrasado)
                    ).ToList();
            }
            else { 
                List<Cobro> aux = lc;
            aux.Sort(new Cobro.MontoAsc());
            return (
                from c in aux
                select new Cobro(this, c.Codigo, c.Vencimiento, c.Monto, c.Tipo, c.Pendiente, c.PagoAtrasado)
                ).ToList();
            }
        }
        public List<Cobro> RetornaLista()
        {
            //lc.Find
            return lc;
        }
        public object RetornarObjetoQueryCobroPendiente()
        {
            var query = (from c in lc
                         where c.Pendiente == true
                         select new
                         {
                             Vencimiento = c.Vencimiento,
                             monto = c.Monto,
                             pendiente = c.Pendiente
                         }).ToArray();
            return query;
        }
        public object RetornarObjetoQueryCobroTodos()
        {
            var query = (from c in lc
                         select new
                         {
                             Vencimiento = c.Vencimiento,
                             monto = c.Monto,
                             pendiente = c.Pendiente
                         }).ToArray();
            return query;
        }
        public void PagarCobro(string pCodigo)
        {
            Cobro aux = lc.Find(c => c.Codigo == pCodigo);
            aux.Pendiente = false;
        }
    }
}
