namespace Presentacion.Maestros
{
    partial class wEditFormatoContable
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
            this.lblCodForCon = new System.Windows.Forms.Label();
            this.txtCodForCon = new System.Windows.Forms.TextBox();
            this.lblDesForCon = new System.Windows.Forms.Label();
            this.txtDesForCon = new System.Windows.Forms.TextBox();
            this.lblDesAltForCon = new System.Windows.Forms.Label();
            this.txtDesAltForCon = new System.Windows.Forms.TextBox();
            this.lblCGru = new System.Windows.Forms.Label();
            this.cmbCGru = new System.Windows.Forms.ComboBox();
            this.lblCNat = new System.Windows.Forms.Label();
            this.cmbCNat = new System.Windows.Forms.ComboBox();
            this.lblCEstForCon = new System.Windows.Forms.Label();
            this.cmbCEstForCon = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodForCon
            // 
            this.lblCodForCon.AutoSize = true;
            this.lblCodForCon.Location = new System.Drawing.Point(30, 57);
            this.lblCodForCon.Name = "lblCodForCon";
            this.lblCodForCon.Size = new System.Drawing.Size(44, 14);
            this.lblCodForCon.TabIndex = 0;
            this.lblCodForCon.Text = "Codigo";
            // 
            // txtCodForCon
            // 
            this.txtCodForCon.Location = new System.Drawing.Point(162, 54);
            this.txtCodForCon.Name = "txtCodForCon";
            this.txtCodForCon.Size = new System.Drawing.Size(100, 22);
            this.txtCodForCon.TabIndex = 1;
            this.txtCodForCon.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodForCon_Validating);
            // 
            // lblDesForCon
            // 
            this.lblDesForCon.AutoSize = true;
            this.lblDesForCon.Location = new System.Drawing.Point(30, 85);
            this.lblDesForCon.Name = "lblDesForCon";
            this.lblDesForCon.Size = new System.Drawing.Size(71, 14);
            this.lblDesForCon.TabIndex = 2;
            this.lblDesForCon.Text = "Descripcion";
            // 
            // txtDesForCon
            // 
            this.txtDesForCon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesForCon.Location = new System.Drawing.Point(162, 82);
            this.txtDesForCon.Name = "txtDesForCon";
            this.txtDesForCon.Size = new System.Drawing.Size(322, 22);
            this.txtDesForCon.TabIndex = 3;
            // 
            // lblDesAltForCon
            // 
            this.lblDesAltForCon.AutoSize = true;
            this.lblDesAltForCon.Location = new System.Drawing.Point(30, 113);
            this.lblDesAltForCon.Name = "lblDesAltForCon";
            this.lblDesAltForCon.Size = new System.Drawing.Size(114, 14);
            this.lblDesAltForCon.TabIndex = 4;
            this.lblDesAltForCon.Text = "Descripcion Alterna";
            // 
            // txtDesAltForCon
            // 
            this.txtDesAltForCon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDesAltForCon.Location = new System.Drawing.Point(162, 110);
            this.txtDesAltForCon.Name = "txtDesAltForCon";
            this.txtDesAltForCon.Size = new System.Drawing.Size(322, 22);
            this.txtDesAltForCon.TabIndex = 5;
            // 
            // lblCGru
            // 
            this.lblCGru.AutoSize = true;
            this.lblCGru.Location = new System.Drawing.Point(30, 138);
            this.lblCGru.Name = "lblCGru";
            this.lblCGru.Size = new System.Drawing.Size(76, 14);
            this.lblCGru.TabIndex = 6;
            this.lblCGru.Text = "Agrupado en";
            // 
            // cmbCGru
            // 
            this.cmbCGru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCGru.FormattingEnabled = true;
            this.cmbCGru.Location = new System.Drawing.Point(162, 138);
            this.cmbCGru.Name = "cmbCGru";
            this.cmbCGru.Size = new System.Drawing.Size(189, 22);
            this.cmbCGru.TabIndex = 7;
            // 
            // lblCNat
            // 
            this.lblCNat.AutoSize = true;
            this.lblCNat.Location = new System.Drawing.Point(30, 166);
            this.lblCNat.Name = "lblCNat";
            this.lblCNat.Size = new System.Drawing.Size(67, 14);
            this.lblCNat.TabIndex = 8;
            this.lblCNat.Text = "Naturaleza";
            // 
            // cmbCNat
            // 
            this.cmbCNat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCNat.FormattingEnabled = true;
            this.cmbCNat.Location = new System.Drawing.Point(162, 166);
            this.cmbCNat.Name = "cmbCNat";
            this.cmbCNat.Size = new System.Drawing.Size(133, 22);
            this.cmbCNat.TabIndex = 9;
            // 
            // lblCEstForCon
            // 
            this.lblCEstForCon.AutoSize = true;
            this.lblCEstForCon.Location = new System.Drawing.Point(30, 195);
            this.lblCEstForCon.Name = "lblCEstForCon";
            this.lblCEstForCon.Size = new System.Drawing.Size(44, 14);
            this.lblCEstForCon.TabIndex = 10;
            this.lblCEstForCon.Text = "Estado";
            // 
            // cmbCEstForCon
            // 
            this.cmbCEstForCon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCEstForCon.FormattingEnabled = true;
            this.cmbCEstForCon.Location = new System.Drawing.Point(162, 194);
            this.cmbCEstForCon.Name = "cmbCEstForCon";
            this.cmbCEstForCon.Size = new System.Drawing.Size(100, 22);
            this.cmbCEstForCon.TabIndex = 11;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(261, 239);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(109, 25);
            this.btnAceptar.TabIndex = 79;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(375, 239);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 25);
            this.btnCancelar.TabIndex = 78;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.DarkGray;
            this.label21.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(30, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(454, 14);
            this.label21.TabIndex = 80;
            this.label21.Text = "Datos Generales";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wEditFormatoContable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 295);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbCEstForCon);
            this.Controls.Add(this.lblCEstForCon);
            this.Controls.Add(this.cmbCNat);
            this.Controls.Add(this.lblCNat);
            this.Controls.Add(this.cmbCGru);
            this.Controls.Add(this.lblCGru);
            this.Controls.Add(this.txtDesAltForCon);
            this.Controls.Add(this.lblDesAltForCon);
            this.Controls.Add(this.txtDesForCon);
            this.Controls.Add(this.lblDesForCon);
            this.Controls.Add(this.txtCodForCon);
            this.Controls.Add(this.lblCodForCon);
            this.Name = "wEditFormatoContable";
            this.Text = "Editar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditFormatoContable_FormClosing);
            this.Controls.SetChildIndex(this.lblCodForCon, 0);
            this.Controls.SetChildIndex(this.txtCodForCon, 0);
            this.Controls.SetChildIndex(this.lblDesForCon, 0);
            this.Controls.SetChildIndex(this.txtDesForCon, 0);
            this.Controls.SetChildIndex(this.lblDesAltForCon, 0);
            this.Controls.SetChildIndex(this.txtDesAltForCon, 0);
            this.Controls.SetChildIndex(this.lblCGru, 0);
            this.Controls.SetChildIndex(this.cmbCGru, 0);
            this.Controls.SetChildIndex(this.lblCNat, 0);
            this.Controls.SetChildIndex(this.cmbCNat, 0);
            this.Controls.SetChildIndex(this.lblCEstForCon, 0);
            this.Controls.SetChildIndex(this.cmbCEstForCon, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label21, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodForCon;
        private System.Windows.Forms.TextBox txtCodForCon;
        private System.Windows.Forms.Label lblDesForCon;
        private System.Windows.Forms.TextBox txtDesForCon;
        private System.Windows.Forms.Label lblDesAltForCon;
        private System.Windows.Forms.TextBox txtDesAltForCon;
        private System.Windows.Forms.Label lblCGru;
        private System.Windows.Forms.ComboBox cmbCGru;
        private System.Windows.Forms.Label lblCNat;
        private System.Windows.Forms.ComboBox cmbCNat;
        private System.Windows.Forms.Label lblCEstForCon;
        private System.Windows.Forms.ComboBox cmbCEstForCon;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label21;
    }
}