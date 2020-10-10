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
            this.lbl_brand = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_exito = new System.Windows.Forms.Label();
            this.btn_end = new System.Windows.Forms.Button();
            this.lbl_total = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_agregado = new System.Windows.Forms.Label();
            this.lbl_precio = new System.Windows.Forms.Label();
            this.lbl_cantidad = new System.Windows.Forms.Label();
            this.lbl_codigo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl_producto = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbl_ventas_cobro = new System.Windows.Forms.DataGridView();
            this.tb_ventas_cobro_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_cobro_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_cobro_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_cobro_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_cobro_cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_cobro_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.tbl_product_ventas = new System.Windows.Forms.DataGridView();
            this.tb_ventas_codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_quant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_ventas_precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tbl1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ventas_cobro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_product_ventas)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 12;
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
            this.tabControl1.Size = new System.Drawing.Size(828, 649);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lbl_brand);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.lbl_desc);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.lbl_exito);
            this.tabPage1.Controls.Add(this.btn_end);
            this.tabPage1.Controls.Add(this.lbl_total);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.lbl_agregado);
            this.tabPage1.Controls.Add(this.lbl_precio);
            this.tabPage1.Controls.Add(this.lbl_cantidad);
            this.tabPage1.Controls.Add(this.lbl_codigo);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.lbl_producto);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.tbl_ventas_cobro);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txt_cantidad);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btn_agregar);
            this.tabPage1.Controls.Add(this.txt_id);
            this.tabPage1.Controls.Add(this.tbl_product_ventas);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(820, 621);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ventas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lbl_brand
            // 
            this.lbl_brand.AutoSize = true;
            this.lbl_brand.Location = new System.Drawing.Point(660, 165);
            this.lbl_brand.Name = "lbl_brand";
            this.lbl_brand.Size = new System.Drawing.Size(44, 15);
            this.lbl_brand.TabIndex = 16;
            this.lbl_brand.Text = "default";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(611, 165);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 15);
            this.label11.TabIndex = 12;
            this.label11.Text = "Marca:";
            // 
            // lbl_desc
            // 
            this.lbl_desc.AutoSize = true;
            this.lbl_desc.Location = new System.Drawing.Point(660, 136);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(44, 15);
            this.lbl_desc.TabIndex = 15;
            this.lbl_desc.Text = "default";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(582, 136);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 15);
            this.label9.TabIndex = 11;
            this.label9.Text = "Descripcion:";
            // 
            // lbl_exito
            // 
            this.lbl_exito.AutoSize = true;
            this.lbl_exito.Location = new System.Drawing.Point(665, 528);
            this.lbl_exito.Name = "lbl_exito";
            this.lbl_exito.Size = new System.Drawing.Size(102, 30);
            this.lbl_exito.TabIndex = 103;
            this.lbl_exito.Text = "La venta se \r\nregistro con exito!";
            this.lbl_exito.Visible = false;
            // 
            // btn_end
            // 
            this.btn_end.Location = new System.Drawing.Point(531, 526);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(107, 56);
            this.btn_end.TabIndex = 102;
            this.btn_end.Text = "Terminar";
            this.btn_end.UseVisualStyleBackColor = true;
            this.btn_end.Click += new System.EventHandler(this.btn_end_Click);
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(592, 483);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(28, 15);
            this.lbl_total.TabIndex = 101;
            this.lbl_total.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(541, 483);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 15);
            this.label6.TabIndex = 100;
            this.label6.Text = "Total:";
            // 
            // lbl_agregado
            // 
            this.lbl_agregado.AutoSize = true;
            this.lbl_agregado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_agregado.ForeColor = System.Drawing.Color.Green;
            this.lbl_agregado.Location = new System.Drawing.Point(411, 57);
            this.lbl_agregado.Name = "lbl_agregado";
            this.lbl_agregado.Size = new System.Drawing.Size(73, 15);
            this.lbl_agregado.TabIndex = 17;
            this.lbl_agregado.Text = "AGREGADO";
            this.lbl_agregado.Visible = false;
            // 
            // lbl_precio
            // 
            this.lbl_precio.AutoSize = true;
            this.lbl_precio.Location = new System.Drawing.Point(660, 231);
            this.lbl_precio.Name = "lbl_precio";
            this.lbl_precio.Size = new System.Drawing.Size(44, 15);
            this.lbl_precio.TabIndex = 16;
            this.lbl_precio.Text = "default";
            // 
            // lbl_cantidad
            // 
            this.lbl_cantidad.AutoSize = true;
            this.lbl_cantidad.Location = new System.Drawing.Point(660, 198);
            this.lbl_cantidad.Name = "lbl_cantidad";
            this.lbl_cantidad.Size = new System.Drawing.Size(44, 15);
            this.lbl_cantidad.TabIndex = 15;
            this.lbl_cantidad.Text = "default";
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.AutoSize = true;
            this.lbl_codigo.Location = new System.Drawing.Point(660, 78);
            this.lbl_codigo.Name = "lbl_codigo";
            this.lbl_codigo.Size = new System.Drawing.Size(44, 15);
            this.lbl_codigo.TabIndex = 13;
            this.lbl_codigo.Text = "default";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(611, 231);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "Precio:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(596, 198);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cantidad:";
            // 
            // lbl_producto
            // 
            this.lbl_producto.AutoSize = true;
            this.lbl_producto.Location = new System.Drawing.Point(660, 109);
            this.lbl_producto.Name = "lbl_producto";
            this.lbl_producto.Size = new System.Drawing.Size(44, 15);
            this.lbl_producto.TabIndex = 10;
            this.lbl_producto.Text = "default";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(595, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Producto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(605, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Codigo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Informacion del producto";
            // 
            // tbl_ventas_cobro
            // 
            this.tbl_ventas_cobro.AllowUserToAddRows = false;
            this.tbl_ventas_cobro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_ventas_cobro.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tb_ventas_cobro_codigo,
            this.tb_ventas_cobro_producto,
            this.tb_ventas_cobro_desc,
            this.tb_ventas_cobro_brand,
            this.tb_ventas_cobro_cantidad,
            this.tb_ventas_cobro_precio});
            this.tbl_ventas_cobro.Location = new System.Drawing.Point(136, 318);
            this.tbl_ventas_cobro.Name = "tbl_ventas_cobro";
            this.tbl_ventas_cobro.ReadOnly = true;
            this.tbl_ventas_cobro.Size = new System.Drawing.Size(493, 162);
            this.tbl_ventas_cobro.TabIndex = 6;
            this.tbl_ventas_cobro.Text = "dataGridView3";
            // 
            // tb_ventas_cobro_codigo
            // 
            this.tb_ventas_cobro_codigo.HeaderText = "Codigo";
            this.tb_ventas_cobro_codigo.Name = "tb_ventas_cobro_codigo";
            this.tb_ventas_cobro_codigo.ReadOnly = true;
            this.tb_ventas_cobro_codigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_ventas_cobro_codigo.Width = 50;
            // 
            // tb_ventas_cobro_producto
            // 
            this.tb_ventas_cobro_producto.HeaderText = "Producto";
            this.tb_ventas_cobro_producto.Name = "tb_ventas_cobro_producto";
            this.tb_ventas_cobro_producto.ReadOnly = true;
            this.tb_ventas_cobro_producto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tb_ventas_cobro_desc
            // 
            this.tb_ventas_cobro_desc.HeaderText = "Descripcion";
            this.tb_ventas_cobro_desc.Name = "tb_ventas_cobro_desc";
            this.tb_ventas_cobro_desc.ReadOnly = true;
            this.tb_ventas_cobro_desc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tb_ventas_cobro_brand
            // 
            this.tb_ventas_cobro_brand.HeaderText = "Marca";
            this.tb_ventas_cobro_brand.Name = "tb_ventas_cobro_brand";
            this.tb_ventas_cobro_brand.ReadOnly = true;
            this.tb_ventas_cobro_brand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tb_ventas_cobro_cantidad
            // 
            this.tb_ventas_cobro_cantidad.HeaderText = "Cantidad";
            this.tb_ventas_cobro_cantidad.Name = "tb_ventas_cobro_cantidad";
            this.tb_ventas_cobro_cantidad.ReadOnly = true;
            this.tb_ventas_cobro_cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_ventas_cobro_cantidad.Width = 50;
            // 
            // tb_ventas_cobro_precio
            // 
            this.tb_ventas_cobro_precio.HeaderText = "Precio";
            this.tb_ventas_cobro_precio.Name = "tb_ventas_cobro_precio";
            this.tb_ventas_cobro_precio.ReadOnly = true;
            this.tb_ventas_cobro_precio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_ventas_cobro_precio.Width = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Productos a cobrar";
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(354, 50);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(33, 23);
            this.txt_cantidad.TabIndex = 4;
            this.txt_cantidad.Text = "1";
            this.txt_cantidad.TextChanged += new System.EventHandler(this.txt_cantidad_TextChanged);
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_cantidad_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cant.";
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(269, 49);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_agregar.TabIndex = 2;
            this.btn_agregar.Text = "Agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(70, 49);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(193, 23);
            this.txt_id.TabIndex = 1;
            this.txt_id.TextChanged += new System.EventHandler(this.txt_id_TextChanged);
            this.txt_id.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_id_KeyPress);
            // 
            // tbl_product_ventas
            // 
            this.tbl_product_ventas.AllowUserToAddRows = false;
            this.tbl_product_ventas.AllowUserToDeleteRows = false;
            this.tbl_product_ventas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_product_ventas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tb_ventas_codigo,
            this.tb_ventas_product,
            this.tb_ventas_desc,
            this.tb_ventas_brand,
            this.tb_ventas_quant,
            this.tb_ventas_precio});
            this.tbl_product_ventas.Location = new System.Drawing.Point(40, 91);
            this.tbl_product_ventas.Name = "tbl_product_ventas";
            this.tbl_product_ventas.Size = new System.Drawing.Size(493, 150);
            this.tbl_product_ventas.TabIndex = 99;
            this.tbl_product_ventas.Text = "dataGridView3";
            // 
            // tb_ventas_codigo
            // 
            this.tb_ventas_codigo.HeaderText = "Codigo";
            this.tb_ventas_codigo.Name = "tb_ventas_codigo";
            this.tb_ventas_codigo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_ventas_codigo.Width = 50;
            // 
            // tb_ventas_product
            // 
            this.tb_ventas_product.HeaderText = "Producto";
            this.tb_ventas_product.Name = "tb_ventas_product";
            this.tb_ventas_product.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tb_ventas_desc
            // 
            this.tb_ventas_desc.HeaderText = "Descripcion";
            this.tb_ventas_desc.Name = "tb_ventas_desc";
            this.tb_ventas_desc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tb_ventas_brand
            // 
            this.tb_ventas_brand.HeaderText = "Marca";
            this.tb_ventas_brand.Name = "tb_ventas_brand";
            this.tb_ventas_brand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // tb_ventas_quant
            // 
            this.tb_ventas_quant.HeaderText = "Cantidad";
            this.tb_ventas_quant.Name = "tb_ventas_quant";
            this.tb_ventas_quant.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_ventas_quant.Width = 50;
            // 
            // tb_ventas_precio
            // 
            this.tb_ventas_precio.HeaderText = "Precio";
            this.tb_ventas_precio.Name = "tb_ventas_precio";
            this.tb_ventas_precio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_ventas_precio.Width = 50;
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
            this.tabPage2.Size = new System.Drawing.Size(820, 621);
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
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(835, 653);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Comercial";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_ventas_cobro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_product_ventas)).EndInit();
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
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tbl_ventas_cobro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_precio;
        private System.Windows.Forms.Label lbl_cantidad;
        private System.Windows.Forms.Label lbl_codigo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl_producto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_agregado;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_end;
        private System.Windows.Forms.Label lbl_exito;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_cobro_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_cobro_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_cobro_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_cobro_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_cobro_cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_cobro_precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_quant;
        private System.Windows.Forms.DataGridViewTextBoxColumn tb_ventas_precio;
        private System.Windows.Forms.Label lbl_brand;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_desc;
        private System.Windows.Forms.Label label9;
    }
}

