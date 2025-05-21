using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class Ejercicio1Model : PageModel
    {
        [BindProperty]
        public int Peso { get; set; }

        [BindProperty]
        public double Altura {  get; set; }

        public double IMC = 0.0;

        public void OnPost()
        {
            int peso = Peso;
            double altura = Altura;
            IMC = peso / altura;
            ModelState.Clear();
        }
    }
}
