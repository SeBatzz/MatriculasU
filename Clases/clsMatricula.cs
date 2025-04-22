using Matriculas.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Matriculas.Clases
{
    public class clsMatricula
    {
        public DBExamenEntities DBExamen = new DBExamenEntities(); 
        public Matricula matricula { get; set; }



        public Matricula ConsultarXId(int Id)
        {
            
            Matricula mt = DBExamen.Matriculas.FirstOrDefault(e => e.idMatricula == Id); 
            return mt; 
        }
        public Matricula ConsultarXSemestre(string semestre)
        {

            Matricula mt = DBExamen.Matriculas.FirstOrDefault(e => e.SemestreMatricula == semestre);
            return mt;
        }
        public List<Matricula> ConsultarXDocumento(string documento)
        {
            var resultado = (from m in DBExamen.Matriculas
                             join e in DBExamen.Estudiantes
                             on m.idEstudiante equals e.idEstudiante
                             where e.Documento == documento
                             select m).ToList();

            return resultado;
        }
        public List<Matricula> ConsultarTodos()
        {
            return DBExamen.Matriculas
                .OrderBy(e => e.idEstudiante) 
                .ToList(); 
        }
        public string Insertar()
        {
            try
            {
                DBExamen.Matriculas.Add(matricula); 
                DBExamen.SaveChanges(); 
                return "Matricula insertada correctamente"; 
            }
            catch (Exception ex)
            {
                return "Error al insertar la matricula: " + ex.Message; 
            }
        }
        public string Actualizar()
        {
            
            Matricula mt = ConsultarXId(matricula.idMatricula); 
            if (mt == null)
            {
               
                return "El id de la matricula no es válido";
            }
            DBExamen.Matriculas.AddOrUpdate(matricula); 
            DBExamen.SaveChanges(); 
            return "Se actualizó la matricula correctamente"; 
        }
        public string Eliminar()
        {
            try
            {
                
                Matricula mt = ConsultarXId(matricula.idMatricula); 
                if (mt == null)
                {
                    
                    return "El id de la matricula no es válido";
                }
                DBExamen.Matriculas.Remove(mt); 
                DBExamen.SaveChanges(); 
                return "Se eliminó la matricula correctamente"; 
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }
    }


}