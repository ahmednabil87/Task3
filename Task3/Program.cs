


namespace Task3
{
    class Student(int studentId, string name, int age, List<Course> courses)
    {
        public int studentId = studentId;
        public string studentName = name;
        public int studentage = age;
        public List<Course> courses = courses;
        public  List<Student> students = new List<Student>();

        public bool Enroll(Course course)
        {
            bool isFounded = false;
            foreach (var item in courses)
            {
                if (item == course)
                {
                    isFounded = true;
                }
            }
            return isFounded;
        }
        public List<Student> printDetails() => students;
    }
    class Course(int courseId, string Title)
    {
        public int courseId = courseId;
        public string courseTitle = Title;
        public List<Course> courses = new List<Course>();
        public List<Course> printDetails() => courses;
    }
    
    class Instructor(int InstructorId, string Name, string Specialization)
    {
        public int instructorId = InstructorId;
        public string instructorName = Name;
        public string instructorSpecialization = Specialization;
        public List<Instructor> instructors = new List<Instructor>();
        public List<Instructor> printDetails() => instructors;
    }
  
    class StudentManager
    {
       public List<Student> students = [];
       public List<Course> courses = [];
       public List<Instructor> instructors = [];


       public bool AddStudent(Student student)
        { 
         foreach(var item in students) 
            {
                if(item.studentId == student.studentId)
                {
                    return false;
                }
            }
            students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            foreach (var item in courses)
            {
                if (item.courseId == course.courseId)
                {
                    return false;
                }
            }
            courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            foreach (var item in instructors)
            {
                if (item.instructorId == instructor.instructorId)
                {
                    return false;
                }
            }
            instructors.Add(instructor);
            return true;
        }
        public Student Isfounded(int studentId)
        {

            foreach (var item in students)
            {
                if ((item.studentId == studentId))
                {
                 return item;
                }
            }
            return new Student(0,null,0,null);
        }
        public Course IsFounded(int CourseId)
        {

            foreach (var item in courses)
            {
                if ((item.courseId == CourseId))
                {
                    return item;
                }
            }
            return new Course(0, null);
        }
        public Instructor isfounded(int InstructorId)
        {

            foreach (var item in instructors)
            {
                if ((item.instructorId == InstructorId))
                {
                    return item;
                }
            }
            return new Instructor(0, null, null);
        }
       public bool EnrollStudentInCourse(int StudentId, int CourseId)
        {
            Student student = Isfounded(StudentId);
            
            Course course = IsFounded(CourseId);

            if (student == null || course == null) 
            {
                return false;
            }
            student.courses.Add(course);
            return true;
        }
           
        
    }

        internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            do
            {
                string Menu = "                              1.Add Student" + "\n"
                             + "                              2.Add Instructor" + "\n"
                             + "                              3.Add Course" + "\n"
                             + "                              4.Enroll Student in Course " + "\n"
                             + "                              5.Show All Students " + "\n"
                             + "                              6.Show All Courses" + "\n"
                             + "                              7.Show All Instructors" + "\n"
                             + "                              8.Find the student by id" + "\n"
                             + "                              9.Find the course by id" + "\n"
                             + "                              10.Exit" + "\n"
                             + "                             =========================================";

                Console.WriteLine(Menu);
                Console.WriteLine("Choose your action: ");
                int action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Student ID");
                            int StudentId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Student Name");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Enter Student Age");
                            int age = Convert.ToInt32(Console.ReadLine());
                            List<Course> Courses = new List<Course>();
                            studentManager.students.Add(new Student(StudentId, Name, age, Courses));
                            Console.WriteLine("Added Student Succesfully");

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Enter Instructor ID");
                            int InstructorId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Instructor Name");
                            string Name = Console.ReadLine();
                            Console.WriteLine("Enter Instructor Specialization");
                            string Specialization = Console.ReadLine();
                            studentManager.instructors.Add(new Instructor(InstructorId, Name, Specialization));
                            Console.WriteLine("Added Instructor Succesfully");
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Enter Course ID");
                            int CourseId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Course Title");
                            string Title = Console.ReadLine();
                            studentManager.courses.Add(new Course(CourseId, Title));
                            Console.WriteLine("Added Course Succesfully");
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("Enter Student ID");
                            int StudentId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Course ID");
                            int CourseId = Convert.ToInt32(Console.ReadLine());
                            var students = studentManager.students;
                            Student student;
                            foreach (var item in studentManager.students)
                            {
                                if (item.studentId == StudentId)
                                {
                                    student = item;
                                    Course course;
                                    foreach (var c in studentManager.courses)
                                    {
                                        if (c.courseId == CourseId)
                                        {
                                            course = c;
                                            student.courses.Add(course);
                                        }
                                        Console.WriteLine("Student Enrolled in the Course Succesfully");
                                    }
                                }
                            }
                        }
                        break;
                    case 5:
                        {
                            foreach (var item in studentManager.students)
                            {
                                Console.WriteLine($"Student ID: {item.studentId}");
                                Console.WriteLine($"Student Name:  {item.studentName}");
                                Console.WriteLine($"Student Age: {item.studentage}");
                                Console.WriteLine("==============");
                            }
                        }
                        break;
                    case 6:
                        {
                            foreach (var item in studentManager.courses)
                            {
                                Console.WriteLine($"Course ID: {item.courseId}");
                                Console.WriteLine($"Course Name:  {item.courseTitle}");
                                Console.WriteLine("==============");
                            }
                        }
                        break;
                    case 7:
                        {
                            foreach (var item in studentManager.instructors)
                            {
                                Console.WriteLine($"instructor ID: {item.instructorId}");
                                Console.WriteLine($"instructor Name:  {item.instructorName}");
                                Console.WriteLine($"instructor Specialization:  {item.instructorSpecialization}");
                                Console.WriteLine("==============");
                            }
                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("Enter Student Id: ");
                            int studentId = Convert.ToInt32(Console.ReadLine());
                            foreach (var item in studentManager.students)
                            {
                                if (item.studentId == studentId)
                                {
                                    Console.WriteLine($"Student ID: {item.studentId}");
                                    Console.WriteLine($"Student Name:  {item.studentName}");
                                    Console.WriteLine($"Student Age: {item.studentage}");
                                }
                            }
                        }
                        break;
                    case 9:
                        {
                            Console.WriteLine("Enter Course Id: ");
                            int CourseId = Convert.ToInt32(Console.ReadLine());
                            foreach (var item in studentManager.courses)
                            {
                                if (item.courseId == CourseId)
                                {
                                    Console.WriteLine($"Student ID: {item.courseId}");
                                    Console.WriteLine($"Student Name:  {item.courseTitle}");
                                }
                            }
                        }
                        break;
                    case 10:
                            Console.WriteLine("Exit");
                            return;
                        
                }
            } while (true);   
        }
    }
}
