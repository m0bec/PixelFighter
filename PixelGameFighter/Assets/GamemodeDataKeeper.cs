using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamemodeDataKeeper {

    private static GamemodeDataKeeper mInstance;

	private GamemodeDataKeeper(){}

    public static GamemodeDataKeeper Instance {

        get {

            if( mInstance == null ) mInstance = new GamemodeDataKeeper();

            return mInstance;
        }
    }

	int difficulty;
    public int Difficulty{
		set{difficulty = value;}
		get{return difficulty;}
	}
}
