module.exports = function(config) {
  config.set({
    frameworks: ['jasmine'],
    reporters: ['spec'],
    browsers: ['Chrome'],
    files: [
      'lib/jasmine.min.js',
      'lib/utils.js',
      'User/Scripts/*.js',
      'User/Tests/Scripts/*.js'
    ]
  });
};
