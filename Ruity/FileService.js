function FileService(){
    let self = this;

    self.read = function(file, handler){
        const reader = new FileReader()
            reader.onload = function(){
                handler(reader.result);
            }

            reader.readAsText(file)
    }
}