using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Livraria.Sistema.Models;
using System.Data.SqlClient;

namespace Livraria.Sistema.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection conexao = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            conexao.ConnectionString = "data source=LETICIA-PC\\SQLEXPRESS; database=BDLIVRARIA; integrated security=SSPI;";
        }
        [HttpPost]
        public ActionResult Verifica(FUNCIONARIOS funcionario)
        {
            connectionString();
            conexao.Open();
            comando.Connection = conexao;
            comando.CommandText = "select * from [FUNCIONARIOS] where [USERNAME]='"+funcionario.USERNAME+"' and [SENHA]='"+funcionario.SENHA+"'";
            dr = comando.ExecuteReader();

            if (dr.Read())
            {
                conexao.Close();
                return View("Create");
            }
            else
            {
                conexao.Close();
                return View("Erro");
            }
            
            
        }
    }
}