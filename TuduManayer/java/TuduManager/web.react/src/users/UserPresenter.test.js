import { createUserService } from './UserService';
import { UserPresenter } from './UserPresenter';
import { spyAllMethodsOf } from '../Testing';
import { createUserView } from './UserView';

describe('User Presenter', () => {

    let view;
    let service;
    let presenter;

    beforeEach(() => {
        view = createUserView();
        spyAllMethodsOf(view);
        service = createUserService();
        spyAllMethodsOf(service);
        presenter = new UserPresenter(view, service);
    });

    describe('loading users is requested', () => {
        it('shows error when there is an internal server error', () => {
            service.find = () => {
                expect(view.showSpinner).toHaveBeenCalled();
                return {statusCode: 500};
            };

            presenter.find();

            expect(view.hideSpinner).toHaveBeenCalled();
            expect(view.showInternalServerError).toHaveBeenCalled();
        });

        it('shows users', () => {
            const users = [];
            service.find = () => {
                return {statusCode: 200, users};
            };

            presenter.find();

            expect(view.show).toHaveBeenCalledWith(users);
            expect(view.cleanErrors).toHaveBeenCalled();
        });
    });
});