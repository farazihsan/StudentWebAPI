﻿using Mapster;
using StudentProject.Application.Contract;
using StudentProject.Application.DTOs;
using StudentProject.Domain.Entities;
using StudentProject.Domain.Exceptions;
using StudentProject.Domain.Repositories;


namespace StudentProject.Application.Logic
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository _repositoryManager;

        public SubjectService(IRepository repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<SubjectDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var Subjects = await _repositoryManager.SubjectRepository.ListAsync(cancellationToken);

            return Subjects.Adapt<IEnumerable<SubjectDto>>();
        }

        public async Task<SubjectDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var subject = await _repositoryManager.SubjectRepository.GetByIdAsync(id, cancellationToken);

            return subject.Adapt<SubjectDto>();
        }

        public async Task<SubjectDto> AddAsync(SubjectForCreationDto SubjectForCreationDto, CancellationToken cancellationToken = default)
        {
            var Subjects = SubjectForCreationDto.Adapt<Subject>();

            _repositoryManager.SubjectRepository.Add(Subjects);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Subjects.Adapt<SubjectDto>();
        }

        public async Task EnrollAsync(EnrollStudentDto enrollStudentDto, CancellationToken cancellationToken = default)
        {
            var subject = await _repositoryManager.SubjectRepository.GetByIdAsync(enrollStudentDto.SubjectId, cancellationToken);

            if (subject == null)
            {
                throw new SubjectNotFoundException(enrollStudentDto.SubjectId);
            }

            var student = await _repositoryManager.StudentRepository.GetByIdAsync(enrollStudentDto.StudentId, cancellationToken);

            if (student == null)
            {
                throw new StudentNotFoundException(enrollStudentDto.StudentId);
            }

            if (!subject.CanEnroll(student))
            {
                throw new EnrollmentException();
            }

            student.EnrolledSubjects.Add(subject);

            _repositoryManager.StudentRepository.Update(student);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        }

        public async Task<IEnumerable<SubjectDto>> RetrieveAsync(int studentId, CancellationToken cancellationToken = default)
        {
            var subjects = await _repositoryManager.SubjectRepository.GetByStudentIdAsync(studentId, cancellationToken);

            return subjects.Adapt<IEnumerable<SubjectDto>>();
        }
    }
}
