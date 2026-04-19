create database JabilMovies

use JabilMovies
go

create table Directors
(
	id int IDENTITY(1,1) primary key,
	name varchar(200),
	Nationality varchar(100),
	age int, 
	active bit
)

create table Movies 
(
	id int IDENTITY(1,1) primary key, 
	Name varchar(100), 
	release_year date, 
	gender varchar(50), 
	duration time, 
	directorId int,
	constraint fk_director foreign key (directorId) references Director(id)
)