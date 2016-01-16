<html>
    <head>
        <style type="text/css">
            input, select{
                display: block;
                margin-top: 4px;
                margin-left: 20px;
            }
        </style>
    </head>
    <body>
        <form action="reg.php" method="post">
            <input type="text" name="login" placeholder="Login" />
            <input type="text" name="name" placeholder="Your real Name" />
            <input type="text" name="email" placeholder="Email" />
            <input type="text" name="age" placeholder="Current age" />
            <select name="gender">
                <option value="male">Male</option>
                <option value="female">Female</option>
            </select>
            <input type="password" name="pass" placeholder="Password" />
            <input type="password" name="pass2" placeholder="Confirmation" />
            <input type="submit" value="Sign In"/>
        </form>
    </body>
</html>