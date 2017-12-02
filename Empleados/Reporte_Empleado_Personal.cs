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


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
namespace Empleados
{
    public partial class Reporte_Empleado_Personal : Form
    {

        SQLiteConnection conexion;

        public Reporte_Empleado_Personal()
        {
            InitializeComponent();
        }

        private void Reporte_Empleado_Personal_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");





            string factu = null;



            DataSet dset = new DataSet();




            string x = textBox1.Text;






            factu = "SELECT     empleado.cod_empleado, empleado.nombres, empleado.apellidos, empleado.cedula, empleado.fecha_ingreso, empleado.fecha_nacimiento, empleado.telefono,  empleado.direccion, empleado.sexo, cargo.nombre_cargo, departamento.nombre_departamento, sucursal.nombre_sucursal, empleado.salario,  empleado.numero_cuenta_nomina, empleado.estado, empleado.foto FROM         cargo INNER JOIN  empleado ON cargo.cod_cargo = empleado.cod_cargo INNER JOIN departamento ON empleado.cod_departamento = departamento.cod_departamento INNER JOIN  sucursal ON empleado.cod_sucursal = sucursal.cod_sucursal  where empleado.cedula like'" + x + "'";




            SQLiteDataAdapter fa = new SQLiteDataAdapter(factu, conexion);


            fa.Fill(dset, "empleado");




            Reporte_informe_empleados reportar = new Reporte_informe_empleados();



            reportar.SetDataSource(dset);


            crystalReportViewer1.ReportSource = reportar;
        }
    }
}
