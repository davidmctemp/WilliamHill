# WilliamHill
Coding test

# WilliamHill.ReaderService
This service reads the two CSV files. It has been implemented using TopShelf to host the service, and Quartz to schedule it's execution (configurable via app.config). AppSetting: CsvImporter
For more information on scheduling, visit http://www.quartz-scheduler.org/documentation/quartz-1.x/tutorials/crontrigger

On import, the bets are loaded into memory and saved in the database. The CSV file is then deleted.

The Service will fail if the input directory has not been set in app.config - AppSetting: CsvFileLocation


# SETUP INSTRUCTIONS
# Database
Restore the database in the solution and configure connection strings in app.config of the ReaderService, and the web.config of the website. 

# ReaderService
Copy the two CSV files into c:\temp\williamhill\

Run the ReaderService first - this will parse all the data and populate the database. 
The folder will be monitored for new files. 

Run the website to view Settled / UnSettled bet data.
