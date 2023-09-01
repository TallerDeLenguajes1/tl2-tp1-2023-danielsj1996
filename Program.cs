// See https://aka.ms/new-console-template for more information

using EmpCadeteria;

string rutaDatosCadeteria = "DatosCadeteria.csv";
string rutaDatosCadetes = "DatosCadetes.csv";

Cadeteria Mostaza = AccesoDatosCadeteria.ObtenerInfoCadeteria(rutaDatosCadeteria);
List<Cadete> listadeCadetes = AccesoDatosCadeteria.ObtenerListaCadetes(rutaDatosCadetes);

Mostaza.AgregarListaCadetes(listadeCadetes);

string opcion = "";
Pedido p = new Pedido();
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
            NroPedido++;
            p = Mostaza.AgregarPedido(NroPedido);
            Console.WriteLine("\n El Pedido se ha agregado Correctamente");

            break;

        case "b":
            if (p != null)
            {
                int idCadete = 0;
                string id = "";
                int referencia = Mostaza.idMaximo();

                do
                {//Mostaza.MostrarCantidadPedidosCadete();
                    Console.WriteLine("Ingrese el id del Cadete para Asignarle el Pedido");
                    id = Console.ReadLine();
                    if (!int.TryParse(id, out idCadete))
                    {
                        Console.WriteLine("\n No existe un cadete con el id solicitado")
                    }
                    else
                    {
                        if (idCadete < 0 || idCadete > referencia)
                        {
                            Console.WriteLine("\n No existe un cadete con el id solicitado")
                        }
                    }

                } while (!int.TryParse(id, out idCadete) || (idCadete < 0 || idCadete > referencia));

                Mostaza.AgregarPedidoACadete(idCadete, p);
                Console.WriteLine("\n El Pedido fue Agregado con exito");
                p = null;


            }


            break;

        case "c":
            break;

        case "d":
            break;

        default:
    }

} while (Opcion != e);