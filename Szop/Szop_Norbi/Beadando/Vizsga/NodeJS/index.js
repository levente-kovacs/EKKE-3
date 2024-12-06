const express = require("express");
const mysql = require("mysql");
const bodyParser = require("body-parser");
const swaggerDocument = require('./swagger.json');
const swaggerUI = require("swagger-ui-express");
const swaggerJsDoc = require("swagger-jsdoc");
const app = express();
const host = process.env.HOST ?? 'localhost';
const port = process.env.PORT ?? 3100;


var dbConnection = mysql.createConnection(
{
    host: "localhost",
    user: "root",
    password: "",
    database: "vizsga",
});
  
dbConnection.connect(function (err) 
{
  try
  {
    if (err) throw err;
  }
  catch
  {
    console.log("Az adatbázis szerver nem elérhető");    
    return;
  }
    
    console.log("A csatlakozás sikerült");
});

app.use(bodyParser.json());
app.use(
  bodyParser.urlencoded({      
      extended: true,
    })
);

var server = app.listen(port, host, function ()
{
var host = server.address().address;
var port = server.address().port;
});

app.get("/swagger", (req, res) => res.json(swaggerDocument));

const auth = function(req,res,next)
  {    
      try
      {
        token=String(req.get("token"));
      }
      catch
      {
          res.send("Something went wrong")
      }      
      var sql = "SELECT id,isAdmin FROM users WHERE token =?";
      dbConnection.query(sql,[Buffer.from(token, 'base64').toString('ascii')],function(error,results,fields)
      {
          if(error)
          {
            res.sendStatus(400);
          }
          else
          {
            try
            {
              isAdmin = results[0].isAdmin;
              if(isAdmin == 0)
              {
                res.sendStatus(403);
              } 
              else
              {                
                req.body.user_id = results[0].id;
                next();
              }
            }  
            catch
            {
                res.send("Please log in")
            }           
          }
      }
    )         
  }

const verify = function(req,res,next)
{
    var data = req.body;    
    if((data.vin).length != 17)
    {
        res.sendStatus(400);
        return       
    }
   
    if(isNaN(data.modelYear) || isNaN(data.numOfCylinders) || isNaN(data.engineDisplacement))
    {
        res.sendStatus(400);
        return
    }    
    next();
}

app.post("/login", function (req, res)
{
    var data = req.body;    
    var sql = "SELECT token FROM users WHERE username=? AND password=?";
    dbConnection.query(sql,[data.username,Buffer.from(data.password).toString('base64')],function (error, results, fields)
       {
        if (error || results.length == 0) 
            res.sendStatus(404);
        else{
          results[0].token = Buffer.from(results[0].token).toString('base64')
          var tempStr = JSON.stringify(results);
          var newStr = tempStr.substring(1, tempStr.length-1);
          res.send(newStr);
        }
      }
    );
});

app.post("/car",[auth, verify, function (req, res)
{
    var data = req.body;
    var sql = "INSERT INTO cars SET ?";
  dbConnection.query(sql,data,function (error, results, fields) 
    {        
      if (error || results.affectedRows == 0)
        res.sendStatus(400);
        else{
          res.send("Database updated successfully");
        }          
    }
  );
}])

app.get("/cars", function (req, res)
{
    var data = req.body;
    var sql = "SELECT * FROM cars";
        dbConnection.query(sql,data,function (error, results, fields) 
        {
          if (error || results.length == 0)
            res.sendStatus(400);
            else{
              res.json(results);
            }          
        }
    );
})

app.get("/cars/:id", function (req, res)
{    
    var sql = "SELECT * FROM cars WHERE id=?";
        dbConnection.query(sql,[req.params.id],function (error, results, fields) 
        {
          if (error || results.length == 0)
            res.sendStatus(404);
            else{
              var tempStr = JSON.stringify(results);
              var newStr = tempStr.substring(1, tempStr.length-1);
              res.send(newStr);
            }          
        }
    );
})

app.delete("/cars/:id",[auth, function (req, res)
{   
    var sql = "DELETE FROM cars WHERE id =?";
        dbConnection.query(sql,[req.params.id],function (error, results, fields) 
        {
          if(error)
            res.sendStatus(400);

          if (results.affectedRows == 0)
            res.sendStatus(404);
            else{
              res.send("Database updated successfully");
            }                      
        }
    );
}])


app.put("/car",[auth, verify, function (req, res)
  {   
      var data = req.body;      
          var sql = "UPDATE cars SET brand=?, vin=?, color=?, modelYear=?, numOfCylinders=?, engineDisplacement=?, fuel=?, user_id=? WHERE id=?";
          dbConnection.query(sql,[data.brand,data.vin,data.color,data.modelYear,data.numOfCylinders,data.engineDisplacement,data.fuel,data.user_id,data.id],function (error, results, fields) 
          {
              if (error)
                res.sendStatus(400);
              if(results.affectedRows == 0)
                res.sendStatus(404);
                else{
                  res.send("Database updated successfully");
                }        
          }             
      );      
  }])

const http = require('http');
const { exit } = require("process");
const { application } = require("express");
const options = {
  hostname: 'localhost',
  port: 80,
  path: '/vizsgaAPI/index.php/',
  method: "GET"
};

app.get("/fuels", function (req, res)
{
  try
  {
    const request = http.request(options, response => {
      var data ="";
      response.on("data", d => {
        res.send(Buffer.from(d))
      });
      response.on("end", () =>{
      })
    });  
    request.on('error', error => {
      res.json(error);
    });  
    request.end();
  }
  catch
  {
    res.json(error)
  }
})