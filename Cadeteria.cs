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




    public Cadeteria(string nombre, string telefono)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
        this.listadePedidos = new List<Pedido>();
    }
    private int CantCadetes()
    {
        return ListadeCadetes.Count;
    }

    public void AgregarListaCadetes(List<Cadete> listadeCadetes)
    {
        this.listadeCadetes = listadeCadetes;
    }

    public bool AgregarPedido(Pedido ped)
    {
        bool agregado = false;
        if (ped != null)
        {
            listadePedidos.Add(ped);
            agregado = true;
        }
        return agregado;

    }
    public bool NuevoPedido(int nroPedido, string obsPedido, int CadeteID, string nombreCliente, string DireccionCliente, string telefonoCl, string datosRefCl)
    {
        Pedido ped = new Pedido(nroPedido, obsPedido, nombreCliente, DireccionCliente, telefonoCl, datosRefCl);
        bool nuevoPedido = AgregarPedido(ped);
        return nuevoPedido;
    }
    public int IdMaximo()
    {
        return (listadeCadetes.Count - 1);
    }
    public bool AsignarCadeteAPedido(int idCadete, int nroPedido)
    {
        bool AsignacionOK = false;
        Cadete cad = listadeCadetes.Find(x => x.Id == idCadete);
        if (cad != null)
        {
            foreach (var p in listadePedidos)
            {
                if (p.Nro == nroPedido)
                {
                    p.VincularCadete(cad);
                    break;
                }
            }
            AsignacionOK = true;
        }
        return AsignacionOK;
    }
    public bool CambiarEstadoDelPedido(int nroPedido)
    {
        foreach (var p in listadePedidos)
        {
            if (p.Nro == nroPedido)
            {
                p.Entregado();
                return true;
            }
        }
        return false;
    }

    public bool ReasignarPedidoACadete(int nroPedido, int idCadete)
    {
        bool reasignacionOk = false;
        Cadete cad = listadeCadetes.Find(cadete => cadete.Id == idCadete);

        if (cad != null)
        {

            foreach (var p in listadePedidos)
            {
                if (p.Nro == nroPedido && p.Estado != EstadoPedido.Entregado)
                {
                    p.vincularCadete(cad);
                }
                reasignacionOk = true
            }
        }

        return reasignacionOk;
    }

    public int CantPedidosCadete(int idCadete, EstadoPedido estado)
    {
        int cant = 0;
        foreach (var p in listadePedidos)
        {
            if ((p.existeCadete()) && (p.IdCadete() == idCadete) && (p.Estado == estado))
            {
                cant++;
            }
        }
        return cant;
    }


    public double JornalACobrar(int idCadete)
    {
        double Jornal = 500 * CantPedidosCadete(idCadete, EstadoPedido.Entregado);
        return Jornal;
    }




    public Informe CrearInforme()
    {
        List<int> idCadetes = listadeCadetes.Select(cad => cad.Id).ToList();
        List<string> NombreDeCadetes = listadeCadetes.Select(cad => cad.Nombre).ToList();
        List<int> cantPedidosEntregadosporCadetes = new List<int>();
        List<double> montosCadetes = new List<double>();
        foreach (var cad in ListadeCadetes)
        {
            cantPedidosEntregadosporCadetes.Add(CantPedidosCadete);
            montosCadetes.Add(JornalACobrar(cad.Id));
        }
        int totalPedidosEntregados = cantPedidosEntregadosporCadetes.Sum();
        int cantPromedioDePedidosEntregados = (int)cantPedidosEntregadosporCadetes.Average();

        Informe informe = new Informe(CantCadetes(), idCadetes, NombreDeCadetes, cantPedidosEntregadosporCadetes, montosCadetes, totalPedidosEntregados, cantPromedioDePedidosEntregados);
        return informe;

    }
}