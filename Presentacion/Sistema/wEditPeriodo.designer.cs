﻿namespace Presentacion.Sistema
{
    partial class wEditPeriodo
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodPer = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAnoPer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbEstPer = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.cmbMesPer = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 60);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 14);
            this.label11.TabIndex = 52;
            this.label11.Text = "Codigo:";
            // 
            // txtCodPer
            // 
            this.txtCodPer.Location = new System.Drawing.Point(98, 57);
            this.txtCodPer.MaxLength = 2;
            this.txtCodPer.Name = "txtCodPer";
            this.txtCodPer.ReadOnly = true;
            this.txtCodPer.Size = new System.Drawing.Size(78, 22);
            this.txtCodPer.TabIndex = 53;
            this.txtCodPer.Validated += new System.EventHandler(this.txtCodPer_Validated);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 88);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 14);
            this.label12.TabIndex = 54;
            this.label12.Text = "Año:";
            // 
            // txtAnoPer
            // 
            this.txtAnoPer.Location = new System.Drawing.Point(98, 85);
            this.txtAnoPer.MaxLength = 50;
            this.txtAnoPer.Name = "txtAnoPer";
            this.txtAnoPer.Size = new System.Drawing.Size(78, 22);
            this.txtAnoPer.TabIndex = 55;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 144);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 14);
            this.label13.TabIndex = 56;
            this.label13.Text = "Estado:";
            // 
            // cmbEstPer
            // 
            this.cmbEstPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstPer.Location = new System.Drawing.Point(98, 141);
            this.cmbEstPer.Name = "cmbEstPer";
            this.cmbEstPer.Size = new System.Drawing.Size(120, 22);
            this.cmbEstPer.TabIndex = 57;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(212, 178);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 71;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(98, 178);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 72;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(26, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(295, 14);
            this.label21.TabIndex = 74;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbMesPer
            // 
            this.cmbMesPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMesPer.Location = new System.Drawing.Point(98, 113);
            this.cmbMesPer.Name = "cmbMesPer";
            this.cmbMesPer.Size = new System.Drawing.Size(120, 22);
            this.cmbMesPer.TabIndex = 76;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 116);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(33, 14);
            this.label14.TabIndex = 75;
            this.label14.Text = "Mes:";
            // 
            // wEditPeriodo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.ClientSize = new System.Drawing.Size(351, 236);
            this.Controls.Add(this.cmbMesPer);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbEstPer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtAnoPer);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtCodPer);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "wEditPeriodo";
            this.Text = "Edit Usuario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditPeriodo_FormClosing);
            this.Controls.SetChildIndex(this.txtCodPer, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.txtAnoPer, 0);
            this.Controls.SetChildIndex(this.label12, 0);
            this.Controls.SetChildIndex(this.label13, 0);
            this.Controls.SetChildIndex(this.cmbEstPer, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.cmbMesPer, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodPer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtAnoPer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbEstPer;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbMesPer;
        private System.Windows.Forms.Label label14;
    }
}
