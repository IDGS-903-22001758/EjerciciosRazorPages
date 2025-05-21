using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EjerciciosRazorPages.Pages
{
    public class Ejercicio3Model : PageModel
    {
        [BindProperty]
        public double A { get; set; } = 1;

        [BindProperty]
        public double B { get; set; } = 1;

        [BindProperty]
        public double X { get; set; } = 1;

        [BindProperty]
        public double Y { get; set; } = 1;

        [BindProperty]
        public int N { get; set; } = 2;

        public string Resultado { get; set; }
        public string Pasos { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (N < 0)
            {
                ModelState.AddModelError("N", "El exponente n debe ser mayor o igual a 0");
                return Page();
            }

            CalcularExpansionBinomial();
            return Page();
        }

        private void CalcularExpansionBinomial()
        {
            double sumaTotal = 0;
            Pasos = "";

            
            for (int k = 0; k <= N; k++)
            {
                
                long coeficiente = CalcularCoeficienteBinomial(N, k);

                
                double axTerm = Math.Pow(A * X, N - k);

                
                double byTerm = Math.Pow(B * Y, k);

                
                double terminoActual = coeficiente * axTerm * byTerm;
                sumaTotal += terminoActual;

               
                Pasos += $"Para k={k}: C({N},{k}) = {coeficiente}, ";
                Pasos += $"(ax)^({N}-{k}) = {axTerm}, ";
                Pasos += $"(by)^{k} = {byTerm}, ";
                Pasos += $"Término = {terminoActual}<br/>";
            }

            Resultado = $"El resultado de ({A}x + {B}y)^{N} es: {sumaTotal}";
        }

        private long CalcularCoeficienteBinomial(int n, int k)
        {
            
            if (k > n - k)
                k = n - k;

            long resultado = 1;

            
            for (int i = 1; i <= k; i++)
            {
                resultado *= (n - k + i);
                resultado /= i;
            }

            return resultado;
        }

        
        private long Factorial(int numero)
        {
            if (numero <= 1)
                return 1;

            long resultado = 1;
            int i = 2;

            
            while (i <= numero)
            {
                resultado *= i;
                i++;
            }

            return resultado;
        }
    }
}
