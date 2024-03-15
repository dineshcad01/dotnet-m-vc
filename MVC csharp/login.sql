use cad_os;
select*from os_user_login;


create table os_user_login(
user_name varchar(20), password varchar(50), new_password varchar(50));
insert into os_user_login(user_name,password, new_password)
values('Dinesh','Dinesh1', Null);