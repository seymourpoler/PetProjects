#!/bin/bash

while true; do 
    printf "\033c" #clear screen
    groovy Allkoans.groovy
    sleep 5;
done