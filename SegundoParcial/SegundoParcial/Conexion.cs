using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SegundoParcial
{
    class Conexion
    {
        private MySqlConnection conn =
              new MySqlConnection("Server=localhost;Database=account;Database=userlong;Uid=root;" +
                  "Pwd=usbw;SSL Mode=None");

        internal static MySqlConnection getConexion()
        {
            throw new NotImplementedException();
        }

        public MySqlCommand command;

        public MySqlConnection openConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
        public MySqlConnection closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }

    }
}


    

