module.exports = function(grunt) {
// Load Grunt tasks declared in the package.json file
require('matchdep').filterDev('grunt-*').forEach(grunt.loadNpmTasks);

// Configure Grunt
grunt.initConfig({
watch: {
  js: {
    files: '*.js, *.html',
    options: {livereload: true}
  }
},

});

grunt.registerTask('server', ['watch']);
};