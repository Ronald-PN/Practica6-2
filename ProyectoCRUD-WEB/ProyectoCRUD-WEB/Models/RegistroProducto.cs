using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoCRUD_WEB.Models
{
    public class RegistroProducto
    {

        private SqlConnection con;
        //Conectarse a DB
        private void Conectar()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConexionDB"].ToString();
            con = new SqlConnection(constr);
        }
        //Grabar un registro en la DB
        public int GrabarProducto(Producto produ)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Insert into Productos (Id, Descripcion, Tipo, Precio)" +
                                                "Values @Id, @Descripcion,@Tipo,@Precio)", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters.Add("@Tipo", SqlDbType.VarChar);
            comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            comando.Parameters["@Id"].Value = produ.Id;
            comando.Parameters["@Descripcion"].Value = produ.Descripcion;
            comando.Parameters["@Tipo"].Value = produ.Tipo;
            comando.Parameters["@Precio"].Value = produ.Precio;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        // Mostrar todos los registros de la DB
        public List<Producto> RecuperarTodos()
        {
            Conectar();
            List<Producto> productos = new List<Producto>();
            SqlCommand com = new SqlCommand("Select Id, Descripcion, Tipo, Precio From Productos", con);
            con.Open();
            SqlDataReader registros = com.ExecuteReader();
            while (registros.Read())
            {
                Producto produ = new Producto
                {
                    Id = int.Parse(registros["Id"].ToString()),
                    Descripcion = registros["Descripcion"].ToString(),
                    Tipo = registros["Tipo"].ToString(),
                    Precio = decimal.Parse(registros["Precio"].ToString())
                };
                productos.Add(produ);
            }
            con.Close();
            return productos;
        }
        //mostrar un registro especifico de la DB
        public Producto Recuperar(int id)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Select Id, Descripcion, Tipo, Precio" +
                                                "From Productos where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = id;
            con.Open();
            SqlDataReader registros = comando.ExecuteReader();
            Producto producto = new Producto();
            if (registros.Read())
            {

                producto.Descripcion = registros["Descripcion"].ToString();
                producto.Tipo = registros["Tipo"].ToString();
                producto.Precio = decimal.Parse(registros["Precio"].ToString());
            }
            con.Close();
            return producto;
        }
        //Crear un registro de la DB
        public int Crear(Producto produ)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Update Productos set Descripcion=@Descripcion, Tipo=@Tipo, Precio=@Precio where Id=@Id", con);


            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters["@Descripcion"].Value = produ.Descripcion;
            comando.Parameters.Add("Tipo", SqlDbType.VarChar);
            comando.Parameters["@Tipo"].Value = produ.Tipo;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            comando.Parameters["@Precio"].Value = produ.Precio;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

        //Modificar un registro especifico de la DB
        public int Modificar(Producto produ)
        {
            Conectar();
            SqlCommand comando = new SqlCommand("Update Productos set  Descripcion=@Descripcion, Tipo=@Tipo, Precio=@Precio Where Id=@Id", con);

            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar);
            comando.Parameters["@Descripcion"].Value = produ.Descripcion;
            comando.Parameters.Add("Tipo", SqlDbType.VarChar);
            comando.Parameters["@Tipo"].Value = produ.Tipo;
            comando.Parameters.Add("@Precio", SqlDbType.Decimal);
            comando.Parameters["@Precio"].Value = produ.Precio;

            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }
        // borrar un registro especifico de la DB
        public int Borrar(int id)
        {
            SqlCommand comando = new SqlCommand("delete from Producto where Id=@Id", con);
            comando.Parameters.Add("@Id", SqlDbType.Int);
            comando.Parameters["@Id"].Value = id;
            con.Open();
            int i = comando.ExecuteNonQuery();
            con.Close();
            return i;
        }

    }
}
