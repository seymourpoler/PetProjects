import { createEditTodoView } from './EditTodoView';
import { spyAllMethodsOf } from '../../Testing';
import { EditTodoPresenter } from './EditTodoPresenter';

describe('EditTodoPresenter', () => {
    let view, presenter;

    beforeEach(() => {
        view = createEditTodoView();
        spyAllMethodsOf(view);

        presenter = new EditTodoPresenter(view);
    });

    describe('when update todo is requested', () => {
        it('cleans messages', () => {
            presenter.update();

            expect(view.cleanMessages).toHaveBeenCalled();
        });

        it('shows spinner', () => {
            presenter.update();

            expect(view.showSpinner).toHaveBeenCalled();
        });
    });
});