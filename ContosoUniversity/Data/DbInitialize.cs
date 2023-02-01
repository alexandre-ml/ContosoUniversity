using ContosoUniversity.Models;
using System.Diagnostics;

namespace ContosoUniversity.Data
{
    public static class DbInitialize 
    {
        public static void Initializer(SchoolContext context)
        {
            // verifica se existem estudantes cadastrados
            if (context.Students.Any())
                return; //banco ja foi criado

            AddStudents(context);

            AddCourses(context);

            AddEnrollment(context);
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
