module.exports = function(config) {
    config.set({
        frameworks: ['jasmine'],
 
        files: [
            './*.js',
            './*.spec.js'
        ],
        reporters: ['progress'],
        port: 9876,
        logLevel: config.LOG_INFO,
        colors: true,
        browsers: ['Chrome'],
        singleRun: false,
        concurrency: Infinity
    });
};