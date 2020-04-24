package net.seymourpoler;

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
}
