<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:import href="copynode.xslt" />
   <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes" />
   
<!-- стаємо в корінь документа-->
   <xsl:template match="/">
   <!-- створюємо інструкцію по обробці -->
    <xsl:processing-instruction name="myxml">
      <xsl:text>version="2.0"</xsl:text>
    </xsl:processing-instruction>
    
    <xsl:apply-templates /> <!-- обробляємо всі інші вузли рекурсивно  -->
  </xsl:template>
  
  <xsl:template match="MyXML">
    <MyXML>
      <xsl:apply-templates /><!-- обробляємо всі дочірні вузли MyXML рекурсивно  -->
    </MyXML>
  </xsl:template>
  
  <xsl:template match="MyXMLMsgsRs">
    <MyXMLMsgsRq>
      <xsl:attribute name="onError">stopOnError</xsl:attribute>
     
    <!--  <xsl:call-template name="TransformObject" /> -->
      
      <!-- обробляємо всі дочірні вузли MyXMLMsgsRs рекурсивно  -->
      <xsl:call-template name="TransformObject0">
        <xsl:with-param name="entryPoint" select="VendorQueryRs" />
      </xsl:call-template>
      
      <xsl:call-template name="TransformObject1">
        <xsl:with-param name="entryPoint" select="CustomerQueryRs" />
      </xsl:call-template>
    </MyXMLMsgsRq>
  </xsl:template>

<!--<xsl:template name="TransformObject">
    <xsl:for-each select="VendorQueryRs//VendorRet">
      <VendorAddRq>
        <xsl:attribute name="requestID">
          <xsl:value-of select="VendorQueryRs/@requestID" />
        </xsl:attribute>
        <VendorAdd>
          <xsl:apply-templates />
        </VendorAdd>
      </VendorAddRq>
    </xsl:for-each>
  </xsl:template>  -->
  
  <xsl:template name="TransformObject0">
    <xsl:param name="entryPoint" />
    <xsl:for-each select="$entryPoint//VendorRet">
      <VendorAddRq>
        <xsl:attribute name="requestID">
          <xsl:value-of select="$entryPoint/@requestID" />
        </xsl:attribute>
        <VendorAdd>
          <xsl:apply-templates />
        </VendorAdd>
      </VendorAddRq>
    </xsl:for-each>
  </xsl:template>
  
  <xsl:template name="TransformObject1">
    <xsl:param name="entryPoint" />
    <xsl:for-each select="$entryPoint//CustomerRet">
      <CustomerAddRq>
        <xsl:attribute name="requestID">
          <xsl:value-of select="$entryPoint/@requestID" />
        </xsl:attribute>
        <CustomerAdd>
          <xsl:apply-templates />
        </CustomerAdd>
      </CustomerAddRq>
    </xsl:for-each>
  </xsl:template>
  
   <xsl:template match="TimeCreated | ItemID | VendorRet/Balance">
  </xsl:template>
  </xsl:stylesheet>
