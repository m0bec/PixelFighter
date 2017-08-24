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

    public void SetStart(){
        score = 0;
        start_movie_fin = false;
        player_hp = 2;
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
    
    int player_hp = 3;
    public int PlayerHp{
        set{player_hp = value;}
        get{return player_hp;}
    }
    public void AddPlayerHp(){player_hp++;}
    public void DownPlayerHp(){player_hp--;}
    bool player_death_flag  =false;
    public bool PlayerDeathFlag{
        set{player_death_flag = value;}
        get{return player_death_flag;}

    }
    public bool GameOverJudge(){
        if(player_hp < 0)   return true;
        else{return false;}
    }

}
