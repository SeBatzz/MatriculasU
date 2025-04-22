﻿using Matriculas.Clases;
using Matriculas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Matriculas.Controllers
{
    [RoutePrefix("api/Login")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        [HttpPost]
        [Route("Ingresar")]
        public IQueryable<LoginRespuesta> Ingresar(Login login)
        {
            clsLogin _Login = new clsLogin();
            _Login.login = login;
            return _Login.Ingresar();
        }
    }
}