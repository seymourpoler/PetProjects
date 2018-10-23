let MiniEventEmitter = require('./MiniEventEmitter');

describe('Mini Event Emitter', function(){
	let eventEmiter = new MiniEventEmitter();
	
	it('handles an event', function(){
		let eventWasThrown = false;
		const theEvent = 'THE_EVENT';
		eventEmiter.subscribe(theEvent, function(){
			eventWasThrown = true;
		});
		
		eventEmiter.emit(theEvent);
		
		expect(eventWasThrown).toBeTruthy();
	});
	
	it('subscribes multiple handlers for the same event', function(){
		let eventWasThrown = false;
		let anotherEventWasThrown = false;
		const theEvent = 'THE_EVENT';
		eventEmiter.subscribe(theEvent, function(){
			eventWasThrown = true;
		});
		eventEmiter.subscribe(theEvent, function(){
			anotherEventWasThrown = true;
		});
		
		eventEmiter.emit(theEvent);
		
		expect(eventWasThrown).toBeTruthy();
		expect(anotherEventWasThrown).toBeTruthy();
	});
	
	it('unsubscribes all handlers for an event', function(){
		let eventWasThrown = false;
		const theEvent = 'THE_EVENT';
		eventEmiter.subscribe(theEvent, function(){
			eventWasThrown = true;
		});
		eventEmiter.emit(theEvent);		
		expect(eventWasThrown).toBeTruthy();
		
		eventEmiter.unSubscribe(theEvent);
		eventWasThrown = false;
		eventEmiter.emit(theEvent);
		
		expect(eventWasThrown).toBeFalsy();
	});
});