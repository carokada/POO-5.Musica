using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Interprete : Contenido, ITemporizable
   {
      // ITemporizable
      public int Duracion { get => CalcularDuracionInterprete(); }

      private List<Cancion> canciones; // asoc bidireccional multiple 1 interprete muchas canciones
      private List<Album> albums; // asoc multiple 1 interprete muchos albums

      public Interprete(string nombre) : base(nombre)
      {
         canciones = new List<Cancion>();
         albums = new List<Album>();

         ContenidoService.AgregarContenido(this); // agrega a la clase utilitaria
      }

      public void AgregarAlbum(Album album)
      {
         if (album == null)
            throw new ArgumentException(" la cancion no puede estar vacia.");
         if (albums.Contains(album))
            throw new ArgumentException($" la cancion {album} ya ha sido agregada al interprete.");
         albums.Add(album);
      }

      public List<Album> ObtenerAlbums()
      {
         return albums;
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

      internal void QuitarCancion(Cancion cancion)
      {
         if (cancion == null)
            throw new ArgumentException(" la cancion no puede estar vacia.");
         if (!canciones.Contains(cancion))
            throw new ArgumentException($" la cancion {cancion} no ha sido agregada al interprete.");
         canciones.Remove(cancion);
      }

      public int CalcularDuracionInterprete()
      {
         int duracionInterprete = 0;
         foreach (var cancion in canciones)
            duracionInterprete += cancion.Duracion;
         return duracionInterprete;
      }

      public override string ToString()
      {
         return $" interprete: {Nombre} ({Duracion} segundos)";
      }
   }
}
