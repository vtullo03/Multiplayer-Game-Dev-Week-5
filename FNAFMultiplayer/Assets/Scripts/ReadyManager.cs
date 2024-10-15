using UnityEngine;
using Unity.Netcode;

public class ReadyManager : MonoBehaviour
{
    GameObject[] players;
    int playerCount;

    bool CheckIfAllReady()
    {
        // CHANGE THIS LATER
        if (playerCount >= 1)
        {
            for (int i = 0; i < playerCount; i++)
            {
                if (players[i].GetComponent<ReadyChecker>().IsReady.Value == false) return false;
            }
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        playerCount = players.Length;
        if (CheckIfAllReady())
        {
            for (int i = 0; i < playerCount; i++)
            {
                if (players[i].GetComponent<NetworkObject>().IsOwner) players[i].GetComponent<ReadyChecker>().StartAvailable = true;
            }
        }
    }
}
