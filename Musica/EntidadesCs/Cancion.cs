using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesCs
{
   public class Cancion : Contenido, ITemporizable
   {
      // ITemporizable
      private int duracion;

      private Interprete interprete; // asoc simple bidireccional 1 cancion tiene 1 interprete
      private Album album; // asoc simple bidireccional 1 cancion tiene 1 album

      public Cancion(string nombre, Interprete interprete, Album album, int duracion) : base(nombre)
      {
         // try/catch para que no cree instancias de mas al generar canciones por medio de las asoc con album, artista y duracion si alguno es nulo
         Interprete = interprete;
         try
         {
            Album = album;
         }
         catch
         {
            Interprete.QuitarCancion(this);
            throw; // el throw solo cancela la creacion del objeto si el album no se valida y quita la cancion del nombre del artista. idem duracion.
         }
         try
         {
            Duracion = duracion;
         }
         catch
         {
            Interprete.QuitarCancion(this);
            Album.QuitarCancion(this);
            throw;
         }

         ContenidoService.AgregarContenido(this); // agrega a clase utilitaria
      }

      public Interprete Interprete
      {
         get => interprete;
         set
         {
            interprete = value ?? throw new ArgumentException(" el artista no puede ser nulo.");
            interprete.AgregarCancion(this); // referencia a interprete
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
         return $" cancion: {Nombre} ({Duracion} segundos)";
      }
   }
}
