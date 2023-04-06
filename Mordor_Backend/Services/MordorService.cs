using Mordor_Backend.Exceptions;
using Mordor_Backend.Models;
using Mordor_Backend.Models.Dto;
using Mordor_Backend.Repositories;

namespace Mordor_Backend.Service
{
    public class MordorService : IMordorService
    {
        private readonly IOrkRepository _orkRepository;

        public MordorService(IOrkRepository orkRepository)
        {
            _orkRepository = orkRepository;
        }

        public async Task<IEnumerable<GetOrkDto>> GetAllOrksAsync()
        {
            IEnumerable<Ork> orks = await _orkRepository.GetAllOrksAsync();

            List<GetOrkDto> orkDtos = orks
                .Select(ork => new GetOrkDto
                {
                    Id = ork.Id,
                    Name = ork.Name,
                    NumberOfKills = ork.NumberOfKills,
                    Type = ork.Type,
                    Weapons = ork.Weapons.Select(x => x.Name).ToList()
                })
                .OrderByDescending(ork => ork.NumberOfKills)
                .ToList();

            return orkDtos;
        }

        public async Task<GetOrkDto> CreateOrkAsync(CreateOrkDto createOrkDto)
        {
            List<Weapon> weapons = createOrkDto.Weapons.Select(w => new Weapon
            {
                Name = w
            })
            .ToList();

            Ork ork = new Ork
            {
                Name = createOrkDto.Name,
                Type = createOrkDto.Type,
                NumberOfKills = createOrkDto.NumberOfKills,
                Weapons = weapons
            };

            await _orkRepository.SaveOrkAsync(ork);

            GetOrkDto resultOrk = new GetOrkDto
            {
                Id = ork.Id,
                Name = ork.Name,
                Type = ork.Type,
                NumberOfKills = ork.NumberOfKills,
                Weapons = ork.Weapons.Select(x => x.Name).ToList()
            };

            return resultOrk;
        }

        public async Task DeleteOrkByIdAsync(int id)
        {
            Ork? ork = await _orkRepository.GetOrkByIdAsync(id);

            if (ork is null)
            {
                throw new OrkNotFoundException($"There is no ork with this id: {id}.");
            }
            await _orkRepository.DeleteOrkAsync(ork);
        }
    }
}
