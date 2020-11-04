function RuityPresenter(view, imageReader, fileService){
    let text = {innerText:'', innerHtml: ''};
    
    view.subscribeToOnCleanningText(onCleanningTextHandler);
    function onCleanningTextHandler(){
        view.cleanText();
        text.innerText = '';
        text.innerHtml = '';
        initializeCounters();
    }

    view.subscribeToOnWritingText(onWritingTextHandler);
    function onWritingTextHandler(plainText, html){
        text.innerText = plainText;
        text.innerHtml = html
        view.showNumberOfCharacters(plainText.length);
        view.showNumberOfWords(plainText.match(/\b[-?(\w+)?]+\b/gi).length);
    }
    view.subscribeToOnWritingHeadingText(onWritingHeadingTextHandler);
    function onWritingHeadingTextHandler(){
        view.showHeadingText();
    }

    view.subscribeToOnWritingSubHeadingText(onWritingSubHeadingTextHandler);
    function onWritingSubHeadingTextHandler(){
        view.showSubHeadingText();
    }

    view.subscribeToOnWritingBodyText(onWritingBodyTextHandler);
    function onWritingBodyTextHandler(){
        view.showBodyText();
    }

    view.subscribeToOnWritingCaptionText(onWritingCaptionTextHandler);
    function onWritingCaptionTextHandler(){
        view.showCaptionText();
    }

    view.subscribeToOnWritingBoldText(onWritingBoldTextHandler);
    function onWritingBoldTextHandler(){
        view.showBoldText();
    }

    view.subscribeToOnWritingItalicText(onWritingItalicTextHandler);
    function onWritingItalicTextHandler(){
        view.showItalicText();
    }

    view.subscribeToOnWritingUnderlineText(onWritingUnderlineTextHandler);
    function onWritingUnderlineTextHandler(){
        view.showUnderlineText();
    }

    view.subscribeToOnWritingWithQuote(onWritingWithQuoteHandler)
    function onWritingWithQuoteHandler(){
        view.showTextWithQuote();
    }

    view.subscribeToOnWritingUnOrderedList(onWritingWithUnOrderedListHandler);
    function onWritingWithUnOrderedListHandler(){
        view.showTextUnOrderedList();
    }

    view.subscribeToOnWritingOrderedList(onWritingWithOrderedListHandler);
    function onWritingWithOrderedListHandler(){
        view.showTextOrderedList();
    }

    view.subscribeToOnInsertingLink(onInsertingLinkHandler);
    function onInsertingLinkHandler(){
        view.showLink();
    }
    
    view.subscribeToOnUploadingImage(onUploadingImageHandler);
    function onUploadingImageHandler(images){
        if(!images.some(x => x.type === 'image')){
            view.showOnlyImagesErrorMessage();
            return;
        }
        //TODO: weird
        for(let position=0; position<images.length; position++){
            const image = images[position];
            const imageReader = new FileReader();
            imageReader.addEventListener("load", function(event) {
                const imageSource = event.target.result;
                const humbnail = "<div class='imgView'><img  src='" + imageSource + "'" +
                    "title='" + image.name + "'/></div>";

                text = text + humbnail;
                view.showText(text);
            });
            imageReader.readAsDataURL(image);
        }
    }

    view.subscribeToOnDownloadingAsHtml(onDownloadingAsHtmlHandler);
    function onDownloadingAsHtmlHandler(){
        view.downloadAsHtml(text.innerHtml);
    }

    view.subscribeToOnDownloadingAsTxt(onDownloadingAsTxtHandler)
    function onDownloadingAsTxtHandler(){
        view.downloadAsTxt(text.innerText);
    }

    view.subscribeToOnImportingTextFile(onImportingTextFileHandler);
    function onImportingTextFileHandler (file) {
        const textFileExtension = 'txt';
        if(!file){
            view.showErrorMessageImportingNonTextFile();
            return;
        }
        const fileExtension = file.name.split(".").pop();
        if(fileExtension != textFileExtension){
            view.showErrorMessageImportingNonTextFile();
            return;
        }
        fileService.read(file, function(content){
            view.showText(content);
        });
    }

    function initializeCounters() {
        const initialNumberOfCharacters = 0;
        view.showNumberOfCharacters(initialNumberOfCharacters);
        const initialNumberOfWords = 0;
        view.showNumberOfWords(initialNumberOfWords);
    }

    if(view.isNotActivated()){
        view.showBrowserDoesNotSupportFileErrorMessage();
        return;
    }

    initializeCounters();
    view.cleanText();
}

function createRuityPresenter(){
    return new RuityPresenter(new RuityView(), new ImageReader(), new FileService());
}
