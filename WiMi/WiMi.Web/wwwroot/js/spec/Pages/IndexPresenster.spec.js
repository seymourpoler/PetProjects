describe('Index Presenter', function () {
    var presenter, view, client;
    
    beforeEach(function () {
        view = WiMi.Pages.Index.createIndexView();
        WiMi.spyAllMethodsOf(view);
        client = WiMi.Pages.Index.createIndexClient();
        WiMi.spyAllMethodsOf(client);
        presenter = new WiMi.Pages.Index.IndexPresenter(view, client);
    });

    describe('when creation new page is requested', function () {
        it('shows an error if there is an internal server error', function () {
            const title = 'title';
            const body = 'content';
            var errors = {'statusCode':WiMi.HttpStatusCode.InternalServerError, errors:[]};
            client.save.andCallFake(function(page, successHandler, errorHandler){
                expect(page.title).toBe(title);
                expect(page.body).toBe(body);
                errorHandler(errors);
            });

            presenter.create({title:title, body: body});

            expect(view.showErrors).toHaveBeenCalledWith();
            expect(true).toBe(false);
        });
    });
});