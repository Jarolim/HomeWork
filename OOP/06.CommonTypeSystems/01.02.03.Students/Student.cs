using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Task 1: Define a class Student, which contains data about a student – first,
  middle and last name, SSN, permanent address, mobile phone e-mail, 
  course, specialty, university, faculty. Use an enumeration for the 
  specialties, universities and faculties. Override the standard methods,
  inherited by  System.Object: Equals(), ToString(), GetHashCode() 
  and operators == and !=.*/

/* Task 2: Add implementations of the ICloneable interface. The Clone() 
  method should deeply copy all object's fields into a new object of type Student.*/

/* Task 3: Implement the  IComparable<Student> interface to compare students by names
  (as first criteria, in lexicographic order) and by social security number 
  (as second criteria, in increasing order).*/

class Student : ICloneable, IComparable<Student>
{
    //Fields with properties:
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public int SSN { get; set; }
    public string PermanentAddress { get; set; }
    public string MobilePhone { get; set; }
    public string Email { get; set; }
    public int? Course { get; set; }
    //Use an enumeration for the specialties, universities and faculties.
    public Speciality SpecialityName { get; set; }
    public University UniversityName { get; set; }
    public Faculty FacultyName { get; set; }
    

    //Constructors:
    public Student(string firstName, string middleName, string lastName, int sSN, string permanentAddress, string mobilePhone,
        string email, University university, Faculty faculty, Speciality speciality, int? course)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.SSN = sSN;
        this.PermanentAddress = permanentAddress;
        this.MobilePhone = mobilePhone;
        this.Email = email;
        this.UniversityName = university;
        this.FacultyName = faculty;
        this.SpecialityName = speciality;
        this.Course = course;
    }
    
    public Student(string firstName, string middleName, string lastName, int sSN) :
        this(firstName, middleName, lastName, sSN, null, null, null, University.Oxford, Faculty.Law,
        Speciality.CivilEngeneering, null)
    {
    }

    //Override the standard methods,inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=
    public override bool Equals(object param)
    {
        Student student = param as Student;
        if (student == null)
        {
            return false;
        }
        if (!Object.Equals(this.FirstName,student.FirstName))
        {
            return false;
        }
        if (!Object.Equals(this.MiddleName, student.MiddleName))
        {
            return false;
        }
        if (!Object.Equals(this.LastName, student.LastName))
        {
            return false;
        }
        if (!Object.Equals(this.SSN, student.SSN))
        {
            return false;
        }
        return true;
    }

    public static bool operator ==(Student first, Student second)
    {
        return Student.Equals(first, second);
    }

    public static bool operator !=(Student first, Student second)
    {
        return !(Student.Equals(first, second));
    }

    public override int GetHashCode()
    {
        return FirstName.GetHashCode() ^ MiddleName.GetHashCode() ^ LastName.GetHashCode() ^ SSN.GetHashCode();
    }

    public override string ToString()
    {
        return String.Format("Name: {0} {1} {2}, SSN: {3}", this.FirstName, this.MiddleName, this.LastName, this.SSN);
    }

    //Add implementations of the ICloneable interface. The Clone() method should deeply copy all object's fields into a new object of type Student
    public Student Clone()
    {
        Student original = this;
        Student result = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermanentAddress,
            this.MobilePhone, this.Email, this.UniversityName, this.FacultyName, this.SpecialityName, this.Course);

        return result;
    }

    Object ICloneable.Clone()
    {
        return this.Clone();
    }

    //Implement the  IComparable<Student> interface to compare students by names(as first criteria, in lexicographic order) and by social security number (as second criteria, in increasing order)
    public int CompareTo(Student student)
    {
        if (this.FirstName != student.FirstName)
        {
            return (this.FirstName.CompareTo(student.FirstName));
        }
        if (this.MiddleName != student.MiddleName)
        {
            return (this.MiddleName.CompareTo(student.MiddleName));
        }
        if (this.LastName != student.LastName)
        {
            return (this.LastName.CompareTo(student.LastName));
        }
        if (this.SSN != student.SSN)
        {
            return (this.SSN - student.SSN);
        }
        return 0;
    }
}

