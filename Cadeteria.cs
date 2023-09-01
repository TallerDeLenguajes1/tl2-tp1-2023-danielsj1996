namespace EmpCadeteria;


public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadeCadetes;
    private List<Pedido> listadePedidos;

    public string Nombre { get => nombre; }
    public string Telefono { get => telefono; }
    public List<Cadete> ListadeCadetes { set => listadeCadetes = value; }

    public Cadeteria() { }

    public Cadeteria(string nombre, string telefono)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadePedidos = new List<Pedido>();
    }

    public Pedido NuevoPedido()
    {

        string? nombreCliente = "", direccionCliente = "", telefonoCl = "", datosRefCl = "";
        string? obsPedido = "";
        Console.WriteLine("\n------------------------ Datos del Cliente ------------------------------\n");
        Console.WriteLine(">Nombre: ");
        nombreCliente = Console.ReadLine();
        Console.WriteLine(">Telefono: ");
        telefonoCl = Console.ReadLine();
        Console.WriteLine(">Direccion: ");
        direccionCliente = Console.ReadLine();
        Console.WriteLine(">Datos de Rerencia del Domicilio: ");
        datosRefCl = Console.ReadLine();
        Console.WriteLine(">Observaciones del Pedido: ");
        obsPedido = Console.ReadLine();

        Cliente cl = new Cliente(nombreCliente, direccionCliente, telefonoCl, datosRefCl);

        Pedido ped = new Pedido(obsPedido, cl);

        return ped;


    }

    public int CantidadPedidos()
    {

        return listadePedidos.Count;
    }


    public void AgregarPedido(Pedido p)
    {

        listadePedidos.Add(p);
    }

    public void MostrarPedidos(){

        foreach (var p in listadePedidos)
        {
            Console.WriteLine($">Numero: {p.Nro}");
            Console.WriteLine($">Observaciones: {p.Observaciones}");
            p.VerDatosCliente();
        }
    }
}