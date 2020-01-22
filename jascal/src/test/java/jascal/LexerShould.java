package jascal;

import org.junit.Test;

import java.util.List;

public class LexerShould {

    @Test
    public void return_an_empty_list_when_code_is_null(){
        Lexer lexer = new Lexer();

        List<Token> tokens = lexer.scan(null);
    }
}
