using System;

namespace GestionNomina
{
    // Esta es la clase padre (base) de todos los empleados
    // Es abstracta porque no queremos crear un Empleado genérico
    // sino que cada uno debe ser de un tipo específico asalariado, por horas, etc.
    public abstract class Empleado
    {
        // Propiedades básicas que tienen todos los empleados
        public string PrimerNombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string NumeroSeguroSocial { get; set; }

        public Empleado(string primerNombre, string apellidoPaterno, string numeroSeguroSocial)
        {
            PrimerNombre = primerNombre;
            ApellidoPaterno = apellidoPaterno;
            NumeroSeguroSocial = numeroSeguroSocial;
        }

        // Este método es abstracto porque el cálculo del pago depende 
        // enteramente de qué tipo de empleado sea Cada hijo lo implementa a su manera
        public abstract decimal CalcularPago();

        // Método virtual para mostrar la información en consola
        // Los hijos pueden usarlo o complementarlo con su propia información
        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre completo: {PrimerNombre} {ApellidoPaterno}");
            Console.WriteLine($"Seguro Social: {NumeroSeguroSocial}");
        }
    }
}
