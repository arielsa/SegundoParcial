using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace administradorDeCobros
{
    //cobros normales y especiales

    //Los cobros cuando se realizan después de la fecha de vencimiento
    //abonan, si son normales un 10% adicional y los especiales un 20% adicional.
    //Los importes calculados por retraso se realizan al momento de recepcionar
    //el pago y deben visualizarse discriminados además del total abonado.
    public class Cobro : ICloneable, IComparable
    {
        //Cliente deudor;
        private DateTime fechaDePago;
      
        public Cliente Deudor { get; set; }
        public string Codigo { get; set; }
        public DateTime Vencimiento { get; set;}
        
        public TipoCobro Tipo { get; set; }
        public bool Pendiente { get; set; }
        public decimal Monto { get; set; }
        
        public bool PagoAtrasado { get; set; }
        public decimal MontoConRecargo { get { return Monto + (Monto * Tipo.adicional()); } }

        public decimal Recargo { get { return Monto * Tipo.adicional(); } }

        private decimal montoTotal;//////////////////////////////////////revisasr ambito

        public event EventHandler<CobroAtrasadoEventArgs> CobroAtrasado;
        public DateTime FechaDePago
        {
            get { return fechaDePago; }
            set 
            { 
                fechaDePago = value; 
                if (fechaDePago > Vencimiento)
                {
                    this.PagoAtrasado = true;
                    CobroAtrasado?.Invoke(this, new CobroAtrasadoEventArgs(Monto,MontoConRecargo,Deudor,Codigo) ); 
                }              
                
                CalcularMontoTotal();
            }
        }
        public Cobro()
        {
            
        }
        public Cobro(Cliente pdeudor , string pcodigo, DateTime pvencimiento, decimal pmonto, TipoCobro ptipo, bool ppendiente, bool ppagoAtrasado)
        {
            Deudor = pdeudor;
            Codigo = pcodigo;
            Vencimiento = pvencimiento;
            Monto = pmonto;
            Tipo = ptipo;
            Pendiente = ppendiente;
            PagoAtrasado = ppagoAtrasado;
        }

        public void CalcularMontoTotal()
        {
            if (PagoAtrasado)
               this.montoTotal = Monto + Recargo;
            else
                
                this.montoTotal = Monto;            
        }

        public object Clone()
        {
            return this.MemberwiseClone();            
        }
        public Cobro ClonCobro()
        {
            return RecuCobro(this);
        }
        public Cobro RecuCobro(Cobro pCobro)
        {
            Cobro aux = (Cobro)pCobro.Clone();
            return aux;
        }

        public int CompareTo(object obj)
        {
           //comparar montos totales
           
          /* Cobro aux = (Cobro)obj;
            if (this.montoTotal > aux.montoTotal)
                return 1;
            else if (this.montoTotal < aux.montoTotal)
                return -1;
            else
                return 0;*/
          throw new NotImplementedException();
            
        }
        public class MontoDesc : IComparer<Cobro>
        {
            public int Compare(Cobro x, Cobro y)
            {
                if (x.montoTotal > y.montoTotal)
                    return -1;
                else if (x.montoTotal < y.montoTotal)
                    return 1;
                else
                    return 0;
            }
        }
        public class MontoAsc : IComparer<Cobro>
        {
            public int Compare(Cobro x, Cobro y)
            {
                if (x.montoTotal > y.montoTotal)
                    return 1;
                else if (x.montoTotal < y.montoTotal)
                    return -1;
                else
                    return 0;
            }
        }

    }
    public abstract class TipoCobro
    {
        public abstract decimal adicional();
    }
    public class CobroNormal : TipoCobro
    {
        public CobroNormal()
        {

        }
        public override decimal adicional()
        {
            return 0.1m;
        }
    }
    public class CobroEspecial : TipoCobro
    {
        public CobroEspecial()
        {

        }
        public override decimal adicional()
        {
            return  0.2m  ;
        }
    }

    public class CobroAtrasadoEventArgs : EventArgs
    {        
        decimal monto, montoConRecargo;
        Cliente cliente;
        string codigo;
        public CobroAtrasadoEventArgs( decimal pmonto, decimal pmontoConRecargo, Cliente pCLiente, string pCodigo)
        {
            monto = pmonto;
            montoConRecargo = pmontoConRecargo;
            cliente = pCLiente;
            codigo = pCodigo;
        }
        public decimal Monto { get { return monto; } }
        public decimal MontoConRecargo { get { return montoConRecargo; } }
        public decimal Recargo { get { return montoConRecargo - monto; } }
        public Cliente Cliente { get { return cliente; } }
        public string Codigo { get { return codigo; } }

    }



}
