using static BounsTask.Program;

namespace BounsTask
{
    internal class Program
    {
        public class Instructor
        {
            public int InstructorId { get; set; }
            public string Name { get; set; }
            public string Specialization { get; set; }

            public string PrintDetails()
            {
                return $"Instructor ID: {InstructorId}, Instructor Name: {Name}, Instructor Specialization: {Specialization}";
            }
        }
        public class Course
        {
            public int CourseId { get; set; }
            public string Title { get; set; }
            public Instructor Instructor { get; set; }

            public string PrintDetails()
            {
                if (Instructor == null)
                {
                    return $"Course ID: {CourseId}, Course Title: {Title}, Instructor: [No instructor]";
                }
                else
                {
                    return $"Course ID: {CourseId}, Course Title: {Title}, Instructor: [{Instructor.PrintDetails()}]";

                }
            }
        }
        public class Student
        {
            public int StudentId { get; set; }
            public string StudentName { get; set; }
            public int StudentAge { get; set; }
            public List<Course> Courses { get; set; }
            public Student()
            {
                Courses = new List<Course>();
            }
            public bool Enroll(Course course)
            {
                if (Courses.Contains(course))
                {
                    return false;
                }
                Courses.Add(course);
                return true;
            }
            public string PrintDetails()
            {
                string result = $"Student ID: {StudentId}, Name: {StudentName}, Age: {StudentAge}";

                if (Courses.Count == 0)
                {
                    result += "\n   No courses enrolled.";
                }
                else
                {
                    result += "\n   Courses:";
                    for (int i = 0; i < Courses.Count; i++)
                    {
                        result += "\n   - " + Courses[i].Title;
                    }
                }
                return result;
            }
        }
        public class StudentManager
        {
            public List<Student> Students;
            public List<Course> Courses;
            public List<Instructor> Instructors;
            public StudentManager()
            {
                Students = new List<Student>();
                Courses = new List<Course>();
                Instructors = new List<Instructor>();
            }
            public bool AddStudent(Student student)
            {
                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].StudentId == student.StudentId)
                        return false;
                }
                Students.Add(student);
                return true;
            }
            public bool AddInstructor(Instructor instructor)
            {
                for (int i = 0; i < Instructors.Count; i++)
                {
                    if (Instructors[i].InstructorId == instructor.InstructorId)
                        return false;
                }
                Instructors.Add(instructor);
                return true;
            }
            public bool AddCourse(Course course)
            {
                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].CourseId == course.CourseId)
                        return false;
                }
                Courses.Add(course);
                return true;
            }
            public Student? FindStudent(string input)
            {
                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].StudentId.ToString() == input || Students[i].StudentName.ToLower() == input.ToLower())
                        return Students[i];
                }
                return null;
            }
            public Course? FindCourse(string input)
            {
                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].CourseId.ToString() == input || Courses[i].Title.ToLower() == input.ToLower())
                        return Courses[i];
                }
                return null;
            }
            public Instructor? FindInstructor(int id)
            {
                for (int i = 0; i < Instructors.Count; i++)
                {
                    if (Instructors[i].InstructorId == id)
                    {
                        return Instructors[i];
                    }
                }
                return null;
            }
            public bool EnrollStudentInCourse(string studentInput, string courseInput)
            {
                Student? student = FindStudent(studentInput);
                Course? course = FindCourse(courseInput);
                if (student == null || course == null)
                    return false;

                return student.Enroll(course);
            }
            public void ShowAllStudents()
            {
                if (Students.Count == 0)
                {
                    Console.WriteLine("No students found.");
                    return;
                }
                for (int i = 0; i < Students.Count; i++)
                    Console.WriteLine(Students[i].PrintDetails());
            }
            public void ShowAllCourses()
            {
                if (Courses.Count == 0)
                {
                    Console.WriteLine("No courses found.");
                    return;
                }
                for (int i = 0; i < Courses.Count; i++)
                    Console.WriteLine(Courses[i].PrintDetails());
            }
            public void ShowAllInstructors()
            {
                if (Instructors.Count == 0)
                {
                    Console.WriteLine("No instructors found.");
                    return;
                }
                for (int i = 0; i < Instructors.Count; i++)
                    Console.WriteLine(Instructors[i].PrintDetails());
            }
            public bool IsStudentEnrolledInCourse(string studentInput, string courseTitle)
            {
                Student student = FindStudent(studentInput);

                if (student != null)
                {
                    for (int i = 0; i < student.Courses.Count; i++)
                    {
                        if (student.Courses[i].Title.ToLower() == courseTitle.ToLower())
                            return true;
                    }
                }
                return false;
            }
            public string GetInstructorByCourse(string courseTitle)
            {
                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].Title.ToLower() == courseTitle.ToLower())
                    {
                        if (Courses[i].Instructor != null)
                            return Courses[i].Instructor.Name;
                        else
                            return "No instructor assigned";
                    }
                }
                return "Course not found";
            }

        }
        static void Main(string[] args)
        {
            StudentManager school = new StudentManager();
            string choice;
            do
            {
                Console.WriteLine("===== Student Management System =====");
                Console.WriteLine("01. Add Student");
                Console.WriteLine("02. Add Instructor");
                Console.WriteLine("03. Add Course");
                Console.WriteLine("04. Enroll Student in Course");
                Console.WriteLine("05. Show All Students");
                Console.WriteLine("06. Show All Courses");
                Console.WriteLine("07. Show All Instructors");
                Console.WriteLine("08. Find Student by ID or Name");
                Console.WriteLine("09. Find Course by ID or Title");
                Console.WriteLine("10. Exit");
                Console.WriteLine("11. Check if Student enrolled in a Course");
                Console.WriteLine("12. Get Instructor by Course Name");
                Console.Write("Choose an option: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Student student = new Student();
                        Console.Write("Enter Student ID: ");
                        student.StudentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        student.StudentName = Console.ReadLine();
                        Console.Write("Enter Age: ");
                        student.StudentAge = int.Parse(Console.ReadLine());
                        if (school.AddStudent(student))
                            Console.WriteLine("Student added successfully.");
                        else
                            Console.WriteLine("Student with this ID already exists.");
                        break;
                    case "2":
                        Instructor instructor = new Instructor();
                        Console.Write("Enter Instructor ID: ");
                        instructor.InstructorId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Name: ");
                        instructor.Name = Console.ReadLine();
                        Console.Write("Enter Specialization: ");
                        instructor.Specialization = Console.ReadLine();
                        if (school.AddInstructor(instructor))
                            Console.WriteLine("Instructor added successfully.");
                        else
                            Console.WriteLine("Instructor with this ID already exists.");
                        break;
                    case "3":
                        Course course = new Course();
                        Console.Write("Enter Course ID: ");
                        course.CourseId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Title: ");
                        course.Title = Console.ReadLine();
                        Console.Write("Enter Instructor ID: ");
                        int instructorId = int.Parse(Console.ReadLine());
                        course.Instructor = school.FindInstructor(instructorId);
                        if (school.AddCourse(course))
                            Console.WriteLine("Course added successfully.");
                        else
                            Console.WriteLine("Course with this ID already exists.");
                        break;
                    case "4":
                        Console.Write("Enter Student ID: ");
                        string studentId = Console.ReadLine();
                        Console.Write("Enter Course ID: ");
                        string courseId = Console.ReadLine();
                        if (school.EnrollStudentInCourse(studentId, courseId))
                            Console.WriteLine("Student enrolled successfully.");
                        else
                            Console.WriteLine("Enrollment failed. Check if Student and Course exist or if already enrolled.");
                        break;
                    case "5":
                        school.ShowAllStudents();
                        break;
                    case "6":
                        school.ShowAllCourses();
                        break;
                    case "7":
                        school.ShowAllInstructors();
                        break;
                    case "8":
                        Console.Write("Enter Student ID or Name: ");
                        string studentInput = Console.ReadLine();

                        Student foundStudent = school.FindStudent(studentInput);

                        if (foundStudent != null)
                            Console.WriteLine(foundStudent.PrintDetails());
                        else
                            Console.WriteLine("Student not found.");
                        break;
                    case "9":
                        Console.Write("Enter Course ID or Name: ");
                        string courseInput = Console.ReadLine();

                        Course foundCourse = school.FindCourse(courseInput);

                        if (foundCourse != null)
                            Console.WriteLine(foundCourse.PrintDetails());
                        else
                            Console.WriteLine("Course not found.");
                        break;
                    case "11":
                        Console.Write("Enter Student ID or Name: ");
                        string stInput = Console.ReadLine();
                        Console.Write("Enter Course Title: ");
                        string crsTitle = Console.ReadLine();
                        if (school.IsStudentEnrolledInCourse(stInput, crsTitle))
                            Console.WriteLine("The student is enrolled in the course.");
                        else
                            Console.WriteLine("The student is not enrolled in the course.");
                        break;
                    case "12":
                        Console.Write("Course Title: ");
                        Console.WriteLine(school.GetInstructorByCourse(Console.ReadLine()));
                        break;
                    case "10":
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }
                Console.WriteLine("========================================\n");
            }
            while (choice != "10");
        }
    }
}
