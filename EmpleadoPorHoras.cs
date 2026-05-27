using System;

namespace GestionNomina
{
    // Clase para los empleados que cobran por hora y tienen horas extras (después de las 40 horas).
    public class EmpleadoPorHoras : Empleado
    {
        public decimal SueldoPorHora { get; set; }
        public decimal HorasTrabajadas { get; set; }

        public EmpleadoPorHoras(string primerNombre, string apellidoPaterno, string numeroSeguroSocial, decimal sueldoPorHora, decimal horasTrabajadas)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
        {
            SueldoPorHora = sueldoPorHora;
            HorasTrabajadas = horasTrabajadas;
        }

        // Calculamos el pago semanal aplicando la regla de horas extras
        public override decimal CalcularPago()
        {
            if (HorasTrabajadas <= 40)
            {
                // Pago normal
                return SueldoPorHora * HorasTrabajadas;
            }
            else
            {
                // Las primeras 40 horas se pagan normal, las extras a 1.5x
                decimal horasNormales = 40;
                decimal horasExtras = HorasTrabajadas - 40;
                return (SueldoPorHora * horasNormales) + (SueldoPorHora * 1.5M * horasExtras);
            }
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo: Empleado por Horas");
            Console.WriteLine($"Sueldo por Hora: {SueldoPorHora:C}");
            Console.WriteLine($"Horas Trabajadas: {HorasTrabajadas}");
        }
    }
}
