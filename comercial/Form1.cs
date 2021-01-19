using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.Util;

namespace comercial
{

    public partial class Form1 : Form
    {
        api api; //Api
        Controller controller; //Instancia la clase controller
        Rectangle panel; // Panel fondo lbls
        Color panelcol; //Color del panel
        int w; //with form
        int h; //height form
        int trys; //Api requests
        int cajas; //Cantidad por caja del producto actual
        Thread thread2;

        public Form1()
        {
            controller = new Controller();
            thread2 = null;
            api = new api(controller);
            api.appio().GetAwaiter().GetResult();
            controller.setApio(api);
            api.getProducts();

            InitializeComponent();

            panelcol = Color.FromArgb(46, 134, 193);
            panel = new Rectangle();
            trys = 0;
            cajas = 0;

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
            controller.setData(null);
            FullProductsData();
            thread2 = new Thread(new ThreadStart(Wait_FullProductsData));
            thread2.Start();
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
            setSelectedProduct(0);
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
            setSelectedProduct(0);
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
            tbl_ventas_cobro.Rows.Clear();
            lbl_exito.Visible = true;
            lbl_total.Text = "";
            Thread t = new Thread(new ThreadStart(successSell));
            Thread s = new Thread(new ThreadStart(Wait_FullProductsData));
            t.Start();
            s.Start();
        }

        //Muestra toda la informacion de la tabla productos
        public void FullProductsData()
        {
            IList<string[]> aux = controller.getRows(chk_mayor.Checked);

            tbl_product_ventas.Rows.Clear();

            for (int i = 0; i < aux.Count; i++)
            {
                string[] item = aux.ElementAt(i);
                tbl_product_ventas.Rows.Add(item);
                object a = tbl_product_ventas.Rows[0];
            }
            tbl_product_ventas.RowCount = controller.RowCheck(aux.Count);
            setSelectedProduct(0);
        }

        //Espera que la api tenga la informacion, para mostrarla y coloca el estado del Sync
        public void Wait_FullProductsData()
        {
            Thread.Sleep(1000);
            trys++;

            if (controller.state == 1)
            {
                ptb.Invoke(new Action(() =>
                {
                    setSyncState();
                    FullProductsData();
                }));
                controller.state = 2;
            }
            else if (controller.state == 2 && trys < 10)
            {
                if (trys == 1)
                {
                    ptb.Invoke(new Action(() =>
                    {
                        setSyncState();
                    }));
                }
                Wait_FullProductsData();
            }
            else if (trys > 9)
            {
                controller.state = 0;
                trys = 0;
                ptb.Invoke(new Action(() =>
                {
                    setSyncState();
                }));
            }
            trys = 0;
        }

        //Setea el estado del Sync en la interfaz
        private void setSyncState()
        {
            if (controller.state == 1)
            {
                ptb.Image = Image.FromFile("../../../media/onState.png");
                lbl_sync.ForeColor = Color.Green;
                lbl_sync.Text = "Sync On";
            }
            else if (controller.state == 0)
            {
                ptb.Image = Image.FromFile("../../../media/offState.png");
                lbl_sync.ForeColor = Color.Red;
                lbl_sync.Text = "Sync Off";

            }
            else if (controller.state == 2)
            {
                ptb.Image = Image.FromFile("../../../media/loadingState.png");
                lbl_sync.ForeColor = panelcol;
                lbl_sync.Text = "loading ...";
            }
        }

        //Muestra el producto seleccionado
        private void setSelectedProduct(int row)
        {
            if (tbl_product_ventas.Rows[0].Cells[0].Value != null)
            {
                lbl_codigo.Text = cutString(row, 0);
                lbl_producto.Text = cutString(row, 1);
                lbl_desc.Text = cutString(row, 2);
                lbl_brand.Text = cutString(row, 3);
                lbl_cantidad.Text = cutString(row, 4);
                lbl_precio.Text = cutString(row, 5);
                cajas = int.Parse(cutString(row, 6));
            }
        }

