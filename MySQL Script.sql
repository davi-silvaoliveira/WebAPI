create database if not exists web_api;
use web_api;

create table if not exists local(
	id int primary key auto_increment,
    nome varchar(50) not null,
    discrepancias int not null,
    concordancias int not null
);

insert into local values(default, "São Paulo", 2, 2);
insert into local values(default, "Rio de Janeiro", 1, 0);

select * from local;

-- drop database web_api;