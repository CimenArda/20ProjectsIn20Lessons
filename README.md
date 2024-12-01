# PROJECT 1 - ADONET CUSTOMER MANAGEMENT SYSTEM PROJECT

This project is a customer management application developed using **ADO.NET** and **Windows Forms**.

## Project Features
- **Homepage**: Serves as the main screen of the application and provides access to other forms.
- **Customer Management Form**: Manages CRUD operations (Create, Read, Update, Delete) related to customers.
- **City Management Form**: Performs CRUD operations for cities.

## Technologies Used
- **ADO.NET**: Used for database operations.
- **Windows Forms**: Preferred for user interface design.

---
# PROJECT 2 - ENTITY FRAMEWORK PRODUCT TRACKING SYSTEM PROJECT

This project is a product tracking system developed using **Entity Framework** and **Windows Forms**.

## Project Features
- **DbFirst Approach**: Used for database operations.
- **Product Management**:
  - Add, delete, update, and list products.
  - Track stock levels.
- **Category Management**:
  - Perform CRUD operations for categories.

## Technologies Used
- **Entity Framework**: Preferred for database management.
- **Windows Forms**: Used for creating a user-friendly interface.

## Screens of the Project
- **Product Management Form**: Handles operations related to products.
- **Category Management Form**: Manages category operations.

---
# PROJECT 3 - ENTITY FRAMEWORK & LINQ STATISTICS SYSTEM PROJECT

This project is a statistics system developed using **Entity Framework**, **LINQ**, and **Windows Forms**.

## Project Features
- Calculates 25 different statistics from database records.
- Statistics are dynamically updated and presented through a user-friendly interface.
- Provides detailed information about users, products, customers, and orders.

### Examples of Calculated Statistics:
1. **Total number of customers**
2. **Total number of countries**
3. **Orders placed from Turkey**
4. **Number of products with stock below 100**
5. **Total stock of active products**

## Technologies Used
- **Entity Framework**: Preferred for database operations.
- **LINQ**: Used for querying and analyzing data.
- **Windows Forms**: Used for user interface design.

---
# PROJECT 4 - ENTITY FRAMEWORK MOVIE/SERIES TRACKING SYSTEM PROJECT

This project is a movie/series tracking system developed using **Entity Framework** and **Windows Forms**.

## Project Features
- **CodeFirst Approach**: Used for database operations.
- **Movie/Series Management**:
  - Add, delete, update, and list watched movies and series.
  - Track watching statuses.
- **Category Management**:
  - Perform CRUD operations for movie and series categories.

## Technologies Used
- **Entity Framework**: Preferred for database management.
- **Windows Forms**: Used for creating a user-friendly interface.

## Screens of the Project
1. **Movie/Series Management Form**: Used for movie and series operations.
2. **Category Management Form**: Handles category management.

---
# PROJECT 5 - DAPPER PRODUCT TRACKING SYSTEM PROJECT

This project is a product tracking system developed using **Dapper** and **Windows Forms**.

## Project Features
- **Northwind Database**: Used for database operations.
- **Category Management**:
  - Perform CRUD operations (Create, Read, Update, Delete) for categories.
- All operations can be handled from a single form.

## Technologies Used
- **Dapper**: Chosen as a lightweight ORM tool.
- **Windows Forms**: Used for user interface design.

# PROJECT 6 - API WEATHER TRACKING PROJECT

This project is a weather tracking system developed using **Web API**.

## Project Features
- **Weather Management for Cities**:
  - Weather data for cities is managed through CRUD (Create, Read, Update, Delete) operations.
- **Special Data Queries**:
  - City with the highest temperature.
  - City with the lowest temperature.
- Users can access and analyze this data via the API.

## Technologies Used
- **Web API**: Used for data management and querying operations.

---
# PROJECT 7 - WEATHER TRACKING WITH API INTEGRATION PROJECT

This project is a weather tracking system developed using a **Console App**.

## Project Features
- **Weather API Integration**:
  - Utilizes the Weather API developed in Project 6 to fetch and process data.
- **CRUD Operations**:
  - Users can add new cities, update existing data, and delete records.
- Users can interact with weather data through the API.

## Technologies Used
- **Console App**: Basic application interface for managing weather tracking.
- **Web API**: Integrated as the data source.

---
# PROJECT 8 - CURRENCY EXCHANGE RATE TRACKING WITH RAPIDAPI PROJECT

This project is a currency exchange rate tracking system developed using **RapidAPI** and **Windows Forms**.

## Project Features
- **RapidAPI Integration**:
  - Retrieves currency exchange rates for USD, EUR, and GBP against Turkish Lira (TRY) using the **Currency Conversion and Exchange Rates API**.
- **Currency Conversion**:
  - Users can input an amount in a specific currency to calculate the total value in another currency.
- **Live Exchange Rates**:
  - Users can track exchange rates and perform conversions between different currencies.

## Technologies Used
- **RapidAPI**: Used to provide currency exchange data.
- **Windows Forms**: Preferred for user interface design.

