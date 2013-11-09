<?xml version="1.0"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xi="http://www.w3.org/2001/XInclude" exclude-result-prefixes="xi">
<xsl:output method="html" doctype-system="about:legacy-compat" />

<xsl:template match="/documentation">
<html>
<head>
    <title>Documentation</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="//netdna.bootstrapcdn.com/bootstrap/3.0.2/css/bootstrap.min.css" rel="stylesheet" />
	<style>
	    <!-- From http://getbootstrap.com/examples/navbar/navbar.css -->
	    body {
		    padding-top: 20px;
			padding-bottom: 20px;
		}
		
		.navbar {
		    margin-bottom: 20px;
		}
	</style>
    <xsl:comment><![CDATA[[if lt IE 9]>
        <script src="//oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="//oss.maxcdn.com/libs/respond.js/1.3.0/respond.min.js"></script>
<![endif]]]></xsl:comment>
</head>
<body>
    <div class="container">
		<xsl:for-each select="xi:include[@href][@parse='xml' or not(@parse)]">
		    <xsl:apply-templates select="document(@href)" />
		</xsl:for-each>
	</div>
    <script src="//code.jquery.com/jquery-1.10.2.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.0.2/js/bootstrap.min.js"></script>
</body>
</html>
</xsl:template>

<xsl:template match="/doc">
    <xsl:for-each select="assembly">
	    <div class="navbar navbar-default">
		    <a class="navbar-brand" href="#">
			    <xsl:value-of select="name" />
		    </a>
	    </div>
	</xsl:for-each>
	
	<div class="clearfix" />
</xsl:template>

</xsl:stylesheet>