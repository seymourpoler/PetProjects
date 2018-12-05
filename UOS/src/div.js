function Div(configuration){
    let self = this;

    self.render = function(){
        if(configuration && configuration.id){
            return "<div id='" + configuration.id + "'></div>";
        }
        return '<div></div>';
    };
}