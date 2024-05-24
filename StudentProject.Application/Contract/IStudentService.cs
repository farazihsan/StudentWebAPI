using StudentProject.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Application.Contract
{
    public interface IStudentService
    {
        Task<StudentDto> AddAsync(StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken = default);

        Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<StudentDto> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<IEnumerable<StudentDto>> RetrieveAsync(int subjectId, CancellationToken cancellationToken = default);
    }
}
