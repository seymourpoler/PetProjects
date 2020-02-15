package org.underscore;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.function.Function;
import java.util.function.Predicate;

public class _Should {
    @Test
    public void each(){
        Boolean[] isExecuted = new Boolean[1];
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);

        _.each(numbers, x -> isExecuted[0] = true);

        Assert.assertTrue(isExecuted[0]);
    }

    @Test
    public void where_with_lambda_function(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);
        numbers.add(4);
        Function<Integer, Boolean> condition = x -> (x % 2) == 0;

        List<Integer> result = _.where(numbers, condition);

        Assert.assertEquals(2, result.size());
    }

    @Test
    public void where_with_lambda_predicate(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);
        numbers.add(4);
        Predicate<Integer> condition = x -> (x % 2) == 0;

        List<Integer> result = _.where(numbers, condition);

        Assert.assertEquals(2, result.size());
    }

    @Test
    public void find_an_element(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);
        numbers.add(4);
        final Integer filter = 2;
        Function<Integer, Boolean> condition = x -> x == filter;

        Optional<Integer> result = _.find(numbers, condition);

        Assert.assertEquals(Optional.of(filter), result);
    }

    @Test
    public void not_find_an_element(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);
        numbers.add(4);
        Function<Integer, Boolean> condition = x -> x == 20;

        Optional<Integer> result = _.find(numbers, condition);

        Assert.assertFalse(result.isPresent());
    }

    @Test
    public void return_true_when_is_empty(){
        List<Integer> numbers = new ArrayList<>();

        Assert.assertTrue(_.isEmpty(numbers));
    }

    @Test
    public void return_true_when_is_not_empty(){
        List<Integer> numbers = new ArrayList<>();
        numbers.add(2);

        Assert.assertTrue(_.isNotEmpty(numbers));
    }

    @Test
    public void return_first(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);
        numbers.add(4);

        Optional<Integer> result = _.first(numbers);

        Assert.assertEquals(Optional.of(1), result);
    }

    @Test
    public void no_return_first(){
        List<Integer> numbers = new ArrayList<Integer>();

        Optional<Integer> result = _.first(numbers);

        Assert.assertEquals(Optional.empty(), result);
    }

    @Test
    public void return_last_element(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);

        Optional<Integer> result = _.last(numbers);

        Assert.assertEquals(Optional.of(2), result);
    }

    @Test
    public void return_no_last_element(){
        List<Integer> numbers = new ArrayList<Integer>();
        Optional<Integer> result = _.last(numbers);

        Assert.assertEquals(Optional.empty(), result);
    }

    @Test
    public void return_true_when_is_null(){
        Assert.assertTrue(_.isNull(null));
    }

    @Test
    public void return_true_when_is_not_null(){
        List<Integer> numbers = new ArrayList<Integer>();

        Assert.assertTrue(_.isNotNull(numbers));
    }

    @Test
    public void map(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);
        Function<Integer, Integer> mapper = x ->  x + 1;
        List<Integer> result = _.map(numbers, mapper);

        Assert.assertTrue( result.get(0).equals(2));
    }

    @Test
    public void return_sum(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);

        Integer result = _.sum(numbers);

        Assert.assertTrue(result.equals(3));
    }

    @Test
    public void return_max(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);
        numbers.add(4);

        Integer result = _.max(numbers);

        Assert.assertTrue(result.equals(4));
    }

    @Test
    public void return_min(){
        List<Integer> numbers = new ArrayList<Integer>();
        numbers.add(1);
        numbers.add(2);
        numbers.add(3);
        numbers.add(4);

        Integer result = _.min(numbers);

        Assert.assertTrue(result.equals(4));
    }
}
