<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" 
								xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.01//EN" indent="yes"/> <!-- вказуємо метод трансформації -->

	<xsl:template match="/"> <!-- шаблон для кореневого елемента -->
		<!-- Основний html документ. Його тіло -->
		<html>
			<head>
				<title>groups demo</title>
			</head>
			<body>
				<xsl:apply-templates /> <!-- застосувати на цьому місці інші
                                              (описані нижче) шаблони (рекурсивно) -->
			</body>
		</html>
	</xsl:template>



	<!-- Трансформація документу. Опис вмісту -->
	<xsl:template match="group"> <!-- Обробляємо тег group – кореневий елемент -->
		<h1>GROUP: <xsl:value-of select="./@name" /></h1> <!-- назва групи -->
		<font color="#FF0000">
		    Specialization: <xsl:value-of select="./@spec"/> <!-- спеціалізація -->
		</font>
		
		<!-- Будуємо таблицю з інформацією про студентів -->
		<table border="1" style="bordercolor:#FF0000;">
			<tbody>
				<tr>
					<th>NameStudent</th><th>Description</th>
				</tr>


				<xsl:for-each select="./student">
					<tr>
						<td>
							<xsl:value-of select="@name"/>
						</td>
						<!-- ім’я та прізвище -->
						<td>
							<xsl:value-of select="." />
						</td>
						<!-- Текстове значення контекстного вузла -->
					</tr>
				</xsl:for-each>
				
				
				
			</tbody>
		</table>
	</xsl:template>


	
</xsl:stylesheet>
