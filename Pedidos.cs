namespace EmpCadeteria;

public enum EstadoPedido
{
    Entregado,
    Pendiente,

}

public class Pedido
{
    private int nro;
    private string? observaciones;
    private EstadoPedido estado;
    private Cliente cliente;


    public int Nro { get => nro; }
    public string? Observaciones { get => observaciones; }
    public EstadoPedido Estado { get => estado; }

    public Pedido() { }


    public Pedido(int nro, string observaciones, string nombreCliente, string direccionCliente, string telefonoCliente, string datosReferenciaDireccionCliente)
    {
        this.nro = nro;
        this.observaciones = observaciones;
        this.estado = EstadoPedido.Pendiente;
        this.cliente = new Cliente(nombreCliente, direccionCliente, telefonoCliente, datosReferenciaDireccionCliente);
    }


    public void VerDatosCliente()
    {
        Console.WriteLine("\n************Datos del Cliente************\n");
        Console.WriteLine($"\nNombre: {cliente.Nombre}\n");
        Console.WriteLine($"\nDireccion: {cliente.Direccion}\n");
        Console.WriteLine($"\nTelefono: {cliente.Telefono}\n");

    }
    public void Entregado()
    {
        estado = EstadoPedido.Entregado;
    }

}