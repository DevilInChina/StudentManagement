DROP database if exists StudentManaged ;
create database StudentManaged;
use StudentManaged;
create table academy_information(
    Academy_id bigint(1) primary key auto_increment,
    Academy_name varchar(24) not null, 
    UNIQUE (Academy_name)
);
create table major_information(
    major_id bigint(1) primary key auto_increment,
    Academy_id bigint(1) not null,
    major_name varchar(24) not null ,
    UNIQUE (major_name)
);

alter table major_information add constraint outkey1 foreign key (Academy_id) 
references academy_information(Academy_id);

create table class_information(
    Class_id bigint(1) primary key,
    Class_name varchar(24) not null,
    Academy_id bigint(1) not null,
    Major_id bigint(1) not null,
    UNIQUE(Class_name)
);




alter table class_information add constraint outkey2 foreign key (Academy_id) 
references academy_information(Academy_id);
alter table class_information add constraint outkey3 foreign key (major_id) 
references major_information(major_id);

create table jwc_information(
    Clerk_id bigint(1) primary key,
    Clerk_name varchar(24) not null,
    Gender varchar(8) not null,
    National varchar(8) ,
    Birthday date ,
    Passwords varchar(24) not null
);

create table classroom_information(
    Classroom_id bigint(1) primary key,
    Classroom_name varchar(24) not null ,
    Max_capacity int(1) not null
);

create table Student(
    Student_id bigint(1) primary key,
    Student_name varchar(24) not null,
    Gender varchar(8) not null,
    National varchar(8) not null,
    Birthday date not null,
    Grade bigint(1) not null,
    Major_id bigint(1) not null,
    Minor_id bigint(1),
    Class_id bigint(1) not null,
    passwords varchar(24) not null,
    originPlace varchar(24) not null,
    graduate varchar(8) not null
);

#alter table Student add constraint outkey4 foreign key (Academy_id) 
#references academy_information(Academy_id);
alter table Student add constraint outkey5 foreign key (major_id) 
references major_information(major_id);
alter table Student add constraint outkey6 foreign key (Minor_id) 
references major_information(major_id);
alter table Student add constraint outkey7 foreign key (Class_id) 
references class_information(Class_id);

create table teacher(
    Teacher_id bigint(1) primary key auto_increment,
    Teacher_name varchar(24) not null,
    Gender varchar(8) not null,
    National varchar(8) not null,
    Birthday date not null,
    Academy_id bigint(1) not null,
    Major_id bigint(1) not null,
    passwords varchar(24) not null
);

alter table teacher add constraint outkey8 foreign key (major_id) 
references major_information(major_id);
alter table teacher add constraint outkey9 foreign key (Academy_id) 
references academy_information(Academy_id);

create table course_information(
    course_id bigint(1) primary key,
    Teacher_id bigint(1) not null ,
    Credit int(1) not null,
    Max_capacity int(1) not null,
    Now_capacity int(1) not null,
    Academy_id bigint(1) not null,
    Major_id bigint(1),
    Classroom_id bigint(1) not null,
    
);

alter table course_information add constraint outkey10 foreign key (Teacher_id) 
references teacher(Teacher_id);
alter table course_information add constraint outkey11 foreign key (major_id) 
references major_information(major_id);
alter table course_information add constraint outkey12 foreign key (Academy_id) 
references academy_information(Academy_id);
alter table course_information add constraint outkey13 foreign key (Classroom_id) 
references classroom_information(Classroom_id);

create table select_information(
    Select_id bigint(1) primary key auto_increment,
    Student_id bigint(1) not null ,
    course_id bigint(1) not null,
    Enable varchar(8) not null
);

alter table select_information add constraint outkey14 foreign key (Student_id) 
references Student(Student_id);
alter table select_information add constraint outkey15 foreign key (course_id) 
references class_information(course_id);


DELIMITER $$

DROP procedure if exists AddAcademy ;
create procedure AddAcademy(in iAcademy_name varchar(24))
begin
    insert into academy_information (Academy_name) values (iAcademy_name);
