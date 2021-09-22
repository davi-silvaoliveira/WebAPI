create database if not exists web_api;
use web_api;

create table if not exists local(
	id int primary key auto_increment,
    nome varchar(50) not null,
    discrepancias int not null,
    concordancias int not null
);

create table if not exists usuario(
	id int primary key auto_increment,
    id_cidade int,
    nome varchar(50) not null,
    username varchar(50) not null,
    senha varchar(50) not null,
    constraint fk_local_user foreign key (id_cidade) references local(id)
);

create table if not exists condicao(
	id int primary key auto_increment,
    id_local int not null,
    id_user int,
	condicao_api varchar(20) not null,
    condicao_user varchar(20) not null,
    -- data_hora datetime not null,
    constraint fk_cond_local foreign key (id_local) references local(id),
    constraint fk_cond_user foreign key (id_user) references usuario(id)
);

create table if not exists sensacao(
	id int primary key auto_increment,
	id_local int not null,
    id_user int,
	temperatura_api int not null,
    temperatura_user int,
    sensacao_user varchar(20),
    -- data_hora datetime not null,
    constraint fk_sens_local foreign key (id_local) references local(id),
	constraint fk_sens_user foreign key (id_user) references usuario(id)
);

DELIMITER $$
CREATE PROCEDURE nova_discrepancia_sencacao (IN  nome_local varchar(50) , IN temp_user int, IN temp_api int)
BEGIN

declare ids int;
set ids = (select id from local where nome = nome_local);
insert into sensacao values(default, ids, null, temp_api, temp_user, null);

update local set discrepancias = discrepancias + 1 where id = ids;
END $$
DELIMITER ;


DELIMITER $$
CREATE PROCEDURE insert_local (nome varchar(50) ,discrepancias int, concordancias int)
BEGIN

insert into local values(default, nome, discrepancias, concordancias);
select @@identity;

END $$
DELIMITER ;

-- call insert_local("Taubaté", 0, 0);
-- call insert_local('Texas', 0, 0);
-- call nova_discrepancia_sencacao ("Rio de Janeiro", 25, 20);


insert into local values(default, "São Paulo", 22, 22);
insert into local values(default, "Rio de Janeiro", 22, 22);
insert into local values(default, "Curitiba", 22, 22);
insert into local values(default, "Taubaté", 22, 22);

select * from local;
select * from sensacao;

-- truncate table local;
-- drop table sensacao;
-- drop table condicao;
-- drop procedure nova_discrepancia_sencacao;
-- drop database web_api;