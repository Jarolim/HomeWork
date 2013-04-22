<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
     <title>form</title>
     <link href="style.css" type="text/css" rel="stylesheet"> 
<style>
span{
	float:left;
	padding-top: 5px;
	font-size: 15px;
}
</style>
</head>
<body>
<?php
	//var_dump($_GET); die();
	$numOne = trim($_GET['num1']);
	$theSign = trim($_GET['sign']);
	$numTwo = trim($_GET['num2']);
	switch ($theSign) {
		case '+':
			$result = $numOne + $numTwo;
			break;
		case '-':
			$result = $numOne - $numTwo;
		break;
		case '*':
			$result = $numOne * $numTwo;
		break;
		case '/':
			$result = $numOne / $numTwo;
		break;

		default:
			$result = 'error';
			break;
	}

	echo '<div>'.'<span>'.$numOne.' '.$theSign.' '.$numTwo.' = '.'</span>'.'<input type="text" value="'.$result.'"></div>';
?>
</body>
</html>