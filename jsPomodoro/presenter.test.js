import { describe, it, expect, vi, beforeEach, afterEach } from "vitest";
const View = require('./view');
const Presenter = require('./presenter')

describe('Presenter', () =>{
    let view, presenter;

    beforeEach(() =>{
        view = new View();
        presenter = new Presenter(view);
    });

    it('works', () =>{
        expect(true).toBeTruthy();
    });
});