---
# PROJECT 9 - MONGODB ORDER TRACKING PROJECT

This project is an order tracking system developed using **MongoDB** and **Windows Forms**.

## Project Features
- **Order Management**:
  - Basic CRUD (Create, Read, Update, Delete) operations for managing orders, including creating, updating, deleting, and listing orders.
- **Flexible Data Structure**:
  - MongoDB's flexible data structure makes order data easy to manage and scalable.

## Technologies Used
- **MongoDB**: Used as the NoSQL database.
- **Windows Forms**: Preferred for user interface design.

---
# PROJECT 10 - POSTGRESQL TODOLIST PROJECT

This project is a task tracking system developed using **PostgreSQL** and **Windows Forms**.

## Project Features
- **Category Management and Task List**:
  - Users can manage categories and create, edit, delete, and update tasks.
- **Task Status Tracking**:
  - Tracks the status of tasks (completed or ongoing).
- **CRUD Operations**:
  - Fully supports CRUD (Create, Read, Update, Delete) operations.

## Technologies Used
- **PostgreSQL**: Used for database management.
- **Windows Forms**: Preferred for user interface design.

# PROJECT 11 - ORDER TRACKING WITH TRIGGERS PROJECT

This project is an order tracking system developed using **SQL Trigger**, **Entity Framework**, and **Console App**.

## Project Features
- **SQL Triggers**:
  - When an order is added, product stock levels and the total amount in the cash register are automatically updated via SQL triggers.
- **Stock and Cash Tracking**:
  - Stock and cash tracking is managed through the MSSQL database.
- **Entity Framework Integration**:
  - Database operations are handled with Entity Framework.

## Technologies Used
- **SQL Trigger**: Used for automatic updates.
- **Entity Framework**: Used for database operations.
- **Console App**: Chosen as the application interface.
- **MSSQL**: Used for database management.

---
# PROJECT 12 - JWT EMPLOYEE TRACKING PROJECT

This project is a modern employee tracking system developed using **JWT (JSON Web Token)**, **MSSQL**, and **Windows Forms**.

## Project Features
- **Secure Authentication with JWT**:
  - After logging in, users are authenticated and authorized with a JWT token generated by the system.
- **Three Main Forms**:
  - **Login Form**: Users enter their credentials.
  - **Token Generation Form**: A token is generated upon successful authentication.
  - **Employee Tracking Form**: Users securely view employee information using the token.
- **Authorization Control**:
  - Token validity and accuracy are continuously checked. Unauthorized access displays a "You are not authorized" error.

## Technologies Used
- **JWT**: Used for user authentication and authorization.
- **MSSQL**: Used for database management.
- **Windows Forms**: Used for the user interface.

---
# PROJECT 13 - REAL-TIME WEATHER TRACKING WITH RAPIDAPI PROJECT

This project is a weather application developed using **RapidAPI** and **Windows Forms**.

## Project Features
- **OpenWeather API Integration**:
  - Weather data for Istanbul, including temperature, humidity, and wind speed, is retrieved using the OpenWeather API provided via RapidAPI.
- **Dynamic Weather Presentation**:
  - Weather conditions such as cloudy, rainy, and sunny are dynamically displayed using appropriate icons in a **PictureBox** based on JSON data.
- **Graphical Weather Representation**:
  - Weather data is enriched with visual elements for a more effective user experience.

## User Experience
- Weather information is presented in a modern and user-friendly interface with graphical enhancements.
- Users can easily view weather forecasts with quick and simple access.

## Technologies Used
- **RapidAPI**: Used to retrieve weather data via the OpenWeather API.
- **Windows Forms**: Used for the user interface.

---
# PROJECT 14 - FOOTBALL DATA ANALYSIS WITH SQL RELATIONS PROJECT

This project is a football data management application developed using **MSSQL** and **Windows Forms**.

## Project Features
- **Relational Database Structure**:
  - Manages data related to football teams, sponsors, and players using a relational database structure.
- **SQL Relations**:
  - One-to-One, One-to-Many, and Many-to-Many SQL relations are utilized for a more organized and connected data presentation.
  - Allows users to easily navigate between related data.
- **Data Display and Tracking**:
  - Users can view team and player information and track sponsor details.

## User Experience
- Users can seamlessly navigate between data to access detailed information about football teams, players, and sponsors.
- The application ensures data is presented visually in an organized and connected manner.

## Technologies Used
- **MSSQL**: Used for database management and SQL relations.
- **Windows Forms**: Used for the user interface.

---
# PROJECT 15 - FUEL PRICE SIMULATION PROJECT

This project is a fuel price simulation application developed using **RapidAPI** and **Windows Forms**.

## Project Features
- **RapidAPI Fuel Prices API**:
  - Dynamically provides current prices for fuel types such as gasoline, diesel, and LPG in Istanbul.
- **Fuel Types and Price Calculation**:
  - Users can calculate the total price based on the selected fuel type.
  - The type and quantity of fuel are chosen by the user.
