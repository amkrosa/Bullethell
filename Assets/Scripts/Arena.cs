using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Arena : MonoBehaviour
{
    [Header("Tilemap")]
    public Tilemap ArenaTilemap;
    public Vector3 LeftTopCorner { get; private set; }
    public Vector3 LeftBotCorner { get; private set; }
    public Vector3 RightTopCorner { get; private set; }
    public Vector3 RightBotCorner { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
