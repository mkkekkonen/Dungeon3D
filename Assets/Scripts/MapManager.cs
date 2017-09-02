using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class MapManager
    {
        public static MapManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new MapManager();
                return instance;
            }
        }

        public int CurrentMapIndex { get; set; }
        public List<TextAsset> Maps { get; set; }

        private static MapManager instance;

        protected MapManager()
        {
            PlayerPrefs.DeleteAll();

            CurrentMapIndex = 0;
            Maps = new List<TextAsset>();

            TextAsset map1 = Resources.Load("Maps/map1") as TextAsset;
            TextAsset map2 = Resources.Load("Maps/map2") as TextAsset;

            Maps.Add(map1);
            Maps.Add(map2);
        }

        public void HelloWorld()
        {
            Debug.Log("Hello world");
        }
    }
}
