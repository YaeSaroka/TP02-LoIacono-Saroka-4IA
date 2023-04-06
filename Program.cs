using System.Collections.Generic;
Dictionary<string, Persona> DiccionarioPersonas = new Dictionary<string, Persona>();
 int cont_personas=0,contador_personas_votar=0, opcion = 0, edad=0;
 double total_edades=0, promedio=0;
 string dni_buscado="", email_nuevo="";

while(opcion!=5)
{
    opcion=Funciones.Menu(opcion);
    Console.Clear();
switch(opcion)
{
    case 1:
        AgregarPersona();
    break;
    case 2:
    VerEstadisticas(ref promedio, ref cont_personas, ref contador_personas_votar);
    if(cont_personas>=1)
    {
        Console.WriteLine("Estadísticas del censo: ");
        Console.WriteLine($"Cantidad de personas {cont_personas}");
        Console.WriteLine($"Cantidad de personas habilitadas para votar: {contador_personas_votar}");
        Console.WriteLine($"Promedio de edad: {promedio}");
    }
    else
    {
        Console.WriteLine("Aún no se ingresaron personas en la lista");
    }
    break;
    case 3:
    dni_buscado=Funciones.IngresarTexto("Ingrese el DNI que desea buscar: ");
    BuscarPersona(dni_buscado);
    break;
    case 4:
    ModificarMail(dni_buscado,email_nuevo);
    break;
}
}

void AgregarPersona()
{
    string dni = Funciones.IngresarTexto("Ingrese su DNI: ");
    ValidarDNI(ref dni); 
    string  surname=Funciones.IngresarTexto("Ingrese su apellido: ");
    string name= Funciones.IngresarTexto("Ingrese su nombre: ");
    DateTime fn= Funciones.IngresarFecha("Ingrese su fecha de nacimiento: ");
    string mail= Funciones.IngresarTexto("Ingrese su email personal: ");

    Persona UnaPersona = new Persona(dni,surname,name,fn,mail);
    DiccionarioPersonas.Add(dni,UnaPersona);
    Console.WriteLine($"Se ha creado la persona {name} {surname} y se ha agregado a la lista");
}
void BuscarPersona(string dni_buscado)
{
    Persona persona_buscada= DiccionarioPersonas[dni_buscado];
    Console.WriteLine( " Nombre: " +persona_buscada.Nombre + " Apellido: " + persona_buscada.Apellido + " Fecha de Nacimiento: "+persona_buscada.FechaNacimiento+ " Email: " +persona_buscada.Email+" Edad: "+ CalcularEdad(persona_buscada.FechaNacimiento, ref edad) );  
}
static int CalcularEdad(DateTime fecha_nacimiento, ref int edad)
{
    DateTime fechaActual = DateTime.Today;
     edad = fechaActual.Year - fecha_nacimiento.Year;
     if (fecha_nacimiento.Month > fechaActual.Month)
    {
        --edad;
    }
    return edad;
}
void VerEstadisticas(ref double promedio, ref int cont_personas, ref int contador_personas_votar)
{
    
    foreach(Persona item in DiccionarioPersonas.Values )
    {
        cont_personas++;
        int edad_= CalcularEdad(item.FechaNacimiento, ref edad);
         total_edades+=edad;
        if(edad>=16)
        {
            contador_personas_votar++;
        }
        promedio=total_edades/cont_personas;
    }
}
void ModificarMail(string dni_buscado, string email_nuevo)
{
    dni_buscado=Funciones.IngresarTexto("Ingrese el DNI que desea cambiar el mail: ");
    if(DiccionarioPersonas.ContainsKey(dni_buscado))
    {
        email_nuevo=Funciones.IngresarTexto("Ingrese el nuevo mail: ");
        Persona usuario=DiccionarioPersonas[dni_buscado];
        usuario.Email = email_nuevo;
    }
    else
    {
        Console.WriteLine("No se encontró el DNI solicitado");
    }
} 
void ValidarDNI(ref string dni)
{
    while(dni.Length<8 || dni.Length>8)
    {
        dni = Funciones.IngresarTexto("Error, ingrese su DNI nuevamente: ");
    }
    foreach( string clave_dni in DiccionarioPersonas.Keys)
    {
        while(clave_dni == dni)
        {
            dni = Funciones.IngresarTexto("Ya se encuentra este DNI, ingreselo nuevamente: ");
        }
    }
    
}




