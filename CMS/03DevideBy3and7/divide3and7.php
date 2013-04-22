<!DOCTYPE html>
<html>
<head>
        <title>Divide by 3 and 7</title>
</head>
<body>
        <?php
                for($i = 0; $i < 1000; $i++)
                {
                        
						if($i%3==0 && $i%7==0)
                        { 
							//Only not to have a "," for the last number (i know its not the best way to do it :-))
							if ($i%3==0 && $i%7==0 && $i>970)
							{
								echo($i);
							}
							else
							{
								echo($i . ", ");
							}
                        }
                }
        ?>
</body>
</html>