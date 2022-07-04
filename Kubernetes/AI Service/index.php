<html>
	<head>
		 <!-- Required meta tags -->
		 <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <title>Tema 3</title>
 	</head>
	
	<body style="background-color: #ebebeb;">
		<div class="container" style="background-color: #6b6b6b;">
			<div class="container text-center pt-3">
				<h1 bold>Image tagging</h1>
					<form action="upload.php" method="post" enctype="multipart/form-data">
						<div class="form-group">Add your file:</label>
							<input type="file"  class="form-control" name="fileToUpload" id="fileToUpload">
						</div>
						<button type="submit" class="btn btn-primary" value="Upload File" name="submit">Submit</button>
					</form>
				<h2 bold>Reading data from table:</h2>
			</div>
	
		<?php
			function displayRow($showLink, $showName, $showTags) {
				$imageURL = 'https://webapp-tema3.azurewebsites.net/uploads/';
				$ext = pathinfo($showName, PATHINFO_EXTENSION);
				$file = basename($showName,".".$ext);
				echo ('<tr>' .
								'<td >' . 
									'<a target="_blank" href="' . $showLink . '">' . $file . '</a>' . 
								'</td>' . 
								'<td>' . 
									'<img width="200" height="200" src="'. $imageURL . $showName .  '"/>' .
								'</td>' . 
								'<td>' . 
									$showTags . 
								'</td>' .
							'</tr>' .
				PHP_EOL);
			}
//-------------------------READ DATA FROM TABLES-----------------------------------------------------------------------------------------------
	 		$serverName = "server-sava.database.windows.net";
   	 		$connectionOptions = array(
        			"Database" => "db-tema3", 
        			"Uid" => "iulian",
        			"PWD" => "Sava1234"
    			);
    	
			//Establishes the connection
    		
			$conn = sqlsrv_connect($serverName, $connectionOptions);
	
			$tsql= "SELECT name, link, time, tag FROM [dbo].[imageinfo] AS II INNER JOIN [dbo].[imagetags] AS IT ON IT.idImage = II.id";
    	
			$getResults= sqlsrv_query($conn, $tsql);
    	
			if ($getResults == FALSE)
       	 			echo (sqlsrv_errors());

			echo('<br>' . PHP_EOL);
			echo '<table class="table table-dark">';
			echo '<tr><td>Link</td><td>Image</td><td>Tag</td></tr>';
			$showLink = '';
			$showTags = '';
			$showName = '';
//-------------------------DISPLAY DATA IN PAGE-----------------------------------------------------------------------------------------------
			while ($row = sqlsrv_fetch_array($getResults, SQLSRV_FETCH_ASSOC)) {
				if($showLink == $row['link'] || $showLink == '') {
					$showLink = $row['link'];
					$showName = $row['name'];
					$showTags = $showTags . $row['tag'] . '</br>';
				} else {
					displayRow($showLink, $showName, $showTags);
					$showTags = '';
					$showLink = '';
					$showName = '';
				}
    	}
			displayRow($showLink, $showName, $showTags);
    	echo '</table>';
		
			sqlsrv_free_stmt($getResults);
			sqlsrv_close($conn);
		?>
		</div>
 	</body>
</html>