module.exports = function(config) {
  config.set({
    frameworks: ['browserify', 'jasmine'],
    "preprocessors": {
        "server.js": [ "browserify" ],
        "Tests/serverSpec.js": [ "browserify" ]
    }
    reporters: ['spec'],
    browsers: ['Chrome'],
    files: [
      'lib/jasmine.min.js',
      'lib/delta.js',
      'lib/utils.js',
      'Tests/*.js',
      'User/Scripts/*.js',
      'User/Tests/Scripts/*.js'
    ]
  });
};
