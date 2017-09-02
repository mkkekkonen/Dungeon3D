using UnityEngine;
using System.Collections;
using Assets.Scripts;
using System.Collections.Generic;

public class MapCreator : MonoBehaviour {

    private GameObject wallCube, player, stairsUp, stairsDown;
    private List<GameObject> wallCubes;

    private const int mapDim = 30;

	// Use this for initialization
	void Start () {

        wallCubes = new List<GameObject>();

        wallCube = Resources.Load("Prefabs/WallCube") as GameObject;
        player = GameObject.FindGameObjectWithTag("Player");

        CreateMap();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateMap()
    {
        TextAsset map = MapManager.Instance.Maps[MapManager.Instance.CurrentMapIndex];
        GameObject stairs;

        Debug.Log(map.text);

        int x = 0, 
            y = 0;

        foreach(char c in map.text)
        {
            switch(c)
            {
                case '#':
                    wallCubes.Add(Instantiate(wallCube, GetVector(x, y), Quaternion.identity) as GameObject);
                    break;
                case '@':
                    player.transform.position = GetVector(x, y);
                    break;
                case '>':
                    stairs = Resources.Load("Prefabs/StairsDown") as GameObject;
                    stairsDown = Instantiate(stairs, GetVector(x, y), Quaternion.identity) as GameObject;
                    break;
                case '<':
                    stairs = Resources.Load("Prefabs/StairsUp") as GameObject;
                    stairsUp = Instantiate(stairs, GetVector(x, y), Quaternion.identity) as GameObject;
                    break;
                case '\n':
                    y++;
                    break;
            }

            switch(c)
            {
                case '#':
                case '.':
                case '@':
                case '>':
                case '<':
                    x++;
                    if (x > mapDim - 1)
                        x = 0;
                    break;
            }
        }
    }

    private Vector3 GetVector(int x, int y)
    {
        return new Vector3(x - mapDim / 2, 0.5f, y - mapDim / 2);
    }
}
