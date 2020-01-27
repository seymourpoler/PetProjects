package jascal;

import org.junit.Test;

import static jascal.StringsUtils.isNullOrWhiteSpace;
import static junit.framework.TestCase.assertTrue;

public class StringsUtilsShould {
    @Test
    public void return_false_when_is_null(){
        assertTrue(isNullOrWhiteSpace(null));
    }
}
