using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
//libreria para comboBox
using System.Collections;

namespace administradorDeCobros
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            institucion = new Institucion();
        }
        #region ignorar

        private void cobroGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void clienteGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            clienteGrid.MultiSelect = false;
            clienteGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cobroGrid.MultiSelect = false;
            cobroGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cobrosPagadosGrid.MultiSelect = false;
            cobrosPagadosGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            cobrosPagadosOrdGrid.MultiSelect = false;
            cobrosPagadosOrdGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Mostrar(DataGridView dgv, object lista)
        {
            dgv.DataSource = null;
            dgv.DataSource = lista;
        }
        public string GeneradorDeLegajo() // generador de numero de legajo automatico
        {
            //ejemplo de legajo : B00074791-T4
            Random random = new Random();
            int randomNumber = random.Next(10000, 99999);
            int randomNum = random.Next(1, 10);
            string legajo = "B000" + randomNumber.ToString() + "-T" + randomNum.ToString();
            if ((institucion.MaximoDeClientes())) { throw new Exception("espacio para legajos superado"); }

            if (institucion.VerificarNumLegajo(legajo)) 
            {
                GeneradorDeLegajo();
            }
            return legajo;
        }
        public string GeneradorDeCodigo()
        {
            Random random = new Random();
            int randomNumber = random.Next(10, 99);
            char caracterRandom = (char)random.Next('A', 'Z' + 1);
            char caracterRandom2 = (char)random.Next('A', 'Z' + 1);
            string codigo = caracterRandom.ToString() + caracterRandom2.ToString() + randomNumber.ToString();
            if (institucion.ValidaCodigoCobro(codigo))
            {
                GeneradorDeCodigo();
            }
            return codigo;
        }
        public string GeneradorDeNombre()
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 10);
            string[] nombres = new string[] { "juan", "pedro", "maria", "jose", "luis", "carlos", "jorge", "laura", "sofia", "lucia" };
               
            return nombres[randomNumber];
        }
        public decimal GeneradorDeMonto()
        {
            Random random = new Random();
            int randomNumber = random.Next(100, 9999);
            return (decimal)randomNumber;
        }
        Regex rgx;
        Institucion institucion;
        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            //legajo : B00074791-T4
            try
            {
                string numLegajo = GeneradorDeLegajo();
                rgx = new Regex(@"[A-Z]\d{8}-[A-Z]\d");
                numLegajo = Interaction.InputBox("legajo creado por sistema: " + numLegajo, "nuevo legajo", numLegajo);
                
                if (!(rgx.IsMatch(numLegajo) && numLegajo.Length == 12)) throw new Exception("Error de formato");
                if (institucion.VerificarNumLegajo(numLegajo)) throw new Exception("legajo existente");
                
                string nombreSugerido = GeneradorDeNombre();
                string nombre = Interaction.InputBox("nombre: " , "nuevo cliente", nombreSugerido);

                Cliente nuevoCliente = new Cliente(nombre,numLegajo);
                institucion.AgregarCliente(nuevoCliente);

                Mostrar(clienteGrid, institucion.RetornaListaCliente());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }      
        private void btnBajaCliente_Click(object sender, EventArgs e)
        {

            try
            {
                if (clienteGrid.SelectedRows.Count == 0) throw new Exception("seleccione un cliente");
                string numLegajo = clienteGrid.SelectedRows[0].Cells[1].Value.ToString();
                institucion.BorrarCliente(numLegajo);
                Mostrar(clienteGrid, institucion.RetornaListaCliente());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
                
        }
        private void btnModCliente_Click(object sender, EventArgs e)
        {

            try
            {
                if (clienteGrid.SelectedRows.Count == 0) throw new Exception("seleccione un cliente");
                string numLegajo = clienteGrid.SelectedRows[0].Cells[1].Value.ToString();
                string nombre = Interaction.InputBox("nombre: ", "modificar cliente", "juana");
              
                Cliente nuevoCliente = new Cliente(nombre, numLegajo);
                institucion.AgregarCliente(nuevoCliente);
                Mostrar(clienteGrid, institucion.RetornaListaCliente());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void btnAltaCobro_Click(object sender, EventArgs e)
        {//el alta de un cobro es con cliente seleccionado
            try
            {
                if (clienteGrid.SelectedRows.Count == 0) throw new Exception("seleccione un cliente");
                string numLegajo = clienteGrid.SelectedRows[0].Cells[1].Value.ToString();

                decimal decimalSugerido = GeneradorDeMonto();
                string importeIngresado = Interaction.InputBox("ingrese monto. utilice coma(,) o punto(.) para indicar los decimales", "importe","100" /*decimalSugerido.ToString()*/);
                string cadenaNumerica = Regex.Replace(importeIngresado, @"[.]", ",");
                string cadenaNumerica2 = Regex.Replace(cadenaNumerica, @"[^0-9,]", "");
                decimal monto = decimal.Parse(cadenaNumerica2);
                
                DateTime fechaActual = DateTime.Now;
                
                Random random = new Random();
                int randomNumber = random.Next(1, 3);
                DateTime fechaVencida = fechaActual.AddMonths(-1);
                DateTime fechaAVencer = fechaActual.AddMonths(1);
                DateTime fechaVencimiento = fechaAVencer;
                if (randomNumber == 1) { fechaVencimiento = fechaVencida ; }
                
                string fechaVencimientoString = fechaVencimiento.ToString("dd/MM/yyyy");                
                rgx = new Regex(@"\d{2}/\d{2}/\d{4}");

                string fechaString = Interaction.InputBox("fecha: ", "nuevo cobro", fechaVencimientoString);
                if (!(rgx.IsMatch(fechaString) && fechaString.Length == 10)) throw new Exception("Error de formato");
                int dia = int.Parse(fechaString.Substring(0, 2));
                int mes = int.Parse(fechaString.Substring(3, 2)); 
                int anio = int.Parse(fechaString.Substring(6, 4));
                DateTime fecha = new DateTime(anio, mes, dia);

                if (institucion.FechaVencimientoExistenteParaCliente(numLegajo, fecha)) throw new Exception("fecha de vencimiento existente");
                                
                string tipo = Interaction.InputBox("tipo: 1. para normal \n 2. para especial ", "tipo de cobro", "1");
                if (tipo != "1" && tipo != "2") throw new Exception("tipo de cobro incorrecto");
                int tipoInt = int.Parse(tipo);
                
                Cobro nuevoCobro = new Cobro();
                nuevoCobro.Monto = monto;
                nuevoCobro.Vencimiento = fecha;
                nuevoCobro.Pendiente = true;
                if (tipoInt == 1) { nuevoCobro.Tipo = new CobroNormal(); }
                else { nuevoCobro.Tipo = new CobroEspecial(); }
               
                Cliente deudor = institucion.RetornaCliente(numLegajo);
                nuevoCobro.Deudor = deudor;

                string codigoSugerido = GeneradorDeCodigo();
                rgx = new Regex(@"[A-Z][A-Z]{2}\d{2}");
                string codigo = Interaction.InputBox("ingrese codigo.(dos letras mayusculas + dos numeros)\n ej.AD37 \n codigo sugerido:" + codigoSugerido, "codigo de beca", codigoSugerido).ToUpper();
                if (rgx.IsMatch(codigo)) throw new Exception("err de formato");
                if (institucion.ValidaCodigoCobro(codigo)) throw new Exception("codigo existente");
                nuevoCobro.Codigo = codigo;

                institucion.AgrearCobroACliente(numLegajo, nuevoCobro.ClonCobro());
               
                institucion.AgregarCobro(nuevoCobro);

                Mostrar(cobroGrid, institucion.RetornaListaDeudaPorCliente(numLegajo));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void clienteGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (clienteGrid.SelectedRows.Count == 0) throw new Exception();
                string numLegajo = clienteGrid.SelectedRows[0].Cells[1].Value.ToString();
                Mostrar(cobroGrid, institucion.RetornaListaDeudaPorCliente(numLegajo));
                Mostrar(cobrosPagadosGrid, institucion.RetornaListaPagosPorCliente(numLegajo));
            }
            catch (Exception ) {  }

        }
        private void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cobroGrid.SelectedRows.Count == 0) throw new Exception("seleccione un cobro");
                string codigo = cobroGrid.SelectedRows[0].Cells[0].Value.ToString();
                string legajo = institucion.RetornaLegajoPorCodigo(codigo);                

                Cobro c= institucion.RetornaCobroPorCodigo(codigo);
                c.CobroAtrasado += FuncionSuscriptaCobroAtrasado;
                
                DateTime fechaActual = DateTime.Now;
                string fechaActualString = fechaActual.ToString("dd/MM/yyyy");
                rgx = new Regex(@"\d{2}/\d{2}/\d{4}");

                string fechaString = Interaction.InputBox("fecha: ", "nuevo cobro", fechaActualString);
                if (!(rgx.IsMatch(fechaString) && fechaString.Length == 10)) throw new Exception("Error de formato");
                int dia = int.Parse(fechaString.Substring(0, 2));
                int mes = int.Parse(fechaString.Substring(3, 2)); 
                int anio = int.Parse(fechaString.Substring(6, 4));
                DateTime fecha = new DateTime(anio, mes, dia);

                c.FechaDePago = fecha;

                institucion.PagarCobro(legajo, codigo);
                Mostrar(cobroGrid, institucion.RetornaListaDeudaPorCliente(legajo));
                Mostrar(cobrosPagadosGrid, institucion.RetornaListaPagosPorCliente(legajo));               
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void FuncionSuscriptaCobroAtrasado(object sender, CobroAtrasadoEventArgs e)
        {
            MessageBox.Show("cobro atrasado: " + e.Recargo + " de recargo");
            string legajo = e.Cliente.Legajo;
            Cliente deudor = institucion.RetornaCliente(legajo);
            deudor.RetornaLista().Find(c => c.Codigo == e.Codigo).PagoAtrasado = true;

        }
        private void MayorAMenorRB_CheckedChanged(object sender, EventArgs e)
        {      
            try
            {
                if (clienteGrid.SelectedRows.Count == 0) throw new Exception();
                string numLegajo = clienteGrid.SelectedRows[0].Cells[1].Value.ToString();
                Mostrar(cobrosPagadosOrdGrid, institucion.RetornaListaPagosPorClienteOrdenados(numLegajo, 1));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void menorAMayorRB_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (clienteGrid.SelectedRows.Count == 0) throw new Exception();
                string numLegajo = clienteGrid.SelectedRows[0].Cells[1].Value.ToString();
                Mostrar(cobrosPagadosOrdGrid, institucion.RetornaListaPagosPorClienteOrdenados(numLegajo, 0));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
