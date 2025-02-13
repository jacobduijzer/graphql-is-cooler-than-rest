#!/usr/bin/env bash

source helpers.sh

files=(
	"SnackFlix.Api/Program.cs"
	"SnackFlix.Api/AuthenticationExtensions.cs"
	"SnackFlix.Api/Accounts/AccountQueries.cs"
	"SnackFlix.Api/Accounts/AccountQueriesType.cs"
	"SnackFlix.Accounts/IdentityService.cs"
	"SnackFlix.Api/Reviews/ReviewMutations.cs"
	"SnackFlix.Api/Reviews/ReviewMutationsType.cs"
)

openFiles "${files[@]}"