end
$$
DROP procedure if exists GetAcademyID ;
create procedure GetAcademyID(in iAcademy_name varchar(24),out iAcademy_id bigint(1))
begin
    select Academy_id into iAcademy_id from academy_information where Academy_name = iAcademy_name;
end
$$
DROP procedure if exists GetAcademyName ;
create procedure GetAcademyName(in  iAcademy_id bigint(1),out iAcademy_name varchar(24))
begin
    select Academy_name into iAcademy_name from academy_information where Academy_id = iAcademy_id;
end
$$

DROP procedure if exists AddMajor ;
create procedure AddMajor(in iAcademy_id bigint(1), in iMajor_name varchar(24))
begin
    insert into major_information (Academy_id,major_name) values (iAcademy_id,iMajor_name);
end
$$
DROP procedure if exists GetMajorID ;
create procedure GetMajorID(in iMajor_name varchar(24),out imajor_id bigint(1))
begin
    select major_id into imajor_id from major_information where major_name = iMajor_name;
end
$$

DROP procedure if exists AddClass ;
create procedure AddClass(in iClass_name varchar(24),in iClass_id bigint(1),in imajor_id bigint(1),in iAcademy_id bigint(1))
begin
    insert into class_information (Class_id,Class_name,major_id,Academy_id) values (iClass_id,iClass_name,imajor_id,iAcademy_id);
end
$$
DROP procedure if exists GetClassID ;
create procedure GetClassID(in iClass_name varchar(24),out iClass_id bigint(1))
begin
    select Class_id into iClass_id from class_information where Class_name = iClass_name;
end
$$

DROP procedure if exists InsertStudent ;
create procedure InsertStudent(in idn bigint(1),in iname varchar(24),in igender VarChar(8),in inational varchar(8),in iGrade bigint(1),
                                in imajor_id bigint(1),in iminor_id bigint(1),in iclass_id bigint(1) ,in iPSD varchar(24),
                                in ibirthday date,in igraduate VarChar(8),in iOriginPlace varchar(24))
begin
    insert into student 
    (Student_id,Student_name,Gender,National,Grade,Major_id,Minor_id,Class_id,passwords,birthday,graduate,OriginPlace) 
    values 
    (idn,iname,igender,inational,iGrade,imajor_id,iminor_id,iclass_id,iPSD,ibirthday,igraduate,iOriginPlace);
end
$$

DROP procedure if exists InsertTeacher ;
create procedure InsertTeacher(in iTeacher_id bigint(1), in iTeacher_name varchar(24),in igender VarChar(8),in inational varchar(8),
                                in imajor_id bigint(1),in iAcademy_id bigint(1),in iPSD varchar(24),
                                in ibirthday date)
begin
    insert into teacher 
    (Teacher_id,Teacher_name,Gender,National,Major_id,Academy_id,Birthday,passwords)
    values 
    (iTeacher_id,iTeacher_name,igender,inational,imajor_id,iAcademy_id,ibirthday,iPSD);
end
$$

DROP procedure if exists PassWordCheck ;
create procedure PassWordCheck(in idn bigint(1),in iPSD varchar(24),out Correct int(1) )
begin
    set @temp = '';
    select passwords into @temp from student where student_id = idn;
    select Correct = @temp into Correct;

end
$$

DROP procedure if exists AddClassroom ;
create procedure AddClassroom(in iClassroom_name varchar(24),in iMax_capacity int(1) )
begin
    insert into classroom_information 
    (Classroom_name,Max_capacity)
    values
    (iClassroom_name,iMax_capacity)
end
$$
DROP procedure if exists GetClassroomByID ;
create procedure GetClassroomByID(in iClassroom_id)
begin
    select * from classroom_information where Classroom_id = iClassroom_id;
end
$$
DROP procedure if exists GetClassroom ;
create procedure GetClassroom()
begin
    select * from classroom_information;
end
$$

DELIMITER ;

