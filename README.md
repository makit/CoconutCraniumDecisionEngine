The Coconut Cranium Decision Engine is my entry to the "Olympiad of Misguided Geeks contest at The Daily WTF (or OMGWTF for short)":

http://omg2.thedailywtf.com/

## Description
The Coconut Cranium Decision Engine is a Windows application that once logged in, allows you to get a random yes or no answer utilising a local and remote random generator. A settings file is used to get the URL of the remote random number generator to allow it to be moved onto different servers.


## Randomness
A local console application will generate a random number based on many factors including time, a random file size, generated GUIDs, PC name, processor count, OS version and processing time of a CPU intensive task. This is then combined with a random number from a remote server which generates a random number from the user, http headers, and a random google search result. These combined numbers are used to seed a random yes or no.


## UI Approach
Upon running the application a login screen is shown, once logged in a yes or no button is present that will produce the random result and show as a message box before putting in the log of results.


## Security Approach
The application requires a username and password to run, these are very cleverly designs to not require a setup or storage. Utilising a clever "Just In Time Password Generation System" (Patent Not Pending) the password and username simply need to be in the correct format allowing administrators to give people accounts without doing any setup. The password must begin with J or L, contain a 1, contain a 5 or 8, contain the username in reverse.

The remote generator is not secured, due to its nature of not taking any input.

Example Login: dave / J81evad22


## Disclaimer
It is only for fun. Do not use this as an example of code, unless its an example of bad code.
