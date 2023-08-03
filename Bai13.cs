namespace Employee
{    
    using CustomException;
    using System.Text.RegularExpressions;
    public class Certificate
    {
        public string CertificatedID { get; set; }
        public string CertificateName { get; set; }
        public string CertificateRank { get; set; }
        public DateTime CertificatedDate { get; set; }

        public Certificate(string id, string name, string rank, DateTime date)
        {
            CertificatedID = id;
            CertificateName = name;
            CertificateRank = rank;
            CertificatedDate = date;
        }
    }

    public abstract class Employee
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int EmployeeType { get; }
        public List<Certificate> Certificates {get; set;}
        public static int EmployeeCount { get; set; }

        public Employee()
        {
            Certificates = new List<Certificate>();
        }

        public Employee(string id, string fullName, DateTime birthDay, string phone, string email, int employeeType, List<Certificate> certificates = null)
        {
            ID = id;
            FullName = fullName;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
            EmployeeType = employeeType;
            Certificates = certificates ?? new List<Certificate>();
        }
        public abstract string GetTypeString();
        public abstract void ShowInfo();
    }

    public class Experience : Employee
    {
        public int ExpInYear {get; set;}
        public string ProSkill {get; set;}

        public Experience(string id, string fullName, DateTime birthDay, string phone, string email, int expInYear, string proSkill, List<Certificate> certificates = null) : base(id, fullName, birthDay, phone, email, 0, certificates) {
            ExpInYear = expInYear;
            ProSkill = proSkill;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Employee info:");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Full name: {FullName}");
            Console.WriteLine($"Birthday: {BirthDay.ToShortDateString()}");
            Console.WriteLine($"Phone number: {Phone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Employee type: {GetTypeString()}");
            Console.WriteLine($"Exp in year: {ExpInYear}");
            Console.WriteLine($"Pro skill: {ProSkill}");
            Console.WriteLine("Certificates:");
            foreach (var certificate in Certificates)
            {
                Console.WriteLine($"Certificate ID: {certificate.CertificatedID}");
                Console.WriteLine($"Certificate name: {certificate.CertificateName}");
                Console.WriteLine($"Certificate rank: {certificate.CertificateRank}");
                Console.WriteLine($"Certificate date: {certificate.CertificatedDate.ToShortDateString()}");
            }
        }

        public override string GetTypeString()
        {
            return "Experience";
        }
    }

    public class Fresher : Employee
    {
        public DateTime GraduationDate {get; set;}
        public string GraduationRank {get; set;}
        public string Education {get; set;}

        public Fresher(string id, string fullName, DateTime birthDay, string phone, string email, DateTime graduationDate, string graduationRank, string education, List<Certificate> certificates = null) : base(id, fullName, birthDay, phone, email, 1, certificates) {
            GraduationDate = graduationDate;
            GraduationRank = graduationRank;
            Education = education;
        }

        public override string GetTypeString()
        {
            return "Fresher";
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Employee info:");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Full name: {FullName}");
            Console.WriteLine($"Birthday: {BirthDay.ToShortDateString()}");
            Console.WriteLine($"Phone number: {Phone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Employee type: {GetTypeString()}");
            Console.WriteLine($"Graduation date: {GraduationDate}");
            Console.WriteLine($"Graduation rank: {GraduationRank}");
            Console.WriteLine($"Education: {Education}");
            Console.WriteLine("Certificates:");
            foreach (var certificate in Certificates)
            {
                Console.WriteLine($"Certificate ID: {certificate.CertificatedID}");
                Console.WriteLine($"Certificate name: {certificate.CertificateName}");
                Console.WriteLine($"Certificate rank: {certificate.CertificateRank}");
                Console.WriteLine($"Certificate date: {certificate.CertificatedDate.ToShortDateString()}");
            }
        }
    }

    public class Intern : Employee
    {
        public string Major {get; set;}
        public int Semester {get; set;}
        public string UniversityName {get; set;}

        public Intern(string id, string fullName, DateTime birthDay, string phone, string email, string major, int semester, string universityName, List<Certificate> certificates = null) : base(id, fullName, birthDay, phone, email, 2, certificates) {
            Major = major;
            Semester = semester;
            UniversityName = universityName;
        }

        public override string GetTypeString()
        {
            return "Intern";
        }

        public override void ShowInfo()
        {
            Console.WriteLine("Employee info:");
            Console.WriteLine($"ID: {ID}");
            Console.WriteLine($"Full name: {FullName}");
            Console.WriteLine($"Birthday: {BirthDay.ToShortDateString()}");
            Console.WriteLine($"Phone number: {Phone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Employee type: {GetTypeString()}");
            Console.WriteLine($"Majors: {Major}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"University name: {UniversityName}");
            Console.WriteLine("Certificates:");
            foreach (var certificate in Certificates)
            {
                Console.WriteLine($"Certificate ID: {certificate.CertificatedID}");
                Console.WriteLine($"Certificate name: {certificate.CertificateName}");
                Console.WriteLine($"Certificate rank: {certificate.CertificateRank}");
                Console.WriteLine($"Certificate date: {certificate.CertificatedDate.ToShortDateString()}");
            }
        }
    }

    public class EmployeeManager
    {
        private static List<Employee> employees;

        static EmployeeManager()
        {
            employees = new List<Employee>();
        }

        public bool AddEmployee(Employee employee)
        {
            if (Validator.BirthDayValidate(employee.BirthDay) && Validator.FullNameValidate(employee.FullName) && Validator.EmailValidate(employee.Email) && Validator.PhoneValidate(employee.Phone))
            {
                employees.Add(employee);
                Employee.EmployeeCount++;
                return true;
            }
            return false;
        }
        
        public Employee FindByID(string id) 
        {
            return employees.FirstOrDefault(e => e.ID == id);
        }
        public bool ModifyEmployee(Employee employee)
        {
            int idx = employees.FindIndex(e => e.ID == employee.ID);
            if (idx == -1)
                return false;
            employees[idx] = employee;
            return true;
        }
        public bool DeleteByID(string id)
        {
            int idx = employees.FindIndex(e => e.ID == id);
            if (idx == -1)
                return false;
            employees.RemoveAt(idx);
            Employee.EmployeeCount--;
            return true;
        }
        public List<Employee> FindAllByType(int type) {
            return employees.FindAll(e => e.EmployeeType == type);
        }
    }

    public class Validator
    {
        public static bool BirthDayValidate(DateTime birthday)
        {
            if (birthday > DateTime.Today)
            {
                throw new BirthDayException(birthday.ToShortDateString()); 
            }
            else
            {
                return true;
            }
        }
        public static bool EmailValidate(string email)
        {
            if (!Regex.IsMatch(email,@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")) {
                throw new EmailException(email);
            }
            else
            {
                return true;
            }
        }
        public static bool FullNameValidate(string fullName)
        {
            if (String.IsNullOrWhiteSpace(fullName)) {
                throw new FullNameException();
            }
            else
            {
                return true;
            }
        }
        public static bool PhoneValidate(string phone)
        {
            if(!Regex.IsMatch(phone, "^\\+?[1-9][0-9]{7,14}$")) {
                throw new PhoneException(phone);
            }
            else
            {
                return true;
            }
        }
    }

    public interface IEmployeeForm
    {
        void AddEmployee();
        void ModifyEmployee(Employee employee);
        void DisplayAllEmployees();
    }
    public class ExperienceForm : IEmployeeForm
    {
        private EmployeeManager employeeManager;
        public ExperienceForm()
        {
            employeeManager = new EmployeeManager();
        }
        public void AddEmployee()
        {
            Console.Write("Enter employee ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter employee full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter employee birthday: ");
            DateTime birthDay;
            while(!DateTime.TryParse(Console.ReadLine(), out birthDay))
            {
                Console.WriteLine("Invalid birthday");
                Console.Write("Enter employee birthday: ");
            }
            Console.Write("Enter employee phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter employee email: ");
            string email = Console.ReadLine();
            Console.Write("Enter employee experience in year: ");
            int expInYear;
            while(!int.TryParse(Console.ReadLine(), out expInYear))
            {
                Console.WriteLine("Invalid experience in year");
                Console.Write("Enter employee experience in year: ");
            }
            Console.Write("Enter employee pro skill: ");
            string proSkill = Console.ReadLine();
            Console.Write("Enter employee education: ");
            List<Certificate> certificates = new List<Certificate>();
            Console.Write("Enter number of certificates: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Certificate {0}:" + i + 1);
                Console.Write("Enter certificate id: ");
                string certificatedID = Console.ReadLine();
                Console.Write("Enter certificate name: ");
                string name = Console.ReadLine();
                Console.Write("Enter certificate rank: ");
                string rank = Console.ReadLine();
                Console.Write("Enter certificate date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                certificates.Add(new Certificate(certificatedID, name, rank, date));
                Console.Write("");
            }
            employeeManager.AddEmployee(new Experience(id, fullName, birthDay, phone, email, expInYear, proSkill, certificates));
        }

        public void DisplayAllEmployees()
        {
            List<Employee> employees = employeeManager.FindAllByType(0);
            foreach (var employee in employees)
            {
                employee.ShowInfo();
            }
        }

        public void ModifyEmployee(Employee employee)
        {
            Experience experience = (Experience)employee;
            Console.WriteLine("Modifying Employee");
            Console.WriteLine("Old full name: " + experience.FullName);
            Console.Write("New full name: ");
            experience.FullName = Console.ReadLine();
            Console.WriteLine("Old birthday: " + experience.BirthDay.ToShortDateString());
            Console.Write("New birthday: ");
            DateTime birthDay;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDay))
            {
                Console.WriteLine("Invalid birthday");
                Console.Write("New birthday: ");
            }
            experience.BirthDay = birthDay;
            Console.WriteLine("Old phone number: " + experience.Phone);
            Console.Write("New phone number: ");
            experience.Phone = Console.ReadLine();
            Console.WriteLine("Old email: " + experience.Email);
            Console.Write("New email: ");
            experience.Email = Console.ReadLine();
            Console.WriteLine("Old experience in year: " + experience.ExpInYear);
            Console.Write("New experience: ");
            int expInYear;
            while (!int.TryParse(Console.ReadLine(), out expInYear))
            {
                Console.WriteLine("Invalid experience in year");
                Console.Write("New experience in year: ");
            }
            experience.ExpInYear = expInYear;
            Console.WriteLine("Old pro skill: " + experience.ProSkill);
            Console.Write("New pro skill: ");
            experience.ProSkill = Console.ReadLine();
            List<Certificate> certificates = experience.Certificates;
            Console.Write("Enter number of new certificates: ");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid number of new certificates");
                Console.Write("Enter number of new certificates: ");
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("New certificate {0}:" + i + 1);
                Console.Write("Enter certificate id: ");
                string certificatedID = Console.ReadLine();
                Console.Write("Enter certificate name: ");
                string name = Console.ReadLine();
                Console.Write("Enter certificate rank: ");
                string rank = Console.ReadLine();
                Console.Write("Enter certificate date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                certificates.Add(new Certificate(certificatedID, name, rank, date));
                Console.Write("");
            }
            employeeManager.ModifyEmployee(experience);
        }
    }

    public class FresherForm : IEmployeeForm
    {
        private EmployeeManager employeeManager;
        public FresherForm()
        {
            employeeManager = new EmployeeManager();
        }
        public void AddEmployee()
        {
            Console.Write("Enter employee ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter employee full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter employee birthday: ");
            DateTime birthDay;
            while(!DateTime.TryParse(Console.ReadLine(), out birthDay))
            {
                Console.WriteLine("Invalid birthday");
                Console.Write("Enter employee birthday: ");
            }
            Console.Write("Enter employee phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter employee email: ");
            string email = Console.ReadLine();
            Console.Write("Enter employee education: ");
            string education = Console.ReadLine();
            Console.Write("Enter employee graduation date: ");
            DateTime graduationDate;
            while(!DateTime.TryParse(Console.ReadLine(), out graduationDate))
            {
                Console.WriteLine("Invalid birthday");
                Console.Write("Enter employee birthday: ");
            }
            Console.Write("Enter employee graduation rank: ");
            string graduationRank = Console.ReadLine();
            List<Certificate> certificates = new List<Certificate>();
            Console.Write("Enter number of certificates: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Certificate {0}:" + i + 1);
                Console.Write("Enter certificate id: ");
                string certificatedID = Console.ReadLine();
                Console.Write("Enter certificate name: ");
                string name = Console.ReadLine();
                Console.Write("Enter certificate rank: ");
                string rank = Console.ReadLine();
                Console.Write("Enter certificate date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                certificates.Add(new Certificate(certificatedID, name, rank, date));
                Console.Write("");
            }
            employeeManager.AddEmployee(new Fresher(id, fullName, birthDay, phone, email, graduationDate, graduationRank, education, certificates));
        }
        public void ModifyEmployee(Employee employee)
        {
            Fresher fresher = (Fresher)employee;
            Console.WriteLine("Modifying Employee");
            Console.WriteLine("Old full name: " + fresher.FullName);
            Console.Write("New full name: ");
            fresher.FullName = Console.ReadLine();
            Console.WriteLine("Old birthday: " + fresher.BirthDay.ToShortDateString());
            Console.Write("New birthday: ");
            DateTime birthDay;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDay))
            {
                Console.WriteLine("Invalid birthday");
                Console.Write("New birthday: ");
            }
            fresher.BirthDay = birthDay;
            Console.WriteLine("Old phone number: " + fresher.Phone);
            Console.Write("New phone number: ");
            fresher.Phone = Console.ReadLine();
            Console.WriteLine("Old email: " + fresher.Email);
            Console.Write("New email: ");
            fresher.Email = Console.ReadLine();
            Console.WriteLine("Old graduation date: " + fresher.GraduationDate.ToShortDateString());
            Console.Write("New graduation date: ");
            DateTime graduationDate;
            while (!DateTime.TryParse(Console.ReadLine(), out graduationDate))
            {
                Console.WriteLine("Invalid graduation date");
                Console.Write("New graduation date: ");
            }
            fresher.GraduationDate = graduationDate;
            Console.WriteLine("Old graduation rank: " + fresher.GraduationRank);
            Console.Write("New graduation rank: ");
            fresher.GraduationRank = Console.ReadLine();
            Console.WriteLine("Old education: " + fresher.Education);
            Console.Write("New education: ");
            fresher.Education = Console.ReadLine();
            List<Certificate> certificates = fresher.Certificates;
            Console.Write("Enter number of new certificates: ");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid number of new certificates");
                Console.Write("Enter number of new certificates: ");
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("New certificate {0}:" + i + 1);
                Console.Write("Enter certificate id: ");
                string certificatedID = Console.ReadLine();
                Console.Write("Enter certificate name: ");
                string name = Console.ReadLine();
                Console.Write("Enter certificate rank: ");
                string rank = Console.ReadLine();
                Console.Write("Enter certificate date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                certificates.Add(new Certificate(certificatedID, name, rank, date));
                Console.Write("");
            }
            employeeManager.ModifyEmployee(fresher);
        }

        public void DisplayAllEmployees()
        {
            List<Employee> employees = employeeManager.FindAllByType(1);
            foreach (var employee in employees)
            {
                employee.ShowInfo();
            }
        }
    }
    public class InternForm : IEmployeeForm
    {
        private EmployeeManager employeeManager;
        public InternForm()
        {
            employeeManager = new EmployeeManager();
        }
        public void AddEmployee()
        {
            Console.Write("Enter employee ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter employee full name: ");
            string fullName = Console.ReadLine();
            Console.Write("Enter employee birthday: ");
            DateTime birthDay;
            while(!DateTime.TryParse(Console.ReadLine(), out birthDay))
            {
                Console.WriteLine("Invalid birthday");
                Console.Write("Enter employee birthday: ");
            }
            Console.Write("Enter employee phone number: ");
            string phone = Console.ReadLine();
            Console.Write("Enter employee email: ");
            string email = Console.ReadLine();
            Console.Write("Enter employee major: ");
            string major = Console.ReadLine();
            int semester;
            while(!int.TryParse(Console.ReadLine(), out semester))
            {
                Console.WriteLine("Invalid semester");
                Console.Write("Enter employee semester: ");
            }
            Console.Write("Enter employee university name: ");
            string universityName = Console.ReadLine();
            List<Certificate> certificates = new List<Certificate>();
            Console.Write("Enter number of certificates: ");
            int num = int.Parse(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Certificate {0}:" + i + 1);
                Console.Write("Enter certificate id: ");
                string certificatedID = Console.ReadLine();
                Console.Write("Enter certificate name: ");
                string name = Console.ReadLine();
                Console.Write("Enter certificate rank: ");
                string rank = Console.ReadLine();
                Console.Write("Enter certificate date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                certificates.Add(new Certificate(certificatedID, name, rank, date));
                Console.Write("");
            }
            employeeManager.AddEmployee(new Intern(id, fullName, birthDay, phone, email, major, semester, universityName, certificates));
        }
        public void ModifyEmployee(Employee employee)
        {
            Intern intern = (Intern)employee;
            Console.WriteLine("Modifying Employee");
            Console.WriteLine("Old full name: " + intern.FullName);
            Console.Write("New full name: ");
            intern.FullName = Console.ReadLine();
            Console.WriteLine("Old birthday: " + intern.BirthDay.ToShortDateString());
            Console.Write("New birthday: ");
            DateTime birthDay;
            while (!DateTime.TryParse(Console.ReadLine(), out birthDay))
            {
                Console.WriteLine("Invalid birthday");
                Console.Write("New birthday: ");
            }
            intern.BirthDay = birthDay;
            Console.WriteLine("Old phone number: " + intern.Phone);
            Console.Write("New phone number: ");
            intern.Phone = Console.ReadLine();
            Console.WriteLine("Old email: " + intern.Email);
            Console.Write("New email: ");
            intern.Email = Console.ReadLine();
            Console.WriteLine("Old major: " + intern.Major);
            Console.Write("New major: ");
            intern.Major = Console.ReadLine();
            Console.WriteLine("Old semester: " + intern.Semester);
            Console.Write("New semester: ");
            int semester;
            while (!int.TryParse(Console.ReadLine(), out semester))
            {
                Console.WriteLine("Invalid semester");
                Console.Write("New semester: ");
            }
            intern.Semester = semester;
            List<Certificate> certificates = intern.Certificates;
            Console.Write("Enter number of new certificates: ");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Invalid number of new certificates");
                Console.Write("Enter number of new certificates: ");
            }
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("New certificate {0}:" + i + 1);
                Console.Write("Enter certificate id: ");
                string certificatedID = Console.ReadLine();
                Console.Write("Enter certificate name: ");
                string name = Console.ReadLine();
                Console.Write("Enter certificate rank: ");
                string rank = Console.ReadLine();
                Console.Write("Enter certificate date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                certificates.Add(new Certificate(certificatedID, name, rank, date));
                Console.Write("");
            }
            employeeManager.ModifyEmployee(intern);
        }

        public void DisplayAllEmployees()
        {
            List<Employee> employees = employeeManager.FindAllByType(3);
            foreach (var employee in employees)
            {
                employee.ShowInfo();
            }
        }
    }

    public class DeleteEmployeeForm
    {
        private EmployeeManager employeeManager;
        public DeleteEmployeeForm()
        {
            employeeManager = new EmployeeManager();
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("Deleting employee: ");
            Console.Write("Enter employee ID: ");
            string id = Console.ReadLine();
            bool res = employeeManager.DeleteByID(id);
            if (res)
            {
                Console.WriteLine("Employee deleted");
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }
    }
}

namespace CustomException {
    
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

namespace Main {

    using Employee;

    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. Add a new experience");
                Console.WriteLine("2. Add a new fresher");
                Console.WriteLine("3. Add a new intern");
                Console.WriteLine("4. Modify an employee by id");
                Console.WriteLine("5. Delete an employee by id");
                Console.WriteLine("6. Display a list of experiences");
                Console.WriteLine("7. Display a list of freshers");
                Console.WriteLine("8. Display a list of interns");
                Console.WriteLine("9. Exit");
                int choose;
                while (!int.TryParse(Console.ReadLine(), out choose))
                {
                    Console.WriteLine("Invalid choice");
                }
                switch (choose) {
                    case 1: {
                        IEmployeeForm experienceForm = new ExperienceForm();
                        experienceForm.AddEmployee();
                        break;
                    }
                    case 2: {
                        IEmployeeForm fresherForm = new FresherForm();
                        fresherForm.AddEmployee();
                        break;
                    }
                    case 3: {
                        IEmployeeForm internForm = new InternForm();
                        internForm.AddEmployee();
                        break;
                    }
                    case 4: {
                        IEmployeeForm? employeeForm = null;
                        Console.Write("Enter employee id: ");
                        string id = Console.ReadLine() ?? string.Empty;
                        Employee employee = new EmployeeManager().FindByID(id);
                        if (employee != null)
                        {
                            Console.WriteLine("Employee not found");
                        }
                        else
                        {
                            switch (employee.EmployeeType) {
                                case 0: {
                                    employeeForm = new ExperienceForm();
                                    break;
                                }
                                case 1: {
                                    employeeForm = new FresherForm();
                                    break;
                                }
                                case 2: {
                                    employeeForm = new InternForm();
                                    break;
                                }
                            }
                        }
                        employeeForm?.ModifyEmployee(employee);
                        break;
                    }
                    case 5:{
                        Console.WriteLine("Delete employee");
                        DeleteEmployeeForm deleteEmployeeForm = new();
                        deleteEmployeeForm.DeleteEmployee();
                        break;
                    }
                    case 6: {
                        IEmployeeForm experienceForm = new ExperienceForm();
                        experienceForm.DisplayAllEmployees();
                        break;
                    }
                    case 7: {
                        IEmployeeForm fresherForm = new FresherForm();
                        fresherForm.DisplayAllEmployees();
                        break;
                    }
                    case 8: {
                        IEmployeeForm internForm = new InternForm();
                        internForm.DisplayAllEmployees();
                        break;
                    }
                    case 9: {
                        return;
                    }
                }
            }
        }
    }
}
