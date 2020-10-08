namespace comercial
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnbusca = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnagregar = new System.Windows.Forms.Button();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btneliminar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbl_product_ventas = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbl1 = new System.Windows.Forms.DataGridView();
            this.tb_ventas_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_product_ventas)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // btnbusca
            // 
            this.btnbusca.Location = new System.Drawing.Point(310, 62);
            this.btnbusca.Name = "btnbusca";
            this.btnbusca.Size = new System.Drawing.Size(75, 23);
            this.btnbusca.TabIndex = 2;
            this.btnbusca.Text = "Buscar";
            this.btnbusca.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(29, 170);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1091, 805);
            this.dataGridView2.TabIndex = 3;
            this.dataGridView2.Text = "dataGridView2";
            // 
            // btnagregar
            // 
            this.btnagregar.Location = new System.Drawing.Point(425, 61);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(85, 23);
            this.btnagregar.TabIndex = 3;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.UseVisualStyleBackColor = true;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Producto
            // 
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(547, 61);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(75, 23);
            this.btneliminar.TabIndex = 5;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1474, 649);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            // 
            // tbl_product_ventas
            // 
            this.tbl_product_ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_product_ventas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tb_ventas_codigo,
            this.tb_ventas_product,
            this.tb_ventas_quant,
            this.tb_ventas_precio});
            this.tbl_product_ventas.Location = new System.Drawing.Point(67, 89);
            this.tbl_product_ventas.Name = "tbl_product_ventas";
            this.tbl_product_ventas.Size = new System.Drawing.Size(500, 150);
            this.tbl_product_ventas.TabIndex = 0;
            this.tbl_product_ventas.Text = "dataGridView3";
            this.tabPage1.Controls.Add(this.tbl_product_ventas);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1466, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ventas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tbl1);
            this.tabPage2.Controls.Add(this.btneliminar);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.btnagregar);
            this.tabPage2.Controls.Add(this.btnbusca);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1466, 621);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tbl1
            // 
            this.tbl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Producto,
            this.Cantidad,
            this.Precio});
            this.tbl1.Location = new System.Drawing.Point(187, 200);
            this.tbl1.Name = "tbl1";
            this.tbl1.Size = new System.Drawing.Size(445, 125);
            this.tbl1.TabIndex = 4;
            this.tbl1.Text = "dataGridView3";
            this.tbl1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tbl1_CellContentClick);
            // 
            // tb_ventas_codigo
            // 
            this.tb_ventas_codigo.HeaderText = "Codigo";
            this.tb_ventas_codigo.Name = "tb_ventas_codigo";
            // 
            // tb_ventas_product
            // 
            this.tb_ventas_product.HeaderText = "Producto";
            this.tb_ventas_product.Name = "tb_ventas_product";
            // 
            // tb_ventas_quant
            // 
            this.tb_ventas_quant.HeaderText = "Cantidad";
            this.tb_ventas_quant.Name = "tb_ventas_quant";
            // 
            // tb_ventas_precio
            // 
            this.tb_ventas_precio.HeaderText = "Precio";
            this.tb_ventas_precio.Name = "tb_ventas_precio";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 653);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_product_ventas)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.DataGridView Datos;
        private System.Windows.Forms.Button btnbusca;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridView tbl1;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView tbl_product_ventas;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_precio;
    }
}

