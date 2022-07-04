<html>
        <head>
                 <!-- Required meta tags -->
                 <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <script type="text/javascript"  src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.0/jquery.min.js"></script>
    <script type="text/javascript">
      var auto_refresh = setInterval(
        function ()
        {
          $('#auto').load('refresh.php').fadeIn("slow");
        }, 1000);
    </script>
    <style>
      .table td, .table th {
        border: none;
      }
    </style>

    <title>Tema 3</title>
        </head>
        <body>

    <div id="auto" class="container"></div>
    <div class="container">
      <form action="" method="post">
        <div class="form-row">
          <div class="col">
            <input
              type="text"
              class="form-control"
              name="username"
              id="username"
              placeholder="Enter username"
            />
          </div>
          <div class="col"></div>
          <div class="col">
            <input
              type="text"
              class="form-control"
              name="message"
              placeholder="Your message"
            />
          </div>
          <div class="col">
            <button type="submit" name='submitButton' class="btn btn-primary">Submit</button>
          </div>
        </div>
      </form>
      <?php
        if(isset($_REQUEST['submitButton']))
        {
          $hostname='postgresapache';
          $dbname='apache';
          $username='apache';
          $password='apache';
          $db_connection = pg_connect("host=$hostname dbname=$dbname user=$username password=$password");
          if($_POST['username']==='' or $POST['message']==='')
                  return;
          $sql= "INSERT INTO chat(username,message) VALUES ('".$_POST['username'] ."','".$_POST['message'] ."');";
          $result = pg_query($db_connection, $sql);
          pg_close($db_connection);
        }
      ?>
    </div>
</html>
