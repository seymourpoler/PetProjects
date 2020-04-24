package net.seymourpoler;

import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class StringUtilShould {
    @Test
    public void
    return_true_when_is_null(){
        assertThat(StringUtil.isNullOrWhiteSpace(null)).isTrue();
    }

    @Test
    public void
    return_true_when_is_empty(){
        assertThat(StringUtil.isNullOrWhiteSpace("")).isTrue();
    }

    @Test
    public void
    return_true_when_is_white_space(){
        assertThat(StringUtil.isNullOrWhiteSpace("   ")).isTrue();
    }

    @Test
    public void
    return_true_when_has_value(){
        assertThat(StringUtil.isNullOrWhiteSpace("aswdef")).isFalse();
    }
}