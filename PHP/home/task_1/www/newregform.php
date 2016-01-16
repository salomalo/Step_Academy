<html>
    <head>    
        <style type="text/css" >
            input,select{
                display: block;
                margin-top: 4px;
                margin-left: 20px;
            }
        </style>
    </head>
    <body>
        <form action="newregphp.php" method="post">
            <input type="text" name="login" placeholder="login" />
            <input type="text" name="email" placeholder="email" />
            <input type="text" name="name" placeholder="name" />
            <input type="text" name="age" placeholder="age" />
            <select name="gender">
                <option value="male" >Male</option>
                <option value="female" >Female</option>
            </select>
            <input type="password" name="pass" placeholder="Password" />
            <input type="password" name="pass2" placeholder="Confirmation" />
            <input type="submit" value="sign in" />
        </form>
    </body>
</html>