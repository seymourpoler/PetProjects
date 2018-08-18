window.Peper = window.Perper|| {};
(function (Peper) {

    Peper.Label = function(id){
        var self = this;
        var control = document.getElementById(id);

        self.setText = function(text){
            control.innerHTML = text;
        };

        self.getText = function(){
            return control.innerHTML;
        };

        self.clear = function(){
            control.innerHTML = '';
        };

        self.showText = function (text) {
            control.style.display = 'inline';
            control.innerHTML = text;
        };

        self.show = function(){
            control.style.display = 'inline';
            //control.style.visibility='visible';
        };

        self.hide = function(){
            control.style.display = 'none';
            //control.style.visibility='hidden';
        };
    };

    Peper.InputText = function(id){
        var self = this;
        var control = document.getElementById(id);

        self.setText = function(text){
            control.value = text;
        };

        self.getText = function(){
            return control.value;
        };

        self.clear = function(){
            control.value = '';
        };

        self.show = function(){
            control.style.display = 'inline';
            //control.style.visibility='visible';
        };

        self.hide = function(){
            control.style.display = 'none';
            //control.style.visibility='hidden';
        };
    };

    Peper.Button = function(id){
        var self = this;
        var control = document.getElementById(id);

        self.setText = function(text){
            control.value = text;
        };

        self.getText = function(){
            return control.value;
        };

        self.clear = function(){
            control.value = '';
        };

        self.show = function(){
            control.style.display = 'inline';
            //control.style.visibility='visible';
        };

        self.hide = function(){
            control.style.display = 'none';
            //control.style.visibility='hidden';
        };

        self.on = function (event, handler) {
            control.addEventListener(event, handler);
        };
    };

    Peper.Select = function(id){
        var self = this;
        var control = document.getElementById(id);

        self.show = function(){
            control.style.display = 'inline';
            //control.style.visibility='visible';
        };

        self.hide = function(){
            control.style.display = 'none';
            //control.style.visibility='hidden';
        };

        self.onChange = function(handler){
            control.onchange = handler;
        };

        self.setSelectedIndex = function(index){
            throw 'not implemented';
        };

        self.getSelectedIndex = function(){
            throw 'not implemented';
        };

        self.setSelectedValue = function(value){
            throw 'not implemented';
        };

        self.getSelectedValue = function(){
            throw 'not implemented';
        };

        self.setSelectedText = function(text){
            throw 'not implemented';
        };

        self.getSelectedText = function(){
            throw 'not implemented';
        };

        self.add = function(value, text){
            control.appendChild(new Option(value, text));
        };

        self.removeByIndex = function(index){
            throw 'not implemented';
        };

        self.removeByValue = function(value){
            throw 'not implemented';
        };

        self.removeByText = function(text){
            throw 'not implemented';
        };

        self.clear = function(){
            for (i = 0; i < control.options.length; i++) {
                control.options[i] = null;
            }
        };
    };

    Peper.InputRadio = function(id){
        var self = this;
        var control = document.getElementById(id);

        self.show = function(){
            control.style.display = 'inline';
            //control.style.visibility='visible';
        };

        self.hide = function(){
            control.style.display = 'none';
            //control.style.visibility='hidden';
        };
    };

    Peper.Checkbox = function(id){
        var self = this;
        var control = document.getElementById(id);

        self.show = function(){
            control.style.display = 'inline';
            //control.style.visibility='visible';
        };

        self.hide = function(){
            control.style.display = 'none';
            //control.style.visibility='hidden';
        };
    };

    Peper.Panel = function(id){
        var self = this;
        var control = document.getElementById(id);

        self.show = function(){
            control.style.display = 'inline';
            //control.style.visibility='visible';
        };

        self.hide = function(){
            control.style.display = 'none';
            //control.style.visibility='hidden';
        };
    };

    Peper.List = function (domId) {
        var self = this;
        var control = document.getElementById(domId);

        self.clear = function () {
            control.innerHTML = "";
        };

        self.addItem = function (item) {
            var li = document.createElement("li");
            li.appendChild(document.createTextNode(item.name));
            li.setAttribute("id", item.id);
            control.appendChild(li);
        };

        self.addHtmlItem = function (htmlItem) {
            list.append(htmlItem);
        };

        self.removeItem = function (itemId) {
            list.find(itemId).remove();
        };
    };

    Peper.Redirector = function(){
        var self = this;

        self.redirect = function(url){
            window.location = url;
        };
    };

})(window.Peper || {})