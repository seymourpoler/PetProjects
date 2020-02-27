package org.underscore;

import org.junit.Assert;
import org.junit.Test;

import java.util.Arrays;
import java.util.List;
import java.util.function.Function;
import java.util.function.Predicate;

public class UnderscoreShould {

    @Test
    public void apply_chains_of_functions(){
        Function<Integer, Integer> addOne = x -> x + 1;
        Function<Integer, Boolean> dividiedByTwo  = x -> x %2 == 0;
        Predicate<Integer> moreThanTwo = x -> x > 2;
        List<Integer> numbers = Arrays.asList(1,2,3,4,5);
        List<Integer> result = new Underscore(numbers)
                .map(addOne)
                .filter(dividiedByTwo)
                .filter(moreThanTwo)
                .result();

        Assert.assertTrue(result.get(0).equals(2));
        Assert.assertTrue(result.get(1).equals(4));
    }
}
