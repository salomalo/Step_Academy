<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:include href="simple.xslt" />
	<xsl:template match="/">
		<xsl:text>Color is </xsl:text>
		<xsl:value-of select="$color" />
	</xsl:template>
</xsl:stylesheet>
