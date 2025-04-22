using Matriculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matriculas.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }

        public DBExamenEntities DBExamen = new DBExamenEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }

        private bool ValidarUsuario()
        {
            try
            {
                Estudiante estudiante = DBExamen.Estudiantes
                    .FirstOrDefault(u => u.Usuario == login.Usuario);

                if (estudiante == null)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Estudiante no existe";
                    return false;
                }

                // Se guarda la clave del estudiante para comparar luego
                login.Clave = estudiante.Clave;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }

        private bool ValidarClave()
        {
            try
            {
                // Comparar la clave directamente (sin hash)
                if (login.Clave != login.Clave)
                {
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "La clave no coincide";
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }

        public IQueryable<LoginRespuesta> Ingresar()
        {
            if (ValidarUsuario() && ValidarClave())
            {
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario);

                return from U in DBExamen.Estudiantes
                       where U.Usuario == login.Usuario && U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.Usuario,
                           Autenticado = true,
                           Perfil = "Estudiante",
                           PaginaInicio = "/matricula",
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                return new List<LoginRespuesta> { loginRespuesta }.AsQueryable();
            }
        }
    }
}
