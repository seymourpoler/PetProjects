function SoundManager(){
	this.playAlarm = function(){
		var effect = []; for (var i=0; i<35000; i++) {
        effect[i] = 64+Math.round(32*(Math.cos(i*i/2000)+Math.sin(i*i/4000)));
      }
      var wave = new RIFFWAVE();
      wave.header.sampleRate = 22000;
      wave.Make(effect);
      var audio = new Audio(wave.dataURI);
      audio.play();
	}
}