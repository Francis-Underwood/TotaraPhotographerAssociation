Instructions for setting up application database:
1. Install & set up SQL Server 2014.
2. Execute the script in .\db\TotaraPhoto_Schema.sql, plz note you may need to replace the following physical path of the .mdf and .ldf file in the script, depending on the location you install your SQL Server 2014.
ON  PRIMARY 
( NAME = N'TotaraPhoto', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRE2014VINC\MSSQL\DATA\TotaraPhoto.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TotaraPhoto_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRE2014VINC\MSSQL\DATA\TotaraPhoto_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)

3. Execute the script in .\db\TotaraPhoto_Data.sql
4. Update the db connection string in \TotaraPhotographyAssociation\Web.config according to your settings.
5. You should be able to log in with two accounts: aaron@example.com,	daisy@example.com, with password [Freud 1900]. And an admin account vince@example.com and password [Freud 1900].
