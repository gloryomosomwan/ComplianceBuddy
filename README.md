# ComplianceBuddy

ComplianceBuddy is a web application built with ASP.NET Core MVC designed to help users track vehicle compliance status based on their inspection history. 

<img width="1642" height="938" alt="image" src="https://github.com/user-attachments/assets/d9e2f592-b18a-4983-8c69-fde157fe3098" />

## Technologies Used

- **Backend**: ASP.NET Core MVC, C#
- **Database**: Entity Framework Core, SQL Server
- **Frontend**: Razor Pages, Bootstrap, HTML, CSS
- **Authentication**: ASP.NET Core Identity

## Usage

1.  Navigate to the application URL in your browser.
2.  Register for a new account and log in.
3.  From the dashboard, click **"Add Vehicle"** to add your first vehicle.
4.  Click **"Add Inspection"** to log an inspection for a vehicle.
5.  The dashboard will automatically update the compliance status of your vehicles. A vehicle is considered "Compliant" if it has passed an inspection within the last 12 months.
