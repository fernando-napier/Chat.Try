import React, { Component } from 'react';
import './Container.css';
import './Wordle.css';
import { Wordle } from 'fennorad-wordle';

export class WordleGame extends Component {
    static displayName = Wordle.name;

    constructor(props) {
        super(props);
    }

    render() {
        return (
            
                    <Wordle
                        wordList={['piano', 'hello', 'plans' ]}   // word list
                        solution="piano"                // final word solution

                        nbRows={6}                      // number of lines
                        nbCols={5}                      // number of cells (letter tile)
                    />
        );
    }
}
