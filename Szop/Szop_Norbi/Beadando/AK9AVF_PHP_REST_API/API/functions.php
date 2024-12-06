<?php
include 'connect.php';

function login(){
    global $pdo;
    $data = json_decode(file_get_contents('php://input',true));    
    $stmt = $pdo->prepare('SELECT token FROM users WHERE username = ? AND password = ?');
    $stmt->execute([$data->username, base64_encode($data->password)]);
    $response = $stmt->fetch(PDO::FETCH_ASSOC);
    if (!$response)
    {
      http_response_code(401);
      die('Authorization error');
    }
    $response['token']= base64_encode($response['token']);    
    echo json_encode($response);
    return;   
}

function getProducts(){    
    global $pdo;
    $data = json_decode(file_get_contents('php://input',true));
    $stmt = $pdo->prepare('SELECT * FROM products');
    $stmt->execute();
    $response = $stmt->fetchAll(PDO::FETCH_ASSOC);    
    if (!$response)
    {
      http_response_code(404);
      die('Not Found');
    }
    echo json_encode($response);
   return;
}

function getProduct($id){
    global $pdo;    
    $data = json_decode(file_get_contents('php://input',true));
    $stmt = $pdo->prepare('SELECT * FROM products WHERE id = ?');
    $stmt->execute([$id]);    
    $response = $stmt->fetch(PDO::FETCH_ASSOC);    
    if (!$response)
    {
      http_response_code(404);
      die('Not Found');
    }
    echo json_encode($response);
    return;
}

function newProduct()
{   
    $id = auth();    
    global $pdo;
    $data = json_decode(file_get_contents('php://input',true));
    $stmt = $pdo->prepare('INSERT INTO products (name, price, stock, user_id) VALUES (?,?,?,'.$id.')');
    $stmt->execute([$data->name, $data->price, $data->stock]);
    $response = $stmt->fetch(PDO::FETCH_ASSOC);
    $count=$stmt->rowCount();
     if ($count > 0)
    {      
      echo json_encode("Product has been added");
    }
    else
    {
        die('Product could not be added');        
    }
    return;   
}

function updateProduct()
{
 $userId=auth(); 
 global $pdo;
 $data = json_decode(file_get_contents('php://input',true));
 $stmt = $pdo->prepare('UPDATE products SET name=?, price=?, stock=?, user_id='.$userId.' WHERE id=?');
 $stmt->execute([$data->name, $data->price, $data->stock,$data->id]);
 $response = $stmt->fetch(PDO::FETCH_ASSOC);    
 $count=$stmt->rowCount();
 
 if ($count > 0)
    {      
      echo json_encode("Product has been modifed");
    }
    else
    {
        die('Product could not be modify');        
    }
    return;   
}

function delProduct($id){
    
    auth(); 
    global $pdo;    
    $data = json_decode(file_get_contents('php://input',true));
    $stmt = $pdo->prepare('DELETE FROM products WHERE id = ?');
    $stmt->execute([$id]);
    $count = $stmt->rowCount();
    $response = $stmt->fetchAll(PDO::FETCH_ASSOC);    
    if($count > 0)
    {
        echo json_encode("Product removed succeffuly");
    }
    else
    {
        die('Deletion failed! No product with that ID');        
    }
      
    return;
}
function auth()
{
global $pdo;
$token = apache_request_headers()['token'];
$token = base64_decode($token);
$stmt = $pdo->prepare('SELECT id,isAdmin FROM users WHERE token = ?');
$stmt->execute([$token]);
$response = $stmt->fetch(PDO::FETCH_ASSOC);
$result = $response['id'];
$admin =$response['isAdmin'];
if($admin == true)
{
    return $result;
}
else
{
      http_response_code(401);
      die('Authorization error');    
}
}
