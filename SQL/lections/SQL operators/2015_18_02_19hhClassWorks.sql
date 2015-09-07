use db19hours

create proc [Add]
	@a int,
	@b int,
	@res1 int out,
	@res2 int out
as
begin
	set @res1 = @a + @b
	set @res2 = @a - @b
end

drop proc [Add]

declare @res1 int, @res2 int
exec [Add] 11, 22, @res1 out, @res2 out
print convert(char(4), @res1) + ' ' +convert(char(4), @res2) 



create proc spGetTotalCount
@totalCount int out
as
begin
	select @totalCount = count(id) from Workers
end

select * from Workers

declare @res int
exec spGetTotalCount @res out
print @res

-----------------------------------
create proc spGetTotalCount2
as
begin
	return (select count(id) from Workers)
end

declare @res int
exec @res = spGetTotalCount2
print @res


------------------------------------
--== Functions ==--
create function whichConinent( @Country nvarchar(16) )
returns nvarchar(16) 
as
begin
	declare @res nvarchar(16)

	select @res = case @Country
		when 'Argentina' then 'South America'
		when 'Germany' then 'Europe'
		when 'Canada' then 'North America'
		else 'unknown'
	end

	return @res
end


print dbo.whichConinent('Germany')

----------------------------------------------
--== Transaction ==--
begin transaction

-- 1
-- select * from Workers
update Workers
set Age = 15

-- 2
update Workers
set Name = 'Pupkin+'
where Name = 'Pupkin'

commit transaction


begin transaction

-- 1
-- select * from Workers
update Workers
set Age = 25
where id in (1, 4)

save transaction pt1 -- save point 1

-- 2
update Workers
set Name = 'Pupkin++'
where Name = 'Pupkin+'

save transaction pt2 -- save point 2

-- select * from Orders
insert into Orders values
('test', 4) -- no id in Workers table!!!

if @@ERROR != 0
	rollback transaction pt1
else
	commit transaction

select * from Workers
select * from Orders

delete from Orders
where id = 7

DBCC CHECKIDENT(Orders, RESEED, 5)

--== Cursors ==--
declare @Id int, 
		@Name nvarchar(16),		
		@phone nvarchar(16)

declare myCursor Cursor for
	select Id, Name, Phone
	from Workers

open myCursor

fetch next from myCursor into @Id, @Name, @Phone

while @@FETCH_STATUS = 0
begin
	print convert(nvarchar(4), @Id) + ': ' + @Name + ' ' + @Phone
	
	fetch next from myCursor into @Id, @Name, @Phone
end

close myCursor
deallocate myCursor


-- 2 way
create table #tmpTable (
	Id int,
	Name nvarchar(16),
	Phone nvarchar(16)
)


declare  @RecNum int, -- total amount
		 @RowCount int -- index
declare @Id int, @Name nvarchar(16), @phone nvarchar(16)

insert into #tmpTable(Id, Name, Phone) 
	( select Id, Name, Phone 
		from Workers
		where Id != 0 )

set @RecNum = @@ROWCOUNT
set @RowCount = 1

while @RowCount <= @RecNum
begin
	select @Id = Id, @Name = Name, @phone = Phone 
	from #tmpTable
	where Id = @RowCount

	begin 
		print convert(nvarchar(4), @Id) + ': ' + @Name + ' ' + @Phone
	end
	
	set @RowCount += 1
end

drop table #tmpTable

select * from Workers
