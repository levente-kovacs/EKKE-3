const express = require("express");
const mysql = require("mysql");
const bodyParser = require("body-parser");
const swaggerUI = require("swagger-ui-express");
const swaggerJsDoc = require("swagger-jsdoc");

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

const specs = swaggerJsDoc(options);

const app = express();

app.use("/api-docs", swaggerUI.serve, swaggerUI.setup(specs));

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

/**
 * @swagger
 * components:
 *   schemas:
 *     Employee:
 *       type: object
 *       required:
 *         - name
 *         - salary
 *         - age
 *       properties:
 *         id:
 *           type: string
 *           description: The auto-generated id of employee
 *         name:
 *           type: string
 *           description: Employee name
 *         salary:
 *           type: number
 *           description: Employee salary
 *         age:
 *           type: number
 *           description: Employee age
 *       example:
 *         id: d5fE_asz
 *         name: Winnie The Pooh
 *         salary: 100000.1
 *         age: 112.5
 */

/**
 * @swagger
 * /employees:
 *   get:
 *     description: Returns the list of all the employees
 *     responses:
 *       '200':
 *         description: Successfully returned a list of employees
 *         content:
 *           application/json:
 *             schema:
 *               type: array
 *               items:
 *                 #  ----- Added line  ----------------------------------------
 *                 $ref: '#/components/schemas/Employee'
 *                 #  ---- /Added line  ----------------------------------------
 *       '400':
 *         description: Invalid request
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 message:
 *                   type: string
 */

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

/**
 * @swagger
 * /employees/{id}:
 *   get:
 *     description: Obtain information about an employee from his or her unique id
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *
 *     responses:
 *       '200':
 *         description: Successfully returned an employee
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 name:
 *                   type: string
 *                 salary:
 *                   type: number
 *                 age:
 *                   type: number
 *
 *       '400':
 *         description: Invalid request
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 message:
 *                   type: string
 */

app.get("/employees/:id", function (req, res) {
  //console.log(req);
  connection.query(
    "select * from employee where id=?",
    [req.params.id],
    function (error, results, fields) {
      if (results.length === 0)
		  res.sendStatus(400);
      else 
		  res.end(JSON.stringify(results));
    }
  );
});

//rest api to create a new record into mysql database
/**
 * @swagger
 * /employees:
 *   post:
 *     description: Lets a user post a new employee
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             #  ----- Added line  ----------------------------------------
 *             $ref: '#/components/schemas/Employee'
 *             #  ---- /Added line  ----------------------------------------
 *     responses:
 *       '200':
 *         description: Successfully created a new employee
 *       '400':
 *         description: Invalid request
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 message:
 *                   type: string
 */
app.post("/employees", function (req, res) {
  var postData = req.body;
  connection.query(
    "INSERT INTO employee SET ?",
    postData,
    function (error, results, fields) {
      if (error) res.sendStatus(400);
      else res.end(JSON.stringify(results));
    }
  );
});

/**
 * @swagger
 * /employees/{id}:
 *   delete:
 *     description: Delete an employee by id
 *     parameters:
 *       - name: id
 *         in: path
 *         required: true
 *         schema:
 *           type: string
 *
 *     responses:
 *       '200':
 *         description: Successfully removed the employee
 *       '400':
 *         description: Invalid request
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 message:
 *                   type: string
 */

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
