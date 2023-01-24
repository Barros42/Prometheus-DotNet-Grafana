
# Observability in .NET with Prometheus and Grafana

This repository was made to a presentation in .NET CONF 2023 that happened in Campinas city in Brazil! 

I used this repository to demonstrate how to instrument and observe a simple .NET API.

## 💻  Prerequisites

Before you start, check if you have all the prerequisites:

-   You have `Docker` installed.
-   You have  `Docker Compose` installed.

## ☕ Run the project

Go to the root folder of this project and simply run the command below:

`docker-compose up -d`

## 🚀 Run a stress test with K6

Go to the root folder of this project and simply run the command below:

`docker run --net=host --rm -i grafana/k6 run - <k6/test.js`


## 😄 Improve this code!
Want to improve this repository? Click [HERE](mailto:mdbf42@gmail.com) and send me an e-mail.