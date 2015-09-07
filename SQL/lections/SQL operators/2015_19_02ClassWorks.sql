
create table #tmpTable(Id int, Name nvarchar(32))

insert into #tmpTable values(1, 'mike')
insert into #tmpTable values(2, 'john')
insert into #tmpTable values(3, 'todd')

select * from #tmpTable

select name from tempdb..sysobjects
where name like '%tmp%'

if OBJECT_ID('tempdb..#tmpTable', 'U') is not null -- перевірка на існування об'єкта
	drop table #tmpTable

-- AF => aggr func
-- C  => check constraint
-- F  => FK constraint
-- FN => scalar func
-- P  => stired  proc
-- PK
-- S  => system base type
-- TT => table type
-- U  => table (user defined)
-- V  => view
-- UQ => UNIQE constraint


--== Indexes ==--
create table IndexDemo
(
	id int primary key,
	name nvarchar(32),
	salary numeric(18, 4),
	gender nvarchar(8)
)


insert into IndexDemo values
 (2, 'sam',  2500, 'male')
,(5, 'pam',  6500, 'female')
,(1, 'jon',  4500, 'male')
,(3, 'mari', 5500, 'female')
,(4, 'todd', 3100, 'male')


select * from IndexDemo

create index ix_IndexDemo_salary
on IndexDemo(salary asc)


select salary from IndexDemo

print rand()

exec sp_helpindex IndexDemo


drop index IndexDemo.ix_IndexDemo_salary


alter table IndexDemo
add constraint uq_IndexDemo_name
unique (name)


select * from orders
--== triggers ==--
alter trigger trNeworder on orders
after insert
as
begin
	-- print 'new order added '  + USER_NAME()
	print @@identity
end



insert into Orders values ('trigger test', 4)

create trigger trForDelete on Orders
instead of delete
as
begin	
	print 'boo - ga - ga'
end

delete from Orders where id = 1

create table Order_artchive
(
	[Desc] nvarchar(64),
	workerId int
)

disable trigger trForDelete on Orders




create trigger trNeworder2 on Orders
after update
as
begin
	insert into Order_artchive ([Desc], WorkerId) 
	select [Desc], WorkerId from  inserted -- deleted  -- buffers !
end

select * from deleted

select * from Order_artchive
delete from Orders where id = 781



--== XML ==--
select * from Workers
for xml auto


select Id, Name, Phone, Age
from Workers
for xml raw('Worker'), root('Workers'), elements


select 777 as tag,
	NULL as parent,
	Id as [Worker!777!Id],
	Name as [Worker!777!Name!element]
from Workers
for xml explicit, root('Workers') 



create table xmlTable
(
	id int identity primary key,
	data xml not null
)


insert into xmlTable(data) values
(
	'<Workers role="admin">
		<Worker name="Zupkin" />
		<Worker name="Buplin" />
	</Workers>'
)

select * from xmlTable

select data.query('Workers/Worker')
from xmlTable


select * from xmlTable
where data.exist('Workers/Worker[@name="Bupkin"]') = 1


