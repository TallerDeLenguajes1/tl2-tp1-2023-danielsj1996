namespace EmpCadeteria;



public enum EstadoPedido
{
    Aceptado,
    Pendiente,
    Rechazado
}
public class Pedido
{
    private int nro;
    private string observaciones;
    private EstadoPedido estado;
    private Cliente cliente;


    public int Nro { get => nro; }
    public string Observaciones { get => observaciones; }
    public EstadoPedido Estado { get => estado; }

public Pedido(){}
    public Pedido(string observaciones, Cliente cliente){
        this.nro += 1;
        this.observaciones = observaciones;
        this.estado = EstadoPedido.Pendiente;
        this.cliente = new Cliente();
        this.cliente = cliente;
    } 
    public Pedido(string nro, string observaciones, EstadoPedido estado, Cliente cliente)
    {
        this.nro = Convert.ToInt32(nro);
        this.observaciones = observaciones;
        this.estado = estado;
        this.cliente = cliente;
    }


    public void VerDatosCliente()
    {
        Console.WriteLine("\n************Datos del Cliente************\n");
        Console.WriteLine($"\nNombre: {cliente.Nombre}\n");
        Console.WriteLine($"\nDireccion: {cliente.Direccion}\n");
        Console.WriteLine($"\nTelefono: {cliente.Telefono}\n");

    }
    public void VerDireccionCliente()
    {
        Console.WriteLine("\n************Datos del Cliente************\n");
        Console.WriteLine($"\nNombre: {cliente.Nombre}\n");
        Console.WriteLine($"\nDireccion: {cliente.Direccion}\n");
        Console.WriteLine($"\nDireccion: {cliente.DatosReferenciaDireccion}\n");
        

    }

}