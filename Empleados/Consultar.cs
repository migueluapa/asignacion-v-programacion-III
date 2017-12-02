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
    public partial class Consultar : Form
    {
        public Consultar()
        {
            InitializeComponent();
        }

        public SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");

        // public SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");

        private void cargardato_nomina()
        {


  

            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();





            da = new SQLiteDataAdapter(" SELECT     cabecera_nomina.cod_cabecera_nomina as codigo, empleado.nombres, empleado.apellidos, empleado.cedula, cabecera_nomina.nombre_empresa, cabecera_nomina.num_nomina, cabecera_nomina.fecha_inicio, cabecera_nomina.fecha_final,   detalle_nomina.sueldo_bruto, detalle_nomina.isr, detalle_nomina.otro, detalle_nomina.tota_deduciones,   detalle_nomina.sueldo_neto, cabecera_nomina.estado, cabecera_nomina.tipo_nomina FROM         cabecera_nomina INNER JOIN  detalle_nomina ON cabecera_nomina.cod_detalle_nomina = detalle_nomina.cod_detalle_nomina INNER JOIN  empleado ON cabecera_nomina.cod_empleado = empleado.cod_empleado AND detalle_nomina.cod_empleado = empleado.cod_empleado", conexion);

            da.Fill(dt);

            this.dataGridView1.DataSource = dt;

            conexion.Close();


        }

        private void Consultar_Load(object sender, EventArgs e)
        {

            cargardato_nomina();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            {
                conexion.Open();

                string sql = " SELECT     cabecera_nomina.cod_cabecera_nomina as codigo,  empleado.nombres, empleado.apellidos, empleado.cedula, cabecera_nomina.nombre_empresa, cabecera_nomina.num_nomina, cabecera_nomina.fecha_inicio, cabecera_nomina.fecha_final,  detalle_nomina.sueldo_bruto, detalle_nomina.isr, detalle_nomina.otro, detalle_nomina.tota_deduciones,   detalle_nomina.sueldo_neto, cabecera_nomina.estado, cabecera_nomina.tipo_nomina FROM         cabecera_nomina INNER JOIN  detalle_nomina ON cabecera_nomina.cod_detalle_nomina = detalle_nomina.cod_detalle_nomina INNER JOIN  empleado ON cabecera_nomina.cod_empleado = empleado.cod_empleado AND detalle_nomina.cod_empleado = empleado.cod_empleado     WHERE cabecera_nomina.num_nomina like '" + textBox1.Text + "%'";

                SQLiteDataAdapter dacliente = new SQLiteDataAdapter(sql, conexion);

                DataTable dtcliente = new DataTable();

                dacliente.Fill(dtcliente);
                dataGridView1.DataSource = dtcliente;

                conexion.Close();
            }




        }
    }
}
