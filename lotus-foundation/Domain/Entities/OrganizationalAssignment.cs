using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{

    public class OrganizationalAssignment
    {
        public string? Zona { get; private set; }
        public string? Provincia { get; private set; }
        public string Territorio { get; private set; }
        public string SubDireccion { get; private set; }

        public OrganizationalAssignment(
            string territorio,
            string subDireccion,
            string? zona = null,
            string? provincia = null)
        {
            Territorio = territorio;
            SubDireccion = subDireccion;
            Zona = zona;
            Provincia = provincia;
        }
    }
}
