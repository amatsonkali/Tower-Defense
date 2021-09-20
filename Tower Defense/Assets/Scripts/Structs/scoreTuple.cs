using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScoreTuple{

    public  ScoreTuple(int score, DateTime date, bool wonRound){
        this.score=score;
        this.date= date;
        this.wonRound = wonRound;
        id=-1;
    }
    public int score;
    public DateTime date;
    public bool wonRound;
    public int id;

    public override string ToString()
    {
        return date+ "\tScore: " + score + " "+(wonRound?"Win":"Lost") ;
    }
    
}