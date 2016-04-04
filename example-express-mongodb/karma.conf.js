module.exports = function(config) {
  config.set({
    frameworks: ['jasmine'],
    reporters: ['spec'],
    browsers: ['Chrome'],
    files: [
      'libs/jquery.min.js',
      'libs/lodash.min.js',
      'User/Scripts/*.js',
      'User/Tests/*.js'
    ]
  });
};
