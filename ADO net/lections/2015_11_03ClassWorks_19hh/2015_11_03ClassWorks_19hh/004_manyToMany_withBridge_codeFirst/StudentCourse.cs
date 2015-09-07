﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_manyToMany_withBridge_codeFirst
{
    public class StudentCourse
    {
        public Course Course { set; get; }
        public Student Student { set; get; }

        [Key, Column(Order = 1)]
        public int StudentId { set; get; }

        [Key, Column(Order = 2)]
        public int CourseId { set; get; }

        public DateTime StartDate { set; get; }
    }
}
