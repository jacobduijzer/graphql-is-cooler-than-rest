#!/usr/bin/bash

BASE_PATH=$HOME/code/github/graphql-is-cooler-than-rest/src

files=(
	"SnackFlix.Api/Program.cs"
	"SnackFlix.Api/Movies/Movie.cs"
	"SnackFlix.Api/Movies/MovieQueries.cs"
	"SnackFlix.Api/Movies/MovieType.cs"
	"SnackFlix.Api/Reviews/ReviewType.cs"
	"SnackFlix.Api/Reviews/Review.cs"
)

i=1
for file in "${files[@]}"; do
	echo "Opening file: $BASE_PATH/$file"
	rider $BASE_PATH/$file --column $i
	((i++))
done