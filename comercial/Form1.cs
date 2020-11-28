using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Linq.Expressions;
using System.Drawing.Drawing2D;

namespace comercial
{

    public partial class Form1 : Form
    {
        Controller controller; //Instancia la clase controller
        Rectangle panel; // Panel fondo lbls
        Color panelcol; //Color del panel
        Panel ventas;
        int w; //with form
        int h; //height form

        public Form1()
        {
            InitializeComponent();

            panelcol = Color.FromArgb(46, 134, 193);
            panel = new Rectangle();
            controller = new Controller();

            //ventas = new Ventas(this.Width, this.Height);
            
            //foreach( Control ctrl in this.Controls)
            //{
            //    if (tabPage1.Contains(ctrl))
            //    {
            //        string a = ctrl.Name;
            //    }
            //}

            //ventas.Parent = tabPage1;


            

            Design();
            RelativePositions();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            txt_id.TabIndex = 1;
            txt_id.TabStop = true;
            FullProductsData();
            Design();
        }

        private void txt_id_TextChanged(object sender, EventArgs e)
        {
                tbl_product_ventas.Rows.Clear();
                int aux = 0;
                foreach (string[] item in controller.getSearch(txt_id.Text))
                {
                    tbl_product_ventas.Rows.Add(item);
                    aux++;
                }
                tbl_product_ventas.RowCount = controller.RowCheck(aux);
            setSelectedProduct();
        }

