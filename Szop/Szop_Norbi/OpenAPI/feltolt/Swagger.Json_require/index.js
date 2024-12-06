const express = require("express");
const mysql = require("mysql");
const bodyParser = require("body-parser");
const swaggerUI = require("swagger-ui-express"),swaggerDocument = require('./swagger.json');
//const swaggerJsDoc = require("swagger-jsdoc");

const host = process.env.HOST ?? 'localhost';
const port = process.env.PORT ?? 3100;

const options = {
  definition: {
    openapi: "3.0.0",
    info: {
      title: "Employee API",
      version: "1.0.0",
      description: "A korábbi REST API OpenAPI dokumentációja",
    },
    servers: [
      {
        url: `http://${host}:${port}`,
      },
    ],
  },
  apis: ["./*.js"],
};

//const specs = swaggerJsDoc(options);

const app = express();

//app.get("./swagger.json", (req, res) => res.json(specs))
app.use("/api-docs", swaggerUI.serve, swaggerUI.setup(swaggerDocument));



//start mysql connection
var connection = mysql.createConnection({
  host: "localhost", //mysql database host name
  user: "root", //mysql database user name
  password: "", //mysql database password
  database: "ksanyi", //mysql database name
});

connection.connect(function (err) {
  if (err) throw err;
  console.log("A csatlakozás sikerült...");
});
//end mysql connection

//start body-parser configuration
app.use(bodyParser.json()); // to support JSON-encoded bodies
app.use(
  bodyParser.urlencoded({
    // to support URL-encoded bodies
    extended: true,
  })
);
//end body-parser configuration

//create app server
var server = app.listen(port, host, function () {
  var host = server.address().address;
  var port = server.address().port;

  console.log("Figyeljük a következő URI-t http://%s:%s", host, port);
});



//rest api to get all results
app.get("/employees", function (req, res) {
  connection.query("select * from employee", function (error, results, fields) {
    if (results.length === 0)
      //és ha a results értéke üres
      res.sendStatus(400);
    //res.end(JSON.stringify(results)); // ez nem megy, a res.end nem állít be megfelelő header-t!!
    else res.json(results);
  });
});

app.get("/employees/:id", function (req, res) {
  //console.log(req);
  connection.query(
    "select * from employee where id=?",
    [req.params.id],
    function (error, results, fields) {
      if (results.length === 0)
		  res.sendStatus(400);
      else 
		  //res.end(JSON.stringify(results));
			res.json(results);
    }
  );
});


app.post("/employees", function (req, res) {
  var postData = req.body;
  connection.query(
    "INSERT INTO employee SET ?",
    postData,
    function (error, results, fields) {
      if (error) res.sendStatus(400);
      else 
		  //res.end(JSON.stringify(results));
		 res.json(results);
    }
  );
});



//rest api to delete record from mysql database
app.delete("/employees/:id", function (req, res) {
  console.log(req.body);
  connection.query(
    "DELETE FROM `employee` WHERE `id`=?",
    [req.params.id],
    function (error, results, fields) {
      if (results.affectedRows === 0) 
		  res.sendStatus(400);
      else 
		  res.sendStatus(200);
    }
  );
});
