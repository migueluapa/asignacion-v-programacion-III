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
    public partial class Detalle_Nomina : Form
    {
        public Detalle_Nomina()
        {
            InitializeComponent();
        }
        public SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");


        public void autogenerar()
        {


            //  SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");

            string ca;
            int t;

            string sql1 = "select cod_detalle_nomina  from  detalle_nomina";
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
        private void cargardato()
        {



            //SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");


            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();

            da = new SQLiteDataAdapter("SELECT empleado.cod_empleado,empleado.nombres,empleado.apellidos,empleado.cedula,empleado.fecha_ingreso,empleado.fecha_nacimiento,empleado.telefono,empleado.direccion,empleado.sexo,cargo.nombre_cargo,departamento.nombre_departamento,sucursal.nombre_sucursal,empleado.salario,empleado.numero_cuenta_nomina,empleado.estado,empleado.foto from empleado  inner join cargo on  cargo.cod_cargo=empleado.cod_cargo inner join departamento on departamento.cod_departamento=empleado.cod_departamento  inner join sucursal on  sucursal.cod_sucursal=empleado.cod_sucursal", conexion);

        

            da.Fill(dt);

            dataGridView2.DataSource = dt;

            conexion.Close();


        }

        private void guardar()
        {
            if (string.IsNullOrEmpty(txtnombres.Text) | string.IsNullOrEmpty(txtnombres.Text) | string.IsNullOrEmpty(txtnomina.Text) | string.IsNullOrEmpty(txtsueldo.Text) | string.IsNullOrEmpty(txttotal.Text) | string.IsNullOrEmpty(txtisr.Text) | string.IsNullOrEmpty(txtotro.Text) | string.IsNullOrEmpty(txtneto.Text))
            {


                MessageBox.Show("Debe Ingesar los Datos del Empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }



            SQLiteCommand cmd = new SQLiteCommand("insert into detalle_nomina values(@cod_detalle_nomina,@sueldo_bruto,@isr,@otro,@cod_empleado,@num_nomina,@tota_deduciones,@sueldo_neto)", conexion);




            cmd.Parameters.Add(new SQLiteParameter("@cod_detalle_nomina", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@sueldo_bruto", txtsueldo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@isr", txtisr.Text));

            cmd.Parameters.Add(new SQLiteParameter("@otro", txtotro.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cod_empleado", txtidempleado.Text));
            cmd.Parameters.Add(new SQLiteParameter("@num_nomina", txtnomina.Text));

            cmd.Parameters.Add(new SQLiteParameter("@tota_deduciones", txttotal.Text));
            cmd.Parameters.Add(new SQLiteParameter("@sueldo_neto", txtneto.Text));

            





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


            SQLiteCommand cmd = new SQLiteCommand("update detalle_nomina set sueldo_bruto=@sueldo_bruto,isr=@isr,otro=@otro,cod_empleado=@cod_empleado,num_nomina=@num_nomina,tota_deduciones=@tota_deduciones,sueldo_neto=@sueldo_neto   where cod_detalle_nomina=@cod_detalle_nomina", conexion);
          
            
            
            cmd.Parameters.Add(new SQLiteParameter("@cod_detalle_nomina", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@sueldo_bruto", txtsueldo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@isr", txtisr.Text));

            cmd.Parameters.Add(new SQLiteParameter("@otro", txtotro.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cod_empleado", txtidempleado.Text));
            cmd.Parameters.Add(new SQLiteParameter("@num_nomina", txtnomina.Text));

            cmd.Parameters.Add(new SQLiteParameter("@tota_deduciones", txttotal.Text));
            cmd.Parameters.Add(new SQLiteParameter("@sueldo_neto", txtneto.Text));


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


            SQLiteCommand cmd = new SQLiteCommand("delete from detalle_nomina  where cod_detalle_nomina=@cod_detalle_nomina", conexion);





            cmd.Parameters.Add(new SQLiteParameter("@cod_detalle_nomina", txtcodigo.Text));






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


            txtcedula.Text = "";
            txtnombres.Text = "";
            txtapellidos.Text = "";


            txtidempleado .Text = "";
        
          txtsueldo.Text = "";
        txtisr.Text = "";

             txtotro.Text = "";
           txtidempleado.Text = "";
         txtnomina.Text = "";

         txttotal.Text = "";
         txtneto.Text = "";









        }

        private void cargardato_detalle_nomina()
        {


            conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");



            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();

              



            da = new SQLiteDataAdapter("SELECT     detalle_nomina.cod_detalle_nomina as numero, detalle_nomina.cod_empleado as codigo, empleado.nombres, empleado.apellidos, empleado.cedula, detalle_nomina.sueldo_bruto,  detalle_nomina.isr, detalle_nomina.otro, detalle_nomina.num_nomina, detalle_nomina.tota_deduciones, detalle_nomina.sueldo_neto FROM         empleado INNER JOIN  detalle_nomina ON empleado.cod_empleado = detalle_nomina.cod_empleado", conexion);

            da.Fill(dt);

            this.dataGridView1.DataSource = dt;

            conexion.Close();


        }


        private void Detalle_Nomina_Load(object sender, EventArgs e)
        {

            panel1.Visible = false;
            autogenerar();

            button3.Enabled = true;
            button6.Enabled = false;
            button4.Enabled = false;

            cargardato_detalle_nomina();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;
            cargardato();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidempleado.Text = dataGridView2.CurrentRow.Cells["cod_empleado"].Value.ToString();

            txtnombres.Text = dataGridView2.CurrentRow.Cells["nombres"].Value.ToString();
            txtapellidos.Text = dataGridView2.CurrentRow.Cells["apellidos"].Value.ToString();
            txtcedula.Text = dataGridView2.CurrentRow.Cells["cedula"].Value.ToString();


            panel1.Visible = false;

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
            txtcodigo.Text = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();

            txtidempleado.Text = dataGridView1.CurrentRow.Cells["codigo"].Value.ToString();


            txtnombres.Text = dataGridView1.CurrentRow.Cells["nombres"].Value.ToString();
            txtapellidos.Text = dataGridView1.CurrentRow.Cells["apellidos"].Value.ToString();
            txtcedula.Text = dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();





            txtsueldo.Text = dataGridView1.CurrentRow.Cells["sueldo_bruto"].Value.ToString();
            txtisr.Text = dataGridView1.CurrentRow.Cells["isr"].Value.ToString();
            txtotro.Text = dataGridView1.CurrentRow.Cells["otro"].Value.ToString();

            txtnomina.Text = dataGridView1.CurrentRow.Cells["num_nomina"].Value.ToString();
            txttotal.Text = dataGridView1.CurrentRow.Cells["tota_deduciones"].Value.ToString();
            txtneto.Text = dataGridView1.CurrentRow.Cells["sueldo_neto"].Value.ToString();








            button3.Enabled = false;
            button6.Enabled = true;
            button4.Enabled = true;









        }
    }
}
