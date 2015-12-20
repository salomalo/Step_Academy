<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" omit-xml-declaration="yes" />
	
	<xsl:template match="/">
	   <xsl:for-each select="books/book">
		  <xsl:apply-templates select="title" />
		  <xsl:apply-templates select="author" />
		  <xsl:apply-templates select="price" />
		  <br />
	   </xsl:for-each>
	</xsl:template>
	
	<xsl:include href="simple.xslt" />
</xsl:stylesheet>