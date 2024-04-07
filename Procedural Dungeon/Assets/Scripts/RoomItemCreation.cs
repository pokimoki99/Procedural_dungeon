using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomItemCreation : MonoBehaviour
{
    public GameObject background, wall_Painting, bench, table, collectable, bookshelf, torch, door, crate;//prefabs for item generation

    public GameObject[] Walls, smallObjects, LargeObjects, DoorLoc;//location for objects

    // Start is called before the first frame update
    int randomNum = 0;

    void Start()
    {
        randomNum = Random.Range(0, 9);
        createObjects(randomNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
//background, wall_Painting, bench, table, collectable, bookshelf, torch, door, crate
    public void createObjects(int objectsNum)
    {
        if (objectsNum == 0)
        {
            Instantiate(background, Walls[Random.Range(0, Walls.Length)].transform.position, Walls[Random.Range(0, Walls.Length)].transform.rotation);
        }
        else if (objectsNum == 1)
        {
            Instantiate(wall_Painting, Walls[Random.Range(0, Walls.Length)].transform.position, Walls[Random.Range(0, Walls.Length)].transform.rotation);
        }
        else if (objectsNum == 2)
        {
            Instantiate(bench, LargeObjects[Random.Range(0, LargeObjects.Length)].transform.position, LargeObjects[Random.Range(0, LargeObjects.Length)].transform.rotation);
        }
        else if (objectsNum == 3)
        {
            Instantiate(table, LargeObjects[Random.Range(0, LargeObjects.Length)].transform.position, LargeObjects[Random.Range(0, LargeObjects.Length)].transform.rotation);
        }
        else if (objectsNum == 4)
        {
            Instantiate(bookshelf, LargeObjects[Random.Range(0, LargeObjects.Length)].transform.position, LargeObjects[Random.Range(0, LargeObjects.Length)].transform.rotation);
        }
        else if (objectsNum == 5)
        {
            Instantiate(collectable, smallObjects[Random.Range(0, smallObjects.Length)].transform.position, smallObjects[Random.Range(0, smallObjects.Length)].transform.rotation);
        }
        else if (objectsNum == 6)
        {
            Instantiate(torch, smallObjects[Random.Range(0, smallObjects.Length)].transform.position, smallObjects[Random.Range(0, smallObjects.Length)].transform.rotation);
        }
        else if (objectsNum == 7)
        {
            Instantiate(crate, smallObjects[Random.Range(0, smallObjects.Length)].transform.position, smallObjects[Random.Range(0, smallObjects.Length)].transform.rotation);
        }
        else if (objectsNum == 8)
        {
            foreach (var item in DoorLoc)
            {
                Instantiate(door, item.transform.position, door.transform.rotation);
            }
        }
    }
}
