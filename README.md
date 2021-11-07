# Interview Demo Project
##### by Israel Duani
----
### Quick start
You can either run the backend and frontend directly on your machine, or you can just use docker :smile:

##### First time build / any changes on code
#
```sh
docker-compose build --no-cache
```

##### Run the project
#
```sh
docker-compose up -d
```

##### Stop the project
#
```sh
docker-compose down
```

### Why am I doing this?
So I created this project to show some of my capabilities in creating projects from scratch,<br />
This project is not only about knowing how to code, but it's also about making architecture decisions before and along the coding process.<br />
if you want, during the interview, I will share with you the process that I went through to create this project.<br />

just a small note before we start,<br />
this is a demo project, so maybe some of the decision I made doesn’t really fit real production project.<br />
I took into factor the time frame that I have,but also there is the complexity factor,<br />
on one hand, I want to show as many capabilities that I learned over the years,<br />
on the other hand, I wanted to keep the project as simple as I can.<br />
so I think I found the right balance for this project.<br />
If you have any questions about the project, please don’t hesitate to ask me about it.

### About this demo
This project is a simple HR system, you will be able to:
-	Create workers (name, id, personal address, salary, worker type)
-	Pay salary
-	See and edit worker details
-	Assign and remove workers from manager
-	Fire workers
-	Switch between 2 DB types

### What is the project made of?
So let's start with the simple ones.
+ ##### Frontend  - written in React.

+ ##### DB – there are two DBs that I will work within this project.
    + Mongo – fully implemented
    + MySQL – everything is set up except for the queries (coming soon)<br />
    I decided to work with two DBs for two reasons
        + To show that I have no problem working with and learning new areas.
        + To show that I have built this project in such a way that it's very easy to scale this project.

+ ##### Backend
    +	Base logic – this project was written in .net standard, it contains all the business logic, so every type of project can use the project reference, which allows changing easily the server without a lot of rewriting code.
    +	Test – I have created unit tests using X-Unit, that test the base logic project.
    +	ASP .Net framework (4.7) – API server.
    +	ASP .Net core (3.1) – API server.<br />
I created 2 API servers to show how easy it is to move from framework server to core server because of the use of the base logic reference.

+ ##### Docker
    I have written two docker files, one for the backend and one for the frontend.
    Also, I created docker-compose  file for easy start.

### Can you do better?
Always, its just depends on time frame and motivation,<br />
If you want to take a look at recent project that im working on (without the source code :see_no_evil: )<br />
Please visit [mimiplan.com](https://mimiplan.com/ "mimiplan.com")



