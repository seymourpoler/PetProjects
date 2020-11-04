function spyAllMethodsOf(element){
    // const allMethods = Object.getOwnPropertyNames(element).filter(item => typeof element[item] === 'function')
    // for(let method in allMethods){
    //     spyOn(element, method);
    // }

    for (var property in element) {
        if (typeof element[property] == "function") {
            spyOn(element, property);
        }
    }
}