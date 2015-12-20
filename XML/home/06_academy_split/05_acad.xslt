<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html" doctype-public="-//W3C//DTD HTML 4.01//EN" indent="yes"/>

  <xsl:template match="/">
    <html>
      <head>
        <title>Academia</title>
      </head>
      <body>
        <xsl:apply-templates />
      </body>
    </html>
  </xsl:template>

  <xsl:template match="group">
    <h1>Group: <xsl:value-of select="./@name" /></h1>
    <font>Specialization: <xsl:value-of select="./@specialization"/></font>

    <table border="1" style="bordercolor:#FF0000;">
      <tbody>
        <tr>
          <th>NameStudent</th>
          <th>Address</th>
          <th>Telephone</th>
          <th>Scolarship</th>
        </tr>
        <xsl:apply-templates />
      </tbody>
    </table>
  </xsl:template>

  <xsl:template match="student">
    <tr>
      <td><xsl:value-of select="name"/></td>
      <td><xsl:apply-templates select="./address"/></td>
      <td><xsl:value-of select="./address/telephone"/></td>
      <td><xsl:value-of select="./address/scolarship"/></td>
    </tr>
  </xsl:template>

  <xsl:template match="address">
    <xsl:value-of select="country"/>
    <xsl:value-of select="street"/>
    <xsl:value-of select="house"/>
  </xsl:template>

  <xsl:template match="subjects_list">
    <h1>Subjects</h1>

    <table border="1" style="bordercolor:#FF0000;">
      <tbody>
        <tr>
          <th>subject</th>
          <th>kurs_plan</th>
        </tr>
        <!--<xsl:apply-templates />-->

        <xsl:for-each select="./*">
          <!--<td><xsl:value-of select="."/></td>-->

          <xsl:if test="local-name(.) = 'subject' ">
            <xsl:text disable-output-escaping="yes">&lt;tr&gt;</xsl:text>
            <td><xsl:value-of select="."/></td>
          </xsl:if>
          <xsl:if test="local-name(.) = 'kurs_plan' ">
            <td><xsl:value-of select="."/></td>
            <xsl:text disable-output-escaping="yes">&lt;/tr&gt;</xsl:text>
          </xsl:if>

        </xsl:for-each>

      </tbody>
    </table>
  </xsl:template>

  <xsl:template match="subject">
    <tr>
      <td>
        <xsl:value-of select="subject[text()]"/>
      </td>
    </tr>
  </xsl:template>
  
  <xsl:template match="teachers_list">
    <h1>Teachers List</h1>

    <table border="1" style="bordercolor:#FF0000;">
      <tbody>
        <tr>
          <th>name</th>
          <th>his_subjects</th>
          <th>count_group</th>
        </tr>
        <xsl:apply-templates />

      </tbody>
    </table>
  </xsl:template>

  <xsl:template match="teacher">
    <tr>
      <td>
        <xsl:value-of select="name"/>
      </td>
      <td>
        <xsl:apply-templates select="./his_subjects"/>
      </td>
      <td>
        <xsl:value-of select="./count_group"/>
      </td>
    </tr>
  </xsl:template>
  
</xsl:stylesheet>