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
    public class LectureTheatreService : ILectureTheatreService
    {
        private readonly IRepository _repositoryManager;

        public LectureTheatreService(IRepository repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<LectureTheatreDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var LectureTheatres = await _repositoryManager.LectureTheatreRepository.ListAsync(cancellationToken);

            return LectureTheatres.Adapt<IEnumerable<LectureTheatreDto>>();
        }

        public async Task<LectureTheatreDto> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var LectureTheatres = await _repositoryManager.LectureTheatreRepository.GetByIdAsync(id, cancellationToken);

            return LectureTheatres.Adapt<LectureTheatreDto>();
        }

        public async Task<LectureTheatreDto> AddAsync(LectureTheatreForCreationDto LectureTheatreForCreationDto, CancellationToken cancellationToken = default)
        {
            var LectureTheatres = LectureTheatreForCreationDto.Adapt<LectureTheatre>();

            _repositoryManager.LectureTheatreRepository.Add(LectureTheatres);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return LectureTheatres.Adapt<LectureTheatreDto>();
        }
    }
}
