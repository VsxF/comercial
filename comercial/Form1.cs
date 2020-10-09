using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comercial
{
    public partial class Form1 : Form
    {
        //Instancia la clase controller
        Controller controller = new Controller();

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbl1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_consola_Click(object sender, EventArgs e)
        {
            //deleteProduct();
            //updateProduct();
            //getProduct();
            //setProduct();
        }

        //Buscar un producto por id y muestra sus datos
        private void getProduct()
        {
            //buscar producto en base al id
            string id = "0";
            Product producto = controller.getProduct(id);
            //Mostrar los atributos del producto
            MessageBox.Show("informacion del producto id 0:" + producto.id +
                ", " + producto.name + ", " + producto.quant + ", " + producto.price);
        }

        //Agrega un producto
        private void setProduct()
        {
            string id = "2";
            string name = "name codigo";
            int quant = 5;
            float price = 3;

            //envia los datos al controlador y returna true/false
            bool exito = controller.setProduct(id, name, quant, price);
            if (exito)
            {
                MessageBox.Show("Producto Agregado");
            }
        }

        //Actualiza el producto
        private void updateProduct()
        {
            string id = "0";
            string name = "nuevo nombre";
            int quant = 79 ;
            float price = 8;

            //envia los datos al controlador y returna true/false
            bool exito = controller.updateProduct(id, name, quant, price);
            if (exito)
            {
                MessageBox.Show("Producto Editado");
            }
        }

        //Elimina un producto
        private void deleteProduct()
        {
            string id = "0";
            bool exito = controller.deleteProduct(id);
            if (exito)
            {
                MessageBox.Show("Producto Eliminado");
            }
        }
    }
}
