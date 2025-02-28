using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public static class ContenidoService
   {
      private static List<Contenido> contenidosService = new List<Contenido>();

      internal static void AgregarContenido(Contenido contenido)
      {
         if (contenido == null)
            throw new ArgumentException(" el contenido no puede ser nulo.");
         if (contenidosService.Contains(contenido))
            throw new ArgumentException(" el contenido ya ha sido agregada al registro");
         contenidosService.Add(contenido);
      }

      public static List<Contenido> GetContenidos()
      {
         return contenidosService;
      }

      public static Contenido BuscarPorNombre(string nombre)
      {
         if (!string.IsNullOrEmpty(nombre))
         {
            foreach (var contenido in contenidosService)
            {
               if (contenido.Nombre == nombre) // asi o contenido.Nombre.Contains(nombre)
               {
                  return contenido;
               }
            }
            Console.WriteLine(" no se encontraron coincidencias");
            return null;
         }
         else
         {
            throw new ArgumentException(" la busqueda no puede estar vacia.");
         }

      }
   }
}
