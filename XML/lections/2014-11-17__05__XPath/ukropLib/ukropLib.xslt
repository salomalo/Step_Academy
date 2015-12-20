<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<!-- метод трансформації -->
	<xsl:output method="html" indent="yes"/>

	<!-- шаблон для кореневого елемента -->
	<xsl:template match="/">

		<!-- Основний html документ. Його тіло -->
		<html>
			<head>
				<title>Ukrop Library</title>
				<style>
					table,td{ border: 1px solid black; border-collapse: collapse;}
				</style>
			</head>
			<body>
				<xsl:apply-templates /> <!-- застосувати на цьому місці інші (описані нижче) шаблони (рекурсивно) -->
			</body>
		</html>
		<!-- Основний html документ. Його тіло -->

	</xsl:template>


	<!-- Кореневий елемент -->
	<xsl:template match="ukropLib">
		
		
		<h1>Бібліотека «укропа»</h1>

		<!-- Будуємо таблицю з інформацією про книги -->
		<table border="1" style="bordercolor:#FF0000;">
			<tbody>
				<tr>
					<th>Назва</th>
					<th>Автор</th>
				</tr>
				
				<xsl:apply-templates /><!-- застосувати на цьому місці інші (описані нижче) шаблони (рекурсивно) -->
				
			</tbody>
		</table>
	</xsl:template>


	<!-- Шаблон для трансформації даних про кожну книгу-->
	<xsl:template match="book">
		
		<!-- Кожен тег book у документ-результат виведеться як рядок таблиці -->
		<tr>
			<td>
				<xsl:value-of select="./title"/>
			</td>
			<td>
				<xsl:value-of select="./author/firstName"/>
				<xsl:text> </xsl:text> <!--виводимо пропуск між іменем та прізвищем автора-->
				<xsl:value-of select="./author/lastName"/>
			</td>
		</tr>
	</xsl:template>



</xsl:stylesheet>