# ComplianceBuddy

ComplianceBuddy is a web application built with ASP.NET Core MVC designed to help users track vehicle compliance status based on their inspection history. 

## Technologies Used

- **Backend**: ASP.NET Core MVC, C#
- **Database**: Entity Framework Core, SQL Server
- **Frontend**: Razor Pages, Bootstrap 5, HTML5, CSS3
- **Authentication**: ASP.NET Core Identity

## Usage

1.  Navigate to the application URL in your browser.
2.  Register for a new account and log in.
3.  From the dashboard, click **"Add Vehicle"** to add your first vehicle.
4.  Click **"Add Inspection"** to log an inspection for a vehicle.
5.  The dashboard will automatically update the compliance status of your vehicles. A vehicle is considered "Compliant" if it has passed an inspection within the last 12 months.