using StudentProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Application.Contract
{
    public interface ISubjectService
    {
        Task<SubjectDto> AddAsync(SubjectForCreationDto SubjectForCreationDto, CancellationToken cancellationToken = default);

        Task<IEnumerable<SubjectDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<SubjectDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<SubjectDto>> RetrieveAsync(int studentId, CancellationToken cancellationToken = default);

        Task EnrollAsync(EnrollStudentDto enrollStudentDto, CancellationToken cancellationToken = default);
    }
}
