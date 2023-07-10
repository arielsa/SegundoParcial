namespace administradorDeCobros
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPagar = new System.Windows.Forms.Button();
            this.cobroGrid = new System.Windows.Forms.DataGridView();
            this.Cobro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.clienteGrid = new System.Windows.Forms.DataGridView();
            this.btnModCliente = new System.Windows.Forms.Button();
            this.btnBajaCliente = new System.Windows.Forms.Button();
            this.btnAltaCliente = new System.Windows.Forms.Button();
            this.btnAltaCobro = new System.Windows.Forms.Button();
            this.cobrosPagadosGrid = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cobrosPagadosOrdGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cobrosDatosGrid = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.menorAMayorRB = new System.Windows.Forms.RadioButton();
            this.MayorAMenorRB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.cobroGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosPagadosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosPagadosOrdGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosDatosGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPagar
            // 
            this.btnPagar.Location = new System.Drawing.Point(731, 277);
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.Size = new System.Drawing.Size(100, 47);
            this.btnPagar.TabIndex = 0;
            this.btnPagar.Text = "Pagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // cobroGrid
            // 
            this.cobroGrid.AllowUserToAddRows = false;
            this.cobroGrid.AllowUserToDeleteRows = false;
            this.cobroGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cobroGrid.Location = new System.Drawing.Point(715, 23);
            this.cobroGrid.Name = "cobroGrid";
            this.cobroGrid.ReadOnly = true;
            this.cobroGrid.RowHeadersWidth = 62;
            this.cobroGrid.RowTemplate.Height = 28;
            this.cobroGrid.Size = new System.Drawing.Size(697, 233);
            this.cobroGrid.TabIndex = 1;
            this.cobroGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.cobroGrid_RowEnter);
            // 
            // Cobro
            // 
            this.Cobro.AutoSize = true;
            this.Cobro.Location = new System.Drawing.Point(711, 0);
            this.Cobro.Name = "Cobro";
            this.Cobro.Size = new System.Drawing.Size(135, 20);
            this.Cobro.TabIndex = 2;
            this.Cobro.Text = "Cobro pendientes";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente";
            // 
            // clienteGrid
            // 
            this.clienteGrid.AllowUserToAddRows = false;
            this.clienteGrid.AllowUserToDeleteRows = false;
            this.clienteGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clienteGrid.Location = new System.Drawing.Point(25, 23);
            this.clienteGrid.Name = "clienteGrid";
            this.clienteGrid.ReadOnly = true;
            this.clienteGrid.RowHeadersWidth = 62;
            this.clienteGrid.RowTemplate.Height = 28;
            this.clienteGrid.Size = new System.Drawing.Size(436, 233);
            this.clienteGrid.TabIndex = 4;
            this.clienteGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clienteGrid_CellContentClick);
            this.clienteGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.clienteGrid_RowEnter);
            // 
            // btnModCliente
            // 
            this.btnModCliente.Location = new System.Drawing.Point(278, 277);
            this.btnModCliente.Name = "btnModCliente";
            this.btnModCliente.Size = new System.Drawing.Size(100, 47);
            this.btnModCliente.TabIndex = 5;
            this.btnModCliente.Text = "Modificar";
            this.btnModCliente.UseVisualStyleBackColor = true;
            this.btnModCliente.Click += new System.EventHandler(this.btnModCliente_Click);
            // 
            // btnBajaCliente
            // 
            this.btnBajaCliente.Location = new System.Drawing.Point(153, 277);
            this.btnBajaCliente.Name = "btnBajaCliente";
            this.btnBajaCliente.Size = new System.Drawing.Size(100, 47);
            this.btnBajaCliente.TabIndex = 6;
            this.btnBajaCliente.Text = "Baja";
            this.btnBajaCliente.UseVisualStyleBackColor = true;
            this.btnBajaCliente.Click += new System.EventHandler(this.btnBajaCliente_Click);
            // 
            // btnAltaCliente
            // 
            this.btnAltaCliente.Location = new System.Drawing.Point(33, 277);
            this.btnAltaCliente.Name = "btnAltaCliente";
            this.btnAltaCliente.Size = new System.Drawing.Size(100, 47);
            this.btnAltaCliente.TabIndex = 7;
            this.btnAltaCliente.Text = "Alta";
            this.btnAltaCliente.UseVisualStyleBackColor = true;
            this.btnAltaCliente.Click += new System.EventHandler(this.btnAltaCliente_Click);
            // 
            // btnAltaCobro
            // 
            this.btnAltaCobro.Location = new System.Drawing.Point(853, 277);
            this.btnAltaCobro.Name = "btnAltaCobro";
            this.btnAltaCobro.Size = new System.Drawing.Size(100, 47);
            this.btnAltaCobro.TabIndex = 8;
            this.btnAltaCobro.Text = "Alta";
            this.btnAltaCobro.UseVisualStyleBackColor = true;
            this.btnAltaCobro.Click += new System.EventHandler(this.btnAltaCobro_Click);
            // 
            // cobrosPagadosGrid
            // 
            this.cobrosPagadosGrid.AllowUserToAddRows = false;
            this.cobrosPagadosGrid.AllowUserToDeleteRows = false;
            this.cobrosPagadosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cobrosPagadosGrid.Location = new System.Drawing.Point(25, 422);
            this.cobrosPagadosGrid.Name = "cobrosPagadosGrid";
            this.cobrosPagadosGrid.ReadOnly = true;
            this.cobrosPagadosGrid.RowHeadersWidth = 62;
            this.cobrosPagadosGrid.RowTemplate.Height = 28;
            this.cobrosPagadosGrid.Size = new System.Drawing.Size(436, 182);
            this.cobrosPagadosGrid.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 399);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cobros pagados";
            // 
            // cobrosPagadosOrdGrid
            // 
            this.cobrosPagadosOrdGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cobrosPagadosOrdGrid.Location = new System.Drawing.Point(517, 422);
            this.cobrosPagadosOrdGrid.Name = "cobrosPagadosOrdGrid";
            this.cobrosPagadosOrdGrid.RowHeadersWidth = 62;
            this.cobrosPagadosOrdGrid.RowTemplate.Height = 28;
            this.cobrosPagadosOrdGrid.Size = new System.Drawing.Size(461, 182);
            this.cobrosPagadosOrdGrid.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(513, 399);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cobros pagados ordenados";
            // 
            // cobrosDatosGrid
            // 
            this.cobrosDatosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cobrosDatosGrid.Location = new System.Drawing.Point(1026, 422);
            this.cobrosDatosGrid.Name = "cobrosDatosGrid";
            this.cobrosDatosGrid.RowHeadersWidth = 62;
            this.cobrosDatosGrid.RowTemplate.Height = 28;
            this.cobrosDatosGrid.Size = new System.Drawing.Size(436, 182);
            this.cobrosDatosGrid.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1022, 390);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Cobros pagados ordenados";
            // 
            // menorAMayorRB
            // 
            this.menorAMayorRB.AutoSize = true;
            this.menorAMayorRB.Location = new System.Drawing.Point(852, 395);
            this.menorAMayorRB.Name = "menorAMayorRB";
            this.menorAMayorRB.Size = new System.Drawing.Size(122, 24);
            this.menorAMayorRB.TabIndex = 15;
            this.menorAMayorRB.TabStop = true;
            this.menorAMayorRB.Text = "MenorMayor";
            this.menorAMayorRB.UseVisualStyleBackColor = true;
            this.menorAMayorRB.CheckedChanged += new System.EventHandler(this.menorAMayorRB_CheckedChanged);
            // 
            // MayorAMenorRB
            // 
            this.MayorAMenorRB.AutoSize = true;
            this.MayorAMenorRB.Location = new System.Drawing.Point(720, 395);
            this.MayorAMenorRB.Name = "MayorAMenorRB";
            this.MayorAMenorRB.Size = new System.Drawing.Size(122, 24);
            this.MayorAMenorRB.TabIndex = 16;
            this.MayorAMenorRB.TabStop = true;
            this.MayorAMenorRB.Text = "MayorMenor";
            this.MayorAMenorRB.UseVisualStyleBackColor = true;
            this.MayorAMenorRB.CheckedChanged += new System.EventHandler(this.MayorAMenorRB_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 631);
            this.Controls.Add(this.MayorAMenorRB);
            this.Controls.Add(this.menorAMayorRB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cobrosDatosGrid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cobrosPagadosOrdGrid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cobrosPagadosGrid);
            this.Controls.Add(this.btnAltaCobro);
            this.Controls.Add(this.btnAltaCliente);
            this.Controls.Add(this.btnBajaCliente);
            this.Controls.Add(this.btnModCliente);
            this.Controls.Add(this.clienteGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cobro);
            this.Controls.Add(this.cobroGrid);
            this.Controls.Add(this.btnPagar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cobroGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosPagadosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosPagadosOrdGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cobrosDatosGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.DataGridView cobroGrid;
        private System.Windows.Forms.Label Cobro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView clienteGrid;
        private System.Windows.Forms.Button btnModCliente;
        private System.Windows.Forms.Button btnBajaCliente;
        private System.Windows.Forms.Button btnAltaCliente;
        private System.Windows.Forms.Button btnAltaCobro;
        private System.Windows.Forms.DataGridView cobrosPagadosGrid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView cobrosPagadosOrdGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView cobrosDatosGrid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton menorAMayorRB;
        private System.Windows.Forms.RadioButton MayorAMenorRB;
    }
}

