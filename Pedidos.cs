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
    private Cadete cadete;


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


    public bool ExisteCadete()
    {
        if (cadete != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int IdCadete()
    {
        return cadete.Id;
    }
    public void Entregado()
    {
        estado = EstadoPedido.Entregado;
    }
public void VincularCadete(Cadete cad){
    cadete=cad;
}
}