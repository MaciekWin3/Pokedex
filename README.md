# Short Description
Simple Rest Api built on .Net platform that allows user to to manage his own Pokedex.

# Features
* JWT Authentication
* Dapper library to communicate with database
* Entity Framework to manage accounts
* Swagger
* Error handling
* Model validation




# Endpoints

## Accounts

### Post

* /api/accounts/create - Create new account
* /api/accounts/login - Log in to existing account

## Pokemons
### Get
* /api/pokemons - List of all pokemons in Pokedex
* /api/pokemons/{id} - Find pokemon by given id
* /api/pokemons/counter - Number of pokemons in Pokedex
* /api/pokemons/searchbyname/{name} - Search pokemon by name
* /api/pokemons/searchbytype/{type} - Search pokemons by type

### Post
* /api/pokemons - Add new pokemon to Pokedex

### Put

* /api/pokemons/{id} - Edit pokemon in your pokedex

### Delete 
* /api/pokemons/{id} - Delete pokemon from your pokedex

# ScreenShoots

|  |  |
:---:|:---:
![alt register](https://i.postimg.cc/QdTbsPfC/register.png) | ![alt login](https://i.postimg.cc/hPhsZhx9/login.png )
![alt get](https://i.postimg.cc/nV3T1qsF/get.png) | ![alt create](https://i.postimg.cc/KYh5YNWN/post.png )

![alt swagger](https://i.postimg.cc/28VpdkSt/pokedex2.png"pageWithAllPokemons")

## Authors

Maciej Winnik
