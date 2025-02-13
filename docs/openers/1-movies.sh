#!/usr/bin/env bash

source helpers.sh

files=(
	"SnackFlix.Api/Program.cs"
	"SnackFlix.Api/ServicesExtensions.cs"
	"SnackFlix.Api/Movies/MovieQueries.cs"
	"SnackFlix.Api/Movies/Movie.cs"
	"SnackFlix.Api/Movies/IMoviesService.cs"
	"SnackFlix.Api/Movies/MovieType.cs"
	"SnackFlix.Api/Movies/MovieQueriesType.cs"
)

openFiles "${files[@]}"