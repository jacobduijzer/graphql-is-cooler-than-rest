# graphql-is-cooler-than-rest
GraphQL is cooler than (the) REST!

## TODO List

- [x] Queries
    - [x] Movies
    - [x] Snack recommendations
    - [x] Ratings
- [x] Mutations
    - [x] Add rating for movie 
- [x] Subscriptions
    - [x] Rating added for movie
- [x] Resolvers
    - [x] Snack recommendations 
    - [x] Ratings
- [ ] Data Loaders
- [ ] Authentication & Authorization

## Movies

```graphql
query movies {
    # all genres as a list
    genres

    # all movie titles and id's
    a: movies {
        id
        title
    }

    # the information of the movie with id 1
    movie(id: 1) {
        title
        year
        genres
        ratings
        description
    }

    # the titles of movies with genre Action
    moviesByGenre(genre: "Action") {
        title
    }

    # all movie titles, filtered by genre, should equal "Action"
    b: movies(where:  {
        genres:  {
            some:  {
                eq: "Action"
            }
        }
    }) {
        title
    }
}
```
