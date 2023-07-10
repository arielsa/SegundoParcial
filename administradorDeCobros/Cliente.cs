using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace administradorDeCobros
{
    internal class Cliente : ICloneable
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
                select new Cobro(this,c.Codigo,c.Vencimiento,c.Monto,c.Tipo,c.Pendiente)
                ).ToList();
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
