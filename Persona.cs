
class Persona
{
    //DEFINICIÓN DE PROPIEDADES:
    public string DNI{get;set;}
    public string Apellido{get;set;}
    public string Nombre{get;set;}
    public DateTime FechaNacimiento{get;set;}
    public string Email{get;set;}
    private int Edad{get;set;}

    public Persona(string dni, string surname, string name, DateTime fn, string mail)
    {
        DNI=dni;
        Apellido= surname;
        Nombre=name;
        FechaNacimiento=fn;
        Email=mail;
    }

    public int ObtenerEdad()
    {
        DateTime FechaActual = new DateTime(DateTime.Today.Year, FechaNacimiento.Month, FechaNacimiento.Day);
        if (FechaActual< DateTime.Today)  Edad = DateTime.Today.Year - FechaActual.Year;
            else   Edad = DateTime.Today.Year - FechaNacimiento.Year -1;
        return Edad;
    }
    public bool PuedeVotar()
    {
        bool puedevotar = false;
        if(Edad>16)
        {
            puedevotar= true;
        }
        return puedevotar;
    }
}