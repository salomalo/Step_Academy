create database db19hours
go

create table Employee
(
	id int identity(1, 1) primary key,
	Name nvarchar(16) not null,
	ManagerId int
)

-- drop table Employee

use db19hours
insert into Employee values
('Mike', 3),
('Rob', 1),
('Todd', null),
('Ben', 1),
('Sam', 1)


select e.Name, m.Name as Manager
from Employee as e
left join Employee as m
on e.ManagerId = m.id

-- 1
select e.Name, ISNULL(m.Name, 'boss') as Manager
from Employee as e
left join Employee as m
on e.ManagerId = m.id


-- 2
select e.Name, 
	case
		when m.Name is null then 'big boss'
		else m.Name
	end
	as Manager

from Employee as e
left join Employee as m
on e.ManagerId = m.id
 

-- 3
select coalesce(null, 'see this')

select e.Name, coalesce(m.Name, 'boss') as Manager
from Employee as e
left join Employee as m
on e.ManagerId = m.id


create table test 
(
	id int identity(1, 1) primary key,
	FirstName nvarchar(16),
	MiddleName nvarchar(16),
	LastName nvarchar(16)
)


insert into test values
	(null, null, null)
	,
	(null, 'tod', null),
	(null, null, 'mike'),
	('pupkin', null, 'vasyl"'),
	('bulkin', 'petrovych', null)

select id, coalesce(FirstName, MiddleName, LastName) as 'name' 
from test


--== UNIN vs UNION ALL ==--

create table CustomersUA
(
	id int identity(1, 1) primary key,
	Name nvarchar(16),
	email nvarchar(16)
)

create table CustomersGER
(
	id int identity(1, 1) primary key,
	Name nvarchar(16),
	email nvarchar(16)
)


insert into CustomersUA values
('Ben', 'b@b.com'),
('Sam', 's@s.com')

insert into CustomersGER values
('Todd', 't@t.com'),
('Sam', 's@s.com')

drop table CustomersGER
drop table CustomersUA

select  * from CustomersGER
union 
select  * from CustomersUA

select  * from CustomersGER
union all
select  * from CustomersUA



create table Workers
(
	id int identity(1, 1) primary key,
	name nvarchar(16),
	phone nvarchar(16)
)

insert into Workers values
('Pupkin', '111-11-11'),
('Bupkin', '111-11-12'),
('Zupkin', '111-11-13'),
('Bulkin', '111-11-14')

select * from Workers

create table Orders
(
	id int identity(1, 1) primary key,
	[Desc] nvarchar(16),
	-- price numeric(18, 4),
	workerId int
)

alter table Orders
	add constraint fk_orders_workerId_workers_id
	foreign key (workerId) references workers(id)
	on delete cascade   

alter table Orders
	add constraint fk_orders_workerId_workers_id
	foreign key (workerId) references workers(id)
	on delete set null  

alter table Orders
	drop constraint fk_orders_workerId_workers_id


insert into Orders values 
('test1', 2),
('test2', 2),
('test3', 3),
('test4', 2),
('test5', 3)

drop table Workers
drop table Orders

delete from Workers
where id = 2

select * from Workers
select * from Orders

delete from Workers
where id = 2


alter table Workers
add Age2 int

alter table Workers
add constraint ck_workers_age check (age > 0 and age < 100)

insert into Workers (age) values (101)
go
--== T-SQL ==--
declare @var int, @str char(16)
-- select @var = 5, @str = 'Hello T-SQL'
set @var = 5
set @str = 'Hello T-SQL'
print convert(varchar(5), @var) + ' ' + @str 

declare @myTable table (
	id int,
	name nvarchar(16),
	phone nvarchar(16),
	age int
)

insert @myTable select * from Workers

select * from @myTable
go


select DATEADD(dd, 7, CURRENT_TIMESTAMP)
select DATEADD(ww, 1, CURRENT_TIMESTAMP)
select DATEADD(mm, 7 * 1 / 28 , CURRENT_TIMESTAMP)

print convert(varchar(30), getdate())
print convert(varchar(30), getdate(), 10)
print convert(varchar(30), getdate(), 110)
print convert(varchar(30), getdate(), 5)
print convert(varchar(30), getdate(), 105)
print convert(varchar(30), getdate(), 113)
print convert(varchar(30), getdate(), 114)

select * from Orders



select datediff(dd, '2015-02-14', getdate())
select datediff(dd, '2015/02/14', '2014-02-14')

-- yy, yyyy
-- qq
-- mm
-- mi, n
-- ss
-- ms 

select datepart(dw, getdate()) as 'day of week'

set language us_english
select datename(dw, getdate()) as 'day of week'

sp_helplanguage

if datename(dw, getdate()) = 'Tuesday'
begin
	print 'сьогодні вівторок'
end
else
begin
	print 'сьогодні не вівторок'
end

---------------------------------------------
--== goto ==--
print 'action'

goto label1
	print 'no action'

label1:
	print 'i am here'
print 'end of script'



--== loops ==--
declare @i int
set @i = 1

while @i <= 10
begin
	print @i
	set @i += 1
end
go

declare @i int
set @i = 1

while @i < 100
begin
	print @i
	set @i += 1

	if @i > 10
		break
end

--== Stores Procuderes ==--
go
create proc test3 
as
begin
	select id, name from Workers
end

execute test3
exec test3
test3

drop proc test3

create proc HelloWorld
as
begin
	print 'Hello Stored Procedures'
end


HelloWorld

create proc HelloUser
as
begin
	print 'Hello Stored Procedures'
end

