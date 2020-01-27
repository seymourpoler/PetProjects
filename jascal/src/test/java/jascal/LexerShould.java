package jascal;

import org.junit.Test;

import java.util.List;

public class LexerShould {

    @Test
    public void return_an_empty_list_when_code_is_null(){
        Lexer lexer = new Lexer();

        List<Token> tokens = lexer.scan(null);
    }

    @Test
    public void return_an_empty_list_when_code_is_string_empty(){
        Lexer lexer = new Lexer();

        List<Token> tokens = lexer.scan("");
    }

    @Test
    public void return_an_empty_list_when_code_is_white_space(){
        Lexer lexer = new Lexer();

        List<Token> tokens = lexer.scan(" ");
    }
}
