using System.Text.Json;
using System.Text.Json.Serialization;

namespace EmpCadeteria;

public abstract class AccesoDatosCadeteria
{
    public abstract Cadeteria ObtenerInfoCadeteria(string rutaDatosCadeteria);

    public abstract List<Cadete> ObtenerListaCadetes(string rutaDatosCadetes);
    public bool ExisteArchivoDatos(string ruta)
    {
        FileInfo archivo = new FileInfo(ruta);

        if (archivo.Exists && archivo.Length > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
public class AccesoCSV : AccesoDatosCadeteria
{

    public override Cadeteria ObtenerInfoCadeteria(string rutaDatosCadeteria)
    {
        string[] datosCadeteria;
        using (StreamReader f = new StreamReader(rutaDatosCadeteria))
        {
            datosCadeteria = f.ReadLine().Split(',');
        }

        Cadeteria cadeteria = new Cadeteria(datosCadeteria[0], datosCadeteria[1]);
        return cadeteria;
    }



    public override List<Cadete> ObtenerListaCadetes(string rutaDatosCadetes)
    {
        List<Cadete> cadetes = new List<Cadete>();

        if (ExisteArchivoDatos(rutaDatosCadetes))
        {
            string linea = "";
            string[] datosCadete;

            using (StreamReader f = new StreamReader(rutaDatosCadetes))
            {
                while ((linea = f.ReadLine()) != null)
                {
                    datosCadete = linea.Split(',');
                    Cadete cadete = new Cadete(Convert.ToInt32(datosCadete[0]), datosCadete[1], datosCadete[2], datosCadete[3]);
                    cadetes.Add(cadete);
                }
            }

        }

        return cadetes;
    }
}

public class AccesoAJson : AccesoDatosCadeteria
{
    public override Cadeteria ObtenerInfoCadeteria(string rutaDatosCadeteria)
    {
        string infoCadeteria = File.ReadAllText(rutaDatosCadeteria);
        Cadeteria cadeteriaConInfo=JsonSerializer.Deserialize<Cadeteria>(infoCadeteria);
        return cadeteriaConInfo;
    }

    public override List<Cadete> ObtenerListaCadetes(string rutaDatosCadete){
        
        string infoDeCadetes = File.ReadAllText(rutaDatosCadete);
        List<Cadete> cadetes=JsonSerializer.Deserialize<List<Cadete>>(infoDeCadetes);
        return cadetes;
    }
}