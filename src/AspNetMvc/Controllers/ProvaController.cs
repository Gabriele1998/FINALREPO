using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace ProvaControllers
{
    public class ProvaController : Controller
    {
         
        // GET: /HelloWorld/

        public string Index()
        {
            return "This is my default action...";
        }
    }
}