package org.underscore;

import org.junit.Assert;
import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;
import java.util.concurrent.atomic.AtomicReference;
import java.util.function.Function;
import java.util.function.Predicate;

public class _Should {
    @Test
    public void each(){
        Boolean[] isExecuted = new Boolean[1];
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        _.each(numbers, x -> isExecuted[0] = true);

        Assert.assertTrue(isExecuted[0]);
    }

    @Test
    public void where_return_empty_list_when_list_is_empty(){
        List<Integer> numbers = Arrays.asList();
        Predicate<Integer> condition =  x -> x > 2;

        List<Integer> result = _.where(numbers, condition);

        Assert.assertEquals(0, result.size());
    }

    @Test
    public void where_return_empty_list_when_list_is_null(){
        Predicate<Integer> condition =  x -> x > 2;

        List<Integer> result = _.where(null, condition);

        Assert.assertEquals(0, result.size());
    }

    @Test
    public void where_with_lambda_predicate(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5);
        Predicate<Integer> condition = x -> (x % 2) == 0;

        List<Integer> result = _.where(numbers, condition);

        Assert.assertEquals(2, result.size());
    }

    @Test
    public void find_an_element(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Integer filter = 2;
        Predicate<Integer> condition = x -> x == filter;

        Optional<Integer> result = _.first(numbers, condition);

        Assert.assertEquals(Optional.of(filter), result);
    }

    @Test
    public void find_an_element_when_list_is_null(){
        final Integer filter = 2;
        Predicate<Integer> condition = x -> x == filter;

        Optional<Integer> result = _.first(null, condition);

        Assert.assertEquals(Optional.empty(), result);
    }

    @Test
    public void not_find_an_element(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        Predicate<Integer> condition = x -> x == 20;

        Optional<Integer> result = _.first(numbers, condition);

        Assert.assertFalse(result.isPresent());
    }

    @Test
    public void return_true_when_there_are_null_elements() {
        Boolean result = _.isEmpty(null);

        Assert.assertTrue(result);
    }

    @Test
    public void return_true_when_is_empty(){
        List<Integer> numbers = new ArrayList<>();

        Assert.assertTrue(_.isEmpty(numbers));
    }

    @Test
    public void return_true_when_is_not_empty(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        Assert.assertTrue(_.isNotEmpty(numbers));
    }

    @Test
    public void return_first(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

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
    public void return_list_empty_when_list_of_elements_are_null(){
        List<Integer> result = _.first(null, 3);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_list_empty_when_list_of_elements_are_empty(){
        List<Integer> numbers = Arrays.asList();

        List<Integer> result = _.first(numbers, 3);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_the_same_list_of_elements_when_the_limit_is_higher_than_the_number_of_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4);

        List<Integer> result = _.first(numbers, 7);

        Assert.assertEquals(numbers.size(), result.size());
    }

    @Test
    public void return_the_same_list_of_elements_when_the_limit_is_equals_than_the_number_of_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4);

        List<Integer> result = _.first(numbers, 4);

        Assert.assertEquals(numbers.size(), result.size());
    }

    @Test
    public void return_list_empty_when_the_limit_is_zero_on_first_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4);

        List<Integer> result = _.first(numbers, 0);

        Assert.assertEquals(Arrays.asList(), result);
    }

    @Test
    public void return_list_empty_when_the_limit_is_negative_on_first_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4);

        List<Integer> result = _.first(numbers, -2);

        Assert.assertEquals(Arrays.asList(), result);
    }

    @Test
    public void return_limit_the_first_number_of_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        List<Integer> result = _.first(numbers, 3);

        Assert.assertTrue(result.get(1).equals(2));
    }

    @Test
    public void return_last_element(){
        List<Integer> numbers = Arrays.asList(1,2);

        Optional<Integer> result = _.last(numbers);

        Assert.assertEquals(Optional.of(2), result);
    }

    @Test
    public void return_empty_when_there_is_no_last_element(){
        List<Integer> numbers = new ArrayList<Integer>();

        Optional<Integer> result = _.last(numbers);

        Assert.assertEquals(Optional.empty(), result);
    }

    @Test
    public void return_empty_when_last_elements_are_null(){
        List<Integer> result = _.last(null, 3);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_empty_when_last_elements_are_empty(){
        List<Integer> result = _.last(Arrays.asList(), 3);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_the_same_elements_when_last_number_is_higher_than_the_number_of_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        List<Integer> result = _.last(numbers, 10);

        Assert.assertEquals(numbers.size(), result.size());
    }

    @Test
    public void return_the_same_elements_when_last_number_is_equals_than_the_number_of_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        List<Integer> result = _.last(numbers, 6);

        Assert.assertEquals(numbers.size(), result.size());
    }

    @Test
    public void return_list_empty_when_last_number_is_zero(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        List<Integer> result = _.last(numbers, 0);

        Assert.assertEquals(result, Arrays.asList());
    }

    @Test
    public void return_list_empty_when_last_number_is_negative(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        List<Integer> result = _.last(numbers, -2);

        Assert.assertEquals(result, Arrays.asList());
    }

    @Test
    public void return_last_number_of_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        List<Integer> result = _.last(numbers, 3);

        Assert.assertTrue( result.get(1).equals(5));
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
    public void return_true_when_some_one_pass_the_condition(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        Predicate<Integer> condition = x -> x > 2;

        Boolean result = _.any(numbers, condition);

        Assert.assertTrue(result);
    }

    @Test
    public void return_false_when_nothing_pass_the_condition(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        Predicate<Integer> condition = x -> x > 100;

        Boolean result = _.any(numbers, condition);

        Assert.assertFalse(result);
    }

    @Test
    public void return_false_when_some_one_not_pass_the_condition(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        Predicate<Integer> condition = x -> x > 2;

        Boolean result = _.all(numbers, condition);

        Assert.assertFalse(result);
    }

    @Test
    public void return_true_when_all_pass_the_condition(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        Predicate<Integer> condition = x -> x > 0;

        Boolean result = _.all(numbers, condition);

        Assert.assertTrue(result);
    }

    @Test
    public void return_true_when_none_pass_the_condition(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        Predicate<Integer> condition = x -> x > 100;

        Boolean result = _.none(numbers, condition);

        Assert.assertTrue(result);
    }

    @Test
    public void return_true_when_some_pass_the_condition(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        Predicate<Integer> condition = x -> x > 5;

        Boolean result = _.none(numbers, condition);

        Assert.assertFalse(result);
    }

    @Test
    public void return_zero_elements_when_is_null(){
        Integer result = _.count(null);

        Assert.assertTrue(result.equals(0));
    }

    @Test
    public void return_zero_elements_when_there_are_no_elements(){
        List<Integer> numbers = Arrays.asList();

        Integer result = _.count(numbers);

        Assert.assertTrue(result.equals(0));
    }

    @Test
    public void return_number_of_elements(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5);

        Integer result = _.count(numbers);

        Assert.assertTrue(result.equals(5));
    }

    @Test
    public void map(){
        List<Integer> numbers = Arrays.asList(1,2,3,4);
        Function<Integer, Integer> mapper = x ->  x + 1;
        List<Integer> result = _.map(numbers, mapper);

        Assert.assertTrue( result.get(0).equals(2));
    }

    @Test
    public void return_zero_when_there_is_no_numbers(){
        List<Integer> numbers = Arrays.asList();

        Integer result = _.sum(numbers);

        Assert.assertTrue(result.equals(0));
    }

    @Test
    public void return_sum(){
        List<Integer> numbers = Arrays.asList(1,2);

        Integer result = _.sum(numbers);

        Assert.assertTrue(result.equals(3));
    }

    @Test
    public void return_max(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        Integer result = _.max(numbers);

        Assert.assertTrue(result.equals(6));
    }

    @Test
    public void return_min(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        Integer result = _.min(numbers);

        Assert.assertTrue(result.equals(1));
    }

    @Test
    public void return_reversed(){
        List<Integer> numbers = Arrays.asList(1,2,3,4,5);

        List<Integer> result = _.reverse(numbers);

        Assert.assertTrue(result.get(0).equals(5));
    }

    @Test
    public void return_zipped(){
        List<String> animals = Arrays.asList("monkey", "rabbit");
        List<String> fruits = Arrays.asList("berry", "banana");

        List<String> result = _.zip(animals, fruits);

        Assert.assertTrue(result.get(0).equals("monkey"));
        Assert.assertTrue(result.get(4).equals("banana"));
    }

    @Test(expected = IllegalArgumentException.class)
    public void throws_illegal_argument_exception_when_runable_is_null(){
        _.times(2, null);

        Assert.fail("IllegalArgumentException expected");
    }

    @Test
    public void no_execute_when_number_of_times_is_zero(){
        AtomicReference<Integer> numberOfTimesResult = new AtomicReference<>(0);

        _.times(0, () ->{
            numberOfTimesResult.getAndSet(numberOfTimesResult.get() + 1);
        });

        Assert.assertTrue( numberOfTimesResult.get().equals(0));
    }

    @Test
    public void no_execute_when_number_of_times_is_negative(){
        AtomicReference<Integer> numberOfTimesResult = new AtomicReference<>(0);

        _.times(-3, () ->{
            numberOfTimesResult.getAndSet(numberOfTimesResult.get() + 1);
        });

        Assert.assertTrue( numberOfTimesResult.get().equals(0));
    }

    @Test
    public void execute_number_of_times(){
        AtomicReference<Integer> numberOfTimesResult = new AtomicReference<>(0);

        _.times(3, () ->{
            numberOfTimesResult.getAndSet(numberOfTimesResult.get() + 1);
        });

        Assert.assertTrue( numberOfTimesResult.get().equals(3));
    }
}
