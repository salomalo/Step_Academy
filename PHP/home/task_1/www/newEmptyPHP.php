<html>
    <head>
        <script type="text/javascript" src="/jquery.js"></script>
        <script type="text/javascript">
        function log(x){
            console && console.log(x);
        }
        $(window).load(function(){
            $('div#content').click(function(){
                log('clicked');
            })
        })
        </script>
        <style type="text/css">
            div#content{
                height: 100px;
                border: 1px solid #eee;
            }
        </style>


    </head>
    <body>
        <div id="content"></div>
    </body>
</html>

