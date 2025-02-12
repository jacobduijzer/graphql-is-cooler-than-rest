#!/usr/bin/bash

BASE_PATH=$HOME/code/github/graphql-is-cooler-than-rest/src

files=(
	"SnackFlix.Razor/Program.cs"
	"SnackFlix.Razor/GraphQl/movie-detail-page.graphql"
	"SnackFlix.Razor/Pages/Index.cshtml.cs"
	"SnackFlix.Razor/Pages/Index.cshtml"
)

i=1
for file in "${files[@]}"; do
	echo "Opening file: $BASE_PATH/$file"
	rider $BASE_PATH/$file --column $i
	((i++))
done