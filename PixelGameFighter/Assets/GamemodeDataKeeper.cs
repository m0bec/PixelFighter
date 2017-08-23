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

    const float PLAYER_FL = -10.0f;
    public float PlayerFL{
        get{return PLAYER_FL;}
    }

	int difficulty;
    public int Difficulty{
		set{difficulty = value;}
		get{return difficulty;}
	}

    int score = 0;
    public int Score{
        get{return score;}
        set{score = value;}
    }
    int high_score;

    bool start_movie_fin = false;
    public bool StartMovieFin{
        get{return start_movie_fin;}
        set{start_movie_fin  =value;}
    }
    
}
