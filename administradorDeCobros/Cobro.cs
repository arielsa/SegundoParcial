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

    //no se aceptan pagos parciales
    internal class Cobro : ICloneable
    {
        //Cliente deudor;
        private DateTime fechaDePago;
      
        public Cliente Deudor { get; set; }
        public string Codigo { get; set; }
        public DateTime Vencimiento { get; set;}
        
        public TipoCobro Tipo { get; set; }
        public bool Pendiente { get; set; }
        public decimal Monto { get; set; }
        public decimal MontoConRecargo { get { return Monto + (Monto * Tipo.adicional()); } }

        public decimal Recargo { get { return Monto * Tipo.adicional(); } }

        public event EventHandler<CobroAtrasadoEventArgs> CobroAtrasado;
        public DateTime FechaDePago
        {
            get { return fechaDePago; }
            set 
            { 
                fechaDePago = value; 
                if (fechaDePago > Vencimiento)
                {
                    CobroAtrasado?.Invoke(this, new CobroAtrasadoEventArgs(Monto,MontoConRecargo) ); 
                }
            }
        }



        public Cobro()
        {

        }
        public Cobro(Cliente pdeudor , string pcodigo, DateTime pvencimiento, decimal pmonto, TipoCobro ptipo, bool ppendiente)
        {
            Deudor = pdeudor;
            Codigo = pcodigo;
            Vencimiento = pvencimiento;
            Monto = pmonto;
            Tipo = ptipo;
            Pendiente = ppendiente;
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
        public CobroAtrasadoEventArgs( decimal pmonto, decimal pmontoConRecargo)
        {
            monto = pmonto;
            montoConRecargo = pmontoConRecargo;            
        }
        public decimal Monto { get { return monto; } }
        public decimal MontoConRecargo { get { return montoConRecargo; } }
        public decimal Recargo { get { return montoConRecargo - monto; } }

    }



}
