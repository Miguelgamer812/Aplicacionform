using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aplicaciónform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Boolean Validar = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'base_num2DataSet1.Productos' Puede moverla o quitarla según sea necesario.
            this.productosTableAdapter.Fill(this.base_num2DataSet1.Productos);
            MostrarProducto();
        }

        public void MostrarProducto()
        {
            CD_Conexion.Conectar();
            dataGridView1.DataSource = llenar_grid();
        }

        public DataTable llenar_grid()
        {
            CD_Conexion.Conectar();
            DataTable dt = new DataTable();
            string consulta = "select * from Productos";
            SqlCommand cmd = new SqlCommand(consulta, CD_Conexion.Conectar());

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);
            return dt;
        }

        public void Limpiar()
        {
            txtDescripcion.Text = "";
            txtNombre.Text = "";
            txtId.Text = "";
            txtPrecio.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    txtId.Text = dataGridView1.CurrentRow.Cells["Id_prod"].Value.ToString();
                    txtNombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                    txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                    txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();

                    Validar = true;

                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila, por favor");
            }

            if(Validar==true)
            {
                btnActualizar.Visible = true;
                btnEliminar.Visible = true;
            }
                    else
            {
                btnActualizar.Visible = false;
                btnEliminar.Visible = false;
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //SqlConnection conexion = new SqlConnection("server=Hp-Laptop14-cm1; database=Base_num2;integrated security = true");
            //conexion.Open();
            //string Descripcion = txtDescripcion.Text;
            //string Precio = txtPrecio.Text;
            //string Id_prod = txtId.Text; 
            //string Nombre = txtNombre.Text;
            //string Cadena = "insert into Productos(Id_prod, Nombre, Precio, Descripcion) values ('" + Id_prod + ","+Nombre+ "," + Precio + "," + Descripcion + "')";
            //SqlCommand comando = new SqlCommand(Cadena, conexion);
            //comando.ExecuteNonQuery();
            //MessageBox.Show("Los datos se guardaron correctamente");
            //txtDescripcion.Text = "";
            //txtPrecio.Text = "";
            //txtNombre.Text = "";
            //txtId.Text = "";
            //conexion.Close();

            CD_Conexion.Conectar();
            string insertar = "insert into Productos (Id_prod,Nombre,Precio,Descripcion) values (@Id_prod,@Nombre,@Precio,@Descripcion)";
            SqlCommand cmd = new SqlCommand(insertar, CD_Conexion.Conectar());
            cmd.Parameters.AddWithValue("@Id_prod", txtId.Text);
            cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@Precio", txtPrecio.Text);
            cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Los datos fueron agregados");
            dataGridView1.DataSource = llenar_grid();
            Limpiar();
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    CD_Conexion.Conectar();
                    string actualizar = "Update Productos Set Id_prod=@Id_prod, Nombre=@Nombre, Precio=@Precio, Descripcion=@Descripcion Where Id_prod=@Id_prod";
                    SqlCommand cmd = new SqlCommand(actualizar, CD_Conexion.Conectar());

                    cmd.Parameters.AddWithValue("@Id_prod", txtId.Text);
                    cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Precio", txtPrecio.Text);
                    cmd.Parameters.AddWithValue("@Descripcion", txtDescripcion.Text);

                    cmd.ExecuteNonQuery();

                    

                    dataGridView1.DataSource = llenar_grid();
                    Limpiar();

                }
                catch (Exception ex)
                {

                }
                MessageBox.Show("Los datos fueron actualizados");
            }
            else
            {
                MessageBox.Show("Selecciona una fila, por favor");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    CD_Conexion.Conectar();
                    string eliminar = "Delete From Productos Where Id_prod=@Id_prod";
                    SqlCommand cmd = new SqlCommand(eliminar, CD_Conexion.Conectar());
                    cmd.Parameters.AddWithValue("@Id_prod", txtId.Text);

                    cmd.ExecuteNonQuery();

                    dataGridView1.DataSource = llenar_grid();
                    Limpiar();


                }
                catch (Exception ex)
                {

                }
                MessageBox.Show("Los datos fueron eliminados");

            }
            else
            {
                MessageBox.Show("Selecciona una fila, por favor");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                CD_Conexion.Conectar();
                string Buscar = "select * from Productos where Id_prod = " + txtBuscar.Text;
                SqlCommand cmd = new SqlCommand(Buscar, CD_Conexion.Conectar());
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
