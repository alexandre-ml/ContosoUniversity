using ContosoUniversity.Models;
using System.Diagnostics;

namespace ContosoUniversity.Data
{
    public static class DbInitialize
    {
        public static void InitializerV0(SchoolContext context)
        {
            // verifica se existem estudantes cadastrados
            if (context.Students.Any())
                return; //banco ja foi criado

            //criar estudantes para popular o banco
            var students = new Student[]
            {
                    new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                    new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                    new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            //adicionar estudantes ao contexto
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }

            //salvar no banco de dados
            context.SaveChanges();

            //criar cursos para popular o banco
            var courses = new Course[]
            {
                    new Course{Title="Chemistry",Credits=3},
                    new Course{Title="Microeconomics",Credits=3},
                    new Course{Title="Macroeconomics",Credits=3},
                    new Course{Title="Calculus",Credits=4},
                    new Course{Title="Trigonometry",Credits=4},
                    new Course{Title="Composition",Credits=3},
                    new Course{Title="Literature",Credits=4}
            };

            //adicionar cursos ao contexto
            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }

            //salvar no banco de dados
            context.SaveChanges();

            //criar estudantes para popular o banco
            var enrollments = new Enrollment[]
            {
                    new Enrollment{StudentID=students[0].ID,CourseID=courses[0].CourseID,Grid=Grid.A},
                    new Enrollment{StudentID=students[0].ID,CourseID=courses[1].CourseID,Grid=Grid.C},
                    new Enrollment{StudentID=students[0].ID,CourseID=courses[2].CourseID,Grid=Grid.B},
                    new Enrollment{StudentID=students[1].ID,CourseID=courses[3].CourseID,Grid=Grid.B},
                    new Enrollment{StudentID=students[1].ID,CourseID=courses[4].CourseID,Grid=Grid.F},
                    new Enrollment{StudentID=students[1].ID,CourseID=courses[5].CourseID,Grid=Grid.F},
                    new Enrollment{StudentID=students[2].ID,CourseID=courses[0].CourseID},
                    new Enrollment{StudentID=students[3].ID,CourseID=courses[0].CourseID},
                    new Enrollment{StudentID=students[3].ID,CourseID=courses[1].CourseID,Grid=Grid.F},
                    new Enrollment{StudentID=students[4].ID,CourseID=courses[2].CourseID,Grid=Grid.C},
                    new Enrollment{StudentID=students[5].ID,CourseID=courses[3].CourseID},
                    new Enrollment{StudentID=students[6].ID,CourseID=courses[4].CourseID,Grid=Grid.A},
            };

            //adicionar estudantes ao contexto
            foreach (Enrollment enrollment in enrollments)
            {
                context.Enrollments.Add(enrollment);
            }

            //salvar no banco de dados
            context.SaveChanges();
        }

