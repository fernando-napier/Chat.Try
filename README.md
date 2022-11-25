# Chat.Try


<h3>Summary of the project</h3>

This is my attempt at creating a Blazor Server application. Blazor Server is very handy for backend developers because it is almost purely a backend application and the UI elenemts are updated via SignalR.

As of 11/25/22 I have deployed this application to my personal azure cloud. The site is https://fennorad.azurewebsites.net/ and will continually be getting updates because the application has deploy pipelines on the `main` repo branch. Most changes from now on will constitute a PR/MR as changes will affect the availability of the site.

If you would like to play around use:  
User: `example@user.com`  
Password: `Password1!`  

<h3>How to clone and run locally</h3>

1) Ensure you have Dotnet 6 and Sql Server installed.
2) Clone Repo
3) Use Sql Server to Resore DB using the backup located [here](https://github.com/fernando-napier/Chat.Try/tree/main/Chat.Try.Db/DatabaseBackup)
4) Run project and create users to chat back and forth with! 

</details>

<details>
  <summary><h3>Things in development</h3></summary>

  
* ~~Database design~~
* ~~Auto generation of dbcontext via EFCore Power Tools~~
* ~~Parent and child razor component interaction~~
* ~~Basic logic/html/css to be able interact with other users~~
* Notification upon new message received
* ~~User Search auto-complete~~
* SignalR realtime messaging between users
  * currently 15 second refresh for new messages
* ~~Better UI~~
* Emoji support
* ~~Data migration for easy cloning and setup~~
* Allow for group chats
* encrypt user messages to ensure user data isn't being monitored
* ~~Deploy as a website~~ [the site is live](https://fennorad.azurewebsites.net/)
* ~~Add CI/CD to main branch for deployments~~

</details>

<details>
  <summary><h3>Database schema for Chat.Try</h3></summary>

Here is what the db components look like, the forking of the arrows implies a one-to-many relationship between the tables. These tables relate to each other via foreign keys, are represented in the DbContext, and allow for easy inclusion of the right data when passing messages between users.

[![Untitled-Diagram-drawio.png](https://i.postimg.cc/66vB3htB/Untitled-Diagram-drawio.png)](https://postimg.cc/0rPTXDz4)

</details>

<details>
  <summary><h3>Demo of the project</h3></summary>

This is ~~a current~~ an outdated snapshot of what the chat capabilities look like (Clicking on the image will take you to youtube)
  
[![Chat.Try Demo](https://i.postimg.cc/J4gPC8tK/Screenshot-2022-11-15-223722.png)](https://youtu.be/R_Ky4iRMuhs)

Here is an updated UI version as of 11/18/22:

[![Screenshot-2022-11-18-165319.png](https://i.postimg.cc/yxzjFCQm/Screenshot-2022-11-18-165319.png)](https://postimg.cc/9RJyhKj0)

</details>


