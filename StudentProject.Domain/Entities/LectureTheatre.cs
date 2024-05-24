﻿
using StudentProject.Domain.Common;

namespace StudentProject.Domain.Entities
{
    public class LectureTheatre : BaseEntity
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public List<Lecture> Lectures { get; set; } = new List<Lecture>();

        public bool CapacityExceeds() => Lectures.Count > Capacity;
    }
}
