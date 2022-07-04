Functionalitate:
	- Apasare buton Choose File;
	- Se alege imaginea dorita;
	- Apasare buton submit pentru a procesa imaginea;
	- La finalul listei se va regasi noua imagine.

Instalare:
	Computer Vision:
		Pricing tier: Free F1
	Web service:
		Publish: Code
		Runtime Stack: PHP 7.4
		Operating System: Windows
		Sku and size: Free F1
	SQL server:
		Tip Basic 
		Max size 100 MB
		Allow Azure services and resources to access this server YES
		Tabele:
			imageinfo:
				id int primary key
				name varchar(1000)
				link varchar(4000)
				time current_timestamp
			imagetags:
				id int primary key
				idImage int foreign key refering imageinfo(id)
				tag varchar(1000)
	Stoage Account de tip Blob Storage:
		Account Kind: Blob Storage
		Replication: LRS
		Connectivity method: Public endpoint
		
		Container cu Public access level Container

	upload.php
		Linia 22: Se modifica numele storage-ului
		Linia 25: Se modifica numele container-ului
		Linia 39: Se modifica connectionString-ul
		Linia 51: Se modifica numele server-ului sql
		Linia 52: Se modifica datele de logare pentru baza de date folosita
		Linia 76: Se modifica numele softului de Computer Vision
		Linia 77+120: Se modifica numele Web App-ului folosit
		Linia 85: Se modifica Key ul pentru Computer Vision

	index.php
		Linia 26: Se modifica numele Web App-ului folosit
		Linia 43: Se modifica numele server-ului sql

	Se adauga upload.php si index.php pe web app si se creaza un folder cu numele uploads.
	

