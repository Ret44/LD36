using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class Game : MonoBehaviour {

    public static Game instance;
    public static LevelManager level;
	// Use this for initializati
    void Awake()
    {
        instance = this;
        level = this.GetComponent<LevelManager>();
    }

	void Start () 
    {
        Game.level.LoadLevel("/Levels/test.csv");
	}
	


	// Update is called once per frame
	void Update () {
	
	}
}
