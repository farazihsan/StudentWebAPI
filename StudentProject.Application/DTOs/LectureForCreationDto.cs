using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Application.DTOs
{
    public class LectureForCreationDto
    {
        public int Id { get; set; }
        public required WeeklyScheduleDto WeeklySchedule { get; set; }
        public int SubjectId { get; set; }
        public int LectureTheatreId { get; set; }
    }
}