        //Si hay mas de 40 caracteres corta el string para la interfaz
        private string cutString(int row, int cell)
        {
            string res = "";

            if (tbl_product_ventas.Rows[row].Cells[cell].Value.ToString().Length > 20)
            {
                res = tbl_product_ventas.Rows[row].Cells[cell].Value.ToString().Substring(0, 19)
                    + "\r\n";
            }

            if (tbl_product_ventas.Rows[row].Cells[cell].Value.ToString().Length <= 20)
            {
                res = tbl_product_ventas.Rows[row].Cells[cell].Value.ToString();
            }
            else if (tbl_product_ventas.Rows[row].Cells[cell].Value.ToString().Length >= 40)
            {
                res += tbl_product_ventas.Rows[row].Cells[cell].Value.ToString().Substring(20, 19);
            }
            else
            {
                res += tbl_product_ventas.Rows[row].Cells[cell].Value.ToString().Substring(19,
                    tbl_product_ventas.Rows[row].Cells[cell].Value.ToString().Length - 19);
            }

            return res;
        }

        //Agrega un producto al cobro
        private void Add()
        {
            decimal price = int.Parse(txt_cantidad.Text) * decimal.Parse(lbl_precio.Text);
            int cant = int.Parse(txt_cantidad.Text);
            int repit = controller.exist(lbl_codigo.Text);
            int row = tbl_product_ventas.SelectedCells[0].RowIndex;

            if (repit == 0)
            {
                if (chk_mayor.Checked)
                {
                    string input = price.ToString();
                    ShowInputDialog(ref input);
                    price = decimal.Parse(input);
                    cant = cajas * cant;
                }
            }
            else
            {
                if (chk_mayor.Checked)
                {
                    string input = price.ToString();
                    ShowInputDialog(ref input);
                    price = decimal.Parse(input) * int.Parse(txt_cantidad.Text);
                    cant = cajas * cant;
                }

                cant += int.Parse(tbl_ventas_cobro.Rows[repit - 1].Cells[4].Value.ToString());
                price += decimal.Parse(tbl_ventas_cobro.Rows[repit - 1].Cells[5].Value.ToString());

                tbl_ventas_cobro.Rows[repit - 1].Cells[4].Value = cant;
                tbl_ventas_cobro.Rows[repit - 1].Cells[5].Value = price;
            }

            if (exist())
            {
                string[] product = { lbl_codigo.Text, lbl_producto.Text, lbl_desc.Text, lbl_brand.Text,
                                  cant.ToString(), price.ToString() };

                controller.setCobros(lbl_codigo.Text, lbl_producto.Text, lbl_desc.Text, lbl_brand.Text,
                                            cant.ToString(), price.ToString());

                tbl_product_ventas.Rows[row].Cells[4].Value = controller.changeQuant(lbl_codigo.Text, cant);

                if (repit == 0)
                {
                    tbl_ventas_cobro.Rows.Add(product);
                }

                txt_id.Clear();
                txt_id.Focus();
                txt_cantidad.Text = "1";

                lbl_agregado.Visible = true;

                lbl_total.Text = controller.getTotal().ToString();

                Thread t = new Thread(new ThreadStart(successAdd));
                t.Start();
            }
            else
            {
                MessageBox.Show("No hay " + lbl_producto.Text + " en existencia.", "No hay existencias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Verifica si hay en existencia
        private bool exist()
        {
            return int.Parse(lbl_cantidad.Text) - int.Parse(txt_cantidad.Text) > 0 ? true : false;
        }

        //Input precio por mayor
        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(400, 70);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Precio de la caja por MAYOR";

            NumericUpDown np = new NumericUpDown();
            np.Size = new System.Drawing.Size(size.Width - 10, 23);
            np.Minimum = 0;
            np.Maximum = 1000000;
            np.Location = new System.Drawing.Point(5, 5);
            np.Controls[0].Visible = false;
            np.Text = input;
            np.Select(0, np.Value.ToString().Length);
            inputBox.Controls.Add(np);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;
            inputBox.StartPosition = FormStartPosition.CenterParent;

            DialogResult result = inputBox.ShowDialog();
            input = np.Text;
            return result;
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
            try
            {
                Thread.Sleep(3000);

                this.Invoke((MethodInvoker)delegate ()
                {
                    lbl_exito.Visible = false;
                });
            }
            catch (Exception e)
            {

            }  
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
            btn_agregar.Location = new Point(getPerc(32, 'x'), raw1);
            txt_cantidad.Location = new Point(getPerc(41, 'x'), raw1);
            lbl_cant_pos.Location = new Point(getPerc(40.5, 'x'), getPerc(4.9, 'y'));
            if (w > 1100)
            {
                txt_cantidad.Location = new Point(getPerc(39, 'x'), raw1);
                lbl_cant_pos.Location = new Point(getPerc(38.5, 'x'), getPerc(5.3, 'y'));
            }
            chk_mayor.Location = new Point(getPerc(45.5, 'x'), raw1 + 3);
            lbl_agregado.Location = new Point(getPerc(52, 'x'), raw1 - 10);
            txt_id.Width = txtwith;
            ptb.Location = new Point(getPerc(80, 'x'), raw1 - 40);
            lbl_sync.Location = new Point(getPerc(80, 'x') + 20, raw1 - 35);

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


            //TabControl - tabla1 - MAYOR Y MENOR - Productos/Ventas
            int tbwith = getPerc(57.87, 'x');
            tbl_product_ventas.Bounds = new Rectangle(getPerc(5, 'x'), getPerc(14.06, 'y'), tbwith, getPerc(25.5, 'y'));
            //tbl_product_ventas.Bounds = new Rectangle(-1, -1, tbwith, getPerc(21.7, 'y'));
            //tbl_product_ventas.Columns[0].Width = (int)(tbwith * 0.2041);
            tbl_product_ventas.Columns[1].Width = (int)(tbwith * 0.449);
            tbl_product_ventas.Columns[3].Width = (int)(tbwith * 0.2449);
            tbl_product_ventas.Columns[4].Width = (int)(tbwith * 0.1429);
            tbl_product_ventas.Columns[5].Width = (int)(tbwith * 0.1632);

            //tabla2 - Cobros -- y objetos
            int tb2with = w - getPerc(12, 'x');
            tbl_ventas_cobro.Bounds = new Rectangle(getPerc(4.3, 'x'), getPerc(48, 'y'), tb2with, getPerc(21.7, 'y'));
            //tbl_ventas_cobro.Columns[0].Width = (int)(tb2with * 0.1056);
            tbl_ventas_cobro.Columns[1].Width = (int)(tb2with * 0.3169);
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
            btn_end.Location = new Point(xtb - getPerc(12, 'x') - btn_agregar.Width / 2, ytb + getPerc(6, 'y'));
            lbl_exito.Location = new Point(xtb - getPerc(7.5, 'x') - btn_agregar.Width - lbl_exito.Width,
                                           ytb + getPerc(6, 'y') + lbl_exito.Height / 2);
            btn_quit.Location = new Point(getPerc(4.3, 'x') + getPerc(7.5, 'x') - btn_quit.Width / 2, ytb + getPerc(6, 'y'));
            btn_cancelar.Location = new Point(getPerc(15, 'x') + btn_quit.Width / 2, ytb + getPerc(6, 'y'));

            //Panel
            if (w > 1250)
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


            // ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
            //tabPage3 - Datos
            lbl_consulta.Location = new Point(getPerc(50, 'x') - lbl_consulta.Size.Width / 2, getPerc(10, 'y'));
            btn_locales.Location = new Point(getPerc(10, 'x'), getPerc(38, 'y'));
            btn_nube.Location = new Point(btn_locales.Location.X + btn_locales.Size.Width + getPerc(3, 'x'), getPerc(38, 'y'));
            lbl_descargar.Location = new Point(btn_nube.Location.X - getPerc(1.5, 'x') - lbl_descargar.Size.Width / 2, getPerc(33, 'y'));
            btn_subir.Location = new Point(getPerc(70, 'x'), getPerc(38, 'y'));
            btn_consultar_ventas.Location = new Point(getPerc(50, 'x') - btn_consultar_ventas.Size.Width / 2, getPerc(63, 'y'));
            btn_actualizar_ventas.Location = new Point(btn_consultar_ventas.Location.X, getPerc(65, 'y') + btn_consultar_ventas.Size.Height);

        }

        //Disenhio (colores y estilos... css?)
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
            tabPage3.BackColor = back;
            lbl_info_pos.ForeColor = back;

            w = this.Width;
            h = this.Height;

            tabControl1.Width = w;
            tabControl1.Height = h;

            //Panel producto
            props(new Label(), 0, Color.Transparent);
            props(new Label(), 1, back);
            props(new Label(), 2, 0);

            //Pintar labels especificos
            lbl_agregado.ForeColor = Color.FromArgb(35, 155, 86);
            lbl_cant_pos.ForeColor = Color.Black;
            lbl_prods_pos.ForeColor = Color.Black;
            lbl_total.ForeColor = Color.Black;
            lbl_total_pos.ForeColor = Color.Black;
            lbl_exito.ForeColor = Color.Black;
            lbl_sync.ForeColor = Color.Red;

            //Bton colors
            btn_quit.BackColor = Color.FromArgb(49, 168, 174);
            btn_agregar.BackColor = Color.FromArgb(49, 168, 174);
            btn_end.BackColor = Color.FromArgb(49, 168, 174);
            btn_cancelar.BackColor = Color.FromArgb(49, 168, 174);
            btn_quit.FlatStyle = FlatStyle.Flat;
            btn_agregar.FlatStyle = FlatStyle.Flat;
            btn_end.FlatStyle = FlatStyle.Flat;
            btn_cancelar.FlatStyle = FlatStyle.Flat;
            btn_quit.FlatAppearance.BorderColor = panelcol;
            btn_agregar.FlatAppearance.BorderColor = panelcol;
            btn_end.FlatAppearance.BorderColor = panelcol;
            btn_cancelar.FlatAppearance.BorderColor = panelcol;
            btn_quit.FlatAppearance.BorderSize = 2;
            btn_agregar.FlatAppearance.BorderSize = 0;
            btn_end.FlatAppearance.BorderSize = 2;
            btn_cancelar.FlatAppearance.BorderSize = 2;
            btn_nube.BackColor = Color.FromArgb(49, 168, 174);
            btn_nube.FlatStyle = FlatStyle.Flat;
            btn_nube.FlatAppearance.BorderColor = panelcol;
            btn_nube.FlatAppearance.BorderSize = 2;
            btn_locales.BackColor = Color.FromArgb(49, 168, 174);
            btn_locales.FlatStyle = FlatStyle.Flat;
            btn_locales.FlatAppearance.BorderColor = panelcol;
            btn_locales.FlatAppearance.BorderSize = 2;
            btn_consultar_ventas.BackColor = Color.FromArgb(49, 168, 174);
            btn_consultar_ventas.FlatStyle = FlatStyle.Flat;
            btn_consultar_ventas.FlatAppearance.BorderColor = panelcol;
            btn_consultar_ventas.FlatAppearance.BorderSize = 2;
            btn_actualizar_ventas.BackColor = Color.FromArgb(49, 168, 174);
            btn_actualizar_ventas.FlatStyle = FlatStyle.Flat;
            btn_actualizar_ventas.FlatAppearance.BorderColor = panelcol;
            btn_actualizar_ventas.FlatAppearance.BorderSize = 2;
            btn_subir.BackColor = Color.FromArgb(49, 168, 174);
            btn_subir.FlatStyle = FlatStyle.Flat;
            btn_subir.FlatAppearance.BorderColor = panelcol;
            btn_subir.FlatAppearance.BorderSize = 2;


            //Tablas
            tbl_product_ventas.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tbl_ventas_cobro.CellBorderStyle = DataGridViewCellBorderStyle.None;
            tb_ventas_desc.Visible = false;
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
        private void props(Control control, int method, object value)
        {
            Color back = Color.FromArgb(243, 240, 205);
            foreach (Control ctr in tabPage1.Controls)
            {
                if (ctr.GetType() == control.GetType())
                {
                    switch (method)
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
            controller.cancelBuy();
            FullProductsData();
            tbl_ventas_cobro.Rows.Clear();
            lbl_total.Text = "";
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

            //Se dibuja como un grafo que empieza en el angulo izq sup, haci la derecha

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
            setSelectedProduct(0);
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

        private void chk_mayor_CheckedChanged(object sender, EventArgs e)
        {
            FullProductsData();
        }

        private void tbl_product_ventas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            setSelectedProduct(int.Parse(tbl_product_ventas.SelectedCells[0].RowIndex.ToString()));
        }

        private void lbl_sync_Click(object sender, EventArgs e)
        {
            thread2 = new Thread(new ThreadStart(Wait_FullProductsData));
            thread2.Start();
            //controller.tryNetword();
            //Wait_FullProductsData();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(controller.getProducts(), Newtonsoft.Json.Formatting.Indented);
            json = "{ \"products\":" + json + "}";
            json = System.Text.RegularExpressions.Regex.Replace(json, @"\.0,", ",");
        }

        private void btn_locales_Click(object sender, EventArgs e)
        {
            dataConvertions dt = new dataConvertions(controller);
            dt.json2excel(true);

        }

        private void btn_subir_Click(object sender, EventArgs e)
        {
            dataConvertions dt = new dataConvertions(controller);
            dt.openFile("xlsx", "Excel", true);
        }

        private void btn_nube_Click(object sender, EventArgs e)
        {
            dataConvertions dt = new dataConvertions(controller);
            dt.json2excel(false); ;
        }
    }

    public class dataConvertions
    {
        Controller controller;

        public dataConvertions(Controller controller)
        {
            this.controller = controller;
        }

        public async void json2excel(bool local)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Productos");
            IRow rowHead = sheet.CreateRow(0);

            var style1 = workbook.CreateCellStyle();
            style1.FillForegroundColor = HSSFColor.SkyBlue.Index;
            style1.FillPattern = FillPattern.SolidForeground;

            rowHead.CreateCell(0).SetCellValue("Código");
            rowHead.CreateCell(1).SetCellValue("Producto");
            rowHead.CreateCell(2).SetCellValue("Descripción");
            rowHead.CreateCell(3).SetCellValue("Marca");
            rowHead.CreateCell(4).SetCellValue("Cantidad");
            rowHead.CreateCell(5).SetCellValue("Precio");
            rowHead.CreateCell(6).SetCellValue("Cantidad por caja");

            for (int j = 0; j < 7; j++)
            {
                rowHead.Cells[j].CellStyle = style1;
                sheet.SetColumnWidth(j, 5300);
            }

            int i = 0;
            IList<Product> products;
            if(local)
            {
                products = controller.getProducts();
            }
            else
            {
                products = await controller.getCloudProducts();
            }

            foreach (Product p in products)
            {
                i++;
                IRow row = sheet.CreateRow(i);

                row.CreateCell(0).SetCellValue(p.id);
                row.CreateCell(1).SetCellValue(p.name);
                row.CreateCell(2).SetCellValue(p.desc);
                row.CreateCell(3).SetCellValue(p.brand);
                row.CreateCell(4).SetCellValue(p.quant);
                row.Cells[4].SetCellType(CellType.Numeric);
                row.CreateCell(5).SetCellValue((double)p.price);
                row.Cells[5].SetCellType(CellType.Numeric);
                row.CreateCell(6).SetCellValue(p.caja);
                row.Cells[6].SetCellType(CellType.Numeric);
            }


            saveDialo(workbook);
        }

        private void saveDialo(IWorkbook wb)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.RestoreDirectory = true;
            save.DefaultExt = "xlsx";
            save.Filter = "Excel|*.xlsx";
            save.FileName = "Inventario Comercial Oliva.xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream st = File.OpenWrite(save.FileName))
                    {
                        wb.Write(st);
                        st.Close();
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Un archivo con el mismo nombre esta abierto.", "Cerrar archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }

        public void openFile(string extension, string fileType, bool inventario)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = true;
            file.DefaultExt = extension;
            file.Filter = fileType + "|*." + extension;
            file.ShowDialog();
            if (file.FileName != "")
            {
                try
                {
                    using (FileStream fs = File.OpenRead(file.FileName))
                    {
                        IWorkbook workbook = new XSSFWorkbook(fs);
                        ISheet sheet = workbook.GetSheetAt(0);

                        if (sheet != null)
                        {
                            int rowIndex = sheet.LastRowNum;
                            bool correctFormat = false;
                            IRow row = sheet.GetRow(0);

                            if (row != null)
                            {
                                correctFormat = row.GetCell(0).StringCellValue == "Código"
                                    && row.GetCell(1).StringCellValue == "Producto"
                                    && row.GetCell(2).StringCellValue == "Descripción"
                                && row.GetCell(3).StringCellValue == "Marca"
                                && row.GetCell(4).StringCellValue == "Cantidad"
                                && row.GetCell(5).StringCellValue == "Precio"
                                && row.GetCell(6).StringCellValue == "Cantidad por caja" ? true : false;
                            }

                            if (correctFormat)
                            {
                                IList<Product> fileProducts = new List<Product>();
                                for (int r = 1; r <= rowIndex; r++)
                                {
                                    row = sheet.GetRow(r);
                                    if (row != null)
                                    {
                                        fileProducts.Add(new Product(row.GetCell(0).ToString(), row.GetCell(1).ToString(), row.GetCell(2).ToString(), row.GetCell(3).ToString(),
                                            int.Parse(row.GetCell(4).ToString()), decimal.Parse(row.GetCell(5).ToString()), int.Parse(row.GetCell(6).ToString())));
                                    }
                                }
                                controller.setProducts(fileProducts);
                                controller.write();
                                MessageBox.Show("Se a actualizado con exito en la nube y localmente.\n(Las versiones anteriores se guardan en la nube\ncontacte con un programador si desea recuperalos)", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("El formato en que debe estar el inventairo es incorrecto.", "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }

                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("El archivo que trata de abrir esta abierto.\nDeber cerrarlo.", "Cerra archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
