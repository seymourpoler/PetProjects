import { SHOW_SPINNER } from './Actions.types';
import { showSpinner } from './Actions';

describe('Articles', () => {
    it('shows spinner', () => {
        var result = showSpinner();

        expect(result.type).toBe(SHOW_SPINNER);
    });
});