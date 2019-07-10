#!/bin/bash

while true; do 
    printf "\033c" #clear screen
    groovy AllKoans.groovy
    sleep 5;
done