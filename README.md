<p align="center">
  <img src="Screenshots/00%20EquipTrack%20-%20Banner.jpg" width="800" alt="EquipTrack Banner">
</p>

# EquipTrack

EquipTrack is a simple web app for tracking IT equipment from the day it's purchased all the way through to when it gets recycled.

## The Problem

A lot of IT teams track their laptops, monitors, and other equipment in a spreadsheet. That works fine at first, but as the list grows it gets messy - updates get missed, warranties expire without anyone noticing, and there's no real record of what happened when something got thrown out or recycled. EquipTrack keeps all of that in one place instead.

## Features

- Track assets (laptops, monitors, servers, etc.) with serial number, purchase info, warranty date, and status
- Organize assets into categories
- Log recycling records - how an asset was wiped and disposed of when it reaches end of life
- Dashboard with asset counts by status, a category breakdown chart, and a warranty-expiring-soon alert
- Reports: assets never recycled, total value by category, and a name/price search
- Form validation, including a check that a warranty date can't be before the purchase date

## Tech Stack

- ASP.NET Core MVC (.NET 10)
- Entity Framework Core
- SQLite
- Bootstrap 5
- Chart.js


## Running Locally

'''bash
git clone https://github.com/Jain2098/EquipTrack-CollegeProject.git
cd EquipTrack-CollegeProject/EquipTrack
dotnet restore
dotnet ef database update
dotnet run
'''


## Screenshots

### Dashboard
<img src="Screenshots/01%20Dashboard.png" width="700" alt="Dashboard">

### Categories
<img src="Screenshots/02%20Categories%20list.png" width="700" alt="Categories list">

### Assets
<img src="Screenshots/03.0%20%20Assets%20list.png" width="700" alt="Assets list"><br>
<img src="Screenshots/03.1%20Asset%20Create%20-%20Base.png" width="700" alt="Asset Create form"><br>
<img src="Screenshots/03.2%20Asset%20Create%20-%20REQUIRED%20FIELDS.png" width="700" alt="Asset Create validation"><br>
<img src="Screenshots/03.3%20Asset%20Create%20-%20ADED.png" width="700" alt="Asset created">

### Reports
<img src="Screenshots/05.1%20Reports%20-%20Never%20Recycled.png" width="700" alt="Never Recycled report"><br>
<img src="Screenshots/05.2%20Reports%20-%20Value%20By%20Category.png" width="700" alt="Value By Category report"><br>
<img src="Screenshots/05.3%20Reports%20-%20Search%20with%20results.png" width="700" alt="Search report">

### Mobile View
<img src="Screenshots/06.1%20Mobile%20View%20-%20Dashboard.png" width="280" alt="Mobile Dashboard"><br>
<img src="Screenshots/06.2%20Mobile%20View%20-%20Navigation%20only.png" width="280" alt="Mobile Navigation">

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.