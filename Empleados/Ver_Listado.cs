using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;


using System.Windows.Forms;

namespace Empleados
{
    public partial class Ver_Listado : Form
    {
        public Ver_Listado()
        {
            InitializeComponent();
        }

        public SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");


        private void cargardato()
        {





            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();


            da = new SQLiteDataAdapter("SELECT empleado.cod_empleado,empleado.nombres,empleado.apellidos,empleado.cedula,empleado.fecha_ingreso,empleado.fecha_nacimiento,empleado.telefono,empleado.direccion,empleado.sexo,cargo.nombre_cargo,departamento.nombre_departamento,sucursal.nombre_sucursal,empleado.salario,empleado.numero_cuenta_nomina,empleado.estado,empleado.foto from empleado  inner join cargo on  cargo.cod_cargo=empleado.cod_cargo inner join departamento on departamento.cod_departamento=empleado.cod_departamento  inner join sucursal on  sucursal.cod_sucursal=empleado.cod_sucursal", conexion);

            da.Fill(dt);

            this.dataGridView1.DataSource = dt;

            conexion.Close();


        }


        private void Ver_Listado_Load(object sender, EventArgs e)
        {
             cargardato();

        }
    }
}
