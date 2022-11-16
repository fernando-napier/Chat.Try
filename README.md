# Chat.Try

This is my attempt at creating a Blazor Server application. Blazor Server is very handy for pure backend developers because it keeps all of the logic out of the browser. 

This application is one where a user should be able to communicate with a peer one to one. However I setup the db tables in such a way that a Conversation could contain many ConversationUsers and so groups would be available. However that's a future enhancement. For now here is a demo of how the application functions:

This is a current snapshot of what the chat capabilities look like
[![Screenshot-2022-11-15-223722.png](https://i.postimg.cc/J4gPC8tK/Screenshot-2022-11-15-223722.png)](https://postimg.cc/ZC8r618y)

Things being worked on:
* ~~Database design~~
* ~~Auto generation of dbcontext via EFCore Power Tools~~
* ~~Parent and child razor component interaction~~
* ~~Basic logic/html/css to be able interact with other users~~
* User Search auto-complete
* SignalR realtime messaging between users
  * currently 15 second refresh for new messages
* Better UI
* Emoji support
* Data migration for easy cloning and setup
* Deploy as a website
