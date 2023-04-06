using Mordor_Backend.Models.Dto;

namespace Mordor_Backend.Service
{
    public interface IMordorService
    {
        Task<GetOrkDto> CreateOrkAsync(CreateOrkDto createOrkDto);
        Task DeleteOrkByIdAsync(int id);
        Task<IEnumerable<GetOrkDto>> GetAllOrksAsync();
    }
}