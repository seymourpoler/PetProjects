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
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        _.each(numbers, x -> isExecuted[0] = true);

        Assert.assertTrue(isExecuted[0]);
    }

    @Test
    public void where_return_empty_list_when_list_is_empty(){
        final List<Integer> numbers = Arrays.asList();
        final Predicate<Integer> condition =  x -> x > 2;

        final List<Integer> result = _.where(numbers, condition);

        Assert.assertEquals(0, result.size());
    }

    @Test
    public void where_return_empty_list_when_list_is_null(){
        final Predicate<Integer> condition =  x -> x > 2;

        final List<Integer> result = _.where(null, condition);

        Assert.assertEquals(0, result.size());
    }

    @Test
    public void where_with_lambda_predicate(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5);
        final Predicate<Integer> condition = x -> (x % 2) == 0;

        final List<Integer> result = _.where(numbers, condition);

        Assert.assertEquals(2, result.size());
    }

    @Test
    public void find_an_element(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Integer filter = 2;
        final Predicate<Integer> condition = x -> x == filter;

        final Optional<Integer> result = _.first(numbers, condition);

        Assert.assertEquals(Optional.of(filter), result);
    }

    @Test
    public void find_an_element_when_list_is_null(){
        final Integer filter = 2;
        final Predicate<Integer> condition = x -> x == filter;

        final Optional<Integer> result = _.first(null, condition);

        Assert.assertEquals(Optional.empty(), result);
    }

    @Test
    public void not_find_an_element(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Predicate<Integer> condition = x -> x == 20;

        final Optional<Integer> result = _.first(numbers, condition);

        Assert.assertFalse(result.isPresent());
    }

    @Test
    public void return_true_when_there_are_null_elements() {
        final Boolean result = _.isEmpty(null);

        Assert.assertTrue(result);
    }

    @Test
    public void return_true_when_is_empty(){
        final List<Integer> numbers = new ArrayList<>();

        Assert.assertTrue(_.isEmpty(numbers));
    }

    @Test
    public void return_true_when_is_not_empty(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        Assert.assertTrue(_.isNotEmpty(numbers));
    }

    @Test
    public void return_first(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final Optional<Integer> result = _.first(numbers);

        Assert.assertEquals(Optional.of(1), result);
    }

    @Test
    public void no_return_first(){
        final List<Integer> numbers = new ArrayList<Integer>();

        final Optional<Integer> result = _.first(numbers);

        Assert.assertEquals(Optional.empty(), result);
    }

    @Test
    public void return_list_empty_when_list_of_elements_are_null(){
        final List<Integer> result = _.first(null, 3);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_list_empty_when_list_of_elements_are_empty(){
        final List<Integer> numbers = Arrays.asList();

        final List<Integer> result = _.first(numbers, 3);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_the_same_list_of_elements_when_the_limit_is_higher_than_the_number_of_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        final List<Integer> result = _.first(numbers, 7);

        Assert.assertEquals(numbers.size(), result.size());
    }

    @Test
    public void return_the_same_list_of_elements_when_the_limit_is_equals_than_the_number_of_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        final List<Integer> result = _.first(numbers, 4);

        Assert.assertEquals(numbers.size(), result.size());
    }

    @Test
    public void return_list_empty_when_the_limit_is_zero_on_first_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        final List<Integer> result = _.first(numbers, 0);

        Assert.assertEquals(Arrays.asList(), result);
    }

    @Test
    public void return_list_empty_when_the_limit_is_negative_on_first_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        final List<Integer> result = _.first(numbers, -2);

        Assert.assertEquals(Arrays.asList(), result);
    }

    @Test
    public void return_limit_the_first_number_of_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final List<Integer> result = _.first(numbers, 3);

        Assert.assertTrue(result.get(1).equals(2));
    }

    @Test
    public void return_last_element(){
        final List<Integer> numbers = Arrays.asList(1,2);

        final Optional<Integer> result = _.last(numbers);

        Assert.assertEquals(Optional.of(2), result);
    }

    @Test
    public void return_empty_when_there_is_no_last_element(){
        final List<Integer> numbers = new ArrayList<Integer>();

        final Optional<Integer> result = _.last(numbers);

        Assert.assertEquals(Optional.empty(), result);
    }

    @Test
    public void return_empty_when_last_elements_are_null(){
        final List<Integer> result = _.last(null, 3);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_empty_when_last_elements_are_empty(){
        final List<Integer> result = _.last(Arrays.asList(), 3);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_the_same_elements_when_last_number_is_higher_than_the_number_of_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final List<Integer> result = _.last(numbers, 10);

        Assert.assertEquals(numbers.size(), result.size());
    }

    @Test
    public void return_the_same_elements_when_last_number_is_equals_than_the_number_of_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final List<Integer> result = _.last(numbers, 6);

        Assert.assertEquals(numbers.size(), result.size());
    }

    @Test
    public void return_list_empty_when_last_number_is_zero(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final List<Integer> result = _.last(numbers, 0);

        Assert.assertEquals(result, Arrays.asList());
    }

    @Test
    public void return_list_empty_when_last_number_is_negative(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final List<Integer> result = _.last(numbers, -2);

        Assert.assertEquals(result, Arrays.asList());
    }

    @Test
    public void return_last_number_of_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final List<Integer> result = _.last(numbers, 3);

        Assert.assertTrue( result.get(1).equals(5));
    }

    @Test
    public void return_no_last_element(){
        final List<Integer> numbers = new ArrayList<Integer>();

        final Optional<Integer> result = _.last(numbers);

        Assert.assertEquals(Optional.empty(), result);
    }

    @Test
    public void return_true_when_is_null(){
        Assert.assertTrue(_.isNull(null));
    }

    @Test
    public void return_true_when_is_not_null(){
        final List<Integer> numbers = new ArrayList<Integer>();

        Assert.assertTrue(_.isNotNull(numbers));
    }

    @Test
    public void return_true_when_some_one_pass_the_condition(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Predicate<Integer> condition = x -> x > 2;

        final Boolean result = _.any(numbers, condition);

        Assert.assertTrue(result);
    }

    @Test
    public void return_false_when_nothing_pass_the_condition(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Predicate<Integer> condition = x -> x > 100;

        final Boolean result = _.any(numbers, condition);

        Assert.assertFalse(result);
    }

    @Test
    public void return_false_when_some_one_not_pass_the_condition(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Predicate<Integer> condition = x -> x > 2;

        final Boolean result = _.all(numbers, condition);

        Assert.assertFalse(result);
    }

    @Test
    public void return_true_when_all_pass_the_condition(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Predicate<Integer> condition = x -> x > 0;

        final Boolean result = _.all(numbers, condition);

        Assert.assertTrue(result);
    }

    @Test
    public void return_true_when_none_pass_the_condition(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Predicate<Integer> condition = x -> x > 100;

        final Boolean result = _.none(numbers, condition);

        Assert.assertTrue(result);
    }

    @Test
    public void return_true_when_some_pass_the_condition(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);
        final Predicate<Integer> condition = x -> x > 5;

        final Boolean result = _.none(numbers, condition);

        Assert.assertFalse(result);
    }

    @Test
    public void return_zero_elements_when_is_null(){
        final Integer result = _.count(null);

        Assert.assertTrue(result.equals(0));
    }

    @Test
    public void return_zero_elements_when_there_are_no_elements(){
        final List<Integer> numbers = Arrays.asList();

        final Integer result = _.count(numbers);

        Assert.assertTrue(result.equals(0));
    }

    @Test
    public void return_number_of_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5);

        final Integer result = _.count(numbers);

        Assert.assertTrue(result.equals(5));
    }

    @Test
    public void map(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);
        final Function<Integer, Integer> mapper = x ->  x + 1;

        final List<Integer> result = _.map(numbers, mapper);

        Assert.assertTrue( result.get(0).equals(2));
    }

    @Test
    public void return_zero_when_there_is_no_numbers(){
        final List<Integer> numbers = Arrays.asList();

        final Integer result = _.sum(numbers);

        Assert.assertTrue(result.equals(0));
    }

    @Test
    public void return_sum(){
        final List<Integer> numbers = Arrays.asList(1,2);

        final Integer result = _.sum(numbers);

        Assert.assertTrue(result.equals(3));
    }

    @Test
    public void return_max(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final Integer result = _.max(numbers);

        Assert.assertTrue(result.equals(6));
    }

    @Test
    public void return_min(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5,6);

        final Integer result = _.min(numbers);

        Assert.assertTrue(result.equals(1));
    }

    @Test
    public void return_reversed(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4,5);

        final List<Integer> result = _.reverse(numbers);

        Assert.assertTrue(result.get(0).equals(5));
    }

    @Test
    public void return_empty_list_when_zipping_the_first_list_is_null(){
        final List<String> fruits = Arrays.asList("berry", "banana");

        final List<String> result = _.zip(null, fruits);

        Assert.assertEquals(result, fruits);
    }

    @Test
    public void return_empty_list_when_zipping_the_first_list_or_empty(){
        final List<String> fruits = Arrays.asList("berry", "banana");

        final List<String> result = _.zip(Arrays.asList(), fruits);

        Assert.assertEquals(result, fruits);
    }

    @Test
    public void return_empty_list_when_zipping_the_second_list_is_null(){
        final List<String> fruits = Arrays.asList("berry", "banana");

        final List<String> result = _.zip(fruits, null);

        Assert.assertEquals(result, fruits);
    }

    @Test
    public void return_empty_list_when_zipping_and_lists_are_null(){
        final List<String> result = _.zip(null, null);

        Assert.assertEquals(result, Arrays.asList());
    }

    @Test
    public void return_zipped(){
        final List<String> animals = Arrays.asList("monkey", "rabbit");
        final List<String> fruits = Arrays.asList("berry", "banana");

        final List<String> result = _.zip(animals, fruits);

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

    @Test
    public void return_false_when_list_of_elements_are_null(){
        Assert.assertFalse(_.include(null, 5));
    }

    @Test
    public void return_false_when_included_element_is_null(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        Assert.assertFalse(_.include(numbers, null));
    }

    @Test
    public void return_false_when_is_not_included(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        Assert.assertFalse(_.include(numbers, 5));
    }

    @Test
    public void return_true_when_is_not_included(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        Assert.assertTrue(_.include(numbers, 4));
    }

    @Test
    public void return_empty_list_when_all_lists_are_null(){
        final List<Integer> numbers = _.union(null, null);

        Assert.assertTrue(numbers.isEmpty());
    }

    @Test
    public void return_second_list_when_first_list_is_null(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        final List<Integer> result = _.union(null, numbers);

        Assert.assertEquals(result, numbers);
    }

    @Test
    public void return_first_list_when_second_list_is_null(){
        final List<Integer> numbers = Arrays.asList(1,2,3,4);

        final List<Integer> result = _.union(numbers, null);

        Assert.assertEquals(result, numbers);
    }

    @Test
    public void return_union_list(){
        final List<Integer> firstList = Arrays.asList(1,2,3,4);
        final List<Integer> secondList = Arrays.asList(5,6,7,7,9);

        final List<Integer> result = _.union(firstList, secondList);

        Assert.assertEquals(firstList.size() + secondList.size(), result.size());
    }

    @Test
    public void return_empty_list_when_second_list_is_null(){
        final List<Integer> firstList = Arrays.asList(5,6,7,7,9);

        final List<Integer> result = _.intersection(firstList, null);

        Assert.assertEquals(0, result.size());
    }

    @Test
    public void return_empty_list_when_second_list_is_empty(){
        final List<Integer> firstList = Arrays.asList(5,6,7,7,9);
        final List<Integer> secondList = Arrays.asList();

        final List<Integer> result = _.intersection(firstList, secondList);

        Assert.assertEquals(0, result.size());
    }

    @Test
    public void return_empty_list_when_first_list_is_null(){
        final List<Integer> secondList = Arrays.asList(5,6,7,7,9);

        final List<Integer> result = _.intersection(null, secondList);

        Assert.assertEquals(0, result.size());
    }

    @Test
    public void return_empty_list_when_first_list_is_empty(){
        final List<Integer> firstList = Arrays.asList();
        final List<Integer> secondList = Arrays.asList(5,6,7,7,9);

        final List<Integer> result = _.intersection(firstList, secondList);

        Assert.assertEquals(0, result.size());
    }

    @Test
    public void return_intersected_elements(){
        final List<Integer> firstList = Arrays.asList(6, 1, 9, 8, 10);
        final List<Integer> secondList = Arrays.asList(5,6,7,7,9);

        final List<Integer> result = _.intersection(firstList, secondList);

        Assert.assertEquals(Arrays.asList(6,9), result);
    }

    @Test
    public void return_empty_list_when_the_lists_are_null(){
        final List<Integer> result = _.difference(null, null);

        Assert.assertTrue(result.isEmpty());
    }

    @Test
    public void return_the_first_list_when_the_second_one_is_null(){
        final List<Integer> firstList = Arrays.asList(1,2,3,4,5);

        final List<Integer> result = _.difference(firstList, null);

        Assert.assertTrue(result.equals(firstList));
    }

    @Test
    public void return_the_second_list_when_the_first_one_is_null(){
        final List<Integer> secondList = Arrays.asList(1,2,3,4,5);

        final List<Integer> result = _.difference(null, secondList);

        Assert.assertTrue(result.equals(secondList));
    }

    @Test
    public void return_the_differences(){
        final List<Integer> firstList = Arrays.asList(1,2,3,4,6);
        final List<Integer> secondList = Arrays.asList(1,2,3,4,5);

        final List<Integer> result = _.difference(firstList, secondList);

        Assert.assertTrue(result.equals(Arrays.asList(6)));
    }

    @Test
    public void return_empty_list_when_unique_list_is_null(){
        final List<Integer> result = _.uniq(null);

        Assert.assertTrue(result != null);
    }

    @Test
    public void return_empty_list_when_unique_list_is_empty(){
        final List<Integer> result = _.uniq(null);

        Assert.assertTrue(result != null);
    }

    @Test
    public void return_list_without_duplicated_elements(){
        final List<Integer> numbers = Arrays.asList(1,2,3,3,4,5,5,6);

        final List<Integer> result = _.uniq(numbers);

        Assert.assertTrue(result.equals(Arrays.asList(1,2,3,4,5,6)));
    }

    @Test
    public void return_empty_list_when_list_is_null(){
        final List<Integer> result = _.without(null, 9, 7);

        Assert.assertTrue(result.equals(Arrays.asList()));
    }

    @Test
    public void return_empty_list_when_numbers_are_null(){
        final List<Integer> result = _.without(Arrays.asList(1,2,3,4), null);

        Assert.assertTrue(result.equals(Arrays.asList()));
    }

    @Test
    public void return_list_without_elements(){
        final List<Integer> result = _.without(Arrays.asList(1,2,3,4,5,6), 3,7);

        Assert.assertTrue(result.equals(Arrays.asList(1,2,4,5,6)));
    }
}
