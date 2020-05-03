
use StudentManaged;
delimiter $$


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
DROP procedure if exists PassWordCheck ;
create procedure PassWordCheck(in idn bigint(1),in iPSD varchar(24),out Correct int(1) )
begin
    set @temp = '';
    select passwords into @temp from student where student_id = idn;
    select Correct = @temp into Correct;

end

$$
DELIMITER ;