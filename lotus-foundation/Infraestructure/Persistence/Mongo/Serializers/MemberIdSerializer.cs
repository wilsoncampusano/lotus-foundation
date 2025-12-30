using Domain.Entities;
using Domain.Members;
using Infraestructure.Persistence.Mongo.Surrogates;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Infraestructure.Persistence.Mongo.Serializers
{
    public sealed class MemberSerializer : SerializerBase<Member>
    {
        public override void Serialize(
            BsonSerializationContext context,
            BsonSerializationArgs args,
            Member value)
        {
            var surrogate = new MemberSurrogate
            {
                Id = value.Id.Value,
                FirstName = value.Name.FirstName,
                LastName = value.Name.LastName, 
                Division = value.Division.ToString(),
                Roles = (int)value.Role,
                Subdireccion = value.Organization.SubDireccion,
                Territorio = value.Organization.Territorio,
                Zona = value.Organization.Zona
            };

            BsonSerializer.Serialize(context.Writer, surrogate);
        }

        public override Member Deserialize(
            BsonDeserializationContext context,
            BsonDeserializationArgs args)
        {
            var surrogate =
                BsonSerializer.Deserialize<MemberSurrogate>(context.Reader);

            var member = new Member(
                MemberId.From(surrogate.Id),
                new FullName(surrogate.FirstName, surrogate.LastName),
                Enum.Parse<Division>(surrogate.Division),
                ((MemberRole)surrogate.Roles),
                new OrganizationUnit(
                    surrogate.Territorio,
                    surrogate.Subdireccion,
                    surrogate.Zona, 
                    surrogate.Provincia));


            return member;
        }
    }

}
