#!/usr/bin/env bash

source helpers.sh

files=(
	"SnackFlix.Api/Program.cs"
	"SnackFlix.Api/Movies/Movie.cs"
	"SnackFlix.Api/Movies/MovieQueries.cs"
	"SnackFlix.Api/Movies/MovieType.cs"
	"SnackFlix.Api/Reviews/ReviewType.cs"
	"SnackFlix.Api/Reviews/Review.cs"
)

openFiles "${files[@]}"