using Matriculas.Clases;
using Matriculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Matriculas.Controllers
{
    [RoutePrefix("api/Matriculas")]
    [Authorize]
    public class MatriculasController : ApiController
    {
        [HttpGet]
        [Route("ConsultarTodos")]
        public List<Matricula> ConsultarTodos()
        {
            clsMatricula matricula = new clsMatricula();
            return matricula.ConsultarTodos();
        }

        [HttpGet]
        [Route("ConsultarXId")]
        public Matricula ConsultarXId(int id)
        {
            clsMatricula matricula = new clsMatricula();
            return matricula.ConsultarXId(id);
        }

        [HttpGet]
        [Route("ConsultarXSemestre")]
        public Matricula ConsultarXSemestre(string semestre)
        {
            clsMatricula matricula = new clsMatricula();
            return matricula.ConsultarXSemestre(semestre);
        }

        [HttpGet]
        [Route("ConsultarXDocumento")]
        public List<Matricula> ConsultarXDocumento(string documento)
        {
            clsMatricula matricula = new clsMatricula();
            return matricula.ConsultarXDocumento(documento);
        }

        [HttpPost]
        [Route("Insertar")]
        public string Insertar([FromBody] Matricula mat)
        {
            clsMatricula matricula = new clsMatricula();
            matricula.matricula = mat;
            return matricula.Insertar();
        }

        [HttpPut]
        [Route("Actualizar")]
        public string Actualizar([FromBody] Matricula mat)
        {
            clsMatricula matricula = new clsMatricula();
            matricula.matricula = mat;
            return matricula.Actualizar();
        }

        [HttpDelete]
        [Route("Eliminar")]
        public string Eliminar([FromBody] Matricula mat)
        {
            clsMatricula matricula = new clsMatricula();
            matricula.matricula = mat;
            return matricula.Eliminar();
        }
    }
}
