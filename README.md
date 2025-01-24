# graphql-is-cooler-than-rest
GraphQL is cooler than (the) REST!

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
        genre
        description
    }

    # the titles of movies with genre Action
    moviesByGenre(genre: "Action") {
        title
    }

    # all movie titles, filtered by genre, should equal "Action"
    b: movies(where:  {
        genre:  {
            some:  {
                eq: "Action"
            }
        }
    }) {
        title
    }
}
```
