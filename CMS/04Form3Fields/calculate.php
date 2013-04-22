<!DOCTYPE html>
<html>
<head>
        <title>Calculate</title>
</head>
<body>
        <?php
                //With using php validation
				$numberOne = $_GET['numberOne'];
                $numberTwo = $_GET['numberTwo'];
                $sign = $_GET['sign'];
                $correctSign = $sign == '+' || $sign == '-' || $sign == '*' || $sign == '/';
                if(is_numeric($numberOne) && is_numeric($numberTwo) && $correctSign)
                {
                        echo($numberOne . " " .  $sign . " " . $numberTwo . " = ");
                        switch($sign)
                        {
                                case '+': echo($numberOne + $numberTwo); break;
                                case '-': echo($numberOne - $numberTwo); break;
                                case '*': echo($numberOne * $numberTwo); break;
                                default: echo($numberOne / $numberTwo); break;
                        }
                }
                else
                {
                        echo("Incorrect input! Please enter a number, then a sign and then another number.<br /><a href='calculate.html'>Try again!</a>");
                }
        ?>
</body>
</html>