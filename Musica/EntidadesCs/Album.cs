using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Album : Contenido, ITemporizable
   {
      // ITemporizable
      public int Duracion { get => CalcularDuracionAlbum(); }

      public DateTime FechaLanzamiento { get; set; }

      private List<Cancion> canciones; // asoc bidireccional multiple 1 album muchas canciones

      public Album (string nombre, DateTime fechaLanzamiento) : base(nombre)
      {
         canciones = new List<Cancion>();

         FechaLanzamiento = fechaLanzamiento;

         ContenidoService.AgregarContenido(this);
      }

      internal void AgregarCancion(Cancion cancion)
      {
         if (cancion == null)
            throw new ArgumentException(" la cancion no puede estar vacia.");
         if (canciones.Contains(cancion))
            throw new ArgumentException($" la cancion {cancion} ya ha sido agregada al interprete.");
         canciones.Add(cancion);
      }

      public List<Cancion> ObtenerCanciones()
      {
         return canciones;
      }

      public int CalcularDuracionAlbum()
      {
         int duracionAlbum = 0;
         foreach (var cancion in canciones)
            duracionAlbum += cancion.Duracion;
         return duracionAlbum;
      }

      public override string ToString()
      {
         return $" album: {Nombre}";
      }
   }
}
