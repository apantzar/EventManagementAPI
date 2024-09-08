
# Event Management API

## Overview

The **Event Management API** is a RESTful service built using .NET Core 8 that allows users to create and manage events. The API demonstrates best practices like many-to-many relationships, API documentation with Swagger.

## Features

- **User Management**: Create, retrieve, update, and delete users.
- **Event Management**: Create, retrieve, update, and delete events.
- **Event Registration**: Register users for events (many-to-many relationship).
- **Event Statistics**: Generate statistics such as the number of attendees for events.
- **Background Tasks**: Schedule background tasks like sending event reminders using Hangfire.
- **API Documentation**: Swagger is enabled to interact with and document the API.

## Technologies

- **.NET Core 8**
- **Entity Framework Core 8**
- **SQL Server** 
- **Swagger** for API documentation
- **Postman** or **Swagger UI** for testing

## Prerequisites

- .NET Core SDK 8.0
- SQLExpress
- Visual Studio 2022
- Postman (for API testing) or Swagger (built-in)

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/apantzar/EventManagementAPI.git
cd EventManagementAPI
```

### 2. Configure the Database

1. Open `appsettings.json` and configure the connection string for your database:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLExpress;Database=EventManagementDb;Trusted_Connection=true;TrustServerCertificate=true;
  }
}
```

2. Run database migrations to create the necessary tables:

```bash
Add-Migration InitialCreate
Update-Database
```

### 3. Run the Application


Navigate to `https://localhost:<port>/swagger` to access the Swagger UI for testing and documentation.

## API Endpoints

### User Endpoints

- **GET /api/Users**: Retrieve all users.
- **GET /api/Users/{id}**: Retrieve a single user by ID.
- **POST /api/Users**: Create a new user.
  - Example request body:
  ```json
  {
    "name": "John Doe",
    "email": "johndoe@example.com"
  }
  ```
- **PUT /api/Users/{id}**: Update a user by ID.
- **DELETE /api/Users/{id}**: Delete a user by ID.
- **POST /api/Users/{userId}/RegisterEvent/{eventId}**: Register a user for an event.

### Event Endpoints

- **GET /api/Events**: Retrieve all events.
- **GET /api/Events/{id}**: Retrieve a single event by ID.
- **POST /api/Events**: Create a new event.
  - Example request body:
  ```json
  {
    "title": "Tech Conference",
    "description": "A conference about the latest in technology.",
    "date": "2024-09-15T09:00:00Z",
    "location": "Athens, Greece"
  }
  ```
- **PUT /api/Events/{id}**: Update an event by ID.
- **DELETE /api/Events/{id}**: Delete an event by ID.

### Example JSON Request for Creating a User

```json
{
  "name": "John Doe",
  "email": "john.doe@example.com"
}
```

### Example JSON Request for Creating an Event

```json
{
  "title": "Developer Conference",
  "description": "A conference focused on software development.",
  "date": "2024-10-01T09:00:00Z",
  "location": "New York, USA"
}
```
You can test the API using **Postman** or **Swagger UI** (available at `https://localhost:<port>/swagger`).

### Postman Testing

- Import the API endpoints into Postman.
- Use the pre-configured example requests to create users, events, and register users for events.

## Future Enhancements

- Add authentication using JWT/OAuth for user management and event registration.
- Implement pagination and filtering for large datasets.
- Set up automated reminders for events.
- Add more comprehensive error handling and logging.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
