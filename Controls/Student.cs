using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Controls
{

    public class Student : IComparable<Student>
    {
        public String name;
        public String national;
        public String From;
        public String birthday;
        public String gender;
        public String majName;
        public long classID;
        public long majID;
        public long stuID;
        public long acaID;
        public int grade;
        public Student(String name, String national, String From, String birthday, String gender, int grade, long majID, long acaID,String majName)
        {
            this.name = name;
            this.national = national;
            this.From = From;
            this.birthday = birthday;
            this.majID = majID;
            this.acaID = acaID;
            this.grade = grade;
            this.gender = gender;
            this.classID = 0;
            this.majName = majName;
        }
        public int CompareTo(Student other)
        {
            if (grade != other.grade)
            {
                return (int)(grade - other.grade);
            }
            if (acaID != other.acaID)
            {
                return (int)(acaID - other.acaID);
            }
            if (majID != other.majID)
            {
                return (int)(majID - other.majID);
            }
            if(classID != other.classID)
            {
                return (int)(classID - other.classID);
            }
            int gend = gender.CompareTo(other.gender);
            if (0 == gend)
            {
                return name.CompareTo(other.name);
            }
            else
            {
                return gend;
            }
        }
    }
}
