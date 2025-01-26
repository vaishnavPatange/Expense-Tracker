# Expense Tracker

This is a web-based **Expense Tracker** application built using **ASP.NET Core**, **Entity Framework Core**, **SQL Server**, and **Syncfusion** for the UI. The app helps users track their expenses and income, providing visual insights into their financial activities.

## Features
- **Categorized Expense/Income Management**: Add and manage different expense/income categories.
- **Transaction Tracking**: Track individual transactions under specific categories.
- **Dashboard Insights**:  
  - Display total income, expenses, and balance.
  - **Doughnut Chart**: Visualize expenses by category.
  - **Spline Chart**: Compare income vs. expenses over time.

## Technologies Used
- **Backend**: ASP.NET Core, Entity Framework Core
- **Database**: SQL Server
- **Frontend**: Syncfusion Component Library, MVC Architecture

## Setup and Installation

1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/vaishnavPatange/Expense-Tracker.git
   ```

2. Open the project in **Visual Studio** or your preferred IDE.

3. Restore the project dependencies:
   ```bash
   dotnet restore
   ```

4. Update your connection string in `appsettings.json` to point to your SQL Server database.

5. Run the application:
   ```bash
   dotnet run
   ```
