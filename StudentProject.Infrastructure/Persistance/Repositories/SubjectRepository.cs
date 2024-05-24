using Microsoft.EntityFrameworkCore;
using StudentProject.Domain.Entities;
using StudentProject.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Infrastructure.Persistance.Repositories
{
    internal sealed class SubjectRepository : ISubjectRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SubjectRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public void Add(Subject Subject) => _dbContext.Subjects.Add(Subject);

        public void Delete(Subject Subject) => _dbContext.Subjects.Remove(Subject);

        public async Task<IEnumerable<Subject>> ListAsync(CancellationToken cancellationToken = default) =>
            await _dbContext.Subjects.Include(x => x.Lectures).ToListAsync(cancellationToken);

        public async Task<Subject> GetByIdAsync(int Id, CancellationToken cancellationToken = default) =>
            await _dbContext.Subjects.Include(x => x.Lectures).ThenInclude(m => m.LectureTheatre).ThenInclude(m => m.Lectures).FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);

        public List<Lecture> GetLecturesBySubjectId(int subjectId) =>
             _dbContext.Lectures.Where(m => m.SubjectId == subjectId).ToList();

        public async Task<IEnumerable<Subject>> GetByStudentIdAsync(int studentId, CancellationToken cancellationToken) =>
            await _dbContext.Subjects.Where(m => m.EnrolledStudents.Select(m => m.Id).Contains(studentId)).ToListAsync(cancellationToken);
    }
}
