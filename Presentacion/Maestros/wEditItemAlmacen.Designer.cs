namespace Presentacion.Maestros
{
    partial class wEditItemAlmacen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCodAlm = new System.Windows.Forms.Label();
            this.cmbCodAlm = new System.Windows.Forms.ComboBox();
            this.lblCodIteAlm = new System.Windows.Forms.Label();
            this.txtCodIteAlm = new System.Windows.Forms.TextBox();
            this.lblDesIteAlm = new System.Windows.Forms.Label();
            this.txtDesIteAlm = new System.Windows.Forms.TextBox();
            this.lblCUniMed = new System.Windows.Forms.Label();
            this.cmbCUniMed = new System.Windows.Forms.ComboBox();
            this.lblCEstIteAlm = new System.Windows.Forms.Label();
            this.cmbCEstIteAlm = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCodAlm
            // 
            this.lblCodAlm.AutoSize = true;
            this.lblCodAlm.Location = new System.Drawing.Point(28, 72);
            this.lblCodAlm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodAlm.Name = "lblCodAlm";
            this.lblCodAlm.Size = new System.Drawing.Size(62, 18);
            this.lblCodAlm.TabIndex = 0;
            this.lblCodAlm.Text = "Almacen";
            // 
            // cmbCodAlm
            // 
            this.cmbCodAlm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodAlm.FormattingEnabled = true;
            this.cmbCodAlm.Location = new System.Drawing.Point(175, 72);
            this.cmbCodAlm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCodAlm.Name = "cmbCodAlm";
            this.cmbCodAlm.Size = new System.Drawing.Size(263, 26);
            this.cmbCodAlm.TabIndex = 1;
            // 
            // lblCodIteAlm
            // 
            this.lblCodIteAlm.AutoSize = true;
            this.lblCodIteAlm.Location = new System.Drawing.Point(28, 106);
            this.lblCodIteAlm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodIteAlm.Name = "lblCodIteAlm";
            this.lblCodIteAlm.Size = new System.Drawing.Size(51, 18);
            this.lblCodIteAlm.TabIndex = 2;
            this.lblCodIteAlm.Text = "Codigo";
            // 
            // txtCodIteAlm
            // 
            this.txtCodIteAlm.Location = new System.Drawing.Point(175, 106);
            this.txtCodIteAlm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodIteAlm.Name = "txtCodIteAlm";
            this.txtCodIteAlm.Size = new System.Drawing.Size(132, 26);
            this.txtCodIteAlm.TabIndex = 3;
            this.txtCodIteAlm.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodIteAlm_Validating);
            // 
            // lblDesIteAlm
            // 
            this.lblDesIteAlm.AutoSize = true;
            this.lblDesIteAlm.Location = new System.Drawing.Point(28, 140);
            this.lblDesIteAlm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDesIteAlm.Name = "lblDesIteAlm";
            this.lblDesIteAlm.Size = new System.Drawing.Size(80, 18);
            this.lblDesIteAlm.TabIndex = 4;
            this.lblDesIteAlm.Text = "Descripcion";
            // 
            // txtDesIteAlm
            // 
            this.txtDesIteAlm.Location = new System.Drawing.Point(175, 140);
            this.txtDesIteAlm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDesIteAlm.Name = "txtDesIteAlm";
            this.txtDesIteAlm.Size = new System.Drawing.Size(457, 26);
            this.txtDesIteAlm.TabIndex = 5;
            // 
            // lblCUniMed
            // 
            this.lblCUniMed.AutoSize = true;
            this.lblCUniMed.Location = new System.Drawing.Point(28, 174);
            this.lblCUniMed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCUniMed.Name = "lblCUniMed";
            this.lblCUniMed.Size = new System.Drawing.Size(61, 18);
            this.lblCUniMed.TabIndex = 6;
            this.lblCUniMed.Text = "Uni.Med";
            // 
            // cmbCUniMed
            // 
            this.cmbCUniMed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCUniMed.FormattingEnabled = true;
            this.cmbCUniMed.Location = new System.Drawing.Point(175, 174);
            this.cmbCUniMed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCUniMed.Name = "cmbCUniMed";
            this.cmbCUniMed.Size = new System.Drawing.Size(132, 26);
            this.cmbCUniMed.TabIndex = 7;
            // 
            // lblCEstIteAlm
            // 
            this.lblCEstIteAlm.AutoSize = true;
            this.lblCEstIteAlm.Location = new System.Drawing.Point(28, 208);
            this.lblCEstIteAlm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCEstIteAlm.Name = "lblCEstIteAlm";
            this.lblCEstIteAlm.Size = new System.Drawing.Size(49, 18);
            this.lblCEstIteAlm.TabIndex = 8;
            this.lblCEstIteAlm.Text = "Estado";
            // 
            // cmbCEstIteAlm
            // 
            this.cmbCEstIteAlm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCEstIteAlm.FormattingEnabled = true;
            this.cmbCEstIteAlm.Location = new System.Drawing.Point(175, 208);
            this.cmbCEstIteAlm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbCEstIteAlm.Name = "cmbCEstIteAlm";
            this.cmbCEstIteAlm.Size = new System.Drawing.Size(132, 26);
            this.cmbCEstIteAlm.TabIndex = 9;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(29, 41);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(605, 19);
            this.label21.TabIndex = 81;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(337, 246);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 32);
            this.btnAceptar.TabIndex = 83;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(489, 246);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(145, 32);
            this.btnCancelar.TabIndex = 82;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // wEditItemAlmacen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 301);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.cmbCEstIteAlm);
            this.Controls.Add(this.lblCEstIteAlm);
            this.Controls.Add(this.cmbCUniMed);
            this.Controls.Add(this.lblCUniMed);
            this.Controls.Add(this.txtDesIteAlm);
            this.Controls.Add(this.lblDesIteAlm);
            this.Controls.Add(this.txtCodIteAlm);
            this.Controls.Add(this.lblCodIteAlm);
            this.Controls.Add(this.cmbCodAlm);
            this.Controls.Add(this.lblCodAlm);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "wEditItemAlmacen";
            this.Text = "Editar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditItemAlmacen_FormClosing);
            this.Controls.SetChildIndex(this.lblCodAlm, 0);
            this.Controls.SetChildIndex(this.cmbCodAlm, 0);
            this.Controls.SetChildIndex(this.lblCodIteAlm, 0);
            this.Controls.SetChildIndex(this.txtCodIteAlm, 0);
            this.Controls.SetChildIndex(this.lblDesIteAlm, 0);
            this.Controls.SetChildIndex(this.txtDesIteAlm, 0);
            this.Controls.SetChildIndex(this.lblCUniMed, 0);
            this.Controls.SetChildIndex(this.cmbCUniMed, 0);
            this.Controls.SetChildIndex(this.lblCEstIteAlm, 0);
            this.Controls.SetChildIndex(this.cmbCEstIteAlm, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodAlm;
        private System.Windows.Forms.ComboBox cmbCodAlm;
        private System.Windows.Forms.Label lblCodIteAlm;
        private System.Windows.Forms.TextBox txtCodIteAlm;
        private System.Windows.Forms.Label lblDesIteAlm;
        private System.Windows.Forms.TextBox txtDesIteAlm;
        private System.Windows.Forms.Label lblCUniMed;
        private System.Windows.Forms.ComboBox cmbCUniMed;
        private System.Windows.Forms.Label lblCEstIteAlm;
        private System.Windows.Forms.ComboBox cmbCEstIteAlm;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}