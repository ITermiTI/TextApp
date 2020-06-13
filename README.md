# Text App

## This is a simple text web application using ASP.NET CORE

### Description
Simple authentication and authorization process was implemented. After successful login you will be redirected to your texts
sorted by date of addition (newest at the top). You can add more texts in another tab. There is also a simple user info in the footer.As an administrator you have one extra tab, where one can find all the texts entered by the users.

### Installation
Download the code -> Enter your database SQL Server credentials in appsettings.json -> Run the code -> Enjoy the App!

#### Entering credentials to your database

Default - by default the app will try to connect to localhost as an sa user with no passwords. In case of omitting User Id default value is sa.

          "dbconn": "server=.;database=TextAppDb;Trusted_Connection=True;MultipleActiveResultSets=True;" 
    
Custom - in fields YOURUSERNAME, YOURPASSWORD, YOURSERVERNAME enter your credentials for your user in your server.
    
    "dbconn": "User Id=YOURUSERNAME;Password=YOURPASSWORD;server=YOURSERVERNAME;database=TextAppDb;Trusted_Connection=True;MultipleActiveResultSets=True;"

### Insides -> Application UI

#### Welcome screen

![alt text](https://github.com/ITermiTI/TextApp/blob/master/1.PNG)

#### List of your texts

![alt text](https://github.com/ITermiTI/TextApp/blob/master/2.PNG)

#### List of all texts seen by administrator
![alt text](https://github.com/ITermiTI/TextApp/blob/master/3.PNG)
