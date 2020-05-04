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
    public class Teacher 
    {
        public String name;
        public String national;
        public String birthday;
        public String gender;
        public long majID;
        public long Teaid;
        public long acaID;
        public Teacher(String name, String national, String birthday, String gender, long majID, long acaID,long Teaid)
        {
            this.name = name;
            this.national = national;
            this.birthday = birthday;
            this.majID = majID;
            this.acaID = acaID;
            this.gender = gender;
            this.Teaid = Teaid;
        }
    }

    public class Class_info
    {
        public string name { get; set; }
        public long aca_id { get; set; }
        public long cls_id { get; set; }
        public long maj_id { get; set; }
        public Class_info(String name, long Aca_id,long Cls_id,long Maj_id)
        {
            this.name = name;
            this.aca_id = Aca_id;
            this.cls_id = Cls_id;
            this.maj_id = Maj_id;
        }
    }




}
