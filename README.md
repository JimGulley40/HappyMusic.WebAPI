# HappyMusic.WebAPI
## What is HappyMusic?
HappyMusic is an application for a person to use that stores all their music--Think something similar to Spotify. A User can go in and create a playlist, adding their favorite songs to it. A user can also see the songs on a particular Album, or Artists that have collaborated on a particular Album. A User's Playlist will show how many songs are on the playlist. 

## How To Use This API
This API is run in Visual Studio. To run this application, please clone the master and run it on Visual Studio 2019 version 4.8 or higher. When you use the API, please start by creating a Username and a Password. The password must be at least 6 characters long, must have an uppercase letter, and a special character in it. Once you have done so, a token will be given to you. The token should then be used when creating/reading/updating/deleting any other infomation in this application.

There are a few caveats with this API:\
There are a few foreign key relationships in this table, and this causes a couple of issues with how data is input. Since albums are connected to artists as well as songs, and album needs to be created first. Please see the endpoints/documentation below for more information.  Next, a User needs to be created. After that, a song and artist can be created with the correct information. Lastly, a playlist can be created-- but in order to put information in the playlist, you must use the PlaylistSong joining table/endpoints. 

## Purpose of this API
The purpose of this API is to store songs for a user. For example, a user would be albe to find songs that he/she/they like and would be able to add the songs to a playlist. This would store songs for the User to listen to at a later date. \
A more practical purpose of this API was for our team to learn how to use Team Github as well as understanding AGILE methodologies more fully. We used Trello (a planning application) to help us with our ticketing and divying up work. 

## Technologies 
Net Framework C#\
PostMan\
Trello\
GoogleDocs\

## Launch
Visual Studio Community 2019 Version 16.7.5\
Microsoft .Net Framework Version 4.8.04084\
## How to use the 
## Data Structure
 ![DataTables](/Images/DataTables.png)
## Used Help Page API End Point Documentation
Option #1 to view our API Documentation is through the API's help page we used this to customize our Documentation With XML Comments. 
![APIDOC1](/Images/APIDOC1.png)
![APIDOC2](/Images/APIDOC2.png)
![APIDOC3](/Images/APIDOC3.png)
## Swagger API End Point Documentation
Option #2 The API documentation can also bey found by running the app in visual studio and adding swagger to the end of the address bar on the asp.net home page.

 ![ApiEndPoints1](/Images/ApiEndPoints1.png)
 ![ApiEndPoints2](/Images/ApiEndPoints2.png)
 ## Customized API Endpoint Example
 This illustration shows where XmL Comments show up in the ApI Endpoint Documentation within the Swagger view. Also isllusted is that the documentation in swagger suggests Properties from the model level of the API that are referenced by the specific controller the end point is reffering to.
 ![XmlExample](/Images/XmlExample.png)
 
## Resources Used
Video used to learn how to Customize the Endpoint Documentation in Swagger https://youtu.be/tyesYzBnS4A  
Trello board for work flow can be found here: https://trello.com/b/ZYGAmQCe/music-app-blue-badge-challenge  
Google Doc for Data Diagram and initial planning can be found here:https://docs.google.com/spreadsheets/d/1sp65-SZqH7f_a67VP-kF2s9rJ7kDOkzDy7KSMEh8qKI/edit#gid=1800955100  
Note the Google Doc has several tabs used in the different phases of planning  \
Github Markup Language guide https://guides.github.com/features/mastering-markdown/  
Video to add photos to a ReadMe file in github https://youtu.be/nvPOUdz5PL4  
Instructions to enable XML Comments to customize API documentation on help page https://stackoverflow.com/questions/24284413/webapi-help-page-description  
Hex Color illustrator https://www.color-hex.com/  
Article about using Swagger and ASP.Net Documentation https://www.c-sharpcorner.com/article/web-api-documentation-using-swagger-and-asp-net-core-with-visual-studio-2019/  
Video about adding xml comments in Swagger https://www.youtube.com/watch?v=tyesYzBnS4A  

