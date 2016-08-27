using UnityEngine;
using System;
using System.IO;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject[] prefabSet;
    public float[,] mapData;
    public float step;

    public void LoadLevel(string path)
    {
        StreamReader reader = new StreamReader(new FileStream(Application.streamingAssetsPath + path, FileMode.Open));
        Vector3 pos = this.transform.position;

        mapData = new float[16, 16];
        int x = 0, y = 0;
        int val = 0;
        String tmpstring = "";
        while(!reader.EndOfStream)
        {
            tmpstring = reader.ReadLine();
            String[] tokens = tmpstring.Split(',');
            for(int i=0; i< tokens.Length; i++)
            {
               
                val = Convert.ToInt32(tokens[i]);
                Debug.Log("Loading " + val);
                if (prefabSet[val] != null)
                {
                    GameObject newObj = Instantiate(prefabSet[val], pos, Quaternion.identity) as GameObject;
                    newObj.transform.parent = this.transform;
                }
                mapData[x, y] = val;
                pos.x += step;
                x++;
            }
            y++;
            x = 0;
            pos.y -= step;
            pos.x = this.transform.position.x;
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
