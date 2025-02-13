#!/usr/bin/env bash

source helpers.sh

files=(
	"SnackFlix.Api/Program.cs"
	"SnackFlix.Api/Accounts/AccountMutations.cs"
	"SnackFlix.Api/Accounts/AccountSubscriptions.cs"
	"SnackFlix.Api/Accounts/AccountAddedPayload.cs"
	"SnackFlix.Api/Accounts/Account.cs"
)
  
openFiles "${files[@]}"