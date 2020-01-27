package jascal;

import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.util.ArrayList;
import java.util.List;

import static jascal.StringsUtils.isNullOrWhiteSpace;

public class Lexer {
    public List<jascal.Token> scan(String text){

        if(isNullOrWhiteSpace(text)){
            return new ArrayList<Token>();
        }
        throw new NotImplementedException();
    }
}
