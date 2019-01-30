# NexPay

## Description

An Api to register and manage residents of a condominium

## Technologies used on this project

.Net Core 2.2  
Entity Framework  
Moq  
XUnit  
Sqlite

## Instructions

The following instructions are supposed to be used in a bash compatible shell

### Running the project

On the root directory, run:

```console
foo@bar:~$ ./build.sh database update
foo@bar:~$ ./build.sh run
```
### Running with docker

On the root directory, run:

```console
foo@bar:~$ docker build -t nexpay .
foo@bar:~$ docker run -p 5000:80 nexpay
```

### Swagger

The Swagger Ui is available at localhost:5000/swagger









