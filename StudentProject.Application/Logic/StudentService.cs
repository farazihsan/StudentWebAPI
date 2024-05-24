using Mapster;
using StudentProject.Application.Contract;
using StudentProject.Application.DTOs;
using StudentProject.Domain.Entities;
using StudentProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Application.Logic
{
    public class StudentService : IStudentService
    {
        private readonly IRepository _repositoryManager;

        public StudentService(IRepository repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<StudentDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var students = await _repositoryManager.StudentRepository.ListAsync(cancellationToken);

            return students.Adapt<IEnumerable<StudentDto>>();
        }

        public async Task<StudentDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var students = await _repositoryManager.StudentRepository.GetByIdAsync(id, cancellationToken);

            return students.Adapt<StudentDto>();
        }

        public async Task<StudentDto> AddAsync(StudentForCreationDto studentForCreationDto, CancellationToken cancellationToken = default)
        {
            var student = studentForCreationDto.Adapt<Student>();

            _repositoryManager.StudentRepository.Add(student);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return student.Adapt<StudentDto>();
        }

        public async Task<IEnumerable<StudentDto>> RetrieveAsync(int subjectId, CancellationToken cancellationToken = default)
        {
            var students = await _repositoryManager.StudentRepository.GetBySubjectIdAsync(subjectId, cancellationToken);

            return students.Adapt<IEnumerable<StudentDto>>();
        }
    }
}
