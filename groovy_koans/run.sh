#!/bin/bash

# while true; do 
#    printf "\033c" #clear screen
#    groovy AllKoans.groovy
#    sleep 5;
#done



chsum1=""

    while [[ true ]]
    do
        chsum2=`find koans/ -type f -exec md5sum {} \;`
        if [[ $chsum1 != $chsum2 ]] ; then
        	printf "\033c" #clear screen          
            groovy AllKoans.groovy
            chsum1=$chsum2
        fi
        sleep 2
    done