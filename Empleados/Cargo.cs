using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
namespace Empleados
{
    public partial class Cargo : Form
    {
        public Cargo()
        {
            InitializeComponent();
        }
        public SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");
       
        
        
        private void cargardato_detalle_nomina()
        {


            conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");



            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();





            da = new SQLiteDataAdapter("SELECT    cod_cargo as codigo, nombre_cargo as cargo, descripcion from  cargo", conexion);

            da.Fill(dt);

            this.dataGridView1.DataSource = dt;

            conexion.Close();


        }

        private void guardar()
        {
            if (string.IsNullOrEmpty(txtnombres.Text) | string.IsNullOrEmpty(txtnombres.Text) | string.IsNullOrEmpty(txtapellidos.Text) )
            {


                MessageBox.Show("Debe Ingesar los Datos del Cargo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }



            SQLiteCommand cmd = new SQLiteCommand("insert into cargo values(@cod_cargo,@nombre_cargo,@descripcion)", conexion);

        


            cmd.Parameters.Add(new SQLiteParameter("@cod_cargo", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@nombre_cargo", txtnombres.Text));
            cmd.Parameters.Add(new SQLiteParameter("@descripcion", txtapellidos.Text));




            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()





            MessageBox.Show("Asido Registrado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();


        }







        private void modificar()
        {


            SQLiteCommand cmd = new SQLiteCommand("update cargo set nombre_cargo=@nombre_cargo,descripcion=@descripcion where cod_cargo=@cod_cargo", conexion);


            cmd.Parameters.Add(new SQLiteParameter("@cod_cargo", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@nombre_cargo", txtnombres.Text));
            cmd.Parameters.Add(new SQLiteParameter("@descripcion", txtapellidos.Text));

            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()





            MessageBox.Show("Asido Modificado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();


        }




        private void eliminar()
        {


            SQLiteCommand cmd = new SQLiteCommand("delete from cargo  where cod_cargo=@cod_cargo", conexion);




            cmd.Parameters.Add(new SQLiteParameter("@cod_cargo", txtcodigo.Text));






            conexion.Open();

            cmd.ExecuteNonQuery();


            //     conexion.Close()





            MessageBox.Show("Asido Eliminado los Datos", "Correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);


            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();


        }







        public void borar()
        {


    

            txtnombres.Text = "";
            txtapellidos.Text = "";

        }

        public void autogenerar()
        {


            SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");

            string ca;
            int t;

            string sql1 = "select cod_cargo  from  cargo";
            SQLiteDataAdapter dacategoria = new SQLiteDataAdapter(sql1, conexion);
            DataTable dtcategoria = new DataTable();
            dacategoria.Fill(dtcategoria);
            t = dtcategoria.Rows.Count;
            conexion.Close();
            ca = (t + 1).ToString();
            do
            {
                ca = "0" + ca;
            } while (ca.Length < 2);
            this.txtcodigo.Text = ca;



        }

        private void Cargo_Load(object sender, EventArgs e)
        {
         



            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

      
            cargardato_detalle_nomina();

            autogenerar();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            guardar();

            cargardato_detalle_nomina();


        }

        private void button6_Click(object sender, EventArgs e)
        {

            modificar();

            cargardato_detalle_nomina();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            eliminar();

            cargardato_detalle_nomina();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("¿Desea Salir del Registro?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.No)
            {

                return;



            }

            this.Dispose();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            txtcodigo.Text = dataGridView1.CurrentRow.Cells["codigo"].Value.ToString();

            txtnombres.Text = dataGridView1.CurrentRow.Cells["cargo"].Value.ToString();
            txtapellidos.Text = dataGridView1.CurrentRow.Cells["descripcion"].Value.ToString();



            button3.Enabled = false;


            button6.Enabled = true;
            button4.Enabled = true;









        }
    }
}
