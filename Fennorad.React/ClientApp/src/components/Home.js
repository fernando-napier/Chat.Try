import React, { Component } from 'react';
import './Container.css';

export class Home extends Component {
  static displayName = Home.name;

  render() {
    return (
        <div class="row center-stuff">
            <div class="col-12 col-md-8">
                <h2>Welcome to Fennorad.React</h2>
                <p>This is an application built on:</p>
                <ul>
                  <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
                  <li><a href='https://facebook.github.io/react/'>React</a> for client-side code</li>
                  <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
                </ul>
                <br></br>
                <h3>Currently Available Pages</h3>
                <ul>
                    <li><strong> <a class="nav-link" href="/wordle">Wordle</a></strong> This is a clone of the popular word game</li>
                    <li><strong> <a class="nav-link" href="/weather">Weather</a></strong> This is the only page that uses the dotnet backend for data, part of the template from Microsoft</li>
                    <li><strong> <a class="nav-link" href="/chat">Chat</a></strong> This is meant to be an interactive page where you can chat with a bot</li>
                </ul>
            </div>
        </div>
    );
  }
}
