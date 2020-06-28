import { createEditTodoView } from './EditTodoView';
import { spyAllMethodsOf } from '../../Testing';
import { EditTodoPresenter } from './EditTodoPresenter';
import { createEditTodoService } from './EditTodoService';
import { HttpStatusCode } from '../../HttpStatusCode';

describe('EditTodoPresenter', () => {
    let view, service, presenter;

    beforeEach(() => {
        view = createEditTodoView();
        spyAllMethodsOf(view);
        service = createEditTodoService();
        spyAllMethodsOf(service);
        presenter = new EditTodoPresenter(view, service);
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

        it('shows error if there is an internal server error', () => {
            service.update = () => { return { statusCode: HttpStatusCode.internalServerError }};

            presenter.update();

            expect(view.showInternalServerError).toHaveBeenCalled();
        });
    });
});