function RuityView(){
    let self = this;

    self.isNotActivated = function(){
        return !window.File || !window.FileList || !window.FileReader;
    }

    self.showBrowserDoesNotSupportFileErrorMessage = function(){
        alert('This Browser does not support file API.');
    };

    self.showNumberOfCharacters = function(numberOfCharacters){
        document.getElementById('numberOfCharacters').innerText = numberOfCharacters;
    };

    self.showNumberOfWords = function(numberOfWords){
        document.getElementById('numberOfWords').innerText = numberOfWords;
    };

    self.subscribeToOnWritingText = function(handler){
        document
            .getElementById('content')
            .addEventListener('keyup', function(event){
                const content = document.getElementById('content');
                handler(content.innerText, content.innerHTML);
            });
    }

    self.subscribeToOnWritingHeadingText = function(handler){
        document
            .getElementById('btnHeading')
            .addEventListener('click', function(event){
                handler();
            });
    }

    self.subscribeToOnWritingSubHeadingText = function(handler){
        document
            .getElementById('btnSubHeading')
            .addEventListener('click', function(event){
                handler();
            });
    }

    self.subscribeToOnWritingBodyText = function(handler){
        document
            .getElementById('btnBody')
            .addEventListener('click', function(event){
                handler();
            });
    }

    self.subscribeToOnWritingCaptionText = function(handler){
        document
            .getElementById('btnCaption')
            .addEventListener('click', function(event){
                handler();
            });
    };

    self.subscribeToOnWritingBoldText = function(handler){
        document
            .getElementById('btnBold')
            .addEventListener('click', function(event){
                handler();
            });
    }

    self.subscribeToOnWritingItalicText = function(handler){
        document
            .getElementById('btnItalic')
            .addEventListener('click', function(event){
                handler();
            });
    }

    self.subscribeToOnCleanningText = function(handler){
        document
            .getElementById('btnClean')
            .addEventListener('click', function(event){
                handler();
            });
    };

    self.subscribeToOnWritingUnderlineText = function(handler){
        document
            .getElementById('btnUnderline')
            .addEventListener('click', function(event){
                handler();
            });
    }

    self.subscribeToOnWritingWithQuote = function(handler)
    {
        document
            .getElementById('btnQuote')
            .addEventListener('click', function(event){
                handler();
            });
    }

    self.subscribeToOnWritingUnOrderedList = function(handler){
        document
        .getElementById('btnUnOrderedList')
        .addEventListener('click', function(event){
            handler();
        });
    }

    self.subscribeToOnWritingOrderedList = function(handler){
        document
        .getElementById('btnOrderedList')
        .addEventListener('click', function(event){
            handler();
        });
    }

    self.subscribeToOnInsertingLink = function(handler){
        document
        .getElementById('btnInsertLink')
        .addEventListener('click', function(event){
            handler();
        });
    }

    self.subscribeToOnUploadingImage = function(handler){
        document
        .getElementById("btnUploadImage")
        .addEventListener('change', function(event){
            handler(event.target.files);
        });
    }

    self.subscribeToOnDownloadingAsHtml = function(handler){
        document
        .getElementById('btnDownloadAsHtml')
        .addEventListener('click', function(event){
            handler();
        });
    }

    self.subscribeToOnDownloadingAsTxt = function(handler){
        document
        .getElementById('btnDownloadAsTxt')
        .addEventListener('click', function(event){
            handler();
        });
    }

    self.subscribeToOnImportingTextFile = function(handler) {
        document.getElementById("btnImportFile")
                .addEventListener("change", function(event){
                    handler(event.currentTarget.files[0]);
                });
    }

    self.showText = function(text){
        document.getElementById('content').innerHTML = text;
    }

    self.showHeadingText = function(){
        document.execCommand('formatBlock', false, 'h1');
    }

    self.showSubHeadingText = function(){
        document.execCommand('formatBlock', false, 'h2');
    }

    self.showBodyText = function(){
        document.execCommand('formatBlock', false, 'p');
    }

    self.showCaptionText = function(){
        document.execCommand('formatBlock', false, 'h5');
    }

    self.showBoldText = function(){
        document.execCommand('bold', false, 'bold');
    }

    self.showItalicText = function(){
        document.execCommand('italic', false, 'italic');
    }

    self.showUnderlineText = function(){
        document.execCommand('underline', false, 'underline');
    }

    self.showTextWithQuote = function(){
        document.execCommand('formatBlock', false, 'blockquote');
    }

    self.showTextUnOrderedList = function(){
        document.execCommand('insertUnorderedList', false, 'insertUnorderedList');
    }

    self.showTextOrderedList = function(){
        document.execCommand('insertOrderedList', false, 'insertOrderedList');
    }

    self.showLink = function(){
        value = prompt('Enter url');
        if (value.slice(0, 4) != 'http') {
            value = 'http://' + value;
        }
        document.execCommand('createLink', false, value);
        document.getSelection().focusNode.parentNode.setAttribute("contenteditable", "false");
    }

    self.showOnlyImagesErrorMessage = function(){
        throw 'not implemeneted';
    }

    self.downloadAsHtml = function(html){
        const page = "<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'></head><body>"  + 
            html + "</body></html>";
        const link = document.createElement("a");
        link.setAttribute("download", 'Written');
        link.setAttribute("href", 'data:text/html;charset=utf-8,' + encodeURIComponent(page));
        link.click();
    }

    self.downloadAsTxt = function(text){
        const page = "<!DOCTYPE html><html lang='en'><head><meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'></head><body>"  + 
            text + "</body></html>";
        const link = document.createElement("a");
        link.setAttribute("download", 'Written');
        link.setAttribute("href", 'data:text/txt;charset=utf-8,' + encodeURIComponent(page));
        link.click();
    }

    self.downloadAsText = function(text){
        throw 'not implemented';
    }

    self.showErrorMessageImportingNonTextFile = function(){
        throw 'not implemented';
    }

    self.cleanText = function(){
        const content = document.getElementById('content');
        content.innerHTML = '';
        content.innerText = '';
    };
}