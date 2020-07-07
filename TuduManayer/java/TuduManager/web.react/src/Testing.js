export function spyAllMethodsOf(element){
    Object
        .getOwnPropertyNames(element)
        .filter(item => typeof element[item] === 'function')
        .forEach(property => {
            jest.spyOn(element, property).mockImplementation();
        });
}