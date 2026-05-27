using System;

namespace GestionNomina
{
    // Clase para los empleados que ganan un sueldo fijo semanal.
    public class EmpleadoAsalariado : Empleado
    {
        public decimal SalarioSemanal { get; set; }

        // El constructor llama al constructor de la clase padre (Empleado) usando base
        public EmpleadoAsalariado(string primerNombre, string apellidoPaterno, string numeroSeguroSocial, decimal salarioSemanal)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
        {
            SalarioSemanal = salarioSemanal;
        }

        // Aquí usamos "override" para darle nuestro propio comportamiento al cálculo del pago
        public override decimal CalcularPago()
        {
            return SalarioSemanal;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion(); // Imprime nombre y seguro social
            Console.WriteLine($"Tipo: Empleado Asalariado");
            Console.WriteLine($"Salario Fijo Semanal: {SalarioSemanal:C}");
        }
    }
}
