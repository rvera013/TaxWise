# TaxWise
Application that allows the user to retrieve values from a comma-defined csv file that stores a company's financial information, and gives each employee their salaries based on their current position and their bonuses based on their performance scores. Then calculations on how much is paid in total to each employee are made, and it evn allows the user to save the graphs into a new .csv file.
## Features
- Open button: opens a dialog that shows the user the current directory so they can select a csv file to be read.
- Statistics: After clicking "View" in the menu strip above, it will show the "Statistics" button, which shows the user a series of metrics per department (Job Code) as well as overall stats for the entire company
- Save button: Shows a dialog that starts in the current directory, allowing the user to save the current report's into .csv one. Key issue would be opening those reports in the same program, since some data fields are modified to have commas, thus being interpreted the program as a separate column from the .csv file.
- Clear: wipes out the screen safe for the created based on the first line of the .csv file being read.
