var assert = {};  
assert.count = 0;
function assert(message, expression){
    if(!expression){
        throw new Error(message)
    }
    assert.count ++;
    return true;
}