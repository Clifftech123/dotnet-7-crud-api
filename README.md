# .NET 7 CRUD API

Welcome to the dotnet-7-crud-api, a robust .NET Core 7 CRUD (Create, Read, Update, Delete) API designed to efficiently manage users within a database.


<!-- Addiing the over view image here for users  -->

![image](/asstes//imageone.png)

## Overview

This API leverages modern technologies such as dotnet, C#, Entity Framework, SQL Server, BCrypt, AutoMapper, and Swashbuckle to offer seamless user management functionalities.

## Features

- **Get All Users**: Retrieve a comprehensive list of all users stored in the database.
- **Get User by GUID**: Fetch a specific user based on their globally unique identifier (GUID).
- **Create User**: Add a new user entry to the database.
- **Update User**: Modify the details of an existing user using their GUID.
- **Delete User**: Permanently remove a user from the database using their GUID.

## API Endpoints

### POST /users

Create a new user.

**URL:** `http://localhost:4000/users`

**Request Body:**

```json
{
    "title": "Mrs",
    "firstName": "Isaiah Clifford",
    "lastName": "Opoku",
    "role": "User",
    "email": "Cliffiordg@gmail.com",
    "password": "clifford",
    "confirmPassword": "clifford"
}
```

### GET /users

Retrieve all users.

**URL:** `http://localhost:4000/users`

**Response Body:**

```json
{
  "message": "Successfully retrieved all users",
  "data": [
    {
      "guid": "c825bf7d-f2f9-4f76-924b-08dc2005ac18",
      "title": "Mr",
      "firstName": "George",
      "lastName": "Costanza",
      "email": "loveg@gmail.com",
      "role": "User"
    },
    {
      "guid": "c985783d-fcda-4c2f-924c-08dc2005ac18",
      "title": "Mrs",
      "firstName": "Isaiah Clifford",
      "lastName": "Opoku",
      "email": "Cliffiordg@gmail.com",
      "role": "User"
    }
  ]
}
```

### GET /users/{id}

Retrieve user by ID.

**URL:** `http://localhost:4000/users/c825bf7d-f2f9-4f76-924b-08dc2005ac18`

**Response Body:**

```json
{
  "message": "Successfully retrieved user with id c825bf7d-f2f9-4f76-924b-08dc2005ac18",
  "data": {
    "guid": "c825bf7d-f2f9-4f76-924b-08dc2005ac18",
    "title": "Mr",
    "firstName": "George",
    "lastName": "Costanza",
    "email": "loveg@gmail.com",
    "role": "User"
  }
}
```

### PUT /users/{id}

Update user details.

**URL:** `http://localhost:4000/users/c985783d-fcda-4c2f-924c-08dc2005ac18`

**Request Body:**

```json
{
    "title": "Mrs",
    "firstName": "Isaiah Clifford",
    "lastName": "Opoku",
    "role": "User",
    "email": "Cliffiordg@gmail.com",
    "password": "clifford",
    "confirmPassword": "clifford"
}
```

### DELETE /users/{id}

Delete user by ID.

**URL:** `http://localhost:4000/users/3634a5e5-5add-4198-55f6-08dc200a693d`

**Response Body:**

```json
{
  "message": "User with id 3634a5e5-5add-4198-55f6-08dc200a693d successfully deleted"
}
```

## Usage

Interact with the API by sending HTTP requests to the respective endpoints. Use the GUID as the unique identifier for user-related operations.

## Setup

Clone the repository and run the application in your local development environment. Ensure you have .NET Core 7 installed. Remember to update the connection string in the `appsettings.json` file with your SQL Server details.

## Contribution

Contributions are encouraged! Please thoroughly test your changes before submitting a pull request.

## License

This project is licensed under the MIT License.
