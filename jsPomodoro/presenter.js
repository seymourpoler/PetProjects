function Presenter(view){
    let self = this;

    view.showTime({minutes: 25, seconds: 0});

    view.subscribeToOnResetClicked(()=>{
        view.showTime({minutes: 25, seconds: 0});
    });
}



if(module && module.exports){
    module.exports	= Presenter;
}