#!/usr/bin/env bash

BASE_PATH=$HOME/code/github/graphql-is-cooler-than-rest/src

openFile() {
  local filename="$1"
  local OS=$(uname)
  
  if [[ "$OS" == "Darwin" ]]; then
    open -na "Rider.app" --args "$filename"
  elif [[ "$OS" == "Linux" ]]; then
    rider $BASE_PATH/$filename 
  else
    echo "Unsupported OS: $OS"
    return 1
  fi
}

openFiles() {
  files="$1"
  
  for file in "${files[@]}"; do
    echo "Opening file: $BASE_PATH/$file"
    openFile "$BASE_PATH/$file" 
  done 
}