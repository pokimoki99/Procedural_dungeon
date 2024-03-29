using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGeneration : MonoBehaviour
{
    public GameObject[] dungeonRooms;
    public float distanceBetweenPrefabs = 5f;
    public int roomNum;

    public Vector2 minRoomSize = new Vector2(1, 1);
    public Vector2 maxRoomSize = new Vector2(5, 5);

    private List<GameObject> rooms = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        DungeonInfo(roomNum);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DungeonInfo(int numRoom)
    {

        int randomNumRooms = Random.Range(0, dungeonRooms.Length);

        for (int i = 0; i < numRoom; i++)
        {
            Vector2 roomSize = new Vector2(Random.Range((int)minRoomSize.x, (int)maxRoomSize.x),
                                            Random.Range((int)minRoomSize.y, (int)maxRoomSize.y));
            Vector3 roomPos = Vector3.zero;

            if (i > 0)
            {
                Vector3 previousRoomSize = rooms[i - 1].transform.localScale;

                if (i == 1)
                {
                    roomPos = rooms[i - 1].transform.position +
                               new Vector3(previousRoomSize.x / 2f + roomSize.x / 2f + distanceBetweenPrefabs, 0f, 0f);
                }
                else
                {
                    Vector3 secondLastRoomSize = rooms[i - 2].transform.localScale;
                    roomPos = rooms[i - 1].transform.position +
                               new Vector3(previousRoomSize.x / 2f + roomSize.x / 2f + distanceBetweenPrefabs, 0f, 0f);
                    if (roomOverlap2(roomPos, roomSize, rooms[i-2].transform.position, secondLastRoomSize))
                    {
                        roomPos = rooms[i - 2].transform.position +
                                   new Vector3(secondLastRoomSize.x / 2f + roomSize.x / 2f + distanceBetweenPrefabs, 0f, 0f);
                    }
                }
                
            }
            while (roomOverlap(roomPos, roomSize))
            {
                roomPos += new Vector3(roomSize.x + distanceBetweenPrefabs, 0f, 0f);
            }
            GameObject room = Instantiate(dungeonRooms[randomNumRooms],
                            Vector3.zero, Quaternion.identity);
            room.transform.localScale = new Vector3(roomSize.x, 1f, roomSize.y);


            room.transform.position = roomPos;

            rooms.Add(room);
        }

        bool roomOverlap (Vector3 proposedPosition, Vector2 roomSize)
        {
            foreach (GameObject existingRoom in rooms)
            {
                Vector3 existingRoomPos = existingRoom.transform.position;
                Vector3 minCorner = existingRoomPos - existingRoom.transform.localScale / 2f;
                Vector3 maxCorner = existingRoomPos + existingRoom.transform.localScale / 2f;
                Vector3 proposedMinCorner = proposedPosition - new Vector3(roomSize.x / 2f, 0f, roomSize.y / 2f);
                Vector3 proposedMaxCorner = proposedPosition + new Vector3(roomSize.x / 2f, 0f, roomSize.y / 2f);

                if (proposedMaxCorner.x > minCorner.x && proposedMinCorner.x < maxCorner.x
                    && proposedMaxCorner.z > minCorner.z && proposedMinCorner.z < maxCorner.z)
                {
                    return true;
                }
            }
            return false;
        }
        bool roomOverlap2 (Vector3 proposedPosition, Vector2 roomSize, Vector3 secondLastRoomPosition, Vector3 secondLastRoomSize)
        {
            foreach (GameObject existingRoom in rooms)
            {
                Vector3 minCorner = secondLastRoomPosition - secondLastRoomSize / 2f;
                Vector3 maxCorner = secondLastRoomPosition + secondLastRoomSize / 2f;
                Vector3 proposedMinCorner = proposedPosition - new Vector3(roomSize.x / 2f, 0f, roomSize.y / 2f);
                Vector3 proposedMaxCorner = proposedPosition + new Vector3(roomSize.x / 2f, 0f, roomSize.y / 2f);

                if (proposedMaxCorner.x > minCorner.x && proposedMinCorner.x < maxCorner.x
                    && proposedMaxCorner.z > minCorner.z && proposedMinCorner.z < maxCorner.z)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
