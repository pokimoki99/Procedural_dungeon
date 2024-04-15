using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomItemCreation : MonoBehaviour
{
    public GameObject background, wall_Painting, bench, table, collectable, bookshelf, torch, door, crate;//prefabs for item generation

    public GameObject[] Walls, smallObjects, LargeObjects, DoorLoc;//location for objects

    public DungeonGeneration DungeonGenerationObject;
    public GameObject parentCanvas;
    public GameObject InputFieldDecor, InputFieldDecorNum, Title, Title2;
    public TMP_InputField textDec,textNum;

    List<GameObject> prefabs;

    float randomY = 0f;

    // Start is called before the first frame update
    int randomNum = 0;
    int Decorations = 0;

    void Start()
    {
        DungeonGenerationObject = GameObject.FindGameObjectWithTag("Player").GetComponent<DungeonGeneration>();
        parentCanvas = GameObject.FindGameObjectWithTag("Canvas");
        prefabs = new List<GameObject>();
        prefabs.Add(Instantiate(InputFieldDecor));
        prefabs.Add(Instantiate(Title));
        prefabs.Add(Instantiate(Title2));
        foreach (var item in prefabs)
        {
            item.transform.SetParent(parentCanvas.transform);
            item.SetActive(true);
        }
        //randomNum = Random.Range(0, 9);
        //createObjects(randomNum);
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
            background.GetComponent<Renderer>().material.color = Color.black;
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


    public void StringInput()
    {
        Decorations = int.Parse(prefabs[2].GetComponent<TMP_InputField>().text.Trim());
        createObjects(Decorations);
        Destroy(prefabs[2]);
        prefabs.RemoveAt(2);
    }
    public void DecorationNum()
    {
        randomNum = int.Parse(prefabs[0].GetComponent<TMP_InputField>().text.Trim());
        for (int i = 0; i < randomNum; i++)
        {
            Vector3 newPos = new Vector3(InputFieldDecorNum.transform.position.x, InputFieldDecorNum.transform.position.y + randomY, InputFieldDecorNum.transform.position.z);
            prefabs.Add(Instantiate(InputFieldDecorNum, newPos, InputFieldDecorNum.transform.rotation));
            randomY += -50;
        }
        foreach (var item in prefabs)
        {
            item.transform.SetParent(parentCanvas.transform);
            item.SetActive(true);
        }
        Destroy(prefabs[0]);
        prefabs.RemoveAt(0);
    }
}
