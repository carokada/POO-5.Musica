using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Usuario
   {
      private string nombre;
      public string Email { get; set; }
      public Biblioteca Biblioteca { get; set; }

      public Usuario(string nombre, string email)
      {
         Nombre = nombre;
         Email = email;

         Biblioteca = new Biblioteca();
      }

      public string Nombre
      {
         get => nombre;
         set => nombre = value.Length >= 3 ? value : throw new ArgumentException(" el nombre debe tener un minimo de 3 caracteres.");
      }

      public override string ToString()
      {
         return $"{Nombre}";
      }
   }
}
