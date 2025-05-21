using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EjerciciosRazorPages.Pages
{
    public class Ejercicio4Model : PageModel
    {
        [BindProperty]
        public int[] Numeros { get; set; } = new int[20];

        public int Suma { get; set; }
        public double Promedio { get; set; }
        public List<int> Moda { get; set; } = new List<int>();
        public double Mediana { get; set; }
        public int[] NumerosOrdenados { get; set; }

        public void OnGet()
        {
            GenerarNumerosAleatorios();
            CalcularEstadisticas();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            CalcularEstadisticas();
            return Page();
        }

        private void GenerarNumerosAleatorios()
        {
            Random rnd = new Random();
            for (int i = 0; i < Numeros.Length; i++)
            {
                Numeros[i] = rnd.Next(0, 101); 
            }
        }

        private void CalcularEstadisticas()
        {
            
            Suma = 0;
            for (int i = 0; i < Numeros.Length; i++)
            {
                Suma += Numeros[i];
            }

           
            Promedio = (double)Suma / Numeros.Length;

            
            NumerosOrdenados = new int[Numeros.Length];
            Array.Copy(Numeros, NumerosOrdenados, Numeros.Length);
            Array.Sort(NumerosOrdenados);

            
            int mitad = NumerosOrdenados.Length / 2;
            if (NumerosOrdenados.Length % 2 == 0)
            {
                Mediana = (NumerosOrdenados[mitad - 1] + NumerosOrdenados[mitad]) / 2.0;
            }
            else
            {
                Mediana = NumerosOrdenados[mitad];
            }

            CalcularModa();
        }

        private void CalcularModa()
        {
            Dictionary<int, int> frecuencias = new Dictionary<int, int>();
            int maxFrecuencia = 0;

            
            foreach (int num in Numeros)
            {
                if (frecuencias.ContainsKey(num))
                {
                    frecuencias[num]++;
                }
                else
                {
                    frecuencias[num] = 1;
                }

                if (frecuencias[num] > maxFrecuencia)
                {
                    maxFrecuencia = frecuencias[num];
                }
            }

            
            Moda.Clear();
            var enumerator = frecuencias.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var item = enumerator.Current;
                if (item.Value == maxFrecuencia)
                {
                    Moda.Add(item.Key);
                }
            }
        }
    }
}
