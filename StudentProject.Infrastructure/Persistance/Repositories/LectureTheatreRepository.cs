using Microsoft.EntityFrameworkCore;
using StudentProject.Domain.Entities;
using StudentProject.Domain.Repositories;

namespace StudentProject.Infrastructure.Persistance.Repositories
{
    internal sealed class LectureTheatreRepository : ILectureTheatreRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LectureTheatreRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void Add(LectureTheatre LectureTheatre) => _dbContext.LectureTheatres.Add(LectureTheatre);

        public void Delete(LectureTheatre LectureTheatre) => _dbContext.LectureTheatres.Remove(LectureTheatre);

        public async Task<IEnumerable<LectureTheatre>> ListAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.LectureTheatres.Include(m => m.Lectures).ToListAsync(cancellationToken);

        public async Task<LectureTheatre> GetByIdAsync(int Id, CancellationToken cancellationToken = default) =>
            await _dbContext.LectureTheatres.Include(m => m.Lectures).FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
    }
}
