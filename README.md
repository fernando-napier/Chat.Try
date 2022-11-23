# Chat.Try

This is my attempt at creating a Blazor Server application. Blazor Server is very handy for pure backend developers because it keeps all of the logic out of the browser. 

This application is one where a user should be able to communicate with a peer one to one. However I setup the db tables in such a way that a Conversation could contain many ConversationUsers and so groups would be available. However that's a future enhancement. For now here is a demo of how the application functions:

This is a current snapshot of what the chat capabilities look like (Clicking on the image will take you to youtube)

<details>
  <summary>Demo of the project</summary>
  
[![Chat.Try Demo](https://i.postimg.cc/J4gPC8tK/Screenshot-2022-11-15-223722.png)](https://youtu.be/R_Ky4iRMuhs)

Here is an updated UI version as of 11/18/22:

[![Screenshot-2022-11-18-165319.png](https://i.postimg.cc/yxzjFCQm/Screenshot-2022-11-18-165319.png)](https://postimg.cc/9RJyhKj0)

</details>

<details>
  <summary>Database schema for Chat.Try</summary>

Here is what the db components look like, the forking of the arrows implies a one-to-many relationship between the tables. These tables relate to each other via foreign keys, are represented in the DbContext, and allow for easy inclusion of the right data when passing messages between users.

[![Untitled-Diagram-drawio.png](https://i.postimg.cc/66vB3htB/Untitled-Diagram-drawio.png)](https://postimg.cc/0rPTXDz4)

</details>

<details>
  <summary>How to clone and run locally</summary>

1) Ensure you have Dotnet 6 and Sql Server installed.l
2) Clone Repo
3) Use Sql Server to Resore DB using the backup located in ./Chat.Try.Db/DatabaseBackup/Chat.bak
4) Run project and create users to chat back and forth with! 

</details>

<details>
  <summary>Things in development</summary>

  
* ~~Database design~~
* ~~Auto generation of dbcontext via EFCore Power Tools~~
* ~~Parent and child razor component interaction~~
* ~~Basic logic/html/css to be able interact with other users~~
* Notification upon new message received
* User Search auto-complete
* SignalR realtime messaging between users
  * currently 15 second refresh for new messages
* Better UI
* Emoji support
~~* Data migration for easy cloning and setup~~
* Allow for group chats
* encrypt user messages to ensure user data isn't being monitored
* Deploy as a website

</details>


