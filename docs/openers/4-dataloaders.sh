#!/usr/bin/env bash

source helpers.sh

files=(
	"SnackFlix.Api/Program.cs"
	"SnackFlix.Api/Movies/MovieType.cs"
	"SnackFlix.Api/Movies/MovieQueries.cs"
	"SnackFlix.Api/Reviews/ReviewsDataLoader.cs"
	"SnackFlix.Api/Reviews/IReviewService.cs"
	"SnackFlix.Reviews/Program.cs"
)

openFiles "${files[@]}"