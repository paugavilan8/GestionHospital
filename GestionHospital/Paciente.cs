using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionHospital
{
    public class Paciente : Persona
    {
        public string Enfermedad { get; set; }
        public int IdMedicoAsignado { get; set; }

        public override string ToString()
        {
            string asignacion = IdMedicoAsignado > 0 ? IdMedicoAsignado.ToString() : "Sin asignar";
            return $"{base.ToString()}, Enfermedad={Enfermedad}, MedicoId={asignacion}";
        }
    }
}
