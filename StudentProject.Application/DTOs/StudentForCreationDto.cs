﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentProject.Application.DTOs
{
    public class StudentForCreationDto
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
    }
}
