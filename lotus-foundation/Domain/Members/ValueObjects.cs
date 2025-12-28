namespace Domain.Members
{

    public enum Division
    {
        Futuro,
        JuvenilMasculina,
        JuvenilFemenina,
        DamasJovenes,
        Damas,
        Caballeros
    }

    public enum MemberRole
    {
        Miembro,
        Encargado,
        Responsable
    }

    public enum MemberStatus
    {
        Active,
        Inactive
    }


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