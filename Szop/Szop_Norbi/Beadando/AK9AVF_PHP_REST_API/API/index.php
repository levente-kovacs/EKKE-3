<?php
include 'functions.php';
include 'connect.php';

switch($request_method)
{
  case 'GET':
      if($_GET['products'] == '')
   {
          getProducts(); 
   }
   else{ 
       getProduct($_GET['products']);
   }
   break;

 case 'POST':
    
  if(isset($_GET['users']))
   {         
      login();
   }
   else
   {
      newProduct();
   }
  break;
  
 case 'PUT':    
   updateProduct();
   break;

 case 'DELETE':
   delProduct($_GET['id']);
   break;
 default:  
    header("HTTP/1.0 405 Method Not Allowed");
    break;
}
?>