# HappyMusic.WebAPI
## What is HappyMusic?
HappyMusic is an application for a person to use that stores all their music--Think something similar to Spotify. A User can go in and create a playlist, adding their favorite songs to it. A user can also see the songs on a particular Album, or Artists that have collaborated on a particular Album. 
## How To Use This API
This APi application is run in Visual Studio To run Clone this repository from github to your local machine and run the application.  

Albums are tied to songs with a foriegn key relationship The album the song belongs to has to be created before the song can be created, if there is only one song in the album label it appropriately with the song name and Single or EP to designate only one song exists in the album.

## Purpose of this API
The purose of Our API is to be an interface with a database of songs and the related data. The API should be run in Visual studio with version 4.8 or higher. 
## How to use the 
## Data Structure
 ![DataTables](/Images/DataTables.png)
## Used Help Page API End Point Documentation
We used the Documentation built into the API's help page to customize our Documentation With XML Comments. 
![APIDOC1](/Images/APIDOC1.png)
![APIDOC2](/Images/APIDOC2.png)
![APIDOC3](/Images/APIDOC3.png)
## Unused Swagger API End Point Documentation
The API documentation was originally found by running the app in visual studio and adding swagger to the end of the address bar on the asp.net home page but was changed to the help page more easily accessed when running the application.

 ![ApiEndPoints1](/Images/ApiEndPoints1.png)
 ![ApiEndPoints2](/Images/ApiEndPoints2.png)
 ## Customized API Endpoint Example
 This illustration shows where XmL Comments show up in the ApI Endpoint Documentation within the Swagger view. Also isllusted is that the documentation in swagger suggests Properties from the model level of the API that are referenced by the specific controller the end point is reffering to.
 ![XmlExample](/Images/XmlExample.png)
 
## Resources Used
Video used to learn how to Customize the Endpoint Documentation in Swagger https://youtu.be/tyesYzBnS4A  
Trello board for work flow can be found here: https://trello.com/b/ZYGAmQCe/music-app-blue-badge-challenge  
Google Dock for Data Diagram and intial planning can be found here:https://docs.google.com/spreadsheets/d/1sp65-SZqH7f_a67VP-kF2s9rJ7kDOkzDy7KSMEh8qKI/edit#gid=1800955100  
Note the Google Doc has several tabs used in the different phases of planning  
Github Markup Language guide https://guides.github.com/features/mastering-markdown/  
Vide to add photos to a ReadMe file in github https://youtu.be/nvPOUdz5PL4  
Instructions to enable XML Comments to customize API documentation on help page https://stackoverflow.com/questions/24284413/webapi-help-page-description  
Hex Color illustrator https://www.color-hex.com/  
Article about using Swagger and ASP.Net Documentation https://www.c-sharpcorner.com/article/web-api-documentation-using-swagger-and-asp-net-core-with-visual-studio-2019/
