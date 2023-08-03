namespace Employee
{    
    using CustomException;
    using System.Text.RegularExpressions;
    public class Certificate
    {
        public int CertificatedID { get; set; }
        public string CertificateName { get; set; }
        public string CertificateRank { get; set; }
        public DateTime CertificatedDate { get; set; }

        public Certificate(int id, string name, string rank, DateTime date)
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
            EmployeeCount++;
            Certificates = new List<Certificate>();
        }

        public Employee(string id, string fullName, DateTime birthDay, string phone, string email, int employeeType, List<Certificate> certificates = null)
        {
            EmployeeCount++;
            ID = id;
            FullName = fullName;
            BirthDay = birthDay;
            Phone = phone;
            Email = email;
            EmployeeType = employeeType;
            Certificates = certificates != null ? certificates : new List<Certificate>();
        }
        public abstract string getTypeString();
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
            Console.WriteLine($"Employee type: {getTypeString()}");
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

        public override string getTypeString()
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

        public override string getTypeString()
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
            Console.WriteLine($"Employee type: {getTypeString()}");
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
        public string Majors {get; set;}
        public int Semester {get; set;}
        public string UniversityName {get; set;}

        public Intern(string id, string fullName, DateTime birthDay, string phone, string email, string majors, int semester, string universityName, List<Certificate> certificates = null) : base(id, fullName, birthDay, phone, email, 2, certificates) {
            Majors = majors;
            Semester = semester;
            UniversityName = universityName;
        }

        public override string getTypeString()
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
            Console.WriteLine($"Employee type: {getTypeString()}");
            Console.WriteLine($"Majors: {Majors}");
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
        private List<Employee> employees;

        public EmployeeManager()
        {
            employees = new List<Employee>();
        }

        public bool AddEmployee(Employee employee)
        {
            if (Validator.BirthDayValidate(employee.BirthDay) && Validator.FullNameValidate(employee.FullName) && Validator.EmailValidate(employee.Email) && Validator.PhoneValidate(employee.Phone))
            {
                employees.Add(employee);
                return true;
            }
            return false;
        }
        public bool AddEmployee(List<Employee> listEmployee)
        {
            foreach (var item in collection)
            {
                
            }
            if (Validator.BirthDayValidate(employee.BirthDay) && Validator.FullNameValidate(employee.FullName) && Validator.EmailValidate(employee.Email) && Validator.PhoneValidate(employee.Phone))
            {
                employees.Add(employee);
                return true;
            }
            return false;
            employees.AddRange(listEmployee);
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
