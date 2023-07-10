using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace administradorDeCobros
{
    public class Institucion
    {
        List<Cliente> lcl;
        List<Cobro> lco;

        public Institucion()
        {
            lcl = new List<Cliente>();
            lco = new List<Cobro>();           
        }
        public void AgregarCliente(Cliente pcliente)
        {
            lcl.Add(pcliente.ClonCliente());
        }
        public object RetornaListaCliente()
        {
            var query = (from c in lcl
                        select new
                        {
                            nombre = c.Nombre,
                            legajo = c.Legajo
                        }).ToArray();
            return query;
        }
        public bool VerificarNumLegajo(string pNumLegajo)
        {
            return lcl.Exists(l => l.Legajo == pNumLegajo);
        }
        public bool MaximoDeClientes() 
        {
            int espaciDisponible = (99999 - 10000);
            return lcl.Count == espaciDisponible;
        }
        public void BorrarCliente(string pNumLegajo)
        {
            lcl.RemoveAll(l => l.Legajo == pNumLegajo);
        }

        public void AgregarCobro(Cobro pcobro)
        {
            lco.Add(pcobro);
        }
        public void AgrearCobroACliente(string pNumLegajo, Cobro pcobro)
        {
            Cliente aux = lcl.Find(l => l.Legajo == pNumLegajo);
            aux.AgregarCobro(pcobro);
        }
        public object RetornaListaCobro()
        {
            var query = (from c in lco
                         where c.Pendiente == true
                         select new
                            {
                             codigo = c.Codigo,
                             vencimiento = c.Vencimiento,
                             monto = c.Monto,
                             deudor = c.Deudor.Nombre,
                             legajo = c.Deudor.Legajo
                             } 
                          
                          ).ToArray();
            return query;
        }
        public object RetornaListaDeudaPorCliente(string pLegajo)
        {
            Cliente aux = lcl.Find(l => l.Legajo == pLegajo);

            var query = (from c in aux.RetornaListaCobro()
                         where c.Pendiente == true
                         select new
                            {
                             codigo = c.Codigo,
                             vencimiento = c.Vencimiento,
                             monto = c.Monto,                             
                             legajo = c.Deudor.Legajo
                         }).ToArray();

            return query;
        }

        public Cliente RetornaCliente(string pNumLegajo)
        {
            return lcl.Find(l => l.Legajo == pNumLegajo);
        }
        public bool ValidaCodigoCobro(string pCodigo)
        {
            return lco.Exists(b => b.Codigo == pCodigo);
        }

        public bool FechaVencimientoExistenteParaCliente(string pNumLegajo, DateTime pFechaVencimiento)
        {
            Cliente aux = lcl.Find(l => l.Legajo == pNumLegajo);

            return aux.RetornaListaCobro().Exists(c => c.Vencimiento == pFechaVencimiento);
        }
        public void PagarCobro(string pNumLegajo, string pCodigo)
        {            
            lcl.Find(l => l.Legajo == pNumLegajo).PagarCobro(pCodigo);
            lco.Find(c => c.Codigo == pCodigo).Pendiente = false;
            
            int a = 1;
        }
        public string RetornaLegajoPorCodigo(string pCodigo)
        {
            Cobro aux = lco.Find(c => c.Codigo == pCodigo);
            return aux.Deudor.Legajo;
        }
        public Cobro RetornaCobroPorCodigo(string pCodigo)
        {
            return lco.Find(c => c.Codigo == pCodigo);
        }
        public object RetornaListaPagosPorCliente(string pLegajo)
        {
            Cliente aux = lcl.Find(l => l.Legajo == pLegajo);

            var query = (from c in aux.RetornaListaCobro()
                         where c.Pendiente == false
                         select new
                         {
                             codigo = c.Codigo,
                             //atraso = c.PagoAtrasado.ToString(),
                             vencimiento = c.Vencimiento,
                             monto = c.Monto,
                             recargo = c.PagoAtrasado? c.Recargo:0,
                             total = c.PagoAtrasado? c.Monto + c.Recargo: c.Monto,
                             legajo = c.Deudor.Legajo
                         }).ToArray();

            return query;
        }
        public object RetornaListaPagosPorClienteOrdenados(string pLegajo,int n)
        {
            Cliente aux = lcl.Find(l => l.Legajo == pLegajo);

            var query = (from c in aux.RetornaListaCobroOrd(n)
                         where c.Pendiente == false
                         select new
                         {
                             codigo = c.Codigo,
                             total = c.PagoAtrasado ? c.Monto + c.Recargo : c.Monto,
                             legajo = c.Deudor.Legajo
                         }).ToArray();

            return query;
        }
    }
}
