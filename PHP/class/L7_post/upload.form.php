<html>
    <head>
    </head>
    <body>
        <h1>Upload form</h1>
        <form action="upload.php" method="post" enctype="multipart/form-data" >
            <input type="file" name="myfile" />  <br>
            <input type="submit" value="Upload" />
        </form>
        <br><br>
        <form action="img.upload.php" method="post" enctype="multipart/form-data" >
            <input type="file" name="myfile" />  <br>
            <input type="submit" value="Upload img" />
        </form>
    </body>
</html>
