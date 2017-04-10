var gzippo = require('gzippo');
var express = require('express');
var app = express();

app.use(gzippo.staticGzip('' + __dirname + '/dist'));
app.all('/*', function(req, res) {
    res.sendFile('/dist/index.html', { root: __dirname });
});
app.listen(process.env.PORT || 5000);
console.log('App listening at port 5000...');
