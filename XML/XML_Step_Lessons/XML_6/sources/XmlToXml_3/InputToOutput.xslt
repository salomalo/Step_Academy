<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
	
	<xsl:template match="/">
		<xsl:processing-instruction name="xml-stylesheet">
			<xsl:text>type="text/xsl" href="style.xsl"</xsl:text>
	    </xsl:processing-instruction>
		<xsl:apply-templates />
	</xsl:template>

   <xsl:template match="@* | *">
		<xsl:copy>
			<xsl:apply-templates select="@* | node()"/>
		</xsl:copy>
  </xsl:template>

</xsl:stylesheet>
