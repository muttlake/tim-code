var path = require('path');

module.exports = {
  mode: 'development',
  entry: './build/main.js',
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: 'app.bundle.js'
  }
};