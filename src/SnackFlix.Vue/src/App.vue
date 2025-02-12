<script setup lang="ts">
import { provideApolloClient, useQuery } from "@vue/apollo-composable";
import gql from "graphql-tag";
import apolloClient from "./apollo-client";

// Provide Apollo Client globally
provideApolloClient(apolloClient);

const GET_MOVIE_DETAIL_PAGE = gql`
  query MovieDetailPage {
    movie(id: 1) {
      title
      description
      year
      genres
    }
    genres
    allMovies {
      id
      title
    }
  }
`;

const { result, loading, error } = useQuery(GET_MOVIE_DETAIL_PAGE);
</script>

<template>
  <div class="container">
    <h1>GraphQL Apollo Client Demo</h1>
    <h2>🎬 Movie Detail Page</h2>

    <p v-if="loading" class="loading">Loading...</p>
    <p v-else-if="error" class="error">Error: {{ error.message }}</p>

    <div v-else class="content">
      <div class="movie-card">
        <h2>{{ result.movie.title }} ({{ result.movie.year }})</h2>
        <p><strong>Genres:</strong> {{ result.movie.genres.join(", ") }}</p>
        <p>{{ result.movie.description }}</p>
      </div>

      <div class="side-section">
        <h3>Available Genres</h3>
        <ul class="genres">
          <li v-for="genre in result.genres" :key="genre">{{ genre }}</li>
        </ul>

        <h3>All Movies</h3>
        <ul class="movies">
          <li v-for="movie in result.allMovies" :key="movie.id">
            {{ movie.title }}
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<style>
body {
  font-family: Arial, sans-serif;
  margin: 0;
  color: black;
  /*background-color: #f4f4f4;*/
}

.container {
  max-width: 800px;
  margin: 40px auto;
  background: white;
  padding: 20px;
  border-radius: 10px;
  box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

h1 {
  text-align: center;
}

.loading {
  text-align: center;
  font-size: 1.2rem;
  color: gray;
}

.error {
  text-align: center;
  color: red;
}

.content {
  display: flex;
  gap: 20px;
}

.movie-card {
  flex: 2;
  background: white;
  padding: 20px;
  border-radius: 8px;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

.side-section {
  flex: 1;
  background: white;
  padding: 15px;
  border-radius: 8px;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

.genres, .movies {
  list-style: none;
  padding: 0;
}

.genres li, .movies li {
  padding: 5px;
  border-bottom: 1px solid #ddd;
}

.movies li:last-child, .genres li:last-child {
  border-bottom: none;
}
</style>