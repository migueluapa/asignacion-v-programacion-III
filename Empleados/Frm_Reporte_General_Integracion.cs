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
    public partial class Frm_Reporte_General_Integracion : Form
    {
        SQLiteConnection conexion;

        public Frm_Reporte_General_Integracion()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_General_Integracion_Load(object sender, EventArgs e)
        {
            conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");





            string factu = null;



            DataSet dset = new DataSet();






            factu = "SELECT      empleado.nombres, empleado.apellidos, cargo.nombre_cargo, sucursal.nombre_sucursal,  departamento.nombre_departamento, cabecera_nomina.nombre_empresa,   detalle_nomina.sueldo_bruto,sueldo_bruto * 0.12 as isr, sueldo_bruto * 0.04 as ss ,sueldo_bruto *0.02 as otros ,sueldo_bruto * (0.12*0.04-0.02) AS tota_deduciones ,sueldo_bruto - (sueldo_bruto * 0.18) as sueldo_neto FROM         detalle_nomina INNER JOIN cabecera_nomina ON detalle_nomina.cod_detalle_nomina = cabecera_nomina.cod_detalle_nomina INNER JOIN  empleado ON detalle_nomina.cod_empleado = empleado.cod_empleado AND cabecera_nomina.cod_empleado = empleado.cod_empleado INNER JOIN   cargo ON empleado.cod_cargo = cargo.cod_cargo INNER JOIN  sucursal ON empleado.cod_sucursal = sucursal.cod_sucursal INNER JOIN  departamento ON empleado.cod_departamento = departamento.cod_departamento";




            SQLiteDataAdapter fa = new SQLiteDataAdapter(factu, conexion);


            fa.Fill(dset, "detalle_nomina");



            Reporte_Nomina_empleadosx reportar = new Reporte_Nomina_empleadosx();



            reportar.SetDataSource(dset);


            crystalReportViewer1.ReportSource = reportar;
        }
    }
}
