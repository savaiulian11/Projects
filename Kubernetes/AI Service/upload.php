<html>
	<head>
		<title>PHP Result</title>
	</head>
	
	<body>
		</br>

		<?php
		
			require_once 'vendor/autoload.php';

			use MicrosoftAzure\Storage\Blob\BlobRestProxy;
			use MicrosoftAzure\Storage\Common\Exceptions\ServiceException;
			use MicrosoftAzure\Storage\Blob\Models\ListBlobsOptions;
			use MicrosoftAzure\Storage\Blob\Models\CreateContainerOptions;
			use MicrosoftAzure\Storage\Blob\Models\PublicAccessType;

			$target_dir = "uploads/";
			$target_file = $target_dir . basename($_FILES["fileToUpload"]["name"]);
			$fileToUpload = basename($_FILES["fileToUpload"]["name"]);
			$linkToUpload = "https://storagetema3.blob.core.windows.net/images/". $fileToUpload;
			$imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));
			$uploadOk = 1;
			$containerName = "images";

//-------------------------VERIFY IMAGE-------------------------------------------------------------------------
			if (file_exists($target_file))
				die("Sorry, file already exists.");

			if ($_FILES["fileToUpload"]["size"] > 400000) 
				die("Sorry, your file is too large.");

			if($imageFileType != "jpg" && $imageFileType != "png" && $imageFileType != "jpeg" && $imageFileType != "gif" )
				die("Sorry, only JPG, JPEG, PNG & GIF files are allowed.");
//-------------------------UPLOAD FILE------------------------------------------------------------------------------------------------------------
			if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_file)) {

				$connectionString = "DefaultEndpointsProtocol=https;AccountName=storagetema3;AccountKey=ZBcqZI4XGmwEOC/7eY1I21951XazQ61L0OeN4r4AoA8bQY5LSpJ7X0r+wf4aRNI/Wp6Bk5iXt+MG+AStH56Nvg==;EndpointSuffix=core.windows.net";
				$blobClient = BlobRestProxy::createBlobService($connectionString);

				$myfile = fopen($fileToUpload, "w") or die("Unable to open file!");
				fclose($myfile);

				$content = fopen($fileToUpload, "r");
				$blobClient->createBlockBlob($containerName, $fileToUpload, $content);
			} 
			else
			 	die("Sorry, there was an error uploading your file.");
//-------------------------INSERT DATA INTO IMAGEINFO-----------------------------------------------------------------------------------------------
			$serverName = "server-sava.database.windows.net";
			$connectionOptions = array("Database" => "db-tema3", "Uid" => "iulian", "PWD" => "Sava1234");
			
			$conn = sqlsrv_connect($serverName, $connectionOptions);

			if( $conn === false ) 
				die("Error on connection to database.");

			$tsql= "INSERT INTO imageinfo (name, link) VALUES ('".$fileToUpload."','".$linkToUpload."')";	
			$getResults= sqlsrv_query($conn, $tsql);
					
			if ($getResults == FALSE)
				die("Error on insert database(imageinfo)."); 
			sqlsrv_free_stmt($getResults);
//-------------------------SELECT DATA OF INSERTED IMAGE-------------------------------------------------------------------------------------------------
			$tsql= "SELECT id, name FROM imageinfo WHERE link = '".$linkToUpload."'";
			$getResults= sqlsrv_query($conn, $tsql);
					
			if ($getResults == FALSE)
				echo "Error on select database(imageinfo).";
			echo "<br />";
			$row = sqlsrv_fetch_array($getResults, SQLSRV_FETCH_ASSOC);
			$id = $row['id'];
			sqlsrv_free_stmt($getResults);
//-------------------------SEND IMAGE TO COMPUTER VISION-------------------------------------------------------------------------------------------------
			$url = 'https://ia-tema3.cognitiveservices.azure.com/vision/v2.1/analyze?visualFeatures=Description&language=en';
			$imageURL='https://webapp-tema3.azurewebsites.net/uploads/';
			$ch = curl_init();
			echo '<img src="'. $imageURL . $fileToUpload . '"/>';

			curl_setopt($ch, CURLOPT_URL, $url);
			curl_setopt($ch, CURLOPT_POST, true);
			curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
			curl_setopt($ch, CURLOPT_HTTPHEADER, array(
				'Ocp-Apim-Subscription-Key: 0cd421933cb244a4beeeb955e5ef0411',
				'Content-Type: application/json',
				'User-Agent: PostmanRuntime/7.29.0',
				'Accept: */*',
				'Host: ia-tema3.cognitiveservices.azure.com',
				'Accept-Encoding: gzip, deflate, br',
				'Connection: keep-alive'
			));
			curl_setopt($ch, CURLINFO_HEADER_OUT, true);
			curl_setopt($ch, CURLOPT_HEADER, 1);
			curl_setopt($ch, CURLOPT_POSTFIELDS, $data);
			curl_setopt($ch, CURLOPT_POSTFIELDS, "{\"url\":\"". $imageURL . $fileToUpload . "\"}");
			$result = curl_exec($ch);

			echo $result;
//-------------------------PARSE JSON FROM COMPUTER VISION-------------------------------------------------------------------------------------------------
			$myTag = '';
	
			$length = strlen($result);
			for ($index = 0; $index < $length - 10; $index++)
				if ( $result[$index] == "n" && $result[$index + 1] == "a" && $result[$index + 2] == "m" && $result[$index + 3] == "e") 
				{
					$index = $index + 7;
					while($result[$index] != "\"") 
					{
						$myTag = $myTag.$result[$index];					
						$index++;
					}
//-------------------------INSERT DATA INTO IMAGETAGS-------------------------------------------------------------------------------------------------		
					$tsql= "INSERT INTO imagetags (idImage, tag) VALUES ('".$id ."','".$myTag ."')";
					$getResults= sqlsrv_query($conn, $tsql);	
					sqlsrv_free_stmt($getResults);
					$myTag='';
				}
			sqlsrv_close($conn);
			header("Location:https://webapp-tema3.azurewebsites.net/");
		?>
	</body>
</html>