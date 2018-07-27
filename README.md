## Rock-Paper-Scissors : Test client
This repo contains the source code for the test client. This client is meant for testing purposes and should not be used otherwise as there is no safe guard like argument validation.

### Command list

 - connect : Connect  to masterserver
 - join <n | r> : Join matchmaking for ranked (r option) or normal (n option) match
 - play <r | p | s> : In game, use this command to play one of the three (je sais pas quelle mot mettre ici lol je suis fatigué, j'changerais ça plus tard)
 
 ### Usage

Firstly, connect to the master server using the "connect" command.
Then, join eitheir a ranked match (not currently available) for the moment or a normal one (using the "join <n|r>" command.
When a match is found on the masterserver, you will be notified that the match has started and will be forwarded to the gameserver that host the game.
In game, use the "play <r|p|s> command to play when it's requested byt the server.
At the end of the match, the client will auto forward you to the masterserver and you can start again a new match if you wish to.
