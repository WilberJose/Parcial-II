using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SegundoParcial
{
    class Control
    {
        public string ControlRegistro(Usuarios usuario)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.Firstname) || string.IsNullOrEmpty(usuario.Lastname) || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Username) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.Confirmpassword))
            {
                respuesta = "Debe llenar todos los campos";
            } else
            {
            }
            if(usuario.Password == usuario.Confirmpassword)
            {
                if (modelo.existeUsuario(usuario.Firstname))
                {
                    respuesta = "El usuario ya existe";
                }
                else
                {
                    usuario.Password = generarSHA1(usuario.Password);
                    modelo.Registro(usuario);
                }
            } else
            {
                respuesta = "Las contraseñas no coinciden";
            }
            return respuesta;
        }

        public string controlLogin(string usuario, string password)
        {
            Modelo modelo = new Modelo();
            string respuesta = "";
            Usuarios datosUsuarios = null;

            if(string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos";
            } else
            {
                datosUsuarios = modelo.porUsuario(usuario);

                if(datosUsuarios == null)
                {
                    respuesta = "El usuario no existe";
                } else 
                {
                    if(datosUsuarios.Password != generarSHA1(password))

                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    } else
                    {
                        
                        Sesion.id = datosUsuarios.Id;
                        Sesion.usuario = datosUsuarios.Firstname;
                        Sesion.id_tipo = datosUsuarios.Id_tipo;
                    }
                }
            }
            return respuesta;
        }

        private string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            stringBuilder sb = new stringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                }
            }

            return sb.ToString();
        }
    }
}







