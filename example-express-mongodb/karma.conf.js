module.exports = function(config) {
  config.set({
    frameworks: ['jasmine'],
    reporters: ['spec'],
    browsers: ['Chrome'],
    files: [
      'lib/jasmine.min.js',
      'lib/jquery.min.js',
      'lib/delta.js',
      'lib/utils.js',
      'Tests/*.js',
      'User/Scripts/*.js',
      'User/Tests/Scripts/*.js'
    ]
  });
};
