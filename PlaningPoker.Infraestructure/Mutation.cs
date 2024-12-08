using PlaningPoker.Application.Contract;
using PlaningPoker.Domain.Dto;

namespace PlaningPoker.Infraestructure
{
    public class Mutation
    {
        public async Task<bool> CreatePoker(PokerDto dto, [Service] IPokerService _pokerService)
        {
            return await _pokerService.CreatePoker(dto);
        }
    }

    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(
            IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(f => f.CreatePoker(default, null!));
        }
    }
}
