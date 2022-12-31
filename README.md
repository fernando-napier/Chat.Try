<h2> Fennorad </h2>

<h3> Introduction </h3>
This is a project that started out as a Blazor Server application to have more experience working with a UI but now has transformed.

<details>
  <summary>Dotnet & React project</summary>

<h3> Getting Started </h3>
This is a project created with a React frontend, DotNet6 backend, Sql Server, Microsoft Identity, CSS, HTML. This is deployed manually to SmarterAsp.Net.
To access the website go to https://fennorad.com/ 

This site is under construction but I wanted to fully deploy an application .

</details>

<details>
  <summary>Blazor Server project</summary>

<h3> Getting Started </h3>
This is a blazor server project built with DotNet6, Sql Server, Blazor/Razor pages, Microsoft Identity, CSS, HTML, some javascript. This project also leverages Github Actions for building and deploying the application as well as deploying database changes. The application and database are hosted on my personal Azure account.
To access the website go to https://fennorad.azurewebsites.net/ and create an account or use the example user:

User: `example-user`  
Password: `password` 


<h3>Functionality of the project</h3>

<h4> Chat </h4>  
https://fennorad.azurewebsites.net/chat

1) Allows any registered user to search for and chat with any existing user.
2) Currently only text can be sent from one user to another
3) User conversations, messages, and read receipts are stored to maintain a historical record of conversations
4) Any unread user conversation will result in the user being alerted to new messages via the conversation tile flashing
5) Can only be accessed by authenticated users

<h4> Maps </h4>
https://fennorad.azurewebsites.net/maps

1) Allows any registered user to search for directions from one place to another.
2) Allows for choosing driving, biking, walking
3) Leverages the Mapbox API through my personal library [Fennorad.Mapbox](https://github.com/fernando-napier/Fennorad.Mapbox)
4) Can only be accessed by authenticated users

<h4> JSON/XML Beautifier </h4>
https://fennorad.azurewebsites.net/beautify

1) Allows any user to paste a string of JSON or XML data and have it be returned in a pretty format.
2) This is something that I use as a software engineer often and figured I could take a shot at writing the functionality myself.
3) This is unlisted to unauthenticated users but can still be accessed.

<h4> Youtube Downloader </h4>
https://fennorad.azurewebsites.net/youtube

1) Allows any user to download youtube videos in either mp3 or mp4 format that is up to 20MB in size
2) videos are embedded so users can also just watch the video on this site
3) Leverages the `YoutubeDLSharp` library for downloading youtube videos and the `BlazorDownloadFileFast` libary for client side downloading.
4) This is unlisted to unauthenticated users but can still be accessed.

</details>