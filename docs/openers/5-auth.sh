#!/usr/bin/bash

BASE_PATH=$HOME/code/github/graphql-is-cooler-than-rest/src

files=(
	"SnackFlix.Api/Program.cs"
	"SnackFlix.Api/AuthenticationExtensions.cs"
	"SnackFlix.Api/Accounts/AccountQueries.cs"
	"SnackFlix.Api/Accounts/AccountQueriesType.cs"
	"SnackFlix.Accounts/IdentityService.cs"
	"SnackFlix.Api/Reviews/ReviewMutations.cs"
	"SnackFlix.Api/Reviews/ReviewMutationsType.cs"
)

i=1
for file in "${files[@]}"; do
	echo "Opening file: $BASE_PATH/$file"
	rider $BASE_PATH/$file --column $i
	((i++))
done