let MiniCache = require('./MiniCache');

describe('MiniCache', function(){
    let miniCache;

    beforeEach(function(){
        miniCache = new MiniCache();
    });

    it('saves value', function(){
        const key = 'key';
        const value = 'value';
        miniCache.set(key, value);

        const result = miniCache.get(key);

        expect(result).toEqual(value);
    });

    it('do not save key if is undefined', function(){
        const key = undefined;
        const value = 'value';
        miniCache.set(key, value);

        const result = miniCache.contains(key);

        expect(result).toBeFalsy();
    });

    it('do not save key if is string empty', function(){
        const key = '';
        const value = 'value';
        miniCache.set(key, value);

        const result = miniCache.contains(key);

        expect(result).toBeFalsy();
    });

    it('do not save value if is undefined', function(){
        const key = 'key';
        const value = undefined;
        miniCache.set(key, value);

        const result = miniCache.contains(key);

        expect(result).toEqual(undefined);
    });

    it('do not save value if is string empty', function(){
        const key = 'key';
        const value = '';
        miniCache.set(key, value);

        const result = miniCache.contains(key);

        expect(result).toEqual(undefined);
    });
});