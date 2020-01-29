package jascal;

import org.junit.Test;

import java.util.List;

import static org.junit.Assert.assertTrue;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class WordScannerShould {

    @Test
    public void return_end_of_file_when_there_is_no_text(){
        TextReader textReader = mock(TextReader.class);
        when(textReader.isEmpty()).thenReturn(true);
        WordScanner wordScanner = new WordScanner(textReader);

        List<Word> words = wordScanner.scan();

        assertTrue(words.isEmpty());
    }
}
