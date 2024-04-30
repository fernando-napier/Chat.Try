<h1> Fennorad </h1>

<h3> Introduction </h3>
This is a project that started out as a Blazor Server application to have more experience working with a UI but now has transformed. <br>


## Blazor Server project

<h3> Getting Started </h3>
This is a blazor server project built with Dotnet8, Sql Server, Blazor/Razor pages, Microsoft Identity, CSS, HTML, and some javascript. This project also leverages Github Actions for building and deploying the application as well as deploying database changes. The application and database are hosted on my personal Azure account.

<h3> Claude </h3>  
https://fennorad.azurewebsites.net/claude  

1) Allows any user to chat with Anthropic's Claude
2) Created a C# library to interface with Anthropics API as no official SDK was available [Link here](https://github.com/fernando-napier/Fennorad.AnthropicClient)
3) Added functionality to be able to upload images and transform them into a format Claude can interpret.

<h3> Chat </h3>  
https://fennorad.azurewebsites.net/chat

1) Allows any registered user to search for and chat with any existing user.
2) Currently only text can be sent from one user to another
3) User conversations, messages, and read receipts are stored to maintain a historical record of conversations
4) Any unread user conversation will result in the user being alerted to new messages via the conversation tile flashing
5) Can only be accessed by authenticated users

#### To access this feature create an account or use the example user:

User: `example-user`  
Password: `password` 

<h3> Maps </h3>
https://fennorad.azurewebsites.net/maps

1) Allows any registered user to search for directions from one place to another.
2) Allows for choosing driving, biking, walking
3) Leverages the Mapbox API through my personal library [Fennorad.Mapbox](https://github.com/fernando-napier/Fennorad.Mapbox)
4) Can only be accessed by authenticated users

<h3> Youtube Downloader </h3>
https://fennorad.azurewebsites.net/youtube

1) Allows any user to download youtube videos in either mp3 or mp4 format
2) videos are embedded so users can also just watch the video on this site
3) Leverages the `YoutubeExplode` library for downloading youtube videos and the `BlazorDownloadFileFast` libary for client side downloading.
4) This is unlisted to unauthenticated users but can still be accessed.

<h3> JSON/XML Beautifier </h3>
https://fennorad.azurewebsites.net/beautify

1) Allows any user to paste a string of JSON or XML data and have it be returned in a pretty format.
2) This is something that I use as a software engineer often and figured I could take a shot at writing the functionality myself.
3) This is unlisted to unauthenticated users but can still be accessed.

## Dotnet & React project

<h3> Getting Started </h3>
This is a project created with a React frontend, DotNet6 backend, Sql Server, Microsoft Identity, CSS, HTML.
Again this site is not live.

This site is under construction but I wanted to fully deploy an application.

<h3> Wordle </h3>

1) I found a react project that has a wordle component to import
2) Created the npm package `fennorad-wordle` based on that project since no npm deploys were available for it
3) This is still under construction but the basic functionality is there.
