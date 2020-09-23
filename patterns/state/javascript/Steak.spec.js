const createSteak = require('./Steak');
const Doneness = require('./Doneness');

describe('Steak', function(){
    const initialTemperature = 0;

    describe('when decreasing temperature ', () =>{
        let steak;

        beforeEach(function(){
            steak = createSteak();
        });

        it('decrease temperature', () =>{
            const someTemperature = 50;
            steak.increaseTemperature(someTemperature);

            steak.decreaseTemperature(someTemperature);

            expect(steak.getTemperature()).toBe(initialTemperature);
        });

        it('decrease temperature, until the minimum value', () =>{
            const someTemperature = 50;
            const initialTemperature = 0;
            steak.increaseTemperature(someTemperature);
            steak.decreaseTemperature(someTemperature);

            steak.decreaseTemperature(someTemperature);

            expect(steak.getTemperature()).toBe(initialTemperature);
        });
    });

    describe('when steak is not cooked', function(){
        it('is uncooked', function(){
            const steak = createSteak();

            expect(steak.getDoneness()).toBe(Doneness.UnCooked);
        });

        it('increase temperature', function(){
            const steak = createSteak();
            const someTemperature = 50;

            steak.increaseTemperature(someTemperature);

            expect(steak.getTemperature()).toBe(someTemperature);
            expect(steak.getDoneness()).toBe(Doneness.Raw);
        });

        it('decrease temperature', function(){
            const steak = createSteak();
            const someTemperature = 50;

            steak.decreaseTemperature(someTemperature);

            expect(steak.getTemperature()).toBe(initialTemperature);
            expect(steak.getDoneness()).toBe(Doneness.UnCooked);
        });
    });

    describe('when has low temperature', function(){
        let steak;
        
        beforeEach(function(){
            steak = createSteak();
            steak.increaseTemperature(50);
        });

        it('is raw meat', function(){
            expect(steak.getDoneness()).toBe(Doneness.Raw);
        });
        
        it('increase temperature', function(){
            steak.increaseTemperature(25);

            expect(steak.getTemperature()).toBe(75);
            expect(steak.getDoneness()).toBe(Doneness.Raw);
        });

        it('decrease temperature', function(){
            steak.decreaseTemperature(50);

            expect(steak.getTemperature()).toBe(initialTemperature);
            expect(steak.getDoneness()).toBe(Doneness.Raw);
        });

        describe('when is raw', function(){
            
            beforeEach(function(){
                steak.increaseTemperature(50);
            });

            it('is medium raw if increase more temperature', function(){
                steak.increaseTemperature(25);

                expect(steak.getDoneness()).toBe(Doneness.MedumRaw);
            });

            it('is raw if decrease more temperature', function(){
                steak.decreaseTemperature(50);

                expect(steak.getDoneness()).toBe(Doneness.Raw);
            });

            describe('when is medium raw', function(){

                beforeEach(function(){
                    steak.increaseTemperature(25);
                });

                it('is medium if increase temperature', function(){
                    steak.increaseTemperature(25);
    
                    expect(steak.getDoneness()).toBe(Doneness.Medum);
                });

                it('is medium if decrease temperature', function(){
                    steak.decreaseTemperature(50);
    
                    expect(steak.getDoneness()).toBe(Doneness.Raw);
                });

                describe('when is medium', function(){

                    beforeEach(function(){
                        steak.increaseTemperature(25);
                    });
    
                    it('is well done if increase temperature', function(){
                        steak.increaseTemperature(25);
        
                        expect(steak.getDoneness()).toBe(Doneness.WellDone);
                    });

                    it('is well done if decrease temperature', function(){
                        steak.decreaseTemperature(5);
        
                        expect(steak.getDoneness()).toBe(Doneness.Medum);
                    });
                });
            });
        });
    });
});