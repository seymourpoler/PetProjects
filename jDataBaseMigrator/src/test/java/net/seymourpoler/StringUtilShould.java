package net.seymourpoler;

import org.junit.Assert;
import org.junit.Test;

public class StringUtilShould {
    @Test
    public void
    return_true_when_is_null(){
        Assert.assertTrue(StringUtil.isNullOrWhiteSpace(null));
    }
}