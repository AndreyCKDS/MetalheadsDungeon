using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private string OpenningDirection;
    private RoomTemplates templates;
    private int rand;
    private bool Spawned = false;

    private void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    private void Spawn()
    {
        if (Spawned == false)
        {
            if (OpenningDirection == "R")
            {
                rand = RandomRoom();
                Instantiate(templates.RightRooms[rand], transform.position, templates.RightRooms[rand].transform.rotation, templates.transform);
            }
            else if (OpenningDirection == "B")
            {
                rand = RandomRoom();
                Instantiate(templates.BottomRooms[rand], transform.position, templates.BottomRooms[rand].transform.rotation, templates.transform);
            }
            else if (OpenningDirection == "L")
            {
                rand = RandomRoom();
                Instantiate(templates.LeftRooms[rand], transform.position, templates.LeftRooms[rand].transform.rotation, templates.transform);
            }
            else if (OpenningDirection == "T")
            {
                rand = RandomRoom();
                Instantiate(templates.TopRooms[rand], transform.position, templates.TopRooms[rand].transform.rotation, templates.transform);
            }
            Spawned = true;
        }
    }

    private int RandomRoom()

    {;
        int i;
        int sum = 0;
        int[] Decrement = { 1, 1, 1, 1, -1, -1, -1, -1 };
        for (i = 0; i < Globals.RoomsV.Length; i++)
            sum += Globals.RoomsV[i];
        int r = Random.Range(0, sum);
        for (i = 0; i < Globals.RoomsV.Length; i++)
        {
            r -= Globals.RoomsV[i];
            if (r < 0)
                break;
        }
        int[] result = new int[8];
        for (int index = 0; index < 8; index++)
            result[index] = Globals.RoomsV[index] + Decrement[index];
        Globals.RoomsV = result;
        return i;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}
