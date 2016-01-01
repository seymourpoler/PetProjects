var fs = require('fs')

function  Mouse(){
  var self = this;
  var MAX_LENGTH = 3;
  var prevLeftBtn, prevRightBtn, prevMiddleBtn = false;
  var onClickHandler = function(){};
  var onMoveHandler = function(){};
  var dev = typeof(mouseid) === 'number' ? 'mouse' + mouseid : 'mice';
  var buf = new Buffer(MAX_LENGTH);
  this.fileDescription;

  fs.open('/dev/input/' + dev, 'r', onOpen);
  self.onClick = function(handler){
     onClickHandler = handler;
   };
   self.onMouseMove = function(handler){
     onMoveHandler = handler;
   };

   function onOpen(error, fileDescription) {
     if(error){
       console.log('error open file', error);
       return;
     }
     this.fileDescription = fileDescription;
     read(this.fileDescription);
   };

   function read(fileDescription){
     fs.read(fileDescription, buf, 0, MAX_LENGTH, null, onRead);
   }

   function onRead(bytesRead) {
     var event = parse(self, buf);
     event.dev = dev;
     manageEvent(event);
     if (this.fileDescription){
       read(this.fileDescription);
     }
   }

   function parse(mouse, buffer) {
     var event = {
       leftBtn:    (buffer[0] & 1  ) > 0, // Bit 0
       rightBtn:   (buffer[0] & 2  ) > 0, // Bit 1
       middleBtn:  (buffer[0] & 4  ) > 0, // Bit 2
       xSign:      (buffer[0] & 16 ) > 0, // Bit 4
       ySign:      (buffer[0] & 32 ) > 0, // Bit 5
       xOverflow:  (buffer[0] & 64 ) > 0, // Bit 6
       yOverflow:  (buffer[0] & 128) > 0, // Bit 7
       xDelta:      buffer.readInt8(1),   // Byte 2 as signed int
       yDelta:      buffer.readInt8(2)    // Byte 3 as signed int
     };
     if (event.leftBtn || event.rightBtn || event.middleBtn) {
       event.type = 'button';
     } else {
       event.type = 'moved';
     }
     return event;
   }

   function manageEvent(event){
     console.log('event.type: ', event.type);
     switch (event.type) {
       case 'button':
          onClickHandler(event);
         break;
       default:
       onMoveHandler(event);
     }
   }

}//end class Mouse

module.exports = new Mouse();
