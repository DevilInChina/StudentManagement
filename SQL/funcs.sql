
use StudentManaged;
delimiter $$
DROP procedure if exists GetStudentInfoFromID ;
create procedure GetStudentInfoFromID(in idn bigint(1) ,out iname varchar(24),out igender VarChar(8),out inational varchar(8),
                                        out iacademic_id bigint(1),out imajor_id bigint(1),out iminor_id bigint(1),
                                        out iclass_id bigint(1) ,out iPSD varchar(24),out ibirthday date,out igraduate VarChar(8))
begin
    select Student_name,Gender,National,Academy_id,Major_id,Minor_id,Class_id,passwords,birthday,graduate into 
    iname,igender,inational,iacademic_id,imajor_id,iminor_id,iclass_id,iPSD,ibirthday,igraduate
    from student
    where student_id = idn;
end
$$

DROP procedure if exists InsertStudent ;
create procedure InsertStudent(in idn bigint(1),in iname varchar(24),in igender VarChar(8),in inational varchar(8),in iacademic_id bigint(1),
                                in imajor_id bigint(1),in iminor_id bigint(1),in iclass_id bigint(1) ,in iPSD varchar(24),in ibirthday date,in igraduate VarChar(8))
begin
    insert into student 
    (Student_id,Student_name,Gender,National,Academy_id,Major_id,Minor_id,Class_id,passwords,birthday,graduate) 
    values 
    (idn,iname,igender,inational,iacademic_id,imajor_id,iminor_id,iclass_id,iPSD,ibirthday,igraduate);
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
DELIMITER ;
