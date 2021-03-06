# Pokedex 🎮
# Short Description 📜
Simple Rest Api built on .Net platform that allows user to manage his own Pokedex.

# Features ✨
* CRUD
* JWT Authentication
* Dapper library to communicate with database
* Entity Framework to manage accounts
* MsSql
* Swagger
* Searching by types, names
* Error handling
* Model validation




# Endpoints 🚩

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

# Response Example 📧
```
https://localhost:44340/api/Pokemons/2
```
```
{
  "id": 2,
  "name": "Ivysaur",
  "type": "Grass, Poison",
  "abilities": "Overgrow",
  "hp": 60,
  "attack": 62,
  "specialAttack": 80,
  "defense": 63,
  "specialDefense": 80,
  "speed": 60,
  "height": 3.03,
  "weight": 28.7,
  "description": "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
  "added": "2021-06-24T20:30:30.283",
  "modified": "2021-06-24T20:30:30.283"
}
```

# Screen Shoots 📸

![alt swagger](https://i.postimg.cc/7YDFc39p/swagger3-pnh.png)
![alt register](https://i.postimg.cc/8PMhFWVP/register2.png)
![alt get](https://i.postimg.cc/0NfMYdtP/get1.png)


## Authors 📕

Maciej Winnik
