let MiniCache = require('./MiniCache');

describe('MiniCache', function(){
    let miniCache;

    beforeEach(function(){
        miniCache = new MiniCache();
    });

    it('sets value', function(){
        const key = 'key';
        const value = 'value';
        miniCache.set(key, value);

        const result = miniCache.get(key);

        expect(result).toEqual(value);
    });

    it('do not set key if is undefined', function(){
        const key = undefined;
        const value = 'value';
        miniCache.set(key, value);

        const result = miniCache.contains(key);

        expect(result).toBeFalsy();
    });

    it('do not set key if is string empty', function(){
        const key = '';
        const value = 'value';
        miniCache.set(key, value);

        const result = miniCache.contains(key);

        expect(result).toBeFalsy();
    });

    it('do not set value if is undefined', function(){
        const key = 'key';
        const value = undefined;
        miniCache.set(key, value);

        const result = miniCache.contains(key);

        expect(result).toEqual(undefined);
    });

    it('do not set value if is string empty', function(){
        const key = 'key';
        const value = '';
        miniCache.set(key, value);

        const result = miniCache.contains(key);

        expect(result).toEqual(undefined);
    });

    it('return false if does not contain key', function(){
        const key = 'key';
        const value = 'value';
        miniCache.set(key, value);

        const result = miniCache.contains('another-key');

        expect(result).toBeFalsy();
    });
});