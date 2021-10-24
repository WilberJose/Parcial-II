using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    class Modelo
    {
        public int Registro(Usuarios usuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "INSERT INTO usuarios (firstname, lastname, email, username, password, id_tipo) VALUES @firstname, @lastname, @email, @username, @password, @id_tipo";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@firstname", usuario.Firstname);
            comando.Parameters.AddWithValue("@lastname", usuario.Lastname);
            comando.Parameters.AddWithValue("@email", usuario.Email);
            comando.Parameters.AddWithValue("@username", usuario.Username);
            comando.Parameters.AddWithValue("@password", usuario.Password);
            comando.Parameters.AddWithValue("@id_tipo", 1);

            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }
        public bool existeUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id FROM usuarios WHERE firstname LIKE @firstname";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@firstname", usuario);

            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true; 
            } else
            {
                return false; 
            }
        }

        public Usuarios porUsuario (string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id, password, firstname, id_tipo FROM usuarios WHERE firstname LIKE @firstname";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@firstname", usuario);

            reader = comando.ExecuteReader();

            Usuarios usr = null; 

            while(reader.Read())
            {
                usr = new Usuarios();
                usr.Id = int.Parse(reader["id"].ToString());
                usr.Password = reader["password"].ToString();
                usr.Username = reader["Username"].ToString();
                usr.Id_tipo = int.Parse(reader["id_tipo"].ToString());
            }
            return usr; 
            }
        }
}



