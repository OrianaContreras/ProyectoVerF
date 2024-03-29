﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibNegVerF;

namespace AppConVerF
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int op = 0;
                do
                {
                    menu();
                    op = int.Parse(Console.ReadLine());
                    if (!(op > 0 && op < 6))
                    {
                        Console.WriteLine("\nDebe ingresar una opción válida ");
                        pausa();
                    }
                } while (!(op > 0 && op < 6));

                switch (op)
                {
                    case 1:
                        ingresar();
                        break;
                    case 2:
                        mostrar();
                        break;
                    case 3:
                        modificar();
                        break;
                    case 4:
                        eliminar();
                        break;
                    case 5:
                        Console.WriteLine("Muchas gracias por utilizar \"Nuestros Servicios de Inventario\"");
                        break;
                    default:
                        Console.WriteLine("No es una opción válida");
                        break;
                }// fin switch

            } while (true);
        }// fin main

        public static void menu()
        {
            Console.WriteLine("Menú CRUD");
            Console.WriteLine("===============");
            Console.WriteLine("1.- Ingresar");
            Console.WriteLine("2.- Mostrar");
            Console.WriteLine("3.- Modificar");
            Console.WriteLine("4.- Eliminar");
            Console.WriteLine("5.- Salir");
            Console.Write("\nIngrese opcion [1-5]: ");
        }// fin menu

        public static void pausa()
        {
            Console.WriteLine("\n\n\nPresione una tecla para continuar....");
            Console.ReadKey();
            Console.Clear();
        }// fin pausa

        public static void ingresar()
        {
            bool esExito = false;
            Amigo objAmigo = new Amigo();

            Console.WriteLine("Ingreso Datos Contacto");
            Console.WriteLine("=======================");
            Console.Write("Ingrese Rut      : ");
            objAmigo.Rut = Console.ReadLine();
            Console.Write("Ingrese Nombre   : ");
            objAmigo.Nombre = Console.ReadLine();
            Console.Write("Ingrese apPaterno: ");
            objAmigo.ApPaterno = Console.ReadLine();
            Console.Write("Ingrese apMaterno: ");
            objAmigo.ApMaterno = Console.ReadLine();
            Console.Write("Ingrese direccion: ");
            objAmigo.Direccion = Console.ReadLine();
            Console.Write("Ingrese edad     : ");
            objAmigo.Edad = int.Parse(Console.ReadLine());
            Console.Write("Ingrese fono     : ");
            objAmigo.Fono = Console.ReadLine();
            Console.Write("Ingrese correo   : ");
            objAmigo.Email = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Mostrando Datos Contacto");
            Console.WriteLine("========================");
            Console.WriteLine("Rut        : {0}", objAmigo.Rut);
            Console.WriteLine("Nombre     : {0}", objAmigo.Nombre);
            Console.WriteLine("Ap. Paterno: {0}", objAmigo.ApPaterno);
            Console.WriteLine("Ap. Materno: {0}", objAmigo.ApMaterno);
            Console.WriteLine("Direccion  : {0}", objAmigo.Direccion);
            Console.WriteLine("Edad       : {0}", objAmigo.Edad);
            Console.WriteLine("Fono       : {0}", objAmigo.Fono);
            Console.WriteLine("Correo     : {0}", objAmigo.Email);

            Console.Write("\nLos datos mostrados son correctos? [S/N]: ");
            string resp = Console.ReadLine();

            if (resp.Equals("S") || resp.Equals("s"))
            {
                Console.WriteLine("Continuamos con el Ingreso de Datos en la Base de Datos");
            }
            else
            {
                Console.WriteLine("Reingreso Datos Contacto");
                Console.WriteLine("=======================");
                Console.WriteLine("Por favor indique cuales desea modificar:");
                if (true)
                {
                    Console.Write("Ingrese Rut      : ");
                    objAmigo.Rut = Console.ReadLine();

                }
                else if (true)
                {
                    Console.Write("Ingrese Nombre   : ");
                    objAmigo.Nombre = Console.ReadLine();
                }
                else if (true)
                {
                    Console.Write("Ingrese apPaterno: ");
                    objAmigo.ApPaterno = Console.ReadLine();
                }
                else if (true)
                {
                    Console.Write("Ingrese apMaterno: ");
                    objAmigo.ApMaterno = Console.ReadLine();
                }
                else if (true)
                {
                    Console.Write("Ingrese direccion: ");
                    objAmigo.Direccion = Console.ReadLine();
                }
                else if (true)
                {
                    Console.Write("Ingrese edad     : ");
                    objAmigo.Edad = int.Parse(Console.ReadLine());
                }
                else if (true)
                {
                    Console.Write("Ingrese fono     : ");
                    objAmigo.Fono = Console.ReadLine();
                }
                else
                {
                    Console.Write("Ingrese correo   : ");
                    objAmigo.Email = Console.ReadLine();
                }

                Console.Clear();
                Console.WriteLine("Mostrando Datos Contacto");
                Console.WriteLine("========================");
                Console.WriteLine("Rut        : {0}", objAmigo.Rut);
                Console.WriteLine("Nombre     : {0}", objAmigo.Nombre);
                Console.WriteLine("Ap. Paterno: {0}", objAmigo.ApPaterno);
                Console.WriteLine("Ap. Materno: {0}", objAmigo.ApMaterno);
                Console.WriteLine("Direccion  : {0}", objAmigo.Direccion);
                Console.WriteLine("Edad       : {0}", objAmigo.Edad);
                Console.WriteLine("Fono       : {0}", objAmigo.Fono);
                Console.WriteLine("Correo     : {0}", objAmigo.Email);

                Console.Write("\nLos datos mostrados son correctos? [S/N]: ");
                // string resp = Console.ReadLine();

            }
            pausa();

            objAmigo = objAmigo.ingresar(objAmigo);

            if (objAmigo.EsExito)
            {
                Console.WriteLine("Los Datos fueron ingresados correctamente........");
            }
            else
            {
                Console.WriteLine("E R R O R Datos no ingresados. !!!!!!!!!");
            }
        }

        public static void mostrar()
        {
            DataSet ds = new DataSet();
            Amigo objAmigo = new Amigo();

            Console.WriteLine("Ingrese rut o * para buscar todos....");
            objAmigo.Rut = Console.ReadLine();

            objAmigo = objAmigo.mostrar(objAmigo);

            Console.WriteLine("Mostrando XML: {0} ", objAmigo.Ds.GetXml().ToString());
            pausa();
            Console.WriteLine("Mostrando datos sin formato XML: ");
            foreach (DataRow fila in objAmigo.Ds.Tables["Table"].Rows)
            {
                Console.WriteLine("\nId \t\t: {0}", fila["id"].ToString());
                Console.WriteLine("Rut \t\t: {0}", fila["Rut"].ToString());
                Console.WriteLine("Nombre \t\t: {0}", fila["Nombre"].ToString());
                Console.WriteLine("Ape. Paterno    : {0}", fila["ApPaterno"].ToString());
                Console.WriteLine("Ape. Materno    : {0}", fila["ApMaterno"].ToString());
                Console.WriteLine("Edad \t\t: {0}", fila["Edad"].ToString());
                Console.WriteLine("Direccion \t: {0}", fila["Direccion"].ToString());
                Console.WriteLine("Fono \t\t: {0}", fila["fono"].ToString());
                Console.WriteLine("Correo \t\t: {0}\n", fila["Email"].ToString());
            }
        }

        public static void modificar()
        {
            Amigo objAmigo = new Amigo();
            objAmigo.modificar(objAmigo);
        }

        public static void eliminar()
        {
            Amigo objAmigo = new Amigo();
            objAmigo.eliminar(objAmigo);
        }


    }// fin class
}
