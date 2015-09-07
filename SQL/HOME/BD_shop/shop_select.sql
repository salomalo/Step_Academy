
-------- SELECT--------------------

---------- 1 Вивести перелік всіх одиниць вимірювання.-------------------
select * from Measures

---------- 2 Вивести перелік всіх контрагентів.-------------------
select * from Customers
select * from Producers

---------- 3 Провести вибірку всіх товарів, для яких не вказаного виробника
SELECT * from Products where ProducerId is NULL


------??? ---- 4 Вивести перелік всіх товарів, що належать заданій групі (за значенням відповідного зовнішнього ключа).



---------- 5 Вивести перелік пакувань товарів, об’єм яких менший за 20.-------------------
select * from Packeges
Where Volume<50


---------- 6. Визначити перелік всіх закупок товарів (InputOrder), що були здійснені у заданий період.
select * from InputOrders
Where CreationTime = '11.02.2015'

---------- 7. Визначити всі склади заданої фірми. ????? як задавати склади -------------------



---------- 8. Визначити перелік вихідних замовлень (OutputOrder), що були здійснені заданим контрагентом.
select * from OutputOrders
where OutputOrders.CustumerId = ( 
						select
						Customers.Id 
						from Customers
						where Customers.Name ='Хороша фірма'
						)

-------додати ынфу додаткову--- 9  Визначити перелік всіх товарів, для яких вказано додаткову інформацію, відсортувавши його за назвою товару.



---------- 10.Визначити перелік всіх виробників, у назві яких є заданий текстовий фрагмент. -------------------
select * from Producers
where Producers.Name LIKE '%у%'

---------- 11 Визначити виробників, для яких не заповнене поле “Address”. -------------------
select * from Producers
where Producers.Address is null

---------- 12 Визначити перелік всіх пакувань товарів, у назві яких зустрічається задане слово.
select * from Producers
where Producers.Name LIKE '%producers%'



---------JOIN--------------------

---------- 13 -------------------
SELECT p.id, pr.Name, ca.Name, prod.Name, p.Volume, me.Name from Packeges p
inner join Products pr
on p.ProductId = pr.Id
inner join Categorys ca
on pr.CategoryId = ca.Id
inner join Producers prod
on pr.ProducerId = prod.Id
inner join Measures me
on p.VolumeMeasureID = me.Id


---------- 14 + wartehous -------------------
SELECT ord.Id, ord.CreationTime, cu.Name from OutputOrders ord
inner join Customers cu
on ord.CustumerId = cu.Id


---------- 15 + Сумарна вартість.-------------------
SELECT ordit.PackegeId,pr.Name, pa.Volume,me.Name, ordit.Quantity, ordit.UnitCost FROM OutputOrderItem ordit
inner join Packeges pa
on ordit.PackegeId = pa.Id
inner join Products pr
on pa.ProductId = pr.Id
inner join Measures me
on pa.VolumeMeasureID = me.Id


---------- 16 Визначити, скільки разів відбувалася зміна ціни для кожного з пакувань товарів.-------------------

UPDATE Prices 
SET UnitCost = UnitCost*2
WHERE Prices.PackegeId = 1


SELECT * from Prices

select p.PackegeId, count(p.PackegeId) from Prices p
group by p.PackegeId



-------17. Вивести таблицю із статистичними даними щодо зміни цін товарів за 
----вказаний період. В таблиці повинні бути такі поля:

select p.PackegeId, avg(p.UnitCost), min(p.UnitCost), max(p.UnitCost), count(p.PackegeId) from Prices p
where p.PriceTime between '2014-01-01' and '2016-01-01'
group by p.PackegeId



----18. Вивести сумарні залишки товарів на всіх складах, залишок яких менший за 50:

select w.PackegeId, sum(w.Quantity) from WarehouseItem w
group by w.PackegeId


---19 Сформувати прайс всіх товарів:



--20.Вивести перелік всіх замовлень (OutputOrder), вказавши їх сумарну вартість.



--21.Визначити середню ціну товарів за заданий період.
select p.PackegeId, avg(p.UnitCost) from Prices p
where p.PriceTime between '2014-01-01' and '2016-01-01'
group by p.PackegeId



--22.Знайти сумарні залишки товарів.
select * from WarehouseItem


--23.Визначити кількість товарів в асортименті.



--24.Знайти сумарну вартість всіх закуплених товарів (InputOrder) за вказаний період.
select  tp.PackegeId, sum(tp.totalprice) as sumtotal  from (select i.PackegeId, (i.Quantity*i.UnitCost) as totalprice from OutputOrderItem i) as tp

group by tp.PackegeId
order by sumtotal  desc

--inner join OutputOrders oo
--WHERE i.OutputOrderId=oo.CustumerId and oo.CreationTime='10/02/2015'


-- 25 Визначити середню сумарну вартість всіх вихідних замовлень (OutputOrder).
select  tp.PackegeId, sum(tp.totalprice) as sumtotal  from (select i.PackegeId, (i.Quantity*i.UnitCost) as totalprice from InputOrderItem i) as tp
group by tp.PackegeId
order by sumtotal  desc


---26 Визначити кількість всіх вихідних замовлень (OutputOrder) за вказний період.

select  tp.PackegeId, sum(tp.totalprice) as sumtotal  from (select i.PackegeId, (i.Quantity*i.UnitCost) as totalprice from InputOrderItem i) as tp
group by tp.PackegeId
order by sumtotal  desc


-------------------------------------------------------------------------------------
--4. Вкладені підзапити

--27.Визначити всі замовлення (OutputOrder), сумарна вартість яких не перевищує 1000 у.о.

--28.Визначити товари, на закупку яких було затрачено найбільше коштів.

--29.Визначити товари, яких було продано найбільше.

--30.Визначити товари, для значення залишку на складі найбільше.

--31.Знайти контрагентів, що зробили найбільшу кількість замовлень.

--32.Визначити контрагентів, середня сумарна вартість замовлень (OutputOrder) яких найменша.

--33.Знайти товари із мінімальною середньою ціною.

--34.Представити перелік всіх товарів, які хоч раз брали участь в замовленнях (OutputOrder).

--35.Представити всіх контрагентів, які зробили більше двох закупок товарів (OutputOrder).

--36.Представити замовників, сумарна вартість закупок якого найбільша.

--37.Визначити замовника, що останнім зробив купівлю заданого товару (товар визначається за PackageID).

--38.Визначити товар, сумарна закупівельна вартість якого найбільша.


-------------------------------------------------------------------------------
--5. Зв’язані підзапити

--1. Отримати групи товарів, у яких немах товарів.
--select  * from Categorys ca
--inner join Products pr
--on pr.CategoryId = ca.Id

--inner join Packeges pac
--on pac.ProductId = pr.CategoryId
--where sum(pac.

--2. Отримати виробників, для яких є більш як 5 товарів.
--select * from Producers pr
--inner join Products prod
--on prod.ProducerId=pr.Id
--where pr.Name


--3. Отримати товари, для яких не вказано ціни.
select * from Products p
inner join Packeges pa
on pa.ProductId=p.Id
inner join Prices pr
on pr.PackegeId=pa.Id
where pr.UnitCost is NULL

--4. Отримати поточну ціну для кожного товару.
select p.Name,pr.UnitCost from Products p
inner join Packeges pa
on pa.ProductId=p.Id
inner join Prices pr
on pr.PackegeId=pa.Id

--5. Для кожного контрагента вивести його перше замовлення для закупівлі товару (OutputOrder).
select cu.Name,oo.Id as 'orderID',ooi.Id as 'items',pro.Name from Customers cu
inner join OutputOrders oo
on oo.CustumerId=cu.Id
inner join OutputOrderItem ooi
on ooi.OutputOrderId=oo.Id
inner join Packeges pac
on pac.ProductId = ooi.PackegeId
inner join Products pro
on pro.Id=pac.ProductId
where ooi.OutputOrderId=1


--6. Для кожного із товарів визначити, в якого контрагента вони були



--7. востаннє закуплені.




