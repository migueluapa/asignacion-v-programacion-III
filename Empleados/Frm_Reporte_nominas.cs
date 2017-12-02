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
    public partial class Frm_Reporte_nominas : Form
    {
        SQLiteConnection conexion;

        public Frm_Reporte_nominas()
        {
            InitializeComponent();
        }

        private void Frm_Reporte_nominas_Load(object sender, EventArgs e)
        {

            conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");





            string factu = null;



            DataSet dset = new DataSet();






            factu = "SELECT     detalle_nomina.cod_detalle_nomina as codigo, empleado.nombres, empleado.apellidos, detalle_nomina.sueldo_bruto,sueldo_bruto * 0.12 as isr, sueldo_bruto * 0.04 as ss ,sueldo_bruto *0.02 as otros ,sueldo_bruto * (0.12*0.04-0.02) AS tota_deduciones ,sueldo_bruto - (sueldo_bruto * 0.18) as sueldo_neto from detalle_nomina   INNER JOIN empleado ON empleado.cod_empleado = detalle_nomina.cod_empleado";




            SQLiteDataAdapter fa = new SQLiteDataAdapter(factu, conexion);


            fa.Fill(dset, "detalle_nomina");



            Reporte_Nomina_Emple reportar = new Reporte_Nomina_Emple();



            reportar.SetDataSource(dset);


            crystalReportViewer1.ReportSource = reportar;
        }
    }
}
