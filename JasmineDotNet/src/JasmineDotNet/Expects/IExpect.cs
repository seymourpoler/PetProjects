namespace JasmineDotNet.Expects
{
    public interface IExpect
    {
        /*
        'toBe', 
        'toBeCloseTo', 
        'toBeDefined', 
        'toBeFalsy', 
        'toBeGreaterThan', 
        'toBeLessThan', 
        'toBeNaN', 
        'toBeNull', 
        'toBeTruthy', 
        'toBeUndefined', 
        'toContain', 
        'toEqual', 
        'toHaveBeenCalled', 
        'toHaveBeenCalledWith', 
        'toHaveBeenCalledTimes', 
        'toMatch', 
        'toThrow', 
        'toThrowError'
        */

        void ToBeNull();
        void ToBe<T>(T expected);
        void ToBeTrue();
        void ToBeFalse();
        void ToThrow<T>();
        void ToContain(string value);
    }
}