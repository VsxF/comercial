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

namespace comercial
{

    public partial class Form1 : Form
    {
        //Instancia la clase controller
        Controller controller = new Controller();

        public Form1()
        {
            InitializeComponent();
        
            this.MaximizeBox = true;
            this.WindowState = FormWindowState.Maximized;
           
            //this.FormBorderStyle = FormBorderStyle.FixedDialog;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            txt_id.TabIndex = 1;
            txt_id.TabStop = true;
            FullProductsData();
           
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
                //tbl_product_ventas.RowCount = controller.RowCheck(aux);
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
            if (tbl_product_ventas.Rows[0].Cells[0].Value != null)
            {
                try
                {
                    lbl_codigo.Text = tbl_product_ventas.Rows[0].Cells[0].Value.ToString();
                    lbl_producto.Text = tbl_product_ventas.Rows[0].Cells[1].Value.ToString();
                    lbl_desc.Text = tbl_product_ventas.Rows[0].Cells[2].Value.ToString();
                    lbl_brand.Text = tbl_product_ventas.Rows[0].Cells[3].Value.ToString();
                    lbl_cantidad.Text = txt_cantidad.Text;
                    lbl_precio.Text = tbl_product_ventas.Rows[0].Cells[5].Value.ToString();
                }
                catch (System.NullReferenceException e)
                {
                }
            }
        }

        //Agrega un producto al cobro
        private void Add()
        {
            float price = int.Parse(lbl_cantidad.Text) * float.Parse(lbl_precio.Text);
            int cant = int.Parse(lbl_cantidad.Text);

            int repit = controller.exist(lbl_codigo.Text);

            if (repit != 0)
            {
                cant = cant + int.Parse(tbl_ventas_cobro.Rows[repit - 1].Cells[2].Value.ToString());
                price = cant * float.Parse(tbl_product_ventas.Rows[0].Cells[3].Value.ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
