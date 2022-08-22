namespace Presentacion.Maestros
{
    partial class wEditTipoDocumento
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
            this.lblCodTipDoc = new System.Windows.Forms.Label();
            this.txtCodTipDoc = new System.Windows.Forms.TextBox();
            this.lblDesTipDoc = new System.Windows.Forms.Label();
            this.txtDesTipDoc = new System.Windows.Forms.TextBox();
            this.lblCAplEnReg = new System.Windows.Forms.Label();
            this.cmbCAplEnReg = new System.Windows.Forms.ComboBox();
            this.lblCAplDocRef = new System.Windows.Forms.Label();
            this.cmbCAplDocRef = new System.Windows.Forms.ComboBox();
            this.lblCEstTipDoc = new System.Windows.Forms.Label();
            this.cmbCEstTipDoc = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCTipNot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCodTipDoc
            // 
            this.lblCodTipDoc.AutoSize = true;
            this.lblCodTipDoc.Location = new System.Drawing.Point(33, 73);
            this.lblCodTipDoc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodTipDoc.Name = "lblCodTipDoc";
            this.lblCodTipDoc.Size = new System.Drawing.Size(51, 18);
            this.lblCodTipDoc.TabIndex = 0;
            this.lblCodTipDoc.Text = "Codigo";
            // 
            // txtCodTipDoc
            // 
            this.txtCodTipDoc.Location = new System.Drawing.Point(189, 70);
            this.txtCodTipDoc.Margin = new System.Windows.Forms.Padding(5);
            this.txtCodTipDoc.Name = "txtCodTipDoc";
            this.txtCodTipDoc.Size = new System.Drawing.Size(49, 26);
            this.txtCodTipDoc.TabIndex = 1;
            this.txtCodTipDoc.Validated += new System.EventHandler(this.txtCodTipDoc_Validated);
            // 
            // lblDesTipDoc
            // 
            this.lblDesTipDoc.AutoSize = true;
            this.lblDesTipDoc.Location = new System.Drawing.Point(33, 109);
            this.lblDesTipDoc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDesTipDoc.Name = "lblDesTipDoc";
            this.lblDesTipDoc.Size = new System.Drawing.Size(80, 18);
            this.lblDesTipDoc.TabIndex = 2;
            this.lblDesTipDoc.Text = "Descripcion";
            // 
            // txtDesTipDoc
            // 
            this.txtDesTipDoc.Location = new System.Drawing.Point(189, 106);
            this.txtDesTipDoc.Margin = new System.Windows.Forms.Padding(5);
            this.txtDesTipDoc.Name = "txtDesTipDoc";
            this.txtDesTipDoc.Size = new System.Drawing.Size(329, 26);
            this.txtDesTipDoc.TabIndex = 3;
            // 
            // lblCAplEnReg
            // 
            this.lblCAplEnReg.AutoSize = true;
            this.lblCAplEnReg.Location = new System.Drawing.Point(33, 145);
            this.lblCAplEnReg.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCAplEnReg.Name = "lblCAplEnReg";
            this.lblCAplEnReg.Size = new System.Drawing.Size(118, 18);
            this.lblCAplEnReg.TabIndex = 4;
            this.lblCAplEnReg.Text = "Aplica En Registro";
            // 
            // cmbCAplEnReg
            // 
            this.cmbCAplEnReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCAplEnReg.FormattingEnabled = true;
            this.cmbCAplEnReg.Location = new System.Drawing.Point(189, 142);
            this.cmbCAplEnReg.Margin = new System.Windows.Forms.Padding(5);
            this.cmbCAplEnReg.Name = "cmbCAplEnReg";
            this.cmbCAplEnReg.Size = new System.Drawing.Size(232, 26);
            this.cmbCAplEnReg.TabIndex = 5;
            // 
            // lblCAplDocRef
            // 
            this.lblCAplDocRef.AutoSize = true;
            this.lblCAplDocRef.Location = new System.Drawing.Point(33, 181);
            this.lblCAplDocRef.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCAplDocRef.Name = "lblCAplDocRef";
            this.lblCAplDocRef.Size = new System.Drawing.Size(97, 18);
            this.lblCAplDocRef.TabIndex = 6;
            this.lblCAplDocRef.Text = "Aplica Doc.Ref";
            // 
            // cmbCAplDocRef
            // 
            this.cmbCAplDocRef.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCAplDocRef.FormattingEnabled = true;
            this.cmbCAplDocRef.Location = new System.Drawing.Point(189, 178);
            this.cmbCAplDocRef.Margin = new System.Windows.Forms.Padding(5);
            this.cmbCAplDocRef.Name = "cmbCAplDocRef";
            this.cmbCAplDocRef.Size = new System.Drawing.Size(77, 26);
            this.cmbCAplDocRef.TabIndex = 7;
            this.cmbCAplDocRef.SelectionChangeCommitted += new System.EventHandler(this.cmbCAplDocRef_SelectionChangeCommitted);
            // 
            // lblCEstTipDoc
            // 
            this.lblCEstTipDoc.AutoSize = true;
            this.lblCEstTipDoc.Location = new System.Drawing.Point(33, 253);
            this.lblCEstTipDoc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCEstTipDoc.Name = "lblCEstTipDoc";
            this.lblCEstTipDoc.Size = new System.Drawing.Size(49, 18);
            this.lblCEstTipDoc.TabIndex = 8;
            this.lblCEstTipDoc.Text = "Estado";
            // 
            // cmbCEstTipDoc
            // 
            this.cmbCEstTipDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCEstTipDoc.FormattingEnabled = true;
            this.cmbCEstTipDoc.Location = new System.Drawing.Point(189, 250);
            this.cmbCEstTipDoc.Margin = new System.Windows.Forms.Padding(5);
            this.cmbCEstTipDoc.Name = "cmbCEstTipDoc";
            this.cmbCEstTipDoc.Size = new System.Drawing.Size(175, 26);
            this.cmbCEstTipDoc.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(219, 289);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(5);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(145, 32);
            this.btnAceptar.TabIndex = 95;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(373, 289);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(145, 32);
            this.btnCancelar.TabIndex = 94;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.DarkGray;
            this.label7.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(33, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(485, 18);
            this.label7.TabIndex = 420;
            this.label7.Text = "Datos Generales";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCTipNot
            // 
            this.cmbCTipNot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCTipNot.FormattingEnabled = true;
            this.cmbCTipNot.Location = new System.Drawing.Point(189, 214);
            this.cmbCTipNot.Margin = new System.Windows.Forms.Padding(5);
            this.cmbCTipNot.Name = "cmbCTipNot";
            this.cmbCTipNot.Size = new System.Drawing.Size(136, 26);
            this.cmbCTipNot.TabIndex = 422;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 217);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 18);
            this.label1.TabIndex = 421;
            this.label1.Text = "Tipo Nota";
            // 
            // wEditTipoDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 354);
            this.Controls.Add(this.cmbCTipNot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.cmbCEstTipDoc);
            this.Controls.Add(this.lblCEstTipDoc);
            this.Controls.Add(this.cmbCAplDocRef);
            this.Controls.Add(this.lblCAplDocRef);
            this.Controls.Add(this.cmbCAplEnReg);
            this.Controls.Add(this.lblCAplEnReg);
            this.Controls.Add(this.txtDesTipDoc);
            this.Controls.Add(this.lblDesTipDoc);
            this.Controls.Add(this.txtCodTipDoc);
            this.Controls.Add(this.lblCodTipDoc);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "wEditTipoDocumento";
            this.Text = "Editar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.wEditTipoDocumento_FormClosing);
            this.Controls.SetChildIndex(this.lblCodTipDoc, 0);
            this.Controls.SetChildIndex(this.txtCodTipDoc, 0);
            this.Controls.SetChildIndex(this.lblDesTipDoc, 0);
            this.Controls.SetChildIndex(this.txtDesTipDoc, 0);
            this.Controls.SetChildIndex(this.lblCAplEnReg, 0);
            this.Controls.SetChildIndex(this.cmbCAplEnReg, 0);
            this.Controls.SetChildIndex(this.lblCAplDocRef, 0);
            this.Controls.SetChildIndex(this.cmbCAplDocRef, 0);
            this.Controls.SetChildIndex(this.lblCEstTipDoc, 0);
            this.Controls.SetChildIndex(this.cmbCEstTipDoc, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbCTipNot, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodTipDoc;
        private System.Windows.Forms.TextBox txtCodTipDoc;
        private System.Windows.Forms.Label lblDesTipDoc;
        private System.Windows.Forms.TextBox txtDesTipDoc;
        private System.Windows.Forms.Label lblCAplEnReg;
        private System.Windows.Forms.ComboBox cmbCAplEnReg;
        private System.Windows.Forms.Label lblCAplDocRef;
        private System.Windows.Forms.ComboBox cmbCAplDocRef;
        private System.Windows.Forms.Label lblCEstTipDoc;
        private System.Windows.Forms.ComboBox cmbCEstTipDoc;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbCTipNot;
        private System.Windows.Forms.Label label1;
    }
}