package net.seymourpoler.jDataBaseMigrator;

import org.junit.Test;

public class CheckShould {
    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_is_null(){
        Check.isNullOrWhiteSpace(null);
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_is_string_empty(){
        Check.isNullOrWhiteSpace("");
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_is_white_space(){
        Check.isNullOrWhiteSpace("     ");
    }

    @Test
    public void
    do_nothing_when_has_value(){
        Check.isNullOrWhiteSpace(" some value    ");
    }
}
