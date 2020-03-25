package org.underscore;

import org.junit.Assert;
import org.junit.Test;

public class CheckerShould {

    @Test(expected = IllegalArgumentException.class)
    public void throw_exception_when_is_null() throws Throwable {
        Checker.ifNull(IllegalArgumentException.class, null);

        Assert.fail("exception expected");
    }
}
