#!/usr/bin/bash

BASE_PATH=$HOME/code/github/graphql-is-cooler-than-rest/src

files=(
	"SnackFlix.Vue/src/apollo-client.ts"
	"SnackFlix.Vue/src/App.vue"
)

i=1
for file in "${files[@]}"; do
	echo "Opening file: $BASE_PATH/$file"
	rider $BASE_PATH/$file --column $i
	((i++))
done