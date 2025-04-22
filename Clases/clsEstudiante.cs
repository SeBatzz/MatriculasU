using Matriculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matriculas.Clases
{
    public class clsEstudiante
    {
        private DBExamenEntities DBExamen = new DBExamenEntities();

        public Estudiante estudiante { get; set; }

        /*public string CrearEstudiante(int idMatricula)
        {
            clsCypher cypher = new clsCypher();
            string ClaveCifrada;

            if (cypher.CifrarClave())
            {
                ClaveCifrada = cypher.PasswordCifrado;
            }
            else
            {
                return "Error al cifrar la clave";
            }

            //Graba el usuario
            estudiante.Clave = ClaveCifrada;
            
            DBExamen.Estudiantes.Add(estudiante);
            DBExamen.SaveChanges();

        }*/
    }
}