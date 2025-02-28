using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Biblioteca : ITemporizable
   {
      // ITemporizable
      public int Duracion { get => CalcularDuracionBiblioteca(); }

      private List<Contenido> favoritos;

      public Biblioteca()
      {
         favoritos = new List<Contenido>();
      }

      public void AgregarFavorito(Contenido contenido)
      {
         if (contenido == null)
            throw new ArgumentException(" el contenido no puede estar vacio.");
         if (favoritos.Contains(contenido))
            throw new ArgumentException($" {contenido} ya ha sido agregado a la lista de favoritos.");
         favoritos.Add(contenido);
      }

      public List<Contenido> ObtenerFavoritos()
      {
         return favoritos;
      }

      public void RemoverFavorito(Contenido contenido)
      {
         if (contenido == null)
            throw new ArgumentException(" el contenido no puede estar vacio.");
         if (!favoritos.Contains(contenido))
            throw new ArgumentException($" {contenido} no ha sido agregado a la lista de favoritos.");
         favoritos.Remove(contenido);
      }

      public int CalcularDuracionBiblioteca()
      {
         int duracionBiblioteca = 0;
         foreach (ITemporizable contenido in favoritos)
            duracionBiblioteca += contenido.Duracion;
         return duracionBiblioteca;
      }
   }
}
