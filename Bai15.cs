namespace ManageStudent
{
    using CustomException;
    public class LessonResult
    {
        public string Semester {get; set;}
        public float MediumScore {get; set;}
        public LessonResult(string semester, float mediumScore) {
            Semester = semester;
            MediumScore = mediumScore;
        }
    }
    public class Student : IComparable
    {
        public string ID {get; set;}
        public string FullName {get; set;}
        public DateTime Birthday {get; set;}
        public int Year {get; set;}
        public float EntryPoint {get; set;}
        public List<LessonResult> LessonResults {get; set;}
        public Student(string id, string fullName, DateTime birthday, int year, float entryPoint)
        {
            ID = id;
            FullName = fullName;
            Birthday = birthday;
            Year = year;
            EntryPoint = entryPoint;
            LessonResults = new List<LessonResult>();
        }

        public bool IsRegularStudent()
        {
            return this is RegularStudent;
        }

        public int CompareTo(object? obj)
        {
            if (IsRegularStudent() && !((Student)obj).IsRegularStudent())
            {
                return 1;
            }
            if (!IsRegularStudent() && ((Student)obj).IsRegularStudent())
            {
                return -1;
            }
            else {
                return Year - ((Student)obj).Year;
            }
        }
    }
    public class RegularStudent : Student
    {
        public RegularStudent(string id, string fullName, DateTime birthday, int year, float entryPoint) : base(id, fullName, birthday, year, entryPoint)
        {
        }
    }
    public class InServiceStudent : Student
    {
        public string TrainingLink { get; set;}
        public InServiceStudent(string id, string fullName, DateTime birthday, int year, float entryPoint, string trainingLink) : base(id, fullName, birthday, year, entryPoint)
        {
            TrainingLink = trainingLink;
        }
    }
    public class Falcuty
    {
        public string Name {get; set;}
        public List<Student> Students {get; set;}
        public Falcuty(string name)
        {
            Name = name;
            Students = new List<Student>();
        }
    }
    public class StudentManager
    {
        private static List<Falcuty> falcuties;
        static StudentManager()
        {
            falcuties = new List<Falcuty>();
        }
        public bool IsValidFalcuty(string name)
        {
            return !falcuties.Any(f => f.Name == name);
        }
        public bool IsValidStudentID(string id)
        {
            return falcuties.Any(f => f.Students.Any(s => s.ID == id));
        }
        public Falcuty GetFalcutyByName(string name)
        {
            return falcuties.FirstOrDefault(f => f.Name == name);
        }
        public bool AddStudent(Student student, String falcuty)
        {
            if (student == null && IsValidStudentID(student.ID))
            {
                GetFalcutyByName(falcuty).Students.Add(student);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddFalcuty(Falcuty falcuty)
        {
            if (falcuty == null && IsValidFalcuty(falcuty.Name))
            {
                falcuties.Add(falcuty);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetNumberOfRegularStudents(Falcuty falcuty)
        {
            return falcuty.Students.Count(s => s.IsRegularStudent());
        }
        public Student GetValedictorian(Falcuty falcuty)
        {
            if (falcuty.Students.Count == 0)
                return null;
            Student valedictorian = falcuty.Students[0];
            foreach (Student student in falcuty.Students)
            {
                if (student.EntryPoint > valedictorian.EntryPoint) 
                {
                    valedictorian = student;
                }
            }
            return valedictorian;
        }
        public List<Student> GetInServiceStudentList(Falcuty falcuty, string trainingLink)
        {
            return falcuty.Students.Where(s => !s.IsRegularStudent() && ((InServiceStudent) s).TrainingLink == trainingLink).ToList();
        }
        public List<Student> GetListGoodStudentList(Falcuty falcuty, float floorPoint)
        {
            return falcuty.Students.Where(s => s.LessonResults.Count > 0 && s.LessonResults[0].MediumScore > floorPoint).ToList();
        }
        public Student GetHighestScoreStudent(Falcuty falcuty)
        {
            if (falcuty.Students.Count == 0)
            {
                return null;
            }
            Student highestScoreStudent = falcuty.Students.FirstOrDefault(s => s.LessonResults.Count > 0);
            float highestScore = highestScoreStudent.LessonResults.Max(s => s.MediumScore);
            foreach (Student student in falcuty.Students)
            {
                if (student.LessonResults.Count > 0 && student.LessonResults.Max(s => s.MediumScore) > highestScore)
                {
                    highestScoreStudent = student;
                    highestScore = student.LessonResults.Max(s => s.MediumScore);
                }
            }
            return highestScoreStudent;
        }
        public List<Student> SortedStudents(Falcuty falcuty)
        {
            return falcuty.Students.OrderByDescending(s => s).ToList();
        }
        public int GetNumberOfStudentsInYear(int year)
        {
            return falcuties.Sum(f => f.Students.Count(s => s.Year == year));
        }
    }
    public interface IStudentForm
    {
        void AddStudent();
    }
    public class RegularStudentForm : IStudentForm
    {
        private StudentManager studentManager;
        public RegularStudentForm()
        {
            studentManager = new StudentManager();
        }
        public void AddStudent()
        {
            Console.WriteLine("Add new regular student:");
            Console.Write("Enter falcuty name: ");
            string falcutyName = Console.ReadLine();
            if (!studentManager.IsValidFalcuty(falcutyName))
            {
                Console.WriteLine("Invalid falcuty name!");
                return;
            }
            Console.Write("Enter student ID: ");
            string studentID = Console.ReadLine() ?? string.Empty;
            if (!studentManager.IsValidStudentID(studentID))
            {
                Console.WriteLine("Invalid student ID!");
                return;
            }
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter birthday: ");
            DateTime birthday;
            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Invalid birthday!");
                Console.Write("Enter birthday: ");
            }
            Console.Write("Enter year: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid year!");
                Console.Write("Enter year: ");
            }
            Console.Write("Enter entry point: ");
            float entryPoint;
            while (!float.TryParse(Console.ReadLine(), out entryPoint))
            {
                Console.WriteLine("Invalid entry point!");
                Console.Write("Enter entry point: ");
            }
            Console.Write("Enter number of semesters: ");
            int numberOfSemesters;
            while (!int.TryParse(Console.ReadLine(), out numberOfSemesters))
            {
                Console.WriteLine("Invalid number of semesters!");
                Console.Write("Enter number of semesters: ");
            }
            List<LessonResult> lessonResults = new();
            for (int i = 0; i < numberOfSemesters; i++)
            {
                Console.Write("Enter semester: ");
                string semester = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter medium score: ");
                float mediumScore;
                while (!float.TryParse(Console.ReadLine(), out mediumScore))
                {
                    Console.WriteLine("Invalid medium score!");
                    Console.Write("Enter medium score: ");
                }
                lessonResults.Add(new LessonResult(semester, mediumScore));
            }
            Student student = new RegularStudent(studentID, fullName, birthday, year, entryPoint)
            {
                LessonResults = lessonResults
            };
            bool res = studentManager.AddStudent(student, falcutyName);
            if (res == true)
            {
                Console.WriteLine("Student added!");
            }
            else
            {
                Console.WriteLine("Student not added!");
            }
        }
    }
    public class InServiceStudentForm : IStudentForm
    {
        private StudentManager studentManager;
        public InServiceStudentForm()
        {
            studentManager = new StudentManager();
        }
        public void AddStudent()
        {
            Console.WriteLine("Add new regular student:");
            Console.Write("Enter falcuty name: ");
            string falcutyName = Console.ReadLine();
            if (!studentManager.IsValidFalcuty(falcutyName))
            {
                Console.WriteLine("Invalid falcuty name!");
                return;
            }
            Console.Write("Enter student ID: ");
            string studentID = Console.ReadLine() ?? string.Empty;
            if (!studentManager.IsValidStudentID(studentID))
            {
                Console.WriteLine("Invalid student ID!");
                return;
            }
            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter birthday: ");
            DateTime birthday;
            while (!DateTime.TryParse(Console.ReadLine(), out birthday))
            {
                Console.WriteLine("Invalid birthday!");
                Console.Write("Enter birthday: ");
            }
            Console.Write("Enter year: ");
            int year;
            while (!int.TryParse(Console.ReadLine(), out year))
            {
                Console.WriteLine("Invalid year!");
                Console.Write("Enter year: ");
            }
            Console.Write("Enter entry point: ");
            float entryPoint;
            while (!float.TryParse(Console.ReadLine(), out entryPoint))
            {
                Console.WriteLine("Invalid entry point!");
                Console.Write("Enter entry point: ");
            }
            Console.Write("Enter training link: ");
            string trainingLink = Console.ReadLine()?? string.Empty;
            Console.Write("Enter number of semesters: ");
            int numberOfSemesters;
            while (!int.TryParse(Console.ReadLine(), out numberOfSemesters))
            {
                Console.WriteLine("Invalid number of semesters!");
                Console.Write("Enter number of semesters: ");
            }
            List<LessonResult> lessonResults = new();
            for (int i = 0; i < numberOfSemesters; i++)
            {
                Console.Write("Enter semester: ");
                string semester = Console.ReadLine() ?? string.Empty;
                Console.Write("Enter medium score: ");
                float mediumScore;
                while (!float.TryParse(Console.ReadLine(), out mediumScore))
                {
                    Console.WriteLine("Invalid medium score!");
                    Console.Write("Enter medium score: ");
                }
                lessonResults.Add(new LessonResult(semester, mediumScore));
            }
            Student student = new InServiceStudent(studentID, fullName, birthday, year, entryPoint, trainingLink)
            {
                LessonResults = lessonResults
            };
            bool res = studentManager.AddStudent(student, falcutyName);
            if (res == true)
            {
                Console.WriteLine("Student added!");
            }
            else
            {
                Console.WriteLine("Student not added!");
            }
        }
    }
}

namespace CustomException
{
    public class BirthDayException : Exception
    {
        public BirthDayException(string msg)
            : base(String.Format("Invalid birthday: {0}", msg))
        {
            
        }
    }

    public class PhoneException : Exception
    {
        public PhoneException(string msg)
            : base(String.Format("Invalid phone number: {0}", msg))
        {
            
        }
    }

    public class EmailException : Exception
    {
        public EmailException(string msg)
            : base(String.Format("Invalid email: {0}", msg))
        {
            
        }
    }

    public class FullNameException : Exception
    {
        public FullNameException()
            : base(String.Format("Invalid full name"))
        {
            
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Ví dụ sử dụng chương trình
        // Số lượng nhân viên
        // Console.WriteLine($"Số lượng nhân viên: {Employee.EmployeeCount}");
    }
}

