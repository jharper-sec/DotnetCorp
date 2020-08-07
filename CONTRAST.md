# Contrast Security Installation Instructions
This document details how to install and run this application with the Contrast Security .NET Core agent. The Contrast Security .NET Core agent is used in conjunction with the Contrast Security platform to continuously monitor and detects application-level vulnerabilities within running applications. It can also optionally prevent vulnerabilities from being exploited in production systems. For more information visit the [Contrast Security Website](https://www.contrastsecurity.com/)

# Pre-requisites
* Access to the Contrast Security platform. [Create a free Contrast Community Edition account](https://www.contrastsecurity.com/contrast-community-edition)
* Docker
* Docker Compose

# Install & Run Contrast in DotnetCorp
Add your agent credentials to the `.env` file using the lines below. Credentials can be retrieved from the Contrast Security Platform `Add Agent` dialog or under the `User Menu -> Organization Settings -> API`.

```
CONTRAST__API__URL=YOUR_CONTRAST_URL
CONTRAST__API__API_KEY=YOUR_CONTRAST_API_KEY
CONTRAST__API__SERVICE_KEY=YOUR_CONTRAST_SERVICE_KEY
CONTRAST__API__USER_NAME=YOUR_CONTRAST_USER_NAME
```

Build application with the Contrast agent
```
docker-compose -f docker-compose-Contrast.yaml build
```

Run application with the Contrast agent
```
docker-compose -f docker-compose-Contrast.yaml up
```

The application should now be accessible at http://localhost:5000

By interacting with the application, the Contrast agent will detect associated vulnerabilities.
