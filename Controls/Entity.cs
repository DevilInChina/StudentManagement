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
    public class Teacher_Info
    {
        public String Teacher_name;
        public String National;
        public String Birthday;
        public String Gender;
        public long Teacher_id;
        public Teacher_Info(String name, String national, String birthday, String gender,  long Teaid)
        {
            this.Teacher_name = name;
            this.National = national;
            this.Birthday = birthday;
            this.Gender = gender;
            this.Teacher_id = Teaid;
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

    public class Course_info
    {
        public string name { get; set; }
        public long cls_id { get; set; }
        public long maj_id { get; set; }
        public int Credit { get; set; }
        public long Teacher_Id { get; set; }
        public int MaxCap { get; set; }
        public int CurCap { get; set; }
        public long Class_Time { get; set; }
        public String teacher_Name { get; set; }
        public String class_Name { get; set; }
        public Course_info(String name, long Teacher_Id, long Cls_id,
            long Maj_id, int MaxCap, int Credit,long Class_Time,
            int CurCap=0,String teacher_name=null,String class_Name =null)
        {
            this.name = name;
            this.cls_id = Cls_id;
            this.maj_id = Maj_id;
            this.Teacher_Id = Teacher_Id;
            this.MaxCap = MaxCap;
            this.Credit = Credit;
            this.Class_Time = Class_Time;
            this.CurCap = CurCap;
            this.teacher_Name = teacher_name;
            this.class_Name = class_Name;
        }
    }

    public class CourseShowed_Info
    {
        public String course_name { get; set; }
        public String Teacher_name { get; set; }
        public String Classroom_name { get; set; }
        public int Max_capacity { get; set; }
        public int Credit { get; set; }
        public long Class_Time { get; set; }
        public int Now_capacity { get; set; }
        public long course_id { get; set; }
        public CourseShowed_Info(
            String course_name,
            String Teacher_name,
            String Classroom_name,
            int Max_capacity,
            int Credit,
            long Class_Time,
            int Now_capacity,
            long course_id
            )
        {
            this.course_name = course_name;
            this.Teacher_name = Teacher_name;
            this.Classroom_name = Classroom_name;
            this.Max_capacity = Max_capacity;
            this.Credit = Credit;
            this.Class_Time = Class_Time;
            this.Now_capacity = Now_capacity;
            this.course_id = course_id;

        }
    }

}
