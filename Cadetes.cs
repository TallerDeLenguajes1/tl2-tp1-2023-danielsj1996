namespace EmpCadeteria;

public class Cadete
{
    private int id;
    private string? nombre;
    private string? direccion;
    private string? telefono;
    private List<Pedido> listadepedidos;

    public int Id { get => id; }
    public string? Nombre { get => nombre; }
    public string? Direccion { get => direccion; set => direccion = value; }
    public string? Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadePedidos { get => listadepedidos; }



    public Cadete(string id, string nombre, string direccion, string telefono)
    {
        this.id = Convert.ToInt32(id);
        this.nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
        this.listadepedidos = new List<Pedido>();
    }

    //metodos

    public void AgregarPedido(Pedido pedido)
    {
        listadepedidos.Add(pedido);
    }
    public bool CambiarEstadoDelPedido(int NroPedido)
    {
        foreach (var ped in listadepedidos)
        {
            if (ped.Nro == NroPedido)
            {
                ped.Entregado();
                return true;
            }
        }
        return false;
    }

    public int CantidadDePendientes()
    {
        int CantPedPendientes = 0;
        foreach (var ped in listadepedidos)
        {
            if (ped.Estado == EstadoPedido.Pendiente)
                CantPedPendientes++;
        }
        return CantPedPendientes;
    }


    public int CantidadDeEntregados()
    {
        int CantPedEntregados = 0;
        foreach (var ped in listadepedidos)
        {
            if (ped.Estado == EstadoPedido.Entregado)
            {
                CantPedEntregados++;
            }

        }
        return CantPedEntregados;
    }


    public double JornalACobrar()
    {
        double Jornal=500 * CantidadDeEntregados();
        return Jornal;
    }

}