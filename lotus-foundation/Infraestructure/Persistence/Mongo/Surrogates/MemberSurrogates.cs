using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence.Mongo.Surrogates
{
    public sealed class MemberSurrogate
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Division { get; set; } = default!;
        public int Roles { get; set; }

        public string Subdireccion { get; set; } = default!;
        public string Territorio { get; set; } = default!;
        public string? Zona { get; set; }
        public string? Provincia { get; set; }
    }

}
