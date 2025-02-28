using System;

namespace EntidadesCs
{
   public abstract class Contenido
   {
      private string nombre;

      protected Contenido(string nombre)
      {
         Nombre = nombre;

         //ContenidoService.AgregarContenido(this); // aca o en cada contenido ??
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = value.Length > 0 ? value : throw new ArgumentException(" el nombre no puede estar vacio.");
      }
   }
}
