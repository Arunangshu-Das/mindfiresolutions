SELECT GETDATE() AS 'Today''s Date and Time', 
@@CONNECTIONS AS 'Login Attempts'

SELECT @@MAX_CONNECTIONS AS 'Max Connections'

SELECT @@CPU_BUSY * CAST(@@TIMETICKS AS FLOAT) AS 'CPU microseconds', 
   GETDATE() AS 'As of' ;

IF @@ERROR <> 0 
PRINT  'Error Encountered !!!';

SELECT @@LANGUAGE AS 'Language Name';

SELECT @@PACK_RECEIVED AS 'Packets Received'

SELECT @@PACK_SENT AS 'Pack Sent'

SELECT @@PACKET_ERRORS AS 'Packet Errors'

SELECT @@SERVERNAME AS 'Server Name'