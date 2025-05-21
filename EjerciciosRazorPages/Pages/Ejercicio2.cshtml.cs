using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class Ejercicio2Model : PageModel
    {
        private const string Alfabeto = "ABCDEFGHIJKLMNOPQRSTUVXYZW";
        private const int LongitudAlfabeto = 25; 

        [BindProperty]
        public int Desplazamiento { get; set; } = 3;

        [BindProperty]
        public string Mensaje { get; set; }

        [BindProperty]
        public string Operacion { get; set; } = "cifrar";

        public string Resultado { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(Mensaje))
            {
                Resultado = ProcesarMensaje();
            }
            return Page();
        }

        private string ProcesarMensaje()
        {
            string resultado = "";
            Mensaje = Mensaje.ToUpper();

            foreach (char letra in Mensaje)
            {
                if (Alfabeto.Contains(letra))
                {
                    int indiceOriginal = Alfabeto.IndexOf(letra);
                    int nuevoIndice;

                    switch (Operacion)
                    {
                        case "cifrar":
                            nuevoIndice = (indiceOriginal + Desplazamiento) % LongitudAlfabeto;
                            if (nuevoIndice < 0) nuevoIndice += LongitudAlfabeto;
                            break;
                        case "descifrar":
                            nuevoIndice = (indiceOriginal - Desplazamiento) % LongitudAlfabeto;
                            if (nuevoIndice < 0) nuevoIndice += LongitudAlfabeto;
                            break;
                        default:
                            nuevoIndice = indiceOriginal;
                            break;
                    }

                    resultado += Alfabeto[nuevoIndice];
                }
                else
                {
                    resultado += letra; 
                }
            }

            return resultado;
        }
    }
}
