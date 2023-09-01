namespace EmpCadeteria;


public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadeCadetes;
    private List<Pedido> listadePedidos;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadeCadetes { get => listadeCadetes; set => listadeCadetes = value; }
    public List<Pedido> ListadePedidos { get => listadePedidos; set => listadePedidos = value; }

    

    public Cadeteria(string nombre, string telefono)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
        this.ListadePedidos = new List<Pedido>();
    }

    public Pedido NuevoPedido()
    {

        string? nombreCliente = "", direccionCliente = "", telefonoCl = "", datosRefCl = "";
        string? obsPedido = "";
        Console.WriteLine("\n------------------------ Datos del Cliente ------------------------------\n");
        Console.WriteLine("Nombre: ");
        nombreCliente = Console.ReadLine();
        Console.WriteLine("Telefono: ");
        telefonoCl = Console.ReadLine();
        Console.WriteLine("Direccion: ");
        direccionCliente = Console.ReadLine();
        Console.WriteLine("Datos de Rerencia del Domicilio: ");
        datosRefCl = Console.ReadLine();
        Console.WriteLine("Observaciones del Pedido: ");
        obsPedido = Console.ReadLine();

        Cliente cl = new Cliente(nombreCliente, direccionCliente, telefonoCl, datosRefCl);
        Pedido ped = new Pedido(obsPedido, cl);

        return ped;


    }

    public int CantidadPedidos()
    {
        return ListadePedidos.Count;
    }


    public void AgregarPedido(Pedido p)
    {
        ListadePedidos.Add(p);
    }

    public void MostrarPedidos(){

        foreach (var p in ListadePedidos)
        {
            Console.WriteLine($">Numero: {p.Nro}");
            Console.WriteLine($">Observaciones: {p.Observaciones}");
            p.VerDatosCliente();
        }
    }
}