namespace EmpCadeteria;

public class Cadete
{
    private string id;
    private string nombre;
    private string direccion;
    private string telefono;


    public Cadete(string id, string nombre, string direccion, string telefono)
    {
        this.id = id;
        this.nombre = nombre;
        this.Direccion = direccion;
        this.Telefono = telefono;
    }

    public string Id { get => id; }
    public string? Nombre { get => nombre; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }



    //metodos

    public void JornalACobrar(int id, List<Pedido> listadepedidos, int idBuscado)
    {

        foreach (var item in listadepedidos)
        {

        }

    }

}