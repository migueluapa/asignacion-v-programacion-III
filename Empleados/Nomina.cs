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
    public partial class Nomina : Form
    {
        public Nomina()
        {
            InitializeComponent();
        }

        public SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");

        private void cargardato_detalle_nomina()
        {


         

            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();





            da = new SQLiteDataAdapter("SELECT     detalle_nomina.cod_detalle_nomina as numero, detalle_nomina.cod_empleado as codigo, empleado.nombres, empleado.apellidos, empleado.cedula, detalle_nomina.sueldo_bruto,  detalle_nomina.isr, detalle_nomina.otro, detalle_nomina.num_nomina, detalle_nomina.tota_deduciones, detalle_nomina.sueldo_neto FROM         empleado INNER JOIN  detalle_nomina ON empleado.cod_empleado = detalle_nomina.cod_empleado", conexion);

            da.Fill(dt);

            this.dataGridView1.DataSource = dt;

            conexion.Close();


        }
        private void cargardato_nomina()
        {


          


            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();





            da = new SQLiteDataAdapter(" SELECT     cabecera_nomina.cod_cabecera_nomina as codigo, cabecera_nomina.cod_empleado as codempleado, empleado.nombres, empleado.apellidos, empleado.cedula, cabecera_nomina.nombre_empresa, cabecera_nomina.num_nomina, cabecera_nomina.fecha_inicio, cabecera_nomina.fecha_final,  cabecera_nomina.cod_detalle_nomina, detalle_nomina.sueldo_bruto, detalle_nomina.isr, detalle_nomina.otro, detalle_nomina.tota_deduciones,   detalle_nomina.sueldo_neto, cabecera_nomina.estado, cabecera_nomina.tipo_nomina FROM         cabecera_nomina INNER JOIN  detalle_nomina ON cabecera_nomina.cod_detalle_nomina = detalle_nomina.cod_detalle_nomina INNER JOIN  empleado ON cabecera_nomina.cod_empleado = empleado.cod_empleado AND detalle_nomina.cod_empleado = empleado.cod_empleado", conexion);

            da.Fill(dt);

            this.dataGridView2.DataSource = dt;

            conexion.Close();


        }

        public void autogenerar()
        {


          
            string ca;
            int t;

            string sql1 = "select cod_cabecera_nomina  from  cabecera_nomina";
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

        private void Nomina_Load(object sender, EventArgs e)
        {
            autogenerar();

           
            panel1.Visible = false;

            cargardato_nomina();



        }
        private void guardar()
        {
            if (string.IsNullOrEmpty(txtnombres.Text) | string.IsNullOrEmpty(txtnombres.Text) | string.IsNullOrEmpty(txtnomina.Text) | string.IsNullOrEmpty(txtsueldo.Text) | string.IsNullOrEmpty(txttotal.Text) | string.IsNullOrEmpty(txtisr.Text) | string.IsNullOrEmpty(txtotro.Text) | string.IsNullOrEmpty(txtneto.Text))
            {


                MessageBox.Show("Debe Ingesar los Datos del Empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }



            SQLiteCommand cmd = new SQLiteCommand("insert into cabecera_nomina values(@cod_cabecera_nomina,@nombre_empresa,@num_nomina,@fecha_inicio,@fecha_final,@cod_detalle_nomina,@estado,@tipo_nomina,@cod_empleado)", conexion);




            cmd.Parameters.Add(new SQLiteParameter("@cod_cabecera_nomina", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@nombre_empresa", txtempresa.Text));
            cmd.Parameters.Add(new SQLiteParameter("@num_nomina", txtnomina.Text));

            cmd.Parameters.Add(new SQLiteParameter("@fecha_inicio", txtinicio.Text));

            cmd.Parameters.Add(new SQLiteParameter("@fecha_final", txtfinal.Text));

            cmd.Parameters.Add(new SQLiteParameter("@cod_detalle_nomina", txtiddetallenomina.Text));
            cmd.Parameters.Add(new SQLiteParameter("@estado", txtestado.Text));


            cmd.Parameters.Add(new SQLiteParameter("@tipo_nomina", txttipo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cod_empleado", txtidempleado.Text));






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


            SQLiteCommand cmd = new SQLiteCommand("update cabecera_nomina set     nombre_empresa=@nombre_empresa,num_nomina=@num_nomina,fecha_inicio=@fecha_inicio,fecha_final=@fecha_final,cod_detalle_nomina=@cod_detalle_nomina,estado=@estado,tipo_nomina=@tipo_nomina,cod_empleado=@cod_empleado    where cod_cabecera_nomina=@cod_cabecera_nomina", conexion);




            cmd.Parameters.Add(new SQLiteParameter("@cod_cabecera_nomina", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@nombre_empresa", txtempresa.Text));
            cmd.Parameters.Add(new SQLiteParameter("@num_nomina", txtnomina.Text));

            cmd.Parameters.Add(new SQLiteParameter("@fecha_inicio", txtinicio.Text));

            cmd.Parameters.Add(new SQLiteParameter("@fecha_final", txtfinal.Text));

            cmd.Parameters.Add(new SQLiteParameter("@cod_detalle_nomina", txtiddetallenomina.Text));
            cmd.Parameters.Add(new SQLiteParameter("@estado", txtestado.Text));


            cmd.Parameters.Add(new SQLiteParameter("@tipo_nomina", txttipo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@cod_empleado", txtidempleado.Text));


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


            SQLiteCommand cmd = new SQLiteCommand("delete from cabecera_nomina  where cod_cabecera_nomina=@cod_cabecera_nomina", conexion);




            cmd.Parameters.Add(new SQLiteParameter("@cod_cabecera_nomina", txtcodigo.Text));






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


           

            txtsueldo.Text = "";
            txtisr.Text = "";

            txtotro.Text = "";
         
            txtnomina.Text = "";

            txttotal.Text = "";
            txtneto.Text = "";





            txtempresa.Text = "";
    txtnomina.Text = "";

           txtinicio.Text = "";

 txtfinal.Text = "";

 txtiddetallenomina.Text = "";
 txtestado.Text = "";


  txttipo.Text = "";
txtidempleado.Text = "";







        }


        private void button3_Click(object sender, EventArgs e)
        {

            guardar();

            cargardato_nomina();

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

        private void button1_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;

            cargardato_detalle_nomina();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtiddetallenomina.Text = dataGridView1.CurrentRow.Cells["numero"].Value.ToString();

            txtidempleado.Text = dataGridView1.CurrentRow.Cells["codigo"].Value.ToString();


            txtnombres.Text = dataGridView1.CurrentRow.Cells["nombres"].Value.ToString();
            txtapellidos.Text = dataGridView1.CurrentRow.Cells["apellidos"].Value.ToString();
            txtcedula.Text = dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();





            txtsueldo.Text = dataGridView1.CurrentRow.Cells["sueldo_bruto"].Value.ToString();
            txtisr.Text = dataGridView1.CurrentRow.Cells["isr"].Value.ToString();
            txtotro.Text = dataGridView1.CurrentRow.Cells["otro"].Value.ToString();

          
            txttotal.Text = dataGridView1.CurrentRow.Cells["tota_deduciones"].Value.ToString();
            txtneto.Text = dataGridView1.CurrentRow.Cells["sueldo_neto"].Value.ToString();


            panel1.Visible =false;

        
      

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ingreser los Datos Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();


            button3.Enabled = true;

   
            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();



        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            txtcodigo.Text = dataGridView2.CurrentRow.Cells["codigo"].Value.ToString();

            txtiddetallenomina.Text = dataGridView2.CurrentRow.Cells["cod_detalle_nomina"].Value.ToString();
            txtidempleado.Text = dataGridView2.CurrentRow.Cells["codempleado"].Value.ToString();


            txtnombres.Text = dataGridView2.CurrentRow.Cells["nombres"].Value.ToString();
            txtapellidos.Text = dataGridView2.CurrentRow.Cells["apellidos"].Value.ToString();
            txtcedula.Text = dataGridView2.CurrentRow.Cells["cedula"].Value.ToString();





            txtsueldo.Text = dataGridView2.CurrentRow.Cells["sueldo_bruto"].Value.ToString();
            txtisr.Text = dataGridView2.CurrentRow.Cells["isr"].Value.ToString();
            txtotro.Text = dataGridView2.CurrentRow.Cells["otro"].Value.ToString();

          
            txttotal.Text = dataGridView2.CurrentRow.Cells["tota_deduciones"].Value.ToString();
            txtneto.Text = dataGridView2.CurrentRow.Cells["sueldo_neto"].Value.ToString();



            txtempresa.Text = dataGridView2.CurrentRow.Cells["nombre_empresa"].Value.ToString();
            txtnomina.Text = dataGridView2.CurrentRow.Cells["num_nomina"].Value.ToString();
            txtinicio.Text = dataGridView2.CurrentRow.Cells["fecha_inicio"].Value.ToString();


            txtfinal.Text = dataGridView2.CurrentRow.Cells["fecha_final"].Value.ToString();
            txtestado.Text = dataGridView2.CurrentRow.Cells["estado"].Value.ToString();
            txttipo.Text = dataGridView2.CurrentRow.Cells["tipo_nomina"].Value.ToString();





            button3.Enabled = false;
            button6.Enabled = true;
            button4.Enabled = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {

            modificar();

            cargardato_nomina();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            eliminar();

            cargardato_nomina();
        }
    }
}
