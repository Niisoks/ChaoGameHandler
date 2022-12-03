# ChaoGameHandler
A desktop app that reads the sa2b chao save and turns it into a password for use with a mobile application

# Stuff that doesnt work right now
Exporting the chao save will currently only export 4 variables to the QR code as the rest havent been implemented

The program currently only imports and exports into chao slot 1

1&2 digit numbers do not work in the chao stats section because i wrote it with a misunderstanding of the endianess.

All variables do not have a toString

Need to add another layer of abstraction for the chao object to include variable categories

The qr code reader will crash if you click import again, not entirely sure why
