// See https://aka.ms/new-console-template for more information
using EmpCadeteria;

internal class Program
{
    private static void Main(string[] args)
    {
        AccesoDatosCadeteria acceso;
        Cadeteria Mostaza;
        List<Cadete> listadeCadetes;
        string acceder = "";

        string rutaDatosCadeteria = "";
        string rutaDatosCadetes = "";
        do
        {
            Console.WriteLine("******************** Bienvenidos ********************");
            Console.WriteLine("******************** Acceso a Datos ********************");
            Console.WriteLine("******************** Seleccione a que Tipo de Datos quiere acceder ********************");
            Console.WriteLine("a) Archivo CSV");
            Console.WriteLine("b) Archivo JSON");
            acceder = Console.ReadLine();

        } while (acceder != "a" && acceder != "b");

        if (acceder == "a")
        {
            rutaDatosCadeteria = "DatosCadeteria.csv";
            rutaDatosCadetes = "DatosCadetes.csv";
            acceso = new AccesoCSV();
        }
        else
        {
            rutaDatosCadeteria = "DatosCadeteria.Json";
            rutaDatosCadetes = "DatosCadetes.Json";
            acceso = new AccesoAJson();
        }
        if (acceso.ExisteArchivoDatos(rutaDatosCadeteria) && acceso.ExisteArchivoDatos(rutaDatosCadetes))
        {
            Mostaza = acceso.ObtenerInfoCadeteria(rutaDatosCadeteria);
            listadeCadetes = acceso.ObtenerListaCadetes(rutaDatosCadetes);
            Mostaza.AgregarListaCadetes(listadeCadetes);
        



        //INTERFAZ
        string nombreCl = "", direccionCl = "", telefonoCl = "", datosRefDirCliente = "";
        string obsPedido = "";
        string opcion = "";
        int NroPedido = 0;

        do
        {

            Console.WriteLine("******************** Bienvenidos ********************");
            Console.WriteLine("******************** Sistema de Pedidos de Mostaza ********************");
            Console.WriteLine("A) Dar de alta pedidos\n");
            Console.WriteLine("B) Asignar cadete a pedido\n");
            Console.WriteLine("C) Cambiar estado del pedido\n");
            Console.WriteLine("D) Reasignar pedido a otro cadete\n");
            Console.WriteLine("E) Salir.");


            opcion = Console.ReadLine();



            switch (opcion)
            {
                case "a":
                    NroPedido++;
                    Console.WriteLine("\n********** Datos del Cliente **********\n");
                    Console.WriteLine(" Nombre: ");
                    nombreCl = Console.ReadLine();
                    Console.WriteLine(" Direccion: ");
                    direccionCl = Console.ReadLine();
                    Console.WriteLine(" Telefono: ");
                    telefonoCl = Console.ReadLine();
                    Console.WriteLine(" Datos de Referencia de su Domicilio: ");
                    datosRefDirCliente = Console.ReadLine();
                    Console.WriteLine(" Observaciones sobre su Pedido: ");
                    obsPedido = Console.ReadLine();
                    Console.WriteLine($"\nNro Pedido: {NroPedido}\n");

                    if (Mostaza.NuevoPedido(NroPedido, obsPedido, nombreCl, direccionCl, telefonoCl, datosRefDirCliente))
                    {
                        Console.WriteLine("Nuevo pedido ingresado Correctamente\n");
                    }
                    break;
                case "b":
                    int idCadete = 0, nropedido = 0;
                    string idCad = "", nro = "";
                    do
                    {
                        MostrarCantidadPedidosDeCadetes(Mostaza);
                        Console.Write("\n Ingrese el nro de pedido: ");
                        nro = Console.ReadLine();
                        Console.Write("\n Ingrese el id del Cadete: ");
                        idCad = Console.ReadLine();
                        if (!int.TryParse(nro, out nropedido) || !int.TryParse(idCad, out idCadete))
                        {
                            Console.WriteLine("Error. Dato Invalido. \n");
                        }
                        else
                        {
                            if (idCadete < 0 || idCadete > Mostaza.IdMaximo())
                            {
                                Console.WriteLine("No existe un cadete con el ID ingresado \n");
                            }
                            else
                            {
                                if (Mostaza.AsignarCadeteAPedido(idCadete, nropedido))
                                {

                                    Console.WriteLine("\nEl Pedido se asigno correctamente al Cadete elegido\n");
                                }
                            }
                        }
                    } while (!int.TryParse(nro, out nropedido) || !int.TryParse(idCad, out idCadete) || idCadete < 0 || idCadete > Mostaza.IdMaximo());
                    break;

                case "c":
                    int nroPedidoACambiar;
                    string nroped = "";
                    do
                    {
                        Console.Write("\n Ingrese el id del Pedido a Cambiar: ");
                        nroped = Console.ReadLine();
                        if (!int.TryParse(nroped, out nroPedidoACambiar))
                        {
                            Console.WriteLine("Error. Dato Invalido. \n");
                        }
                        else
                        {
                            if (!Mostaza.CambiarEstadoDelPedido(nroPedidoACambiar))
                            {
                                Console.WriteLine("Error. No se pudo Cambiar el estado del Pedido. \n");
                            }
                            else
                            {
                                Console.WriteLine("\nSe Cambió correctamente el estado del Pedido\n");
                            }
                        }
                    } while (!int.TryParse(nroped, out nroPedidoACambiar));
                    break;


                case "d":
                    int nroPedidoAReasignar, idCadeteAReasignar;
                    string nroPedido = "", id = "";
                    do
                    {
                        Console.WriteLine("Ingrese un Nro de Pedido: ");
                        nroPedido = Console.ReadLine();
                        Console.WriteLine("Ingrese ID del Cadete a Reasignar el Pedido: ");
                        id = Console.ReadLine();
                        if (!int.TryParse(nroPedido, out nroPedidoAReasignar) || !int.TryParse(id, out idCadeteAReasignar))
                        {
                            Console.WriteLine("\n Error. El id o el Nro de pedido no existen");
                        }
                        else
                        {
                            if (idCadeteAReasignar < 0 || idCadeteAReasignar > Mostaza.IdMaximo())
                            {
                                Console.WriteLine("\n Error. ID inexistente");
                            }
                            else
                            {
                                if (!Mostaza.ReasignarPedidoACadete(nroPedidoAReasignar, idCadeteAReasignar))
                                {
                                    Console.WriteLine("\n No es posible reasignar un pedido ya Entregado\n");
                                }
                                else
                                {
                                    Console.WriteLine("\n Reasignacion OK! \n");
                                }
                            }
                        }


                    } while (!int.TryParse(nroPedido, out nroPedidoAReasignar) || !int.TryParse(id, out idCadeteAReasignar) || idCadeteAReasignar < 0 || idCadeteAReasignar > Mostaza.IdMaximo());


                    break;
            }
        } while (opcion != "e");
        Informe informe = Mostaza.CrearInforme();
        MostrarInforme(informe);


    }else
    {
        Console.WriteLine("\nNo existen los archivos para iniciar la aplicacion");
    }
}


    private static void MostrarCantidadPedidosDeCadetes(Cadeteria Cad)
    {
        Console.WriteLine("\n **************** Cantidad de Pedidos por Cadete ****************");
        foreach (var cad in Cad.ListadeCadetes)
        {
            Console.WriteLine($"ID: {cad.Id}      Nombre: {cad.Nombre}        CantPedidos: {Cad.CantPedidosCadete(cad.Id,EstadoPedido.Pendiente)}");

        }
        Console.WriteLine("\n");
    }

    private static void MostrarInforme(Informe informe)
    {

        Console.WriteLine("\n************** Informe **************");
        Console.WriteLine($"Cantidad de Cadetes: {informe.CantCadetes}");
        Console.WriteLine($"\nID                Nombre                      cant. Pedidos Entregados            Monto Ganado\n");
        for (int i = 0; i < informe.CantCadetes; i++)
        {
            Console.WriteLine($"{informe.IdCadetes[i]}              {informe.NombresCadetes[i]}                             {informe.CantPedidosEntregadosporCadetes[i]}                                  {informe.MontoCadetes[i]}");
        }
        Console.WriteLine($"\n Total de Pedidos Entregados: {informe.TotalPedidosEntregados}");
        Console.WriteLine($"\n Cantidad promedio de Pedidos Entregados por cadete: {informe.CantPromedioDePedidosEntregados}");


    }
}