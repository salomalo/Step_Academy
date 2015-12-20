<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>
	
	<xsl:template match="/">
		<transform>
		   <xsl:apply-templates/>
		</transform>
	</xsl:template>
	
	<xsl:template match="person">
		 <record>
			<id>
			   <xsl:value-of select="@username" />
			</id>
			<fullname>
			   <xsl:value-of select="name" /><xsl:text> </xsl:text><xsl:value-of select="surname" />
			</fullname> 
		 </record> 
	</xsl:template>
</xsl:stylesheet>
