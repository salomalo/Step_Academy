USE AutoCar
GO

SELECT * FROM Cars



SELECT Color as 'My Color' 
FROM Cars cs
WHERE cs.Color > 2

SELECT cs.Color as 'My Color Id' , c.Name 'Color'   --перехресний запит
FROM Cars cs, Color c
WHERE cs.Color = c.IdColor  --вказуЇмо наш зв€зок м≥ж таблиц€ми

SELECT cr.IdCars , br.Name 'Brend', m.Name 'Model', p.Name 'Packaging',
		 te.Name 'TypeEngine', cr.Litres, cr.Power, cr.Year, b.Name 'Body', c.Name 'Color', cr.Price
FROM Cars cr, Color c, Brend br, [TypeEngine] te, [Model] m, [Packaging] p, [Body] b
WHERE cr.Brend = br.IdBrend AND cr.Model = m.IdModel AND cr.Packaging = p.IdPackaging AND 
		te.IdTypeEngine = cr.Engine AND cr.Type = b.IdBody AND cr.Color = c.IdColor

		
SELECT cr.IdCars , br.Name 'Brend', m.Name 'Model', p.Name 'Packaging',
		 te.Name 'TypeEngine', cr.Litres, cr.Power, cr.Year, b.Name 'Body', c.Name 'Color', cr.Price
FROM Cars cr, Color c, Brend br, [TypeEngine] te, [Model] m, [Packaging] p, [Body] b
WHERE cr.Brend = br.IdBrend AND cr.Model = m.IdModel AND cr.Packaging = p.IdPackaging AND 
		te.IdTypeEngine = cr.Engine AND cr.Type = b.IdBody AND cr.Color = c.IdColor
ORDER BY cr.Litres DESC , cr.Year ASC, cr.Price DESC




SELECT SUM(Price) as 'Total sum'
FROM Cars

SELECT COUNT(cr.IdCars) as 'Cars Count',c.Name 'Color'
FROM Cars cr, Color c
WHERE c.IdColor = cr.Color
GROUP BY c.Name



SELECT COUNT(cr.IdCars) as 'Cars Count',c.Name 'Color'
FROM Cars cr, Color c
WHERE c.IdColor = cr.Color
GROUP BY c.Name

HAVING COUNT(cr.IdCars) > 2


SELECT COUNT(cr.IdCars) as 'Cars Count',c.Name 'Color'
INTO tmpCar   --створюЇтьс€ тимчасова таблиц€, в €ку записуютьс€ вибран≥ дан≥
FROM Cars cr, Color c
WHERE c.IdColor = cr.Color
GROUP BY c.Name

select * from tmpCar

SELECT * FROM tmpCar
WHERE [Cars Count] > 2


SELECT DISTINCT TOP(3)  Year FROM 
Cars 

SELECT * FROM Cars


SELECT COUNT(Cars.IdCars) , Cars.Color
FROM Cars
WHERE ANY 