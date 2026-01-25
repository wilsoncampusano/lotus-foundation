using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Outbox
{
    public sealed class OutboxMesage
    {
        public Guid Id { get; set; }

        public string Type { get; set; } = default!;
        public string Payload { get; set; } = default!;
        public DateTime OccuredOn { get; set; }
        public DateTime? ProcessedOn { get; set; }
    }
}
