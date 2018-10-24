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
});