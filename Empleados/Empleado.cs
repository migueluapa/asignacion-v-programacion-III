using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;


using System.Windows.Forms;

namespace Empleados
{
    public partial class Empleado : Form
    {




        public Empleado()
        {
            InitializeComponent();
        }

        public SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");

    


      public bool InsertSQL(string sql)
{
      try
         {

    conexion.Open();

    SQLiteCommand Command = new SQLiteCommand(sql, conexion);


    int i = Command.ExecuteNonQuery();

    return true;

      
       }
      catch  (Exception e)

     {
    string  n= e.Message;
    return false;



     }
    finally 
    {

   conexion.Close();

   
}
    
}
        public void autogenerar()
        {


            SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");

            string ca;
            int t;

            string sql1 = "select cod_empleado  from  empleado";
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



            SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");


            conexion.Open();


            SQLiteDataAdapter da;
            DataTable dt = new DataTable();


            da = new SQLiteDataAdapter("SELECT  * from empleado ", conexion);

            da.Fill(dt);

            this.dataGridView1.DataSource = dt;

            conexion.Close();


        }
       



        private void Empleado_Load(object sender, EventArgs e)
        {
            button7.Enabled = false;

            panel1.Visible = false;



            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();
            sucursal();
            departamento();
            cbodepartamento.Text = "";
            cbosucursal.Text = "";

            cargo();
            cbocargo.Text = "";

        }



        private void  guardar()

            {
             if (string.IsNullOrEmpty(cbodepartamento.Text) | string.IsNullOrEmpty(txtnombres.Text) | string.IsNullOrEmpty(txtapellidos.Text) | string.IsNullOrEmpty(txtnacimiento.Text) | string.IsNullOrEmpty(txttelefono.Text) | string.IsNullOrEmpty(cbocargo.Text) |  string.IsNullOrEmpty(txtcedula.Text) | string.IsNullOrEmpty(cbosucursal.Text))
            {
            

                MessageBox.Show("Debe Ingesar los Datos del Empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                return;
            }



             SQLiteCommand cmd = new SQLiteCommand("insert into empleado values(@cod_empleado,@nombres,@apellidos,@cedula,@fecha_ingreso,@fecha_nacimiento,@telefono,@direccion,@sexo,@cod_cargo,@cod_departamento,@cod_sucursal,@salario,@numero_cuenta_nomina,@estado,@foto)", conexion);

            MemoryStream stream = new MemoryStream();

            pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);



            cmd.Parameters.Add(new SQLiteParameter("@cod_empleado", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@nombres", txtnombres.Text));
            cmd.Parameters.Add(new SQLiteParameter("@apellidos", txtapellidos.Text));

            cmd.Parameters.Add(new SQLiteParameter("@cedula", txtcedula.Text));
            cmd.Parameters.Add(new SQLiteParameter("@fecha_ingreso", txtingreso.Text));
            cmd.Parameters.Add(new SQLiteParameter("@fecha_nacimiento", txtnacimiento.Text));

            cmd.Parameters.Add(new SQLiteParameter("@telefono", txttelefono.Text));
            cmd.Parameters.Add(new SQLiteParameter("@direccion", txtdireccion.Text));

            cmd.Parameters.Add(new SQLiteParameter("@sexo", txtsexo.Text));

            cmd.Parameters.Add(new SQLiteParameter("@cod_cargo", cbocargo.SelectedValue));
            cmd.Parameters.Add(new SQLiteParameter("@cod_departamento", cbodepartamento.SelectedValue));
            cmd.Parameters.Add(new SQLiteParameter("@cod_sucursal", cbosucursal.SelectedValue));

 
            cmd.Parameters.Add(new SQLiteParameter("@salario", txtsalario.Text));
            cmd.Parameters.Add(new SQLiteParameter("@numero_cuenta_nomina", txtcuenta.Text));

            cmd.Parameters.Add(new SQLiteParameter("@estado", txtestado.Text));



            byte[] pic = stream.ToArray();

            cmd.Parameters.AddWithValue("@FOTO", pic);



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


            SQLiteCommand cmd = new SQLiteCommand("update empleado set nombres=@nombres,apellidos=@apellidos,cedula=@cedula,fecha_ingreso=@fecha_ingreso,fecha_nacimiento=@fecha_nacimiento,telefono=@telefono,direccion=@direccion,sexo=@sexo,cod_cargo=@cod_cargo,cod_departamento=@cod_departamento,cod_sucursal=@cod_sucursal,salario=@salario,numero_cuenta_nomina=@numero_cuenta_nomina,estado=@estado,foto=@foto where cod_empleado=@cod_empleado", conexion);

            MemoryStream stream = new MemoryStream();

            pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);



            cmd.Parameters.Add(new SQLiteParameter("@cod_empleado", txtcodigo.Text));
            cmd.Parameters.Add(new SQLiteParameter("@nombres", txtnombres.Text));
            cmd.Parameters.Add(new SQLiteParameter("@apellidos", txtapellidos.Text));

            cmd.Parameters.Add(new SQLiteParameter("@cedula", txtcedula.Text));
            cmd.Parameters.Add(new SQLiteParameter("@fecha_ingreso", txtingreso.Text));
            cmd.Parameters.Add(new SQLiteParameter("@fecha_nacimiento", txtnacimiento.Text));

            cmd.Parameters.Add(new SQLiteParameter("@telefono", txttelefono.Text));
            cmd.Parameters.Add(new SQLiteParameter("@direccion", txtdireccion.Text));

            cmd.Parameters.Add(new SQLiteParameter("@sexo", txtsexo.Text));

            cmd.Parameters.Add(new SQLiteParameter("@cod_cargo", cbocargo.SelectedValue));
            cmd.Parameters.Add(new SQLiteParameter("@cod_departamento", cbodepartamento.SelectedValue));
            cmd.Parameters.Add(new SQLiteParameter("@cod_sucursal", cbosucursal.SelectedValue));




            cmd.Parameters.Add(new SQLiteParameter("@salario", txtsalario.Text));
            cmd.Parameters.Add(new SQLiteParameter("@numero_cuenta_nomina", txtcuenta.Text));

            cmd.Parameters.Add(new SQLiteParameter("@estado", txtestado.Text));



            byte[] pic = stream.ToArray();

            cmd.Parameters.AddWithValue("@FOTO", pic);



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


            SQLiteCommand cmd = new SQLiteCommand("delete from empleado  where cod_empleado=@cod_empleado", conexion);

          


            cmd.Parameters.Add(new SQLiteParameter("@cod_empleado", txtcodigo.Text));
           

           



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
            txtingreso.Text = "";
            txtnacimiento.Text = "";


           txtnombres.Text = "";
        txtapellidos.Text = "";

          txtcedula.Text = "";
     txtingreso.Text = "";
 txtnacimiento.Text = "";

txttelefono.Text = "";
  txtdireccion.Text = "";
        cbocargo.Text = "";
        txtsexo.Text = "";
        cbosucursal.Text = "";

      cbodepartamento.Text = "";
 txtsalario.Text = "";
       txtcuenta.Text = "";

       txtestado.Text = "";


            pictureBox1.Visible = false;

            pictureBox2.Visible = true;


            textBox1.Text = "";
        }


        private void button3_Click(object sender, EventArgs e)
        {



         


            guardar();

            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Bitmap bmImagen;
                
                openFileDialog1.Filter = "jpeg (*.jpg,*.jpeg)|*.jpg;*.jpeg|gif (*.gif)|*.gif|bitmap   (*.bmp)|*.bmp";
                 
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                   
                    string sNombre = openFileDialog1.FileName;
                   
                    bmImagen = new Bitmap(sNombre);
             
                    pictureBox1.Image = bmImagen;

                    pictureBox1.Visible = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            modificar();
            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;
            button7.Enabled = false;
            autogenerar();

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

        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Ingreser los Datos Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            borar();


            button3.Enabled = true;

            button7.Enabled = false;
            button6.Enabled = false;
            button4.Enabled = false;

            autogenerar();

 


        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            
            
            eliminar();



            borar();


            button3.Enabled = true;


            button6.Enabled = false;
            button4.Enabled = false;
            button7.Enabled = false;
            autogenerar();








        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

            panel1.Visible = true;


            cargardato();
            button7.Enabled = true;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["cedula"].Value.ToString();

            panel1.Visible = false;

            button3.Enabled = false;


            button6.Enabled = true;
            button4.Enabled = true;


        }
        public void cargo()
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");


            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from cargo", conexion);



            DataSet ds = new DataSet();
            da.Fill(ds, "cargo");



            cbocargo.DataSource = ds.Tables[0].DefaultView;

            this.cbocargo.DisplayMember = "nombre_cargo";
            this.cbocargo.ValueMember = "cod_cargo";



        }

        public void departamento()
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");


            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from departamento", conexion);



            DataSet ds = new DataSet();
            da.Fill(ds, "departamento");



            cbodepartamento.DataSource = ds.Tables[0].DefaultView;

            this.cbodepartamento.DisplayMember = "nombre_departamento";
            this.cbodepartamento.ValueMember = "cod_departamento";



        }

        public void sucursal()
        {
            SQLiteConnection conexion = new SQLiteConnection("Data Source=C:/Users/User/Documents/Visual C #-SQLite/Empleados_BD_SQLite.s3db");


            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from sucursal", conexion);



            DataSet ds = new DataSet();
            da.Fill(ds, "sucursal");



            cbosucursal.DataSource = ds.Tables[0].DefaultView;

            this.cbosucursal.DisplayMember = "nombre_sucursal";
            this.cbosucursal.ValueMember = "cod_sucursal";



        }
        private void  buscar ()
            {



                //conexion = new SQLiteConnection("Data Source=C:/Users/Miguel/Desktop/Visual C #-SQLite/Empleados_BD_SQLite.s3db");



                SQLiteDataAdapter adp = new SQLiteDataAdapter("SELECT empleado.cod_empleado,empleado.nombres,empleado.apellidos,empleado.cedula,empleado.fecha_ingreso,empleado.fecha_nacimiento,empleado.telefono,empleado.direccion,empleado.sexo,cargo.nombre_cargo,departamento.nombre_departamento,sucursal.nombre_sucursal,empleado.salario,empleado.numero_cuenta_nomina,empleado.estado,empleado.foto from empleado  inner join cargo on  cargo.cod_cargo=empleado.cod_cargo inner join departamento on departamento.cod_departamento=empleado.cod_departamento  inner join sucursal on  sucursal.cod_sucursal=empleado.cod_sucursal  WHERE empleado.cedula LIKE '%" + this.textBox1.Text + "%'", conexion);
           
            DataSet ds = new DataSet("foto");
            adp.Fill(ds, "foto");
          
            this.txtcodigo.Text = ds.Tables[0].Rows[0]["cod_empleado"].ToString();
            this.txtnombres.Text = ds.Tables[0].Rows[0]["nombres"].ToString();


            this.txtapellidos.Text = ds.Tables[0].Rows[0]["apellidos"].ToString();
            this.txtcedula.Text = ds.Tables[0].Rows[0]["cedula"].ToString();

            this.txtingreso.Text = ds.Tables[0].Rows[0]["fecha_ingreso"].ToString();

            this.txtnacimiento.Text = ds.Tables[0].Rows[0]["fecha_nacimiento"].ToString();


            this.txttelefono.Text = ds.Tables[0].Rows[0]["telefono"].ToString();
            this.txtdireccion.Text = ds.Tables[0].Rows[0]["direccion"].ToString();

            this.txtsexo.Text = ds.Tables[0].Rows[0]["sexo"].ToString();


            this.cbocargo.Text = ds.Tables[0].Rows[0]["nombre_cargo"].ToString();


            this.cbodepartamento.Text = ds.Tables[0].Rows[0]["nombre_departamento"].ToString();

            this.cbosucursal.Text = ds.Tables[0].Rows[0]["nombre_sucursal"].ToString();


            this.txtsalario.Text = ds.Tables[0].Rows[0]["salario"].ToString();
            this.txtcuenta.Text = ds.Tables[0].Rows[0]["numero_cuenta_nomina"].ToString();

            this.txtestado.Text = ds.Tables[0].Rows[0]["estado"].ToString();
          

    



            byte[] datos = new byte[0];

            DataRow dr = ds.Tables["foto"].Rows[0];

            datos = (byte[])dr["foto"];

            System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);

            pictureBox1.Image = System.Drawing.Bitmap.FromStream(ms);

            pictureBox1.Visible = true;

            }

        private void button7_Click(object sender, EventArgs e)
        {

            buscar();

            try
            {


                //buscar();

            }
            catch (Exception )
            {
               
            }
            finally
            {
                
            }



        }

        private void button9_Click(object sender, EventArgs e)
        {
            Ver_Listado abrir = new Ver_Listado();

            abrir.Show();


        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            
        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtsalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcuenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

                MessageBox.Show("Solo se Ingresa Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



            }
        }

        private void txtapellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

                MessageBox.Show("Solo se Ingresa Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



            }
        }

        private void txtcargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

                MessageBox.Show("Solo se Ingresa Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



            }
        }

        private void txtestado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

                MessageBox.Show("Solo se Ingresa Letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