        private void txt_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)8 && txt_id.TextLength == 1)
            {
                FullProductsData();
            } 
            else if (e.KeyChar == (char)13)
            {
                txt_cantidad.Select();
                txt_cantidad.Focus();
            }
        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {
            setSelectedProduct();
        }

        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Add();
            }
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            controller.endBuy();
            FullProductsData();
            tbl_ventas_cobro.Rows.Clear();
            lbl_exito.Visible = true;
            Thread t = new Thread(new ThreadStart(successSell));

            t.Start();
        }

        //Muestra toda la informacion de la tabla productos
        private void FullProductsData()
        {
            IList<string[]> aux = controller.getRows();

            tbl_product_ventas.Rows.Clear();

            for (int i = 0; i < aux.Count; i++)
            {
                string[] item = aux.ElementAt(i);
                tbl_product_ventas.Rows.Add(item);
            }
            tbl_product_ventas.RowCount = controller.RowCheck(aux.Count);
            setSelectedProduct();
        }

        //Muestra el producto seleccionado
        private void setSelectedProduct()
        {
            if (tbl_product_ventas.Rows[0].Cells[0].Value != null && txt_id.Text.Length != 0)
            {
                try
                {
                    lbl_codigo.Text = cutString(0);
                    lbl_producto.Text = cutString(1);
                    lbl_desc.Text = cutString(2);
                    lbl_brand.Text = cutString(3);
                    lbl_cantidad.Text = txt_cantidad.Text;
                    lbl_precio.Text = cutString(5);
                }
                catch (System.NullReferenceException e)
                {
                }
            }
            else
            {
                lbl_codigo.Text = "";
                lbl_producto.Text = "";
                lbl_desc.Text = "";
                lbl_brand.Text = "";
                lbl_cantidad.Text = "";
                lbl_precio.Text = "";
            }
        }

        //Si hay mas de 40 caracteres corta el string para la interfaz
        private string cutString(int cell)
        {
            string res = "";
            int a = tbl_product_ventas.Rows[0].Cells[cell].Value.ToString().Length;
            if (tbl_product_ventas.Rows[0].Cells[cell].Value.ToString().Length > 20)
            {
                res = tbl_product_ventas.Rows[0].Cells[cell].Value.ToString().Substring(0, 19)
                    + "\r\n";
            }

            if (tbl_product_ventas.Rows[0].Cells[cell].Value.ToString().Length <= 20)
            {
                res = tbl_product_ventas.Rows[0].Cells[cell].Value.ToString();
            }
            else if (tbl_product_ventas.Rows[0].Cells[cell].Value.ToString().Length >= 40)
            {
                res += tbl_product_ventas.Rows[0].Cells[cell].Value.ToString().Substring(20, 19);
            }
            else
            {
                res += tbl_product_ventas.Rows[0].Cells[cell].Value.ToString().Substring(19,
                    tbl_product_ventas.Rows[0].Cells[cell].Value.ToString().Length-19);
            }

            return res;
        }

        //Agrega un producto al cobro
        private void Add()
        {
            float price = int.Parse(lbl_cantidad.Text) * float.Parse(lbl_precio.Text);
            int cant = int.Parse(lbl_cantidad.Text);

            int repit = controller.exist(lbl_codigo.Text);

            if (repit != 0)
            {
                cant += int.Parse(tbl_ventas_cobro.Rows[repit-1].Cells[4].Value.ToString());
                price = cant * float.Parse(tbl_product_ventas.Rows[0].Cells[5].Value.ToString());
            }

            string[] product = { lbl_codigo.Text, lbl_producto.Text, lbl_desc.Text, lbl_brand.Text,
                                  cant.ToString(), price.ToString() };

            if (repit == 0)
            {
                controller.setCobros(lbl_codigo.Text, lbl_producto.Text, lbl_desc.Text, lbl_brand.Text,
                                        cant.ToString(), price.ToString());
                tbl_ventas_cobro.Rows.Add(product);
            }
            else
            {
                tbl_ventas_cobro.Rows[repit - 1].Cells[4].Value = cant;
                tbl_ventas_cobro.Rows[repit - 1].Cells[5].Value = price;
            }

            txt_id.Clear();
            txt_id.Focus();
            txt_cantidad.Text = "1";

            lbl_agregado.Visible = true;

            lbl_total.Text = controller.getTotal().ToString();

            Thread t = new Thread(new ThreadStart(successAdd));
            t.Start();

        }

        //Hilo para quitar el aviso agregado
        private void successAdd()
        {
            Thread.Sleep(1000);

            this.Invoke((MethodInvoker)delegate ()
            {
                lbl_agregado.Visible = false;
            });
        }
        
        //Hilo para quitar el aviso vendido
        private void successSell()
        {
            Thread.Sleep(3000);

            this.Invoke((MethodInvoker)delegate ()
            {
                lbl_exito.Visible = false;
            });
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            ResizeVentas();
        }
        
        //posicion y tamnhio responsive
        private void ResizeVentas()
        {
            w = this.Width;
            h = this.Height;
            tabControl1.Width = w;
            tabControl1.Height = h;
            RelativePositions();
        }

        //Posiciones de los objetos (responsive)
        private void RelativePositions()
        {

            //Fila de textbox
            int txtwith = getPerc(22.5, 'x');
            int raw1 = getPerc(7.5, 'y');
            txt_id.Location = new Point(getPerc(9, 'x'), raw1);
            btn_border_id.Location = new Point(getPerc(9, 'x'), raw1);
            btn_agregar.Location = new Point(getPerc(32, 'x'), raw1);
            txt_cantidad.Location = new Point(getPerc(41, 'x'), raw1);
            lbl_cant_pos.Location = new Point(getPerc(40.5, 'x'), getPerc(4.9, 'y'));
            if (w  > 1100)
            {
                txt_cantidad.Location = new Point(getPerc(39, 'x'), raw1);
                lbl_cant_pos.Location = new Point(getPerc(38.5, 'x'), getPerc(5.3, 'y'));
            }
            lbl_agregado.Location = new Point(getPerc(49, 'x'), raw1-10);
            txt_id.Width = txtwith;

            lbl_info_pos.Location = new Point(getPerc(80, 'x') - lbl_info_pos.Width / 2, raw1);
            //Label colum1
            int y_col1 = getPerc(75, 'x');
            lbl_cod_pos.Location = new Point(AlignFromRight(y_col1, lbl_cod_pos.Width), getPerc(12.2, 'y'));
            lbl_prod_pos.Location = new Point(AlignFromRight(y_col1, lbl_prod_pos.Width), getPerc(16.4, 'y'));
            lbl_des_pos.Location = new Point(AlignFromRight(y_col1, lbl_des_pos.Width), getPerc(20.6, 'y'));
            lbl_branch_pos.Location = new Point(AlignFromRight(y_col1, lbl_branch_pos.Width), getPerc(24.8, 'y'));
            lbl_quant_pos.Location = new Point(AlignFromRight(y_col1, lbl_quant_pos.Width), getPerc(29, 'y'));
            lbl_price_pos.Location = new Point(AlignFromRight(y_col1, lbl_price_pos.Width), getPerc(33.2, 'y'));

            //Label colum2
            int y_col2 = getPerc(80, 'x');
            lbl_codigo.Location = new Point(y_col2, getPerc(12.2, 'y'));
            lbl_producto.Location = new Point(y_col2, getPerc(16.4, 'y'));
            lbl_desc.Location = new Point(y_col2, getPerc(20.6, 'y'));
            lbl_brand.Location = new Point(y_col2, getPerc(24.8, 'y'));
            lbl_cantidad.Location = new Point(y_col2, getPerc(29, 'y'));
            lbl_precio.Location = new Point(y_col2, getPerc(33.2, 'y'));


            //tabla1 - Productos/Ventas
            int tbwith = getPerc(57.87, 'x');
            tbl_product_ventas.Bounds = new Rectangle(getPerc(5.3, 'x'), getPerc(14.06, 'y'), tbwith, getPerc(21.7, 'y'));
            tbl_product_ventas.Columns[0].Width = (int)(tbwith * 0.2041);
            tbl_product_ventas.Columns[1].Width = (int)(tbwith * 0.2449);
            tbl_product_ventas.Columns[3].Width = (int)(tbwith * 0.2449);
            tbl_product_ventas.Columns[4].Width = (int)(tbwith * 0.1429);
            tbl_product_ventas.Columns[5].Width = (int)(tbwith * 0.1632);

            //tabla2 - Cobros -- y objetos
            int tb2with = w - getPerc(12, 'x');
            tbl_ventas_cobro.Bounds = new Rectangle(getPerc(4.3, 'x'), getPerc(48, 'y'), tb2with, getPerc(21.7, 'y'));
            tbl_ventas_cobro.Columns[0].Width = (int)(tb2with * 0.1056);
            tbl_ventas_cobro.Columns[1].Width = (int)(tb2with * 0.2113);
            tbl_ventas_cobro.Columns[2].Width = (int)(tb2with * 0.3451);
            tbl_ventas_cobro.Columns[3].Width = (int)(tb2with * 0.1411);
            tbl_ventas_cobro.Columns[4].Width = (int)(tb2with * 0.0986);
            tbl_ventas_cobro.Columns[5].Width = (int)(tb2with * 0.0986);

            //Ultima Fila
            int xtb = tbl_ventas_cobro.Location.X + tbl_ventas_cobro.Width;
            int ytb = tbl_ventas_cobro.Location.Y + tbl_ventas_cobro.Height;
            lbl_prods_pos.Location = new Point(getPerc(14, 'x'), getPerc(43, 'y'));
            lbl_total_pos.Location = new Point(xtb - getPerc(10, 'x'), ytb + getPerc(1, 'y'));
            lbl_total.Location = new Point(xtb - getPerc(5, 'x'), ytb + getPerc(1, 'y'));
            btn_end.Location = new Point(xtb - getPerc(12, 'x')-btn_agregar.Width/2, ytb + getPerc(6, 'y'));
            lbl_exito.Location = new Point(xtb - getPerc(7.5, 'x') - btn_agregar.Width - lbl_exito.Width,
                                           ytb + getPerc(6, 'y') + lbl_exito.Height/2);
            btn_quit.Location = new Point(getPerc(4.3, 'x') + getPerc(7.5, 'x') - btn_quit.Width / 2, ytb + getPerc(6, 'y'));

            //Panel
            if(w > 1250)
            {
                panel.X = lbl_des_pos.Location.X - getPerc(4, 'x');
                panel.Y = lbl_info_pos.Location.Y - getPerc(2, 'y');
                panel.Width = getPerc(28.23, 'x');
                panel.Height = getPerc(35.94, 'y');
            } 
            else if (w > 925)
            {
                panel.X = (y_col2 - y_col1) / 2 + y_col1 - 120;
                panel.Y = lbl_info_pos.Location.Y - getPerc(2, 'y');
                panel.Width = 280;
                panel.Height = getPerc(35.94, 'y');
            }
            else
            {
                panel.X = (y_col2 - y_col1) / 2 + y_col1 - 100;
                panel.Y = lbl_info_pos.Location.Y - getPerc(2, 'y');
                panel.Width = 260;
                panel.Height = getPerc(35.94, 'y');
            }
}

        //Disenhio
        private void Design()
        {

            //Form -- General
            Color back = Color.FromArgb(243, 240, 205);
            this.ActiveControl = txt_id;
            this.txt_id.Focus();
            this.MaximizeBox = true;
            //w = Screen.PrimaryScreen.Bounds.Width;
            //h = Screen.PrimaryScreen.Bounds.Height;
            //this.Width = w;
            //this.Height = h;
            //this.WindowState = FormWindowState.Maximized;

            tabPage1.BackColor = back;
            lbl_info_pos.ForeColor = back;

            w = this.Width;
            h = this.Height;

            tabControl1.Width = w;
            tabControl1.Height = h;

            //Panel producto
            props(new Label(), 0, Color.Transparent);
            props(new Label(), 1, back);
            props(new Label(), 2, 0);
            
            
            //Tablas
            tbl_product_ventas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tbl_ventas_cobro.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tb_ventas_desc.Visible = false;

            //Extra styles

            Button bid = btn_border_id;

            if (txt_id.Focused)
            {
                bid.SetBounds(bid.Location.X - 2, bid.Location.Y - 2, bid.Width + 4, bid.Height + 4);

                //txt_id.BorderStyle = BorderStyle.None;
            }
            else
            {
                txt_id.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        //Obtener porcentajes para Respoinsive
        private int getPerc(double percentage, char wh) // with: true; height: false
        {
            if (wh.Equals('x'))
            {
                return Convert.ToInt32(w * percentage * 0.01);
            }
            else if (wh.Equals('y'))
            {
                return Convert.ToInt32(h * percentage * 0.01);
            } 
            else
            {
                return -99;
            }
        }

        //Alinear objeto de derecha a izquierda
        private int AlignFromRight(int x, int obj_with)
        {
            return x - obj_with;
        }
        
        //Pintar el fondo de los lables, del color de fondo
        private void props(Control control, int method , object value)
        {
            Color back = Color.FromArgb(243, 240, 205);
            foreach (Control ctr in tabPage1.Controls)
            {
                if (ctr.GetType() == control.GetType())
                {
                    switch ( method )
                    {
                        case 0: //Color de fondo lbls
                            ctr.BackColor = (Color)value;
                            break;
                        case 1: //Colo de letra, cualquiera
                            ctr.ForeColor = (Color)value;
                            break;
                        case 2: //Estilo de letra default0
                            ctr.Font = new System.Drawing.Font(ctr.Font, FontStyle.Bold);
                            break;
                           
                    }
                }
            }
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {

        }

        //Dibuja panel a los lbl
        private void DrawPanel(PaintEventArgs e, Rectangle r)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(panelcol);
            SolidBrush inn = new SolidBrush(Color.FromArgb(49, 168, 174));
            GraphicsPath path = new GraphicsPath();
            int x1 = r.X;
            int y1 = r.Y;
            int x2 = r.X + r.Width;
            int y2 = r.Y + r.Height;

            path.AddArc(x1, y1, 10, 10, 180, 90); //teta 1
            path.AddLine(x1 + 5, y1, x2 - 5, y1); //Horizontal 1
            path.AddArc(x2 - 10, y1, 10, 10, 270, 90); //teta 2
            path.AddLine(x2, y1 + 5, x2, y2 - 5); //Vertical 2
            path.AddArc(x2 - 10, y2 - 10, 10, 10, 0, 90); // teta 3
            path.AddLine(x1 + 5, y2, x2 - 5, y2); //Horizontal 2
            path.AddArc(x1, y2 - 10, 10, 10, 90, 90); //teta 4
            path.AddLine(x1, y1 + 5, x1, y2 - 5);// Vertical 1

            

            //LinearGradientBrush lnBush = new LinearGradientBrush( new Point(x1, y1), new Point(x1,y2), Color.Blue, Color.Green);

            //Se dibuja como un grafo que empieza en el angulo izq sup, haci la derecha

            //g.FillPath(new SolidBrush(panelcol), path);
            g.FillPath(inn, path);
            g.DrawPath(pen, path);
        }


        

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            DrawPanel(e, panel);
            this.Invalidate();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tbl1.Rows.Clear();
            int aux1 = 0;
            foreach (string[] item in controller.getSearch(txtbuscar.Text))
            {
                tbl1.Rows.Add(item);
                aux1++;
            }
            tbl1.RowCount = controller.RowCheck(aux1);
            setSelectedProduct();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(tbl1);
            fila.Cells[0].Value = txtcodigo.Text;
            fila.Cells[1].Value = txtproducto.Text;
            fila.Cells[2].Value = txtdescripcion.Text;
            fila.Cells[3].Value = txtmarca.Text;
            fila.Cells[4].Value = txtcantidad.Text;
            fila.Cells[5].Value = txtprecio.Text;

            tbl1.Rows.Add(fila);

            txtcodigo.Text = "";
            txtproducto.Text = "";
            txtdescripcion.Text = "";
            txtmarca.Text = "";
            txtcantidad.Text = "";
            txtprecio.Text = "";

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtcodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtproducto.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtproducto.Focus();
            }
           
        }

        private void txtproducto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtdescripcion.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtdescripcion.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtcodigo.Focus();
            }
        }

        private void txtdescripcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtmarca.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtmarca.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtproducto.Focus();
            }
        }

        private void txtmarca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtcantidad.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtcantidad.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtdescripcion.Focus();
            }
        }

        private void txtcantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtprecio.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtprecio.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtmarca.Focus();
            }
        }

        private void txtprecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnagregar.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnagregar.Focus();
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtcantidad.Focus();
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            tbl1.Rows.Remove(tbl1.CurrentRow);
        }
    }
}
