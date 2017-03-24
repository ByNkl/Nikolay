var express = require("express");
var bodyParser = require("body-parser");
var http = require("http");

var app = express();

app.use(bodyParser.json());
app.use('/', express.static(__dirname + '/client'));



app.get('/agent', function (req, res) {
	var request = http.request({
		hostname: "localhost",
		path: "/restconf/data/iconverter1",
		port: 5002,
		method: "GET"
	}, function (response) {
		var a = "";
		response.on('data', function (chunk) {
			a += chunk;
		});

		response.on('end', function () {
			res.send(a);
		});
	});

	request.end();
});

app.listen(8081);