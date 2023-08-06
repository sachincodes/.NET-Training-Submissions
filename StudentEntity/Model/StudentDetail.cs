﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntity.Model
{
    public class StudentDetail
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string? StudentName { get; set; }
        public int Age { get; set; }
        public string? City { get; set; }
        public List<CourseModel>? Course { get; set; }
    }
}
