describe('Ruity', function(){
   describe('when is loading', function(){
        let view, imageReader, fileService;

        beforeEach(function(){
            imageReader = new ImageReader();
            spyAllMethodsOf(imageReader);
            fileService = new FileService();
            spyAllMethodsOf(fileService);
            view = new RuityView();
            spyAllMethodsOf(view);
            view.isNotActivated.and.returnValue(false);
        });

    it('show error message if file is not activated', function(){
        view.isNotActivated.and.returnValue(true);

        new RuityPresenter(view, imageReader, fileService);

        expect(view.showBrowserDoesNotSupportFileErrorMessage).toHaveBeenCalled();
    });

    it('initialize number of characters', function(){
        view.isNotActivated.and.returnValue(false);

        new RuityPresenter(view, imageReader);

        const initialNumberOfCharacters = 0;
        expect(view.showNumberOfCharacters).toHaveBeenCalledWith(initialNumberOfCharacters);
    });

    it('initialize number of words', function(){
        view.isNotActivated.and.returnValue(false);
        
        new RuityPresenter(view, imageReader, fileService);

        const initialNumberOfWords = 0;
        expect(view.showNumberOfWords).toHaveBeenCalledWith(initialNumberOfWords);
    });

    it('cleans text', function(){
        view.isNotActivated.and.returnValue(false);

        new RuityPresenter(view, imageReader, fileService);

        expect(view.cleanText).toHaveBeenCalled();
    });

    describe('when cleanning text is requested', function(){
        let onCleanningTextHandler;

        beforeEach(function(){
            view.subscribeToOnCleanningText.and.callFake(function(handler){
                onCleanningTextHandler = handler;
            });
            new RuityPresenter(view, imageReader, fileService);
        });

        it('cleans text', function(){
            onCleanningTextHandler();
            
            expect(view.cleanText).toHaveBeenCalled();
        });

        it('initialize number of characters', function(){
            onCleanningTextHandler();
    
            const initialNumberOfCharacters = 0;
            expect(view.showNumberOfCharacters).toHaveBeenCalledWith(initialNumberOfCharacters);
        });
    
        it('initialize number of words', function(){
            onCleanningTextHandler();
    
            const initialNumberOfWords = 0;
            expect(view.showNumberOfWords).toHaveBeenCalledWith(initialNumberOfWords);
        });
    });
    
    describe('when writting text is requested', function(){
        let onWritingTextHandler;

        beforeEach(function(){
            view.subscribeToOnWritingText.and.callFake(function(handler){
                onWritingTextHandler = handler;
            });
            new RuityPresenter(view, imageReader, fileService);
        });

        it('updated number of characters', function(){
            onWritingTextHandler('one upon a time', '<html>one upon a time</html>');

            expect(view.showNumberOfCharacters).toHaveBeenCalledWith(15);
        });

        it('updated number of words', function(){
            onWritingTextHandler('one upon a time', '<html>one upon a time</html>');

            expect(view.showNumberOfWords).toHaveBeenCalledWith(4);
        });
        
        describe('when writing as heading text is requested', function(){
            let onWritingHeadingTextHandler;
            beforeEach(function(){
                view.subscribeToOnWritingHeadingText.and.callFake(function(handler){
                    onWritingHeadingTextHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes heading text', function(){
                onWritingHeadingTextHandler();

                expect(view.showHeadingText).toHaveBeenCalledWith()
            });
        });

        describe('when writing as subHeading text', function(){
            let onWritingSubHeadingTextHandler;

            beforeEach(function(){
                view.subscribeToOnWritingSubHeadingText.and.callFake(function(handler){
                    onWritingSubHeadingTextHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes heading text', function(){
                onWritingSubHeadingTextHandler();

                expect(view.showSubHeadingText).toHaveBeenCalledWith()
            });
        });

        describe('when writing as body text', function(){
            let onWritingBodyTextHandler;
            beforeEach(function(){
                view.subscribeToOnWritingBodyText.and.callFake(function(handler){
                    onWritingBodyTextHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes heading text', function(){
                onWritingBodyTextHandler();

                expect(view.showBodyText).toHaveBeenCalledWith()
            });
        });

        describe('when writing as caption text', function(){
            let onWritingCaptionTextHandler;
            beforeEach(function(){
                view.subscribeToOnWritingCaptionText.and.callFake(function(handler){
                    onWritingCaptionTextHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes caption text', function(){
                onWritingCaptionTextHandler();

                expect(view.showCaptionText).toHaveBeenCalledWith()
            });
        });

        describe('when writing as bold text', function(){
            let onWritingBoldTextHandler;
            beforeEach(function(){
                view.subscribeToOnWritingBoldText.and.callFake(function(handler){
                    onWritingBoldTextHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes bold text', function(){
                onWritingBoldTextHandler();

                expect(view.showBoldText).toHaveBeenCalledWith()
            });
        });

        describe('when writing as italic text', function(){
            let onWritingItalicTextHandler;
            beforeEach(function(){
                view.subscribeToOnWritingItalicText.and.callFake(function(handler){
                    onWritingItalicTextHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes italic text', function(){
                onWritingItalicTextHandler();

                expect(view.showItalicText).toHaveBeenCalledWith()
            });
        });

        describe('when writing as underline text', function(){
            let onWritingUnderlineTextHandler;
            beforeEach(function(){
                view.subscribeToOnWritingUnderlineText.and.callFake(function(handler){
                    onWritingUnderlineTextHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes underline text', function(){
                onWritingUnderlineTextHandler();

                expect(view.showUnderlineText).toHaveBeenCalledWith()
            });
        });

        describe('when writing quotes', function(){
            let onWritingWithQuotetHandler;
            beforeEach(function(){
                view.subscribeToOnWritingWithQuote.and.callFake(function(handler){
                    onWritingWithQuotetHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes quote text', function(){
                onWritingWithQuotetHandler();

                expect(view.showTextWithQuote).toHaveBeenCalledWith()
            });
        });

        describe('when unordered list', function(){
            let onWritingWithUnOrderedListHandler;
            beforeEach(function(){
                view.subscribeToOnWritingUnOrderedList.and.callFake(function(handler){
                    onWritingWithUnOrderedListHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes unordered list', function(){
                onWritingWithUnOrderedListHandler();

                expect(view.showTextUnOrderedList).toHaveBeenCalledWith()
            });
        });

        describe('when ordered list', function(){
            let onWritingWithOrderedListHandler;
            beforeEach(function(){
                view.subscribeToOnWritingOrderedList.and.callFake(function(handler){
                    onWritingWithOrderedListHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes ordered list', function(){
                onWritingWithOrderedListHandler();

                expect(view.showTextOrderedList).toHaveBeenCalledWith()
            });
        });

        describe('when inserting link', function(){
            let onInsertingLinkHandler;
            beforeEach(function(){
                view.subscribeToOnInsertingLink.and.callFake(function(handler){
                    onInsertingLinkHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('writes ordered list', function(){
                onInsertingLinkHandler();

                expect(view.showLink).toHaveBeenCalledWith()
            });
        });

        describe('when uploading image', function(){
            let onUploadingImageHandler;
            beforeEach(function(){
                view.subscribeToOnUploadingImage.and.callFake(function(handler){
                    onUploadingImageHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });
            
            it('shows errors if is not a picture', function(){
                const noUploadsImages = [{id: '1', type:'json'}, {name:'john', type:'xml'}];

                onUploadingImageHandler(noUploadsImages);
                
                expect(view.showOnlyImagesErrorMessage).toHaveBeenCalled();
            });
        });

        describe('when downloading as HTML', function(){
            let onDownloadingAsHtmlHandler;
            beforeEach(function(){
                view.subscribeToOnDownloadingAsHtml.and.callFake(function(handler){
                    onDownloadingAsHtmlHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('downloads as html', function(){
                const text = 'some text';
                const html = "<b>some text</b>";
                onWritingTextHandler(text, html);
                
                onDownloadingAsHtmlHandler();
                
                expect(view.downloadAsHtml).toHaveBeenCalledWith(html);
            });
        });

        describe('when downloading as txt', function(){
            let onDownloadingAsTxtHandler;
            beforeEach(function(){
                view.subscribeToOnDownloadingAsTxt.and.callFake(function(handler){
                    onDownloadingAsTxtHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('downloads as txt', function(){
                const text = 'some text';
                const html = "<b>some text</b>";
                onWritingTextHandler(text, html);
                
                onDownloadingAsTxtHandler();
                
                expect(view.downloadAsTxt).toHaveBeenCalledWith(text);
            });
        });

        describe('when importing text sfile is requested', function(){
            
            let onImportingTextFileHandler;

            beforeEach(function(){
                view.subscribeToOnImportingTextFile.and.callFake(function(handler){
                    onImportingTextFileHandler = handler;
                });
                new RuityPresenter(view, imageReader, fileService);
            });

            it('show error message if there is null file', function(){
                onImportingTextFileHandler(null);

                expect(view.showErrorMessageImportingNonTextFile).toHaveBeenCalled();
            });

            it('show error message if is not file plain text', function(){
                const file = {name:'file.html'};
                
                onImportingTextFileHandler(file);

                expect(view.showErrorMessageImportingNonTextFile).toHaveBeenCalled();
            });

            it('imports text file', function(){
                const someText = 'some text';
                const file = {name:'file.txt', content: someText};
                fileService.read.and.callFake(function(file, handler){
                    handler(someText);
                });
                
                onImportingTextFileHandler(file);

                expect(view.showText).toHaveBeenCalledWith(someText);
            });            
        });
    });
   });
});