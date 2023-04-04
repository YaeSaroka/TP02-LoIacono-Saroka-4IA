public static class Funciones
{
public static int IngresarEntero(string msj)
{
    Console.WriteLine(msj);
    return int.Parse(Console.ReadLine());
}
public static string IngresarTexto(string msj)
{
    Console.WriteLine(msj);
    return Console.ReadLine();
}
public static int Menu(int opcion)
{
    do
    {
        Console.WriteLine("1) Cargar Nueva Persona");
        Console.WriteLine("2) Obtener Estadísticas del Censo");
        Console.WriteLine("3) Buscar Persona");
        Console.WriteLine("4) Modificar Mail de una Persona");
        Console.WriteLine("5) Salir");
        opcion= Funciones.IngresarEntero("Ingrese la opción que desea ejecutar: ");
    } while(opcion<0 || opcion>5);
    return opcion;
} 
public static DateTime IngresarFecha(string msj)
    {
        DateTime fechaDate;
        string fecha_ingresada = IngresarTexto(msj);
        while (!DateTime.TryParse(fecha_ingresada, out fechaDate))
        {
            fecha_ingresada = IngresarTexto("ERROR! " + msj);
        }
        return fechaDate;
    }
}



