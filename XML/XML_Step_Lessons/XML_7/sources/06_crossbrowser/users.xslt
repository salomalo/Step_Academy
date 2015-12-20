<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>Users</title>
			</head>
			<body>
				<xsl:apply-templates select="/users" />
			</body>
		</html>
	</xsl:template>
	
	<xsl:template match="users">
			<table border="1">
			<tbody>
				<tr style="background-color: lightgray;">
					<th>Код</th>
					<th>Повне ім'я</th>
					<th>Логін</th>
					<th>Пароль</th>
				</tr>
				<xsl:apply-templates select="/users/*" />
			</tbody>
		</table>
	</xsl:template>
	
	<xsl:template match="user">
		<tr>
			<xsl:choose>
				<xsl:when test="role = 'user'">
					<xsl:attribute name="style">background-color: white</xsl:attribute>
				</xsl:when>
				<xsl:when test="role = 'student'">
					<xsl:attribute name="style">background-color: lightblue</xsl:attribute>
				</xsl:when>
				<xsl:when test="role = 'admin'">
					<xsl:attribute name="style">background-color: red</xsl:attribute>
				</xsl:when>
				<xsl:otherwise>
					<xsl:attribute name="style">background-color: magenta</xsl:attribute>
				</xsl:otherwise>
			</xsl:choose>
				
			<td><xsl:value-of select="@id" /></td>
			<td><xsl:value-of select="name" /></td>
			<td><xsl:value-of select="login" /></td>
			<td><xsl:value-of select="password" /></td>
		</tr>
	</xsl:template>
</xsl:stylesheet>
