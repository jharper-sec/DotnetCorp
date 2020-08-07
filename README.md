# DotnetCorp: Vulnerable application written in .NET Core

# Introduction
DotnetCorp is an intentionally vulnerable application written in .NET Core to learn about security flaws.

# Prerequisites
* Docker (tested on 19.03.12)
* Docker Compose (tested on 1.26.2)
* .NET Core 2.2

# Quick Start
Download and install dependencies
```
git clone https://github.com/jharper-sec/dotnetcorp.git
cd dotnetcorp
npm install
```

Build application
```
docker-compose build
```

Run application
```
docker-compose up
```
Application is accessible at http://localhost:5000/

Stop application
```
docker-compose down
```

# Currently Implemented Vulnerabilities
* SQL Injection

# Installing Contrast Security Agent
Instructions for installing and running the Contrast Security .NET Core agent within this application are available [here](CONTRAST.md)