namespace EmpCadeteria;


public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadeCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadeCadetes { get => listadeCadetes; set => listadeCadetes = value; }


    public Cadeteria() { }

    public Cadeteria(string nombre, string telefono)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;

    }
    private int CantCadetes()
    {
        return ListadeCadetes.Count;
    }

    public void AgregarListaCadetes(List<Cadete> listadeCadetes)
    {
        this.listadeCadetes = listadeCadetes;
    }

    public bool NuevoPedido(int nroPedido, string obsPedido, int CadeteID, string nombreCliente, string DireccionCliente, string telefonoCl, string datosRefCl)
    {

        Pedido ped = new Pedido(nroPedido, obsPedido, nombreCliente, DireccionCliente, telefonoCl, datosRefCl);
        bool AsignarPedido = AsignarPedidoCadete(CadeteID, ped);
        return AsignarPedido;
    }
    public int IdMaximo()
    {
        return (listadeCadetes.Count - 1);
    }
    public bool AsignarPedidoCadete(int idCadete, Pedido pedidoTomado)
    {
        bool pedidoAsignado = false;
        foreach (var cad in listadeCadetes)
        {
            if (cad.Id == idCadete)
            {
                cad.AgregarPedido(pedidoTomado);
                pedidoAsignado = true;
            }

        }
        return pedidoAsignado;
    }
    public bool CambiarEstadoDelPedido(int nroPedido)
    {
        foreach (var cad in listadeCadetes)
        {
            if (cad.CambiarEstadoDelPedido(nroPedido))
            {
                return true;
            }
        }
        return false;
    }

    public bool ReasignarPedidoACadete(int nroPedido, int idCadete)
    {
        bool reasignacionOk = false;
        Pedido pedidoAReasignar = null;
        foreach (var cad in listadeCadetes)
        {
            pedidoAReasignar = cad.ListadePedidos.Find(ped => ped.Nro == nroPedido);
            if (pedidoAReasignar != null)
            {
                cad.ListadePedidos.Remove(pedidoAReasignar);
                break;
            }
        }
        if (pedidoAReasignar != null && pedidoAReasignar.Estado != EstadoPedido.Entregado)
        {
            foreach (var cad in listadeCadetes)
            {
                if (cad.Id == idCadete)
                {
                    cad.AgregarPedido(pedidoAReasignar);
                    reasignacionOk = true;
                    break;
                }

            }
        }
        return reasignacionOk;
    }

    public Informe CrearInforme()
    {
        List<int> idCadetes = listadeCadetes.Select(cad => cad.Id).ToList();
        List<string> NombreDeCadetes = listadeCadetes.Select(cad => cad.Nombre).ToList();
        List<int> cantPedidosEntregadosporCadetes = listadeCadetes.Select(cad => cad.CantidadDeEntregados()).ToList();
        List<double> montosCadetes = listadeCadetes.Select(cad => cad.JornalACobrar()).ToList();
        int totalPedidosEntregados = listadeCadetes.Sum(cad => cad.CantidadDeEntregados());
        int cantPromedioDePedidosEntregados = (int)cantPedidosEntregadosporCadetes.Average();
        
        
        Informe informe = new Informe(CantCadetes(), idCadetes, NombreDeCadetes, cantPedidosEntregadosporCadetes, montosCadetes, totalPedidosEntregados, cantPromedioDePedidosEntregados);
        return informe;

    }
}