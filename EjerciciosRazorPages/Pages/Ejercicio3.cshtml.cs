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

            // Usamos un ciclo for para cada término de la sumatoria
            for (int k = 0; k <= N; k++)
            {
                // Calcular el coeficiente binomial C(n,k)
                long coeficiente = CalcularCoeficienteBinomial(N, k);

                // Calcular (ax)^(n-k)
                double axTerm = Math.Pow(A * X, N - k);

                // Calcular (by)^k
                double byTerm = Math.Pow(B * Y, k);

                // Calcular el término actual
                double terminoActual = coeficiente * axTerm * byTerm;
                sumaTotal += terminoActual;

                // Construir la representación del paso
                Pasos += $"Para k={k}: C({N},{k}) = {coeficiente}, ";
                Pasos += $"(ax)^({N}-{k}) = {axTerm}, ";
                Pasos += $"(by)^{k} = {byTerm}, ";
                Pasos += $"Término = {terminoActual}<br/>";
            }

            Resultado = $"El resultado de ({A}x + {B}y)^{N} es: {sumaTotal}";
        }

        private long CalcularCoeficienteBinomial(int n, int k)
        {
            // Usamos la propiedad C(n,k) = C(n, n-k) para optimizar
            if (k > n - k)
                k = n - k;

            long resultado = 1;

            // Calculamos el coeficiente usando un ciclo for
            for (int i = 1; i <= k; i++)
            {
                resultado *= (n - k + i);
                resultado /= i;
            }

            return resultado;
        }

        // Método alternativo para calcular factorial (no usado en este caso por optimización)
        private long Factorial(int numero)
        {
            if (numero <= 1)
                return 1;

            long resultado = 1;
            int i = 2;

            // Usamos un ciclo while para calcular el factorial
            while (i <= numero)
            {
                resultado *= i;
                i++;
            }

            return resultado;
        }
    }
}
