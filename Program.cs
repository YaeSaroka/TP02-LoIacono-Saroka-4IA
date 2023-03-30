using System.Collections.Generic;
Dictionary<string, string> DiccionarioPersonas = new Dictionary<string, string>();
int opcion = 0;
while(opcion!=5)
{
    opcion=Funciones.Menu(opcion);

switch(opcion)
{
    case 1:
        AgregarPersona();
    break;

    case 2:
    break;

    case 3:
    break;
}
}

void AgregarPersona()
{
    string dni = Funciones.IngresarTexto("Ingrese su DNI: ");
    ValidarDNI(ref dni);  
}
void ValidarDNI(ref string dni)
{
    while(dni.Length<8)
    {
        dni = Funciones.IngresarTexto("Error, ingrese su DNI nuevamente: ");
    }
    foreach( string clave_dni in DiccionarioPersonas.Keys)
    {
        if(clave_dni == dni)
        {
            dni = Funciones.IngresarTexto("Ya se encuentra este DNI, ingreselo nuevamente: ");
        }
    }
    
}




