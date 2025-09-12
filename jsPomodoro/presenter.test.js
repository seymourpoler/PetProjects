import { describe, it, expect, vi, beforeEach } from "vitest";
const View = require('./view');
const Presenter = require('./presenter')

describe('Presenter', () =>{
    let view, presenter;

    beforeEach(() =>{
        view = new View();
        vi.spyOn(view, 'showTime');
        presenter = new Presenter(view);
    });

    describe('When it is loaded', () =>{
        it('show the default time', () =>{
            expect(view.showTime).toHaveBeenCalledWith({minutes: 25, seconds: 0});
        });
    });
});