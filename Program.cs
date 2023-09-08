// See https://aka.ms/new-console-template for more information

using EmpCadeteria;

internal class Program
{
    private static void Main(string[] args)
    {
        string rutaDatosCadeteria = "DatosCadeteria.csv";
        string rutaDatosCadetes = "DatosCadetes.csv";

        Cadeteria Mostaza = AccesoDatosCadeteria.ObtenerInfoCadeteria(rutaDatosCadeteria);
        List<Cadete> listadeCadetes = AccesoDatosCadeteria.ObtenerListaCadetes(rutaDatosCadetes);

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
            Console.WriteLine("a) dar de alta pedidos");
            Console.WriteLine("b) asignarlos a cadetes");
            Console.WriteLine("c) cambiarlos de estado");
            Console.WriteLine("d) reasignar el pedido a otro cadete.");
            Console.WriteLine("e) Salir.");

            opcion = Console.ReadLine();



            switch (opcion)
            {
                case "a":
                    int idCadete = 0;
                    string idCad = "";
                    NroPedido++;
                    Console.WriteLine("\n$********** Datos del Cliente **********\n");
                    Console.WriteLine("> Nombre: ");
                    nombreCl = Console.ReadLine();
                    Console.WriteLine("> Direccion: ");
                    direccionCl = Console.ReadLine();
                    Console.WriteLine("> Telefono: ");
                    telefonoCl = Console.ReadLine();
                    Console.WriteLine("> Datos de Referencia de su Domicilio: ");
                    datosRefDirCliente = Console.ReadLine();
                    Console.WriteLine("> Observaciones sobre su Pedido: ");
                    obsPedido = Console.ReadLine();
                    Console.WriteLine("$\nNro Pedido: {nroPedido}\n");
                    MostrarCantidadPedidosDeCadetes(Mostaza);
                    do
                    {
                        Console.WriteLine("Ingresar el Id del Cadete para Asignar: ");
                        idCad = Console.ReadLine();
                    } while (!int.TryParse(idCad, out idCadete) || idCadete < 0 || idCadete > Mostaza.IdMaximo());
                    if (Mostaza.NuevoPedido(NroPedido, obsPedido, idCadete, nombreCl, direccionCl, telefonoCl, datosRefDirCliente)) ;
                    {
                        Console.WriteLine("El pedido se agregó con Exito");
                    }


                    break;

                case "b":
                    int nroPedidoACambiar;
                    string nro = "";
                    do
                    {
                        Console.Write("\n Ingrese el id del Pedido a Cambiar: ");
                        nro = Console.ReadLine();
                        if (!int.TryParse(nro, out nroPedidoACambiar))
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
                    } while (!int.TryParse(nro, out nroPedidoACambiar));
                    break;

                case "c":
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
        } while (opcion != "d");
        Informe informe = Mostaza.CrearInforme();
        MostrarInforme(informe);


    }

    private static void MostrarCantidadPedidosDeCadetes(Cadeteria Cad)
    {
        Console.WriteLine("\n **************** Cantidad de Pedidos ****************");
        foreach (var cad in Cad.ListadeCadetes)
        {
            Console.WriteLine($"ID: {cad.Id}      Nombre: {cad.Nombre}        CantPedidos: {cad.CantidadDePendientes()}");

        }
        Console.WriteLine("\n");
    }

    private static void MostrarInforme(Informe informe)
    {

        Console.WriteLine("\n************** Informe **************");
        Console.WriteLine($"Cantidad de Cadetes: {informe.CantCadetes}");
        Console.WriteLine($"\nID            Nombre          cant. Pedidos Entregados            Monto Ganado\n");
        for (int i = 0; i < informe.CantCadetes; i++)
        {
            Console.WriteLine($"{informe.IdCadetes[i]}             {informe.NombresCadetes[i]}            {informe.CantPedidosEntregadosporCadetes[i]}           {informe.MontoCadetes[i]}");
        }
        Console.WriteLine($"\n Total de Pedidos Entregados: {informe.TotalPedidosEntregados}");
        Console.WriteLine($"\n Cantidad promedio de Pedidos Entregados por cadete: {informe.CantPromedioDePedidosEntregados}");


    }
}