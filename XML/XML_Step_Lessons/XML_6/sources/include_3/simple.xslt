<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="title">
	   Title: <xsl:value-of select="."/><br />
	</xsl:template>
	
	<xsl:template match="author">
		Author: <xsl:value-of select="."/><br />
	</xsl:template>
	
	<xsl:template match="price">
	   Price: <xsl:value-of select="."/><br />
	</xsl:template>

</xsl:stylesheet>
