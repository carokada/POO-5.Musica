using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesCs;

namespace DemoCs
{
   class Program
   {
      static void Main(string[] args)
      {
         string divisor = "----------------------------------------------------------";

         Console.WriteLine(divisor);
         Console.WriteLine(" creando interpretes...");
         Interprete interptete1 = new Interprete("Sabrina Carpenter");
         Interprete interprete2 = new Interprete("Chappell Roan");
         Interprete interprete3 = new Interprete("Billie Eilish");
         try
         {
            Interprete interprete4 = new Interprete("");
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error : {e.Message}");
         }
         Console.WriteLine("\n mostrando interpretes cargados: ");
         Console.WriteLine(interptete1);
         Console.WriteLine(interprete2);
         Console.WriteLine(interprete3);

         Console.WriteLine("\n " + divisor);
         Console.WriteLine(" creando albums...");
         Album album1 = new Album("Short 'n Sweet", new DateTime(2024, 8, 23));
         Album album2 = new Album("The Rise and Fall of a Midwest Princess", new DateTime(2023, 9, 22));
         Album album3 = new Album("Hit Me Hard and Soft", new DateTime(2024, 5, 17));
         Console.WriteLine(" asignando albums a interpretes... ");
         interptete1.AgregarAlbum(album1);
         interprete2.AgregarAlbum(album2);
         interprete3.AgregarAlbum(album3);
         Console.WriteLine("\n mostrando albums cargados: ");
         Console.WriteLine(album1);
         Console.WriteLine(album2);
         Console.WriteLine(album3);

         Console.WriteLine("\n " + divisor);
         Console.WriteLine(" creando canciones...");
         Cancion cancion1 = new Cancion("Please please please", interptete1, album1, 186);
         Cancion cancion2 = new Cancion("Espresso", interptete1, album1, 175);
         Cancion cancion3 = new Cancion("Femininomenon", interprete2, album2, 219);
         Cancion cancion4 = new Cancion("HOT TO GO", interprete2, album2, 184);
         Cancion cancion5 = new Cancion("WILDFLOWER", interprete3, album3, 261);
         Cancion cancion6 = new Cancion("BLUE", interprete3, album3, 343);
         try
         {
            Cancion cancion7 = new Cancion("!!!!!!!!", null, album3, 13);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error : {e.Message}");
         }
         try
         {
            Cancion cancion7 = new Cancion("!!!!!!!!", interprete3, null, 13);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error : {e.Message}");
         }
         try
         {
            Cancion cancion7 = new Cancion("!!!!!!!!", interprete3, album3, 9);
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error : {e.Message}");
         }
         Console.WriteLine("\n mostrando canciones cargadas: ");
         Console.WriteLine(cancion1);
         Console.WriteLine(cancion2);
         Console.WriteLine(cancion3);
         Console.WriteLine(cancion4);
         Console.WriteLine(cancion5);
         Console.WriteLine(cancion6);

         Console.WriteLine("\n " + divisor);
         Console.WriteLine(" resumen de contenidos subidos:");
         Console.WriteLine("\n -> por interprete");
         Console.WriteLine("\t -> albums: ");
         MostrarAlbums(interptete1);
         MostrarAlbums(interprete2);
         MostrarAlbums(interprete3);
         Console.WriteLine("\t -> canciones: ");
         MostrarCancionesPorInterprete(interptete1);
         MostrarCancionesPorInterprete(interprete2);
         MostrarCancionesPorInterprete(interprete3);
         Console.WriteLine("\n -> por album");
         MostrarCancionesPorAlbum(album1);
         MostrarCancionesPorAlbum(album2);
         MostrarCancionesPorAlbum(album3);

         Console.WriteLine(divisor);
         Console.WriteLine(" creando usuarios...");
         Usuario user1 = new Usuario("Jazmin", "jazmin@gmail.com");
         Usuario user2 = new Usuario("Ramiro", "ramiro@gmail.com");
         Usuario user3 = new Usuario("Alexis", "alexis@gmail.com");
         try
         {
            Usuario user4 = new Usuario("Al", "alejo@gmail.com");
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error : {e.Message}");
         }
         Console.WriteLine("\n mostrando usuarios cargados: ");
         Console.WriteLine(user1);
         Console.WriteLine(user2);
         Console.WriteLine(user3);

         Console.WriteLine("\n " + divisor);
         Console.WriteLine(" mostrando contenidoService...");
         MostrarContenidoService();

         Console.WriteLine("\n buscando contenidos y agregando a bibliotecas...");
         Contenido busqueda1 = ContenidoService.BuscarPorNombre("Sabrina Carpenter");
         user1.Biblioteca.AgregarFavorito(busqueda1);
         Contenido busqueda2 = ContenidoService.BuscarPorNombre("Hit Me Hard and Soft");
         user1.Biblioteca.AgregarFavorito(busqueda2);
         user2.Biblioteca.AgregarFavorito(busqueda2);
         Contenido busqueda3 = ContenidoService.BuscarPorNombre("Femininomenon");
         user1.Biblioteca.AgregarFavorito(busqueda3);
         user2.Biblioteca.AgregarFavorito(busqueda3);
         user3.Biblioteca.AgregarFavorito(busqueda3);
         try
         {
            Contenido busqueda4 = ContenidoService.BuscarPorNombre("brat");
         }
         catch (Exception e)
         {
            Console.WriteLine($" !! error : {e.Message}");
         }

         Console.WriteLine("\n " + divisor);
         Console.WriteLine(" mostrando bibliotecas: \n");
         MostrarBibliotecaPorUsuario(user1);
         MostrarBibliotecaPorUsuario(user2);
         MostrarBibliotecaPorUsuario(user3);

         //Console.WriteLine("");
         //Console.WriteLine();
         Console.WriteLine(divisor);
         Console.WriteLine("\n presione una tecla para salir ");
         Console.ReadKey();
      }

      private static void MostrarContenidoService()
      {
         Console.WriteLine("\n -> contenidos en ContenidoService");
         foreach (var contenido in ContenidoService.GetContenidos())
            Console.WriteLine($"\t - {contenido}");
      }

      private static void MostrarBibliotecaPorUsuario(Usuario usuario)
      {
         Console.WriteLine($"-> contenidos en biblioteca de usuario {usuario.Nombre}");
         foreach (var contenido in usuario.Biblioteca.ObtenerFavoritos())
            Console.WriteLine($"\t - {contenido}");
         Console.WriteLine($"\t Duracion: {usuario.Biblioteca.Duracion} segundos");
         Console.WriteLine();
      }

      private static void MostrarAlbums(Interprete artista)
      {
         Console.WriteLine($" albums de artista {artista.Nombre}");
         foreach (var album in artista.ObtenerAlbums())
            Console.WriteLine($" - {album}");
         Console.WriteLine();
      }

      private static void MostrarCancionesPorInterprete(Interprete artista)
      {
         Console.WriteLine($" canciones de artista {artista.Nombre}");
         foreach (var cancion in artista.ObtenerCanciones())
            Console.WriteLine($" - {cancion}");
         Console.WriteLine();
      }

      private static void MostrarCancionesPorAlbum(Album album)
      {
         Console.WriteLine($" canciones de album {album.Nombre}");
         foreach (var cancion in album.ObtenerCanciones())
            Console.WriteLine($" - {cancion}");
         Console.WriteLine();
      }
   }
}
