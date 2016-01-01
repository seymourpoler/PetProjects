var mouse = require("./mouse.js");

mouse.onClick(function(event){
  console.log('onClick event: ', event);
});

mouse.onMouseMove(function(event){
  console.log('onMouseMove event: ', event);
});
