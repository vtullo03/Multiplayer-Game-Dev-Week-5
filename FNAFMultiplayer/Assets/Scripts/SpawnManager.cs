using UnityEngine;
using Unity.Netcode;

public class SpawnManager : NetworkBehaviour
{
    [SerializeField] private GameObject body;
    [SerializeField] private Camera cam;

    [SerializeField] private GameObject badSpawn;
    [SerializeField] private GameObject goodSpawn;
    private GameObject me;

    private void SpawnPlayerBodies()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            GameObject currentBody = Instantiate(body);
            currentBody.transform.position = new Vector3(0f, 0f, 0f);
            if (players[i].GetComponent<NetworkObject>().IsLocalPlayer)
            {
                Camera playerCam = Instantiate(cam);
                playerCam.transform.position = new Vector3(0f, 0f, 0f);
                playerCam.transform.SetParent(currentBody.transform);
            }
            currentBody.transform.SetParent(players[i].transform);
        }
    }

    private void FindMe()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].GetComponent<NetworkObject>().IsOwner) me = players[i];
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlayerBodies();
        FindMe();
        if (IsServer) me.transform.position = goodSpawn.transform.position;
        else me.transform.position = badSpawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
