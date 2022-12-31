import React, { Component } from 'react';
import './Container.css';
import Chatbot from 'react-chatbot-kit'
import ActionProvider from './ActionProvider';
import MessageParser from './MessageParser';
import Config from './Config';

export class Chat extends Component {
  static displayName = Chat.name;

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };
    this.incrementCounter = this.incrementCounter.bind(this);
  }

  incrementCounter() {
    this.setState({
      currentCount: this.state.currentCount + 1
    });
  }

  render() {
    return (
        <div class="row center-stuff">
            <div class="col-12 col-md-8">
                <h2>Chat Page</h2>
                <p>This is a page where one can strike up a conversation with any user or continue an ongoing convo.</p>
                <hr />
                <Chatbot config={Config} actionProvider={ActionProvider} messageParser={MessageParser} />
            </div>
        </div>
    );
  }
}
