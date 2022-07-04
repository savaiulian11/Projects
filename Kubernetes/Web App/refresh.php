<table class="table table-hover table-bordered">
<?php
    $hostname='postgresapache';
    $dbname='apache';
    $username='apache';
    $password='apache';
    $db_connection = pg_connect("host=$hostname dbname=$dbname user=$username password=$password");

    $sql='SELECT EXISTS (
    SELECT FROM
        information_schema.tables
    WHERE
        table_schema LIKE \'public\' AND
        table_type LIKE \'BASE TABLE\' AND
        table_name =\'chat\'
    );';
    $result = pg_query($db_connection, $sql);
    $row=pg_fetch_row($result)[0];
    if ($row !== 't') {
      $sql='CREATE TABLE chat(                                                                               id SERIAL PRIMARY KEY,                                                                            username VARCHAR(1000) NOT NULL,                                                                  message VARCHAR(8000) NOT NULL,                                                                   date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP                                               );';
      $result = pg_query($db_connection, $sql);
    }

    $sql = 'WITH ordered AS (
              SELECT *
              FROM chat
              ORDER BY date DESC LIMIT 5
            )
            SELECT * FROM ordered
            ORDER by date ASC;';
    $result=pg_query($db_connection,$sql);
    while($row = pg_fetch_row($result)) {
      echo ('<tr>' .
            '<td>' . $row[1] . '</td>' .
            '<td>' . $row[2] . '</td>' .
            '<td>' . $row[3] . '</td>' .
            '</tr>'
            );
    }
    pg_close($db_connection);
    ?>
</table>
