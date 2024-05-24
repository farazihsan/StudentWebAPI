using StudentProject.Application.DTOs;

namespace StudentProject.Application.Contract
{
    public interface ILectureService
    {
        Task<LectureDto> AddAsync(LectureForCreationDto LectureForCreationDto, CancellationToken cancellationToken = default);

        Task<IEnumerable<LectureDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<LectureDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}
