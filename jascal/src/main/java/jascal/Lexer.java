package jascal;

import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.util.ArrayList;
import java.util.List;

import static jascal.StringsUtils.isNullOrWhiteSpace;

public class Lexer {
    public List<Word> scan(String text){

        if(isNullOrWhiteSpace(text)){
            return new ArrayList<Word>();
        }
        throw new NotImplementedException();
    }
}
