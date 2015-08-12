# WilliamHill
Coding test


# WilliamHill.ReaderService
This service reads the two CSV files. It has been implemented using TopShelf to host the service, and Quartz to schedule it's execution (configurable via app.config). AppSetting: CsvImporter
For more information on scheduling, visit http://www.quartz-scheduler.org/documentation/quartz-1.x/tutorials/crontrigger

On import, the bets are loaded into memory and saved in the database. The CSV file is then deleted.

The Service will fail if the input directory has not been set in app.config - AppSetting: CsvFileLocation


