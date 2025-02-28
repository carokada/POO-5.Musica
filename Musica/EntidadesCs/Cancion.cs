using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Cancion : Contenido, ITemporizable
   {
      // ITemporizable
      private int duracion;

      private Interprete artista; // asoc simple bidireccional 1 cancion tiene 1 interprete
      private Album album; // asoc simple bidireccional 1 cancion tiene 1 album

      public Cancion (string nombre, Interprete artista, Album album, int duracion) : base(nombre)
      {
         Artista = artista;
         Album = album;
         Duracion = duracion;

         ContenidoService.AgregarContenido(this);
      }

      public Interprete Artista
      {
         get => artista;
         set
         {
            artista = value ?? throw new ArgumentException(" el artista no puede ser nulo.");
            // if album != null se agregaria la cancion al artista pero si verifico album entonces nunca agrega cancion a artista
            artista.AgregarCancion(this); // referencia a interprete: al agregar los dos en la misma clase, cuando el artista no es nulo pero el album si se sube igual la cancion al artista. como evitar ?
         }
      }

      public Album Album
      {
         get => album;
         set
         {
            album = value ?? throw new ArgumentException(" el album no puede ser nulo.");
            album.AgregarCancion(this); // referencia a album
         }
      }

      public int Duracion
      {
         get => duracion;
         set => duracion = value > 10 ? value : throw new ArgumentException(" la duracion de la cancion debe ser mayor a 10");
      }

      public override string ToString()
      {
         return $" cancion: {Nombre}";
      }
   }
}
