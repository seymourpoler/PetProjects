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
});