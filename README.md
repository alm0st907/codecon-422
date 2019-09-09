# codecon-422
DEFCON scale based task tracker project for CptS 422

## Summary:
This will act initially as a standalone alternative to a Jira or similar issue based tracking system, however we plan to integrate with github/gitlab issues time permitting

Issues will be tied to DEFCON levels of severity and assigned due dates. DEFCON 5 is the best state and the project will hit all deadlines on time or early. DEFCON 1 represents project failure or immenent failure to meet deadline/spec.

Issues that are not resolved by due dates escalate the DEFCON level of the project which represents the health or launch readiness of the project by its projected deadline.

&nbsp;

Project Members
* Garrett Rudisill
* Mike Berger
* Slater Weinstock
* Jeff Kremer

# **STARTING GUIDE**

**Download node+npm for your os**
**Install SQL Server Express**
**Install mssql-tools**
**Attach CodeconDB to the sql server instance**

- `cd codecon`
  
# Installing Dependencies for ReactJS:

`bash install.sh`


# Building Locally:

- To begin running the app, `npm start` which builds on localhost
- With every saved change, the webpage is re-rendered

# Editing VSCode for JSX linting:
- VSCode->Settings->Extensions->settings.json
- Add the following to the settings.json for emmet:
  
    "emmet.includeLanguages": {
        "javascript": "javascriptreact"
    }
- In VSCode, install the vscode-styled-components extension 


# Common Build Errors Encountered:
- it's better to use VSCode's line commenting command as react can be very finicky depending on the placement of comments **(This is especially important when working with Konva which detects spaces as text and will fail)**

# How to write React code:
- React used to have stateless and stateful components.  There were referred to as functional vs class components.  Nowadays, functional components when used with React v>16.8 have access to hooks, which allow data management such that in the future functional components will have all the features of class components.  However, class components ***will*** work just fine and there are no plans to remove this.  If writing functional components with hooks, be careful as some third-party packages may ***not*** support them.



# Installing SQL Server Express
You can download SQL Server Express 2017 here: https://www.microsoft.com/en-us/sql-server/sql-server-editions-express
If you are on Ubuntu 18.04 follow these steps instead
Run the following commands:

1. Import the public repository GPG keys:

wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -

2. Register the Microsoft SQL Server Ubuntu repository:

sudo add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/16.04/mssql-server-2017.list)"

3. Run the following commands to install SQL Server:
bash

sudo apt-get update
sudo apt-get install -y mssql-server

4. After the package installation finishes, run mssql-conf setup and follow the prompts to set the SA password and choose your edition.

sudo /opt/mssql/bin/mssql-conf setup
**Be sure to select option 3-express(free)**

5. Once the configuration is done, verify that the service is running:

systemctl status mssql-server --no-pager

At this point, SQL Server is running on your Ubuntu machine and is ready to use

# Installing mssql-tools
1. Import the public repository GPG keys.

curl https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -

2. Register the Microsoft Ubuntu repository.

curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list | sudo tee /etc/apt/sources.list.d/msprod.list

3. Update the sources list and run the installation command with the unixODBC developer package.

sudo apt-get update 
sudo apt-get install mssql-tools unixodbc-dev

# Optional: Add /opt/mssql-tools/bin/ to your PATH environment variable in a bash shell.

To make sqlcmd/bcp accessible from the bash shell for login sessions, modify your PATH in the ~/.bash_profile file with the following command:

echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bash_profile

To make sqlcmd/bcp accessible from the bash shell for interactive/non-login sessions, modify the PATH in the ~/.bashrc file with the following command:

echo 'export PATH="$PATH:/opt/mssql-tools/bin"' >> ~/.bashrc
source ~/.bashrc

# Updating mssql-tools

To update to the latest version of mssql-tools run the following commands:

sudo apt-get update 
sudo apt-get install mssql-tools 

# Connecting to a local database

The following steps use sqlcmd to locally connect to your new SQL Server instance.

Run sqlcmd with parameters for your SQL Server name (-S), the user name (-U), and the password (-P). The user name is SA and the password is the one you provided for the SA account during setup.

sqlcmd -S localhost -U SA -P '<YourPassword>'

If successful, you should get to a sqlcmd command prompt: 1>

**Whenever you create a command in mssql-tools you must execute the command with a 'go' statement**

# Retore database from backup (.bak file)	<-- easy start

1. Detach CodeconDB if it is already running

EXEC sp_detach_db 'CodeconDB', 'true'; 

2. Restore the database 
**With Replace is necessary when the CodeconDB.mdf and CodeconDB_log.ldf are in the same directory as CodeconDB.bak**

RESTORE DATABASE CodeConDB
FROM DISK = '<Path to repo>/codecon-422/codecon/data/CodeconDB.bak'
WITH REPLACE

# Attaching the database file to the sql server instance	<-- hard mode

The files 'CodeconDB.mdf' and 'Codecon_log.ldf' need to be attached to the sql server to create the database. These files can be found in codecon-422/codecon/data.

1. Execute the command:

CREATE DATABASE CodeconDB
    ON (FILENAME = '/<The path to repository>/codecon-422/codecon/data/CodeconDB.mdf'),
    (FILENAME = '/<The path to repository>/codecon-422/codecon/data/CodeconDB_Log.ldf')
    FOR ATTACH;
GO

2. After this execute the command:

use CodeconDB
GO

in mssql-tools to switch the context to our database stub.



# To make sure the database is operative:

1. Run the command:

SELECT name FROM sys.Databases
GO

to ensure that CodeconDB is in the sql server instance

2. Run the commands:

SELECT * FROM Project
SELECT * FROM Task
SELECT * from [User]
GO

to see sample entries in the database.
There should be one sample entry in each table.
