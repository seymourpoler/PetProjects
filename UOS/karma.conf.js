module.exports = function(config) {
    config.set({
      basePath: '',
      frameworks: ['jasmine'],
      files: [
        'src/uos.js',
        'src/base-control.js',
        'src/label.js',
        'src/span.js',
        'src/text-box.js',
        'src/div.js',
        'src/link.js',
        'src/drop-down.js',
        'src/button.js',
        'spec/*.js',
      ],
      exclude: [
      ],
      preprocessors: {
      },
      reporters: ['progress'],
      port: 9876,
      colors: true,
      logLevel: config.LOG_INFO,
      autoWatch: true,
      browsers: ['Chrome'],
      singleRun: false,
      concurrency: Infinity
    });
  };