- **Simulation with Visual Support**:
  - Price calculations are visualized using a **ProgressBar**.
  - Designed with a modern user interface to enhance the simulation experience.

## User Experience
- Users can calculate prices based on selected fuel types and track the process visually.
- The application provides real-time price updates and the ability to run simulations.

## Technologies Used
- **RapidAPI**: Used to fetch fuel prices via API.
- **Windows Forms**: Used for the user interface.

# PROJECT 16 - MAILKIT EMAIL ACTIVATION PROJECT

This project is an email activation application developed using **MailKit**, **Entity Framework**, and **Windows Forms**.

## Project Features
- **Email Verification Process**:
  - When a user registers, a randomly generated six-digit verification code is sent to the entered email address.
  - The user enters the verification code on the confirmation screen, and the account is activated if the code is correct.
- **MailKit Integration**:
  - **MailKit** is used to send emails via SMTP.
  - A message containing the verification code is sent to the user during email transmission.
- **Database Update**:
  - If the user enters the correct code, the **IsConfirm** field in the database is updated to `true`, activating the account.
  - An error message is displayed if the user enters an incorrect code.

## User Experience
- Users can activate their accounts after entering the email verification code.
- The application ensures a smooth verification process with a user-friendly interface.

## Technologies Used
- **MailKit**: Provides SMTP support for sending emails.
- **Entity Framework**: Used for database operations.
- **Windows Forms**: Developed for the user interface.

---
# PROJECT 17 - KAGGLE DATASET INTEGRATION PROJECT

This project uses the **Global Superstore Dataset** from **Kaggle** for data analysis, aiming to create a database foundation for future **dashboard** projects.

## Project Features
- **Data Analysis**:
  - The project utilizes the **Global Superstore Dataset**, a comprehensive commercial dataset, to analyze sales data, orders, profits, customer information, and more.
  - Analyzed data provides users with deeper insights into commerce trends.
- **Dashboard Creation**:
  - This project lays the groundwork for designing dashboards based on insights gained from the dataset.
- **Dataset Features**:
  - Includes critical commercial data such as sales figures, orders, profits, customer segments, and geographical information.

## User Experience
- Users can analyze the dataset to explore business trends, performance indicators, and customer behaviors.
- The dataset's analysis provides a foundation for developing interactive dashboards, enabling users to create detailed reports.

## Technologies Used
- **Kaggle Dataset**: The Global Superstore dataset was sourced from Kaggle.
- **Data Analysis Tools**: Appropriate tools and techniques were used for data analysis.

---
# PROJECT 18 - SUPERSTORE DASHBOARD PROJECT

This project is an e-commerce dashboard application developed using the **Global Superstore Dataset** and **Windows Forms**.

## Project Features
- **Data Analysis and Visualization**:
  - The application is designed to analyze sales data from the **Superstore** database and present it graphically to users.
  - SQL queries are used to provide various statistics and visualizations from the database.
  - Interactive graphs and widgets help users easily understand the data.

### Visualizations
- **Total Product Count**: Displays the total number of products.
- **Order Counts by City and Country**: Shows the number of orders placed in different cities and countries.
- **Order Quantities by Country**: Visualizes the distribution of orders across countries using graphical charts.
- **Order Distribution by Priority**: Graphs displaying orders based on their priority levels.

### Interactive Widgets
- Interactive widgets on the main screen allow users to instantly analyze sales rates and order counts for different cities and countries.
- Information such as **Order Quantities**, **Product Count**, and **City-Based Orders** are updated in real-time.

### User-Friendly Interface
- The application provides a user-friendly interface, presenting complex data in a visually simple and understandable format.

## User Experience
- Users can thoroughly examine sales performance in the Superstore database.
- Data is presented in visual and numerical formats, making analysis and decision-making easier.

## Technologies Used
- **Global Superstore Dataset**: The dataset was sourced from Kaggle.
- **Windows Forms**: The application's interface was developed with Windows Forms for user interaction.
- **SQL**: Used for data analysis and querying.

---
# PROJECT 19 - REAL-TIME TABLE STATUS TRACKING PROJECT

This project is a table status tracking application developed using **Windows Forms**.

## Project Features
- **Real-Time Table Tracking**:
  - Displays the occupancy status of tables in a restaurant in real-time.
  - Each table is represented by a button, with button colors indicating table status:
    - **Occupied tables** are shown in red,
    - **Vacant tables** are shown in green.

- **Timer Integration**:
  - The application uses a timer to periodically check the database and update table statuses.
  - This feature allows users to track table statuses in real-time.

- **Dynamic Table Layout**:
  - Buttons are dynamically placed on the screen based on the number of tables.
  - This ensures a visually organized table layout and provides a user-friendly interface.

## User Experience
- Users can easily monitor and view the real-time status of restaurant tables.
- Table statuses are clearly indicated by button colors, allowing users to quickly determine whether a table is occupied or vacant.

## Technologies Used
- **Windows Forms**: Used for the user interface and interaction.

- **Database**: The states of the tables are kept in the database and updated via the scheduler.
