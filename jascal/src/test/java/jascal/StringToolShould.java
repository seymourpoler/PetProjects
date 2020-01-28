package jascal;

import org.junit.Test;

import static jascal.StringTool.isNullOrWhiteSpace;
import static junit.framework.TestCase.assertTrue;

public class StringToolShould {
    @Test
    public void return_false_when_is_null(){
        assertTrue(isNullOrWhiteSpace(null));
    }

    @Test
    public void return_false_when_is_string_empty(){
        assertTrue(isNullOrWhiteSpace(""));
    }

    @Test
    public void return_false_when_is_white_space(){
        assertTrue(isNullOrWhiteSpace("  "));
    }
}
