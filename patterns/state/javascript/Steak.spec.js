const createSteak = require('./Steak');
const Doneness = require('./Doneness');

describe('Steak', function(){
    it('works', function(){
        expect(true).toBe(true);
    });

    describe('when steak is not cooked', function(){
        it('is uncooked', function(){
            const steak = createSteak();

            expect(steak.getDoneness()).toBe(Doneness.UnCooked);
        });

        it('adds temperature', function(){
            const steak = createSteak();
            const someTemperature = 50;

            steak.addTemperature(someTemperature);

            expect(steak.getTemperature()).toBe(someTemperature);
        });
    });

    describe('when has low temperature', function(){
        let steak;
        
        beforeEach(function(){
            steak = createSteak();
            steak.addTemperature(50);
        });
        
        it('add temperature', function(){
            steak.addTemperature(25);

            expect(steak.getTemperature()).toBe(75);
        });

        it('is raw meat', function(){
            expect(steak.getDoneness()).toBe(Doneness.Raw);
        });

        describe('when is raw', function(){
            
            beforeEach(function(){
                steak.addTemperature(50);
            });

            it('is medium raw if adds more temperature', function(){
                steak.addTemperature(25);

                expect(steak.getDoneness()).toBe(Doneness.MedumRaw);
            });

            describe('when is medium raw', function(){

                beforeEach(function(){
                    steak.addTemperature(25);
                });

                it('is medium if adds more temperature', function(){
                    steak.addTemperature(25);
    
                    expect(steak.getDoneness()).toBe(Doneness.Medum);
                });

                describe('when is medium', function(){

                    beforeEach(function(){
                        steak.addTemperature(25);
                    });
    
                    it('is well done if adds more temperature', function(){
                        steak.addTemperature(25);
        
                        expect(steak.getDoneness()).toBe(Doneness.WellDone);
                    });
                });
            });
        });
    });
});