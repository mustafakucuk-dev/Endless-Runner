using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class TileManager : MonoBehaviour
{
    private Queue<GameObject> activeTiles = new Queue<GameObject>();
    private Transform playertr;

    public GameObject[] tilePrefabs;

    public GameObject emptyTile;
    private float startGenerateZ = 0;

    private float yoffset = 1;
    private float xoffset = 0;
    private float tileLength = 15.0f;
    private int numberofTiles = 7;
    private int tileCount = 0;

    private ArrayList prefabs = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        
        playertr = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < 2; i++){
            CreateTile();
        }
        for(int i = 0; i<5; i++){
            CreateTile(GetRandomIndex());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playertr.position.z > (tileCount - numberofTiles) * tileLength){
            DeleteTile();
            CreateTile(GetRandomIndex());
        }
    }

    private void CreateTile(int prefabIndex = 0){
        GameObject newtile = Instantiate(tilePrefabs[prefabIndex],new Vector3(xoffset,yoffset,startGenerateZ+tileLength*tileCount),Quaternion.identity);
        activeTiles.Enqueue(newtile);
        tileCount ++;
        
    }

    private void DeleteTile(){
        var toDelete = activeTiles.Dequeue();
        Destroy(toDelete);
        
    }
    private int GetRandomIndex(){
        return Random.Range(0,tilePrefabs.Length);
    }
    
}
