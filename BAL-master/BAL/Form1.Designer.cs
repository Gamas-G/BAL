namespace BAL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBoxPalabra = new System.Windows.Forms.TextBox();
            this.Buscar = new System.Windows.Forms.Button();
            this.labelTextNumUnidades = new System.Windows.Forms.Label();
            this.NumUnidades = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMensjaeEspere = new System.Windows.Forms.Label();
            this.labelUnidad = new System.Windows.Forms.Label();
            this.labelTrabajandoSobreUni = new System.Windows.Forms.Label();
            this.progressBarArchivos = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxInfProceso = new System.Windows.Forms.GroupBox();
            this.labelContador = new System.Windows.Forms.Label();
            this.dataGridViewArchivos = new System.Windows.Forms.DataGridView();
            this.ColumnPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastModif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelNumErr = new System.Windows.Forms.Label();
            this.listBoxAdvertencias = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonSalir = new System.Windows.Forms.Button();
            this.ButtonLimpiar = new System.Windows.Forms.Button();
            this.groupBoxInfProceso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchivos)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPalabra
            // 
            this.textBoxPalabra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPalabra.Location = new System.Drawing.Point(23, 58);
            this.textBoxPalabra.Name = "textBoxPalabra";
            this.textBoxPalabra.Size = new System.Drawing.Size(178, 26);
            this.textBoxPalabra.TabIndex = 0;
            // 
            // Buscar
            // 
            this.Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Buscar.Location = new System.Drawing.Point(224, 58);
            this.Buscar.Name = "Buscar";
            this.Buscar.Size = new System.Drawing.Size(75, 26);
            this.Buscar.TabIndex = 1;
            this.Buscar.Text = "Buscar";
            this.Buscar.UseVisualStyleBackColor = true;
            this.Buscar.Click += new System.EventHandler(this.Buscar_Click);
            // 
            // labelTextNumUnidades
            // 
            this.labelTextNumUnidades.AutoSize = true;
            this.labelTextNumUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextNumUnidades.Location = new System.Drawing.Point(323, 58);
            this.labelTextNumUnidades.Name = "labelTextNumUnidades";
            this.labelTextNumUnidades.Size = new System.Drawing.Size(128, 15);
            this.labelTextNumUnidades.TabIndex = 2;
            this.labelTextNumUnidades.Text = "Unidades Detectadas:";
            // 
            // NumUnidades
            // 
            this.NumUnidades.AutoSize = true;
            this.NumUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumUnidades.Location = new System.Drawing.Point(457, 58);
            this.NumUnidades.Name = "NumUnidades";
            this.NumUnidades.Size = new System.Drawing.Size(14, 15);
            this.NumUnidades.TabIndex = 3;
            this.NumUnidades.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Palabra a Buscar";
            // 
            // labelMensjaeEspere
            // 
            this.labelMensjaeEspere.AutoSize = true;
            this.labelMensjaeEspere.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelMensjaeEspere.Location = new System.Drawing.Point(3, 18);
            this.labelMensjaeEspere.Name = "labelMensjaeEspere";
            this.labelMensjaeEspere.Size = new System.Drawing.Size(318, 16);
            this.labelMensjaeEspere.TabIndex = 6;
            this.labelMensjaeEspere.Text = "PREPARANDO EL EQUIPO, ESPERE POR FAVOR";
            // 
            // labelUnidad
            // 
            this.labelUnidad.AutoSize = true;
            this.labelUnidad.Location = new System.Drawing.Point(193, 46);
            this.labelUnidad.Name = "labelUnidad";
            this.labelUnidad.Size = new System.Drawing.Size(45, 16);
            this.labelUnidad.TabIndex = 7;
            this.labelUnidad.Text = "label2";
            this.labelUnidad.Visible = false;
            // 
            // labelTrabajandoSobreUni
            // 
            this.labelTrabajandoSobreUni.AutoSize = true;
            this.labelTrabajandoSobreUni.Location = new System.Drawing.Point(6, 46);
            this.labelTrabajandoSobreUni.Name = "labelTrabajandoSobreUni";
            this.labelTrabajandoSobreUni.Size = new System.Drawing.Size(181, 16);
            this.labelTrabajandoSobreUni.TabIndex = 8;
            this.labelTrabajandoSobreUni.Text = "Trabajando sobre la Unidad:";
            this.labelTrabajandoSobreUni.Visible = false;
            // 
            // progressBarArchivos
            // 
            this.progressBarArchivos.Location = new System.Drawing.Point(6, 77);
            this.progressBarArchivos.Name = "progressBarArchivos";
            this.progressBarArchivos.Size = new System.Drawing.Size(470, 54);
            this.progressBarArchivos.TabIndex = 9;
            this.progressBarArchivos.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Coincidencias:";
            // 
            // groupBoxInfProceso
            // 
            this.groupBoxInfProceso.Controls.Add(this.labelTrabajandoSobreUni);
            this.groupBoxInfProceso.Controls.Add(this.labelMensjaeEspere);
            this.groupBoxInfProceso.Controls.Add(this.labelUnidad);
            this.groupBoxInfProceso.Controls.Add(this.progressBarArchivos);
            this.groupBoxInfProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxInfProceso.Location = new System.Drawing.Point(26, 94);
            this.groupBoxInfProceso.Name = "groupBoxInfProceso";
            this.groupBoxInfProceso.Size = new System.Drawing.Size(502, 148);
            this.groupBoxInfProceso.TabIndex = 11;
            this.groupBoxInfProceso.TabStop = false;
            this.groupBoxInfProceso.Text = "Proceso";
            this.groupBoxInfProceso.Visible = false;
            // 
            // labelContador
            // 
            this.labelContador.AutoSize = true;
            this.labelContador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContador.Location = new System.Drawing.Point(125, 273);
            this.labelContador.Name = "labelContador";
            this.labelContador.Size = new System.Drawing.Size(15, 16);
            this.labelContador.TabIndex = 12;
            this.labelContador.Text = "0";
            // 
            // dataGridViewArchivos
            // 
            this.dataGridViewArchivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewArchivos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewArchivos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewArchivos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewArchivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewArchivos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPath,
            this.ColumnInf,
            this.ColumnCreacion,
            this.ColumnLastModif,
            this.ColumnType});
            this.dataGridViewArchivos.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewArchivos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewArchivos.Location = new System.Drawing.Point(0, 309);
            this.dataGridViewArchivos.Name = "dataGridViewArchivos";
            this.dataGridViewArchivos.ReadOnly = true;
            this.dataGridViewArchivos.RowHeadersVisible = false;
            this.dataGridViewArchivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewArchivos.Size = new System.Drawing.Size(1433, 438);
            this.dataGridViewArchivos.TabIndex = 13;
            this.dataGridViewArchivos.TabStop = false;
            this.dataGridViewArchivos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewArchivos_CellDoubleClick);
            // 
            // ColumnPath
            // 
            this.ColumnPath.HeaderText = "Ruta del Archivo";
            this.ColumnPath.Name = "ColumnPath";
            this.ColumnPath.ReadOnly = true;
            this.ColumnPath.Visible = false;
            this.ColumnPath.Width = 112;
            // 
            // ColumnInf
            // 
            this.ColumnInf.HeaderText = "Contenido";
            this.ColumnInf.Name = "ColumnInf";
            this.ColumnInf.ReadOnly = true;
            this.ColumnInf.Visible = false;
            this.ColumnInf.Width = 75;
            // 
            // ColumnCreacion
            // 
            this.ColumnCreacion.HeaderText = "Creacion";
            this.ColumnCreacion.Name = "ColumnCreacion";
            this.ColumnCreacion.ReadOnly = true;
            this.ColumnCreacion.Visible = false;
            this.ColumnCreacion.Width = 68;
            // 
            // ColumnLastModif
            // 
            this.ColumnLastModif.HeaderText = "Ult.Modificación";
            this.ColumnLastModif.Name = "ColumnLastModif";
            this.ColumnLastModif.ReadOnly = true;
            this.ColumnLastModif.Visible = false;
            this.ColumnLastModif.Width = 109;
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "Tipo";
            this.ColumnType.Name = "ColumnType";
            this.ColumnType.ReadOnly = true;
            this.ColumnType.Visible = false;
            this.ColumnType.Width = 42;
            // 
            // labelNumErr
            // 
            this.labelNumErr.AutoSize = true;
            this.labelNumErr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumErr.Location = new System.Drawing.Point(564, 37);
            this.labelNumErr.Name = "labelNumErr";
            this.labelNumErr.Size = new System.Drawing.Size(210, 15);
            this.labelNumErr.TabIndex = 14;
            this.labelNumErr.Text = "Problemas en los siguientes Archivos";
            // 
            // listBoxAdvertencias
            // 
            this.listBoxAdvertencias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxAdvertencias.FormattingEnabled = true;
            this.listBoxAdvertencias.HorizontalScrollbar = true;
            this.listBoxAdvertencias.ItemHeight = 15;
            this.listBoxAdvertencias.Location = new System.Drawing.Point(567, 61);
            this.listBoxAdvertencias.Name = "listBoxAdvertencias";
            this.listBoxAdvertencias.Size = new System.Drawing.Size(798, 199);
            this.listBoxAdvertencias.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 747);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1433, 31);
            this.panel1.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Programa creado por: Ing. Gamas";
            // 
            // ButtonSalir
            // 
            this.ButtonSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSalir.Location = new System.Drawing.Point(1346, 0);
            this.ButtonSalir.Name = "ButtonSalir";
            this.ButtonSalir.Size = new System.Drawing.Size(87, 34);
            this.ButtonSalir.TabIndex = 18;
            this.ButtonSalir.Text = "Salir";
            this.ButtonSalir.UseVisualStyleBackColor = true;
            this.ButtonSalir.Click += new System.EventHandler(this.ButtonSalir_Click);
            // 
            // ButtonLimpiar
            // 
            this.ButtonLimpiar.Location = new System.Drawing.Point(1120, 266);
            this.ButtonLimpiar.Name = "ButtonLimpiar";
            this.ButtonLimpiar.Size = new System.Drawing.Size(205, 37);
            this.ButtonLimpiar.TabIndex = 19;
            this.ButtonLimpiar.Text = "Limpiar";
            this.ButtonLimpiar.UseVisualStyleBackColor = true;
            this.ButtonLimpiar.Click += new System.EventHandler(this.ButtonLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1433, 778);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridViewArchivos);
            this.Controls.Add(this.ButtonLimpiar);
            this.Controls.Add(this.ButtonSalir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBoxAdvertencias);
            this.Controls.Add(this.labelNumErr);
            this.Controls.Add(this.labelContador);
            this.Controls.Add(this.groupBoxInfProceso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumUnidades);
            this.Controls.Add(this.labelTextNumUnidades);
            this.Controls.Add(this.Buscar);
            this.Controls.Add(this.textBoxPalabra);
            this.MaximumSize = new System.Drawing.Size(1449, 817);
            this.MinimumSize = new System.Drawing.Size(1449, 817);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Buscador";
            this.groupBoxInfProceso.ResumeLayout(false);
            this.groupBoxInfProceso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewArchivos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPalabra;
        private System.Windows.Forms.Button Buscar;
        private System.Windows.Forms.Label labelTextNumUnidades;
        private System.Windows.Forms.Label NumUnidades;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMensjaeEspere;
        private System.Windows.Forms.Label labelUnidad;
        private System.Windows.Forms.Label labelTrabajandoSobreUni;
        private System.Windows.Forms.ProgressBar progressBarArchivos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxInfProceso;
        private System.Windows.Forms.Label labelContador;
        private System.Windows.Forms.DataGridView dataGridViewArchivos;
        private System.Windows.Forms.Label labelNumErr;
        private System.Windows.Forms.ListBox listBoxAdvertencias;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button ButtonSalir;
        private System.Windows.Forms.Button ButtonLimpiar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInf;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastModif;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
    }
}

