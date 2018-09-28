import { SHOW_SPINNER, HIDE_SPINNER } from './Actions.types';
import { showSpinner, hideSpinner } from './Actions';

describe('Articles', () => {
    it('shows spinner', () => {
        var result = showSpinner();

        expect(result.type).toBe(SHOW_SPINNER);
    });

    it('hides spinner', () => {
        var result = hideSpinner();

        expect(result.type).toBe(HIDE_SPINNER);
    });
});