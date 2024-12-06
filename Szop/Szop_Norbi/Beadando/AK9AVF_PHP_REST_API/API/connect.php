<?php

$servername = "localhost";
$username = "root";
$password = "";
$dbname = "restapi";
$pdo = new PDO('mysql:host='.$servername.';dbname='.$dbname.'', $username, $password);
$request_method=$_SERVER["REQUEST_METHOD"];
?>
