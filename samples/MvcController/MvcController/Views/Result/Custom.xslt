<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:param name="publish" select="'秀和システム'" />
  <xsl:output method="html" indent="yes"/>

  <xsl:template match="/">
    <html>
    <head>
    <meta charset="utf-8" />
    <title> 書籍情報 </title>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" />
    </head>
    <body>
    <div class="container">
      <h3> 書籍情報 </h3>
      <table class="table">
        <tr>
          <th>ISBNコード</th>
          <th>タイトル</th>
          <th>価格</th>
          <th>出版社</th>
          <th>刊行日</th>
        </tr>
        <xsl:for-each select="books/book[publish=$publish]">
          <tr>
            <td><xsl:value-of select="@isbn"/></td>
            <td><xsl:value-of select="title"/></td>
            <td><xsl:value-of select="format-number(price, '#,###円')"/></td>
            <td><xsl:value-of select="publish"/></td>
            <td><xsl:value-of select="published"/></td>
          </tr>
        </xsl:for-each>
      </table>
    </div>
    </body>
    </html>      
  </xsl:template>
</xsl:stylesheet>

