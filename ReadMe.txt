Instructions for setting up application database:
1. Install & configure SQL Server 2014.
2. Execute the script in \db\TotaraPhoto_Schema.sql, plz note you may need to replace the following physical path of the 
   .mdf and .ldf file in the script, depending on the location you install your SQL Server 2014.
   ON  PRIMARY 
   ( NAME = N'TotaraPhoto', FILENAME = N'<path to your SQL Server 2014 instance>\MSSQL\DATA\TotaraPhoto.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
   LOG ON 
   ( NAME = N'TotaraPhoto_log', FILENAME = N'<path to your SQL Server 2014 instance>\MSSQL\DATA\TotaraPhoto_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
3. Execute the script in \db\TotaraPhoto_Data.sql.
4. Update the db connection string in \TotaraPhotographyAssociation\Web.config according to your settings.
5. You should be able to log in with two accounts: aaron@example.com, daisy@example.com, with the same password [Freud 1900]. 
   And an admin account, and its login name is vince@example.com and password is [Freud 1900].

Instructions for running the unit test cases with Selenium:
1. Unzip \SeleniumDrivers.7z, and put the IEDriverServer.exe to some place you prefer.
2. Update IEDriverServer.exe directory, and a directory to save screenshots on your disk in file UIBrowserTest.cs:
   public class UIBrowserTest
   {
       private const string IE_DRIVER_PATH = @"<put your driver server directory here>";
	   private const string SCREENSHOT_LOCATION = @"<put your screenshot directory here>";
   }
3. Right click the mouse on the main project, and select View -> View in Browser (Internet Explorer).
4. Go to menu: Test -> Run -> All Tests
5. I have three test cases in total, and test TestShoppingCheckout will not run successfully. This three cases have covered all
   the common scenarios, which are testable and repeatable.