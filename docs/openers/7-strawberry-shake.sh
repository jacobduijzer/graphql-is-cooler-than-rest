#!/usr/bin/env bash

source helpers.sh

files=(
	"SnackFlix.Razor/Program.cs"
	"SnackFlix.Razor/GraphQl/movie-detail-page.graphql"
	"SnackFlix.Razor/Pages/Index.cshtml.cs"
	"SnackFlix.Razor/Pages/Index.cshtml"
)

openFiles "${files[@]}"