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

    
    
    public GameObject collectible;
    private Queue<List<GameObject>> activeCollectibles = new Queue<List<GameObject>>();
    private float startGenerateZ = 0;

    public GameObject seaPlane;
    private Queue<GameObject> activePlanes = new Queue<GameObject>();
    private int planeCount = 0;
    private float planeLength = 50.0f;

    private float yoffset = 1;
    private float xoffset = 0;
    private float tileLength = 15.0f;
    private int numberofTiles = 7;
    private int tileCount = 0;
    private float playerOffset = 3.0f;


    private ArrayList prefabs = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        
        playertr = GameObject.FindGameObjectWithTag("Player").transform;

        CreatePlane();
        
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
        if(playertr.position.z > (tileCount - numberofTiles) * tileLength+playerOffset){
            //Debug.Log(playertr.position.z);
            //Debug.Log(playerOffset);
            DeleteTile();
            CreateTile(GetRandomIndex());
        }

        if(playertr.position.z > planeCount * planeLength + playerOffset){
            DeletePlane();
            CreatePlane();
        }
    }

    private void CreateTile(int prefabIndex = 0){
        GameObject newtile = Instantiate(tilePrefabs[prefabIndex],new Vector3(xoffset,yoffset,startGenerateZ+tileLength*tileCount),Quaternion.identity);
        activeTiles.Enqueue(newtile);
        tileCount ++;
        GenerateCollectible();  
    }

    private void DeleteTile(){
        var toDeleteTile = activeTiles.Dequeue();
        Destroy(toDeleteTile);
        DeleteCollectible();
    }

    private int GetRandomIndex(){
        return Random.Range(0,tilePrefabs.Length);
    }

    private void GenerateCollectible(){
        List<GameObject> cols = new List<GameObject>();
        var location = Vector3.zero;
        int rand = Random.Range(0,6);
        location.y = 2f;
        if(rand<3){
            if(rand == 0){
                location.x = -1;
            }else if(rand == 1){
                location.x = 0;
            }else{
                location.x = 1;
            }
            location.z = startGenerateZ+tileLength*tileCount -34;
            GameObject newCollectible = Instantiate(collectible,location,Quaternion.identity);
            cols.Add(newCollectible);
        }
        rand = Random.Range(0,6);
        
        if(rand<3){
            if(rand == 0){
                location.x = -1;
            }else if(rand == 1){
                location.x = 0;
            }else{
                location.x = 1;
            }
            location.z = startGenerateZ+tileLength*tileCount -26;
            GameObject newCollectible = Instantiate(collectible,location,Quaternion.identity);
            cols.Add(newCollectible);
        }
        activeCollectibles.Enqueue(cols);
    }
    private void DeleteCollectible(){
        List<GameObject> dellist = activeCollectibles.Dequeue();
        foreach (var col in dellist)
        {
            Destroy(col);
        }
        
    }

    private void CreatePlane(){
        GameObject newplane = Instantiate(seaPlane,new Vector3(xoffset,0,startGenerateZ+planeLength*planeCount),Quaternion.identity);
        activePlanes.Enqueue(newplane);
        planeCount++;
    }

    private void DeletePlane(){
        var toDeletePlane = activePlanes.Dequeue();
        Destroy(toDeletePlane);
    }
}