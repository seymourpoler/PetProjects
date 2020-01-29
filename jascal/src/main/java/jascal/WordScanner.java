package jascal;

import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.util.ArrayList;
import java.util.List;

public class WordScanner {

    private final TextReader textReader;

    public WordScanner(TextReader textReader) {
        this.textReader = textReader;
    }

    public List<Word> scan(){
        List<Word> words = new ArrayList<Word>();
        while (!textReader.isEmpty()){
            throw new NotImplementedException();
        }
        return words;
    }
}
