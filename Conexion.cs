using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Veterinario
{
    class Conexion
    {
        public MySqlConnection conexion;

        public Conexion()
        {
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = veterinario; Uid = root; Pwd =; Port = 3306;");
        }

        public Boolean loginVeterinario(String DNI, String pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("SELECT * FROM usuario WHERE DNI = @DNI AND Pass = @pass", conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@pass", pass);

                MySqlDataReader resultado = consulta.ExecuteReader();

                if (resultado.Read())
                {
                    return true;
                }

                conexion.Close();
                return false;
            }
            catch (MySqlException e)
            {
                return false;
            }

        }

        public String insertaUsuario(String DNI, String Nombre, String Pass)
        {
            try
            {
                conexion.Open();
                MySqlCommand consulta = new MySqlCommand("INSERT INTO usuario (id, DNI, Nombre, Pass) VALUES (NULL, @DNI, @Nombre, @Pass)",conexion);
                consulta.Parameters.AddWithValue("@DNI", DNI);
                consulta.Parameters.AddWithValue("@Nombre", Nombre);
                consulta.Parameters.AddWithValue("@Pass", Pass);

                consulta.ExecuteNonQuery();

                conexion.Close();
                return "ok";
            }
            catch (MySqlException e)
            {
                return "error";
            }
        }

    }
}
