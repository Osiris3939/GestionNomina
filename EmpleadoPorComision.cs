using System;

namespace GestionNomina
{
    // Clase para los empleados que ganan basándose en sus ventas totales.
    public class EmpleadoPorComision : Empleado
    {
        public decimal VentasBrutas { get; set; }
        public decimal TarifaComision { get; set; }

        public EmpleadoPorComision(string primerNombre, string apellidoPaterno, string numeroSeguroSocial, decimal ventasBrutas, decimal tarifaComision)
            : base(primerNombre, apellidoPaterno, numeroSeguroSocial)
        {
            VentasBrutas = ventasBrutas;
            TarifaComision = tarifaComision;
        }

        // Multiplicamos el monto de ventas por la tarifa de comisión (ej. 0.10 para 10%)
        public override decimal CalcularPago()
        {
            return VentasBrutas * TarifaComision;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Tipo: Empleado por Comisión");
            Console.WriteLine($"Ventas Totales: {VentasBrutas:C}");
            Console.WriteLine($"Tarifa de Comisión: {TarifaComision:P2} (o {TarifaComision})");
        }
    }
}
