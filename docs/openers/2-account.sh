#!/usr/bin/bash

BASE_PATH=$HOME/code/github/graphql-is-cooler-than-rest/src

files=(
	"SnackFlix.Api/Program.cs"
	"SnackFlix.Api/Accounts/AccountMutations.cs"
	"SnackFlix.Api/Accounts/AccountSubscriptions.cs"
	"SnackFlix.Api/Accounts/AccountAddedPayload.cs"
	"SnackFlix.Api/Accounts/Account.cs"
)

i=1
for file in "${files[@]}"; do
	echo "Opening file: $BASE_PATH/$file"
	rider $BASE_PATH/$file --column $i
	((i++))
done