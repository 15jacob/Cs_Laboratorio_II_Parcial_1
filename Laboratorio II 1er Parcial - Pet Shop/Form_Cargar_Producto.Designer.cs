
namespace Laboratorio_II_1er_Parcial___Pet_Shop
{
    partial class Form_Cargar_Producto
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
            this.lblWarningProducto = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.lblWarningCategoria = new System.Windows.Forms.Label();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWarningStock = new System.Windows.Forms.Label();
            this.lblWarningPrecio = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.lblPeso = new System.Windows.Forms.Label();
            this.lblWarningPeso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWarningProducto
            // 
            this.lblWarningProducto.AutoSize = true;
            this.lblWarningProducto.ForeColor = System.Drawing.Color.Red;
            this.lblWarningProducto.Location = new System.Drawing.Point(34, 103);
            this.lblWarningProducto.Name = "lblWarningProducto";
            this.lblWarningProducto.Size = new System.Drawing.Size(135, 15);
            this.lblWarningProducto.TabIndex = 47;
            this.lblWarningProducto.Text = "Ese nombre no es valido";
            this.lblWarningProducto.Visible = false;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.ForeColor = System.Drawing.Color.White;
            this.lblProducto.Location = new System.Drawing.Point(34, 59);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(56, 15);
            this.lblProducto.TabIndex = 46;
            this.lblProducto.Text = "Producto";
            // 
            // txtProducto
            // 
            this.txtProducto.BackColor = System.Drawing.Color.White;
            this.txtProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProducto.Location = new System.Drawing.Point(34, 77);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(206, 23);
            this.txtProducto.TabIndex = 45;
            // 
            // lblWarningCategoria
            // 
            this.lblWarningCategoria.AutoSize = true;
            this.lblWarningCategoria.ForeColor = System.Drawing.Color.Red;
            this.lblWarningCategoria.Location = new System.Drawing.Point(246, 103);
            this.lblWarningCategoria.Name = "lblWarningCategoria";
            this.lblWarningCategoria.Size = new System.Drawing.Size(153, 15);
            this.lblWarningCategoria.TabIndex = 50;
            this.lblWarningCategoria.Text = "Debes indicar una categoría";
            this.lblWarningCategoria.Visible = false;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.ForeColor = System.Drawing.Color.White;
            this.lblCategoria.Location = new System.Drawing.Point(246, 59);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(58, 15);
            this.lblCategoria.TabIndex = 49;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.ForeColor = System.Drawing.Color.White;
            this.lblPrecio.Location = new System.Drawing.Point(175, 137);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(85, 15);
            this.lblPrecio.TabIndex = 56;
            this.lblPrecio.Text = "Precio Unitario";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.ForeColor = System.Drawing.Color.White;
            this.lblStock.Location = new System.Drawing.Point(34, 137);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(36, 15);
            this.lblStock.TabIndex = 54;
            this.lblStock.Text = "Stock";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(372, 253);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 46);
            this.btnCancelar.TabIndex = 59;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.Location = new System.Drawing.Point(266, 253);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 46);
            this.btnConfirmar.TabIndex = 58;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.Color.White;
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.ItemHeight = 15;
            this.cmbCategoria.Location = new System.Drawing.Point(246, 77);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(200, 23);
            this.cmbCategoria.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(34, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 15);
            this.label1.TabIndex = 61;
            this.label1.Text = "*De no especificar, el stock sera 0";
            // 
            // lblWarningStock
            // 
            this.lblWarningStock.AutoSize = true;
            this.lblWarningStock.ForeColor = System.Drawing.Color.Red;
            this.lblWarningStock.Location = new System.Drawing.Point(34, 181);
            this.lblWarningStock.Name = "lblWarningStock";
            this.lblWarningStock.Size = new System.Drawing.Size(121, 15);
            this.lblWarningStock.TabIndex = 62;
            this.lblWarningStock.Text = "Ese stock no es valido";
            this.lblWarningStock.Visible = false;
            // 
            // lblWarningPrecio
            // 
            this.lblWarningPrecio.AutoSize = true;
            this.lblWarningPrecio.ForeColor = System.Drawing.Color.Red;
            this.lblWarningPrecio.Location = new System.Drawing.Point(175, 181);
            this.lblWarningPrecio.Name = "lblWarningPrecio";
            this.lblWarningPrecio.Size = new System.Drawing.Size(126, 15);
            this.lblWarningPrecio.TabIndex = 63;
            this.lblWarningPrecio.Text = "Ese precio no es valido";
            this.lblWarningPrecio.Visible = false;
            // 
            // txtStock
            // 
            this.txtStock.BackColor = System.Drawing.Color.White;
            this.txtStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStock.Location = new System.Drawing.Point(34, 155);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(135, 23);
            this.txtStock.TabIndex = 64;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.White;
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Location = new System.Drawing.Point(175, 155);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(135, 23);
            this.txtPrecio.TabIndex = 65;
            // 
            // txtPeso
            // 
            this.txtPeso.BackColor = System.Drawing.Color.White;
            this.txtPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPeso.Location = new System.Drawing.Point(316, 155);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(130, 23);
            this.txtPeso.TabIndex = 66;
            // 
            // lblPeso
            // 
            this.lblPeso.AutoSize = true;
            this.lblPeso.ForeColor = System.Drawing.Color.White;
            this.lblPeso.Location = new System.Drawing.Point(316, 137);
            this.lblPeso.Name = "lblPeso";
            this.lblPeso.Size = new System.Drawing.Size(99, 15);
            this.lblPeso.TabIndex = 67;
            this.lblPeso.Text = "Peso (En gramos)";
            // 
            // lblWarningPeso
            // 
            this.lblWarningPeso.AutoSize = true;
            this.lblWarningPeso.ForeColor = System.Drawing.Color.Red;
            this.lblWarningPeso.Location = new System.Drawing.Point(316, 181);
            this.lblWarningPeso.Name = "lblWarningPeso";
            this.lblWarningPeso.Size = new System.Drawing.Size(84, 15);
            this.lblWarningPeso.TabIndex = 68;
            this.lblWarningPeso.Text = "Peso no valido";
            this.lblWarningPeso.Visible = false;
            // 
            // Form_Cargar_Producto
            // 
            this.AcceptButton = this.btnConfirmar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.lblWarningPeso);
            this.Controls.Add(this.lblPeso);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.lblWarningPrecio);
            this.Controls.Add(this.lblWarningStock);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblStock);
            this.Controls.Add(this.lblWarningCategoria);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.lblWarningProducto);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.txtProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form_Cargar_Producto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargar Nuevo Producto";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWarningProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Label lblWarningCategoria;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblWarningStock;
        private System.Windows.Forms.Label lblWarningPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.Label lblPeso;
        private System.Windows.Forms.Label lblWarningPeso;
    }
}