        public static void InitializerV1(SchoolContext context)
        {
            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                    new Student { FirstMidName = "Carson",   LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2010-09-01") },
                    new Student { FirstMidName = "Meredith", LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Arturo",   LastName = "Anand",
                        EnrollmentDate = DateTime.Parse("2013-09-01") },
                    new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Yan",      LastName = "Li",
                        EnrollmentDate = DateTime.Parse("2012-09-01") },
                    new Student { FirstMidName = "Peggy",    LastName = "Justice",
                        EnrollmentDate = DateTime.Parse("2011-09-01") },
                    new Student { FirstMidName = "Laura",    LastName = "Norman",
                        EnrollmentDate = DateTime.Parse("2013-09-01") },
                    new Student { FirstMidName = "Nino",     LastName = "Olivetto",
                        EnrollmentDate = DateTime.Parse("2005-09-01") }
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                    new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
                        HireDate = DateTime.Parse("1995-03-11") },
                    new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
                        HireDate = DateTime.Parse("2002-07-06") },
                    new Instructor { FirstMidName = "Roger",   LastName = "Harui",
                        HireDate = DateTime.Parse("1998-07-01") },
                    new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
                        HireDate = DateTime.Parse("2001-01-15") },
                    new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
                        HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                    new Department { Name = "English",     Budget = 350000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = instructors.Single( i => i.LastName == "Abercrombie").ID },
                    new Department { Name = "Mathematics", Budget = 100000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = instructors.Single( i => i.LastName == "Fakhouri").ID },
                    new Department { Name = "Engineering", Budget = 350000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = instructors.Single( i => i.LastName == "Harui").ID },
                    new Department { Name = "Economics",   Budget = 100000,
                        StartDate = DateTime.Parse("2007-09-01"),
                        InstructorID  = instructors.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                    new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                        DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                    },
                    new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                        DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                    },
                    new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                        DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                    },
                    new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                        DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                    },
                    new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                        DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                    },
                    new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                        DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                    },
                    new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                        DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                    },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssignments = new OfficeAssignment[]
            {
                    new OfficeAssignment {
                        InstructorID = instructors.Single( i => i.LastName == "Fakhouri").ID,
                        Location = "Smith 17" },
                    new OfficeAssignment {
                        InstructorID = instructors.Single( i => i.LastName == "Harui").ID,
                        Location = "Gowan 27" },
                    new OfficeAssignment {
                        InstructorID = instructors.Single( i => i.LastName == "Kapoor").ID,
                        Location = "Thompson 304" },
            };

            foreach (OfficeAssignment o in officeAssignments)
            {
                context.OfficeAssignments.Add(o);
            }
            context.SaveChanges();

            var courseInstructors = new CourseAssignment[]
            {
                    new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Kapoor").ID
                        },
                    new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                        },
                    new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                        },
                    new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Zheng").ID
                        },
                    new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Fakhouri").ID
                        },
                    new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Harui").ID
                        },
                    new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                        },
                    new CourseAssignment {
                        CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                        InstructorID = instructors.Single(i => i.LastName == "Abercrombie").ID
                        },
            };

            foreach (CourseAssignment ci in courseInstructors)
            {
                context.CourseAssignments.Add(ci);
            }
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        Grid = Grid.A
                    },
                        new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,
                        CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                        Grid = Grid.C
                        },
                        new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alexander").ID,
                        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                        Grid = Grid.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Alonso").ID,
                        CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                        Grid = Grid.B
                        },
                        new Enrollment {
                            StudentID = students.Single(s => s.LastName == "Alonso").ID,
                        CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                        Grid = Grid.B
                        },
                        new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Alonso").ID,
                        CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                        Grid = Grid.B
                        },
                        new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Anand").ID,
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                        },
                        new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Anand").ID,
                        CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                        Grid = Grid.B
                        },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
                        CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                        Grid = Grid.B
                        },
                        new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Li").ID,
                        CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                        Grid = Grid.B
                        },
                        new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Justice").ID,
                        CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                        Grid = Grid.B
                        }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }

        public static void AddStudents(SchoolContext c)
        {
            //criar estudantes para popular o banco
            var students = new Student[]
            {
                    new Student{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
                    new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                    new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                    new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                    new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            //adicionar estudantes ao contexto
            foreach (Student s in students)
            {
                c.Students.Add(s);
            }

            //salvar no banco de dados
            c.SaveChanges();
        }

        public static void AddCourses(SchoolContext c)
        {
            //criar cursos para popular o banco
            var courses = new Course[]
            {
                    new Course{CourseID=1050,Title="Chemistry",Credits=3},
                    new Course{CourseID=4022,Title="Microeconomics",Credits=3},
                    new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
                    new Course{CourseID=1045,Title="Calculus",Credits=4},
                    new Course{CourseID=3141,Title="Trigonometry",Credits=4},
                    new Course{CourseID=2021,Title="Composition",Credits=3},
                    new Course{CourseID=2042,Title="Literature",Credits=4}
            };

            //adicionar cursos ao contexto
            foreach (Course course in courses)
            {
                c.Courses.Add(course);
            }

            //salvar no banco de dados
            c.SaveChanges();
        }

        public static void AddEnrollment(SchoolContext c)
        {
            //criar estudantes para popular o banco
            var enrollments = new Enrollment[]
            {
                    new Enrollment{StudentID=1,CourseID=1050,Grid=Grid.A},
                    new Enrollment{StudentID=1,CourseID=4022,Grid=Grid.C},
                    new Enrollment{StudentID=1,CourseID=4041,Grid=Grid.B},
                    new Enrollment{StudentID=2,CourseID=1045,Grid=Grid.B},
                    new Enrollment{StudentID=2,CourseID=3141,Grid=Grid.F},
                    new Enrollment{StudentID=2,CourseID=2021,Grid=Grid.F},
                    new Enrollment{StudentID=3,CourseID=1050},
                    new Enrollment{StudentID=4,CourseID=1050},
                    new Enrollment{StudentID=4,CourseID=4022,Grid=Grid.F},
                    new Enrollment{StudentID=5,CourseID=4041,Grid=Grid.C},
                    new Enrollment{StudentID=6,CourseID=1045},
                    new Enrollment{StudentID=7,CourseID=3141,Grid=Grid.A},
            };

            //adicionar estudantes ao contexto
            foreach (Enrollment enrollment in enrollments)
            {
                c.Enrollments.Add(enrollment);
            }

            //salvar no banco de dados
            c.SaveChanges();
        }
    }
}
