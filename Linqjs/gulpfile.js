var gulp = require('gulp'),
   jshint = require('gulp-jshint'),
   mocha = require('gulp-mocha');

gulp.task('jshint', function(){
	gulp.src('source/*.js')
    jshint.reporter('default');
});

gulp.task('mocha', function () {
    gulp.src('test/*.js')
        .pipe(mocha({
            reporter: 'list'
        }))
        .on('error', function(err){
        	console.log(err.message);
    		this.emit('end');	
        });
});

gulp.task('watch', function () {
	gulp.watch('source/*.js', function(){
		gulp.start('mocha');
	});
	gulp.watch('test/*.js', function(){
		gulp.start('mocha');
	});
});

gulp.task('default', function() {
    gulp.start('jshint', 'watch');
});
