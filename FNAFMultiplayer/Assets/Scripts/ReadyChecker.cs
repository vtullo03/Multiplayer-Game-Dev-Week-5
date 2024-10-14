using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyChecker : NetworkBehaviour
{
    [SerializeField] private GameObject readyButton;
    [SerializeField] private GameObject startButton;
    private GameObject buttonMade;

    public bool StartAvailable { get; set; }
    public NetworkVariable<bool> IsReady = new NetworkVariable<bool>();

    private bool readySpawned = false;
    private bool startSpawned = false;
    private bool readyDeleted = false;

    private void SwitchToGame()
    {
        NetworkManager.SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

    [ServerRpc]
    public void SetReadyServerRpc()
    {
        IsReady.Value = true;
        Destroy(buttonMade);
        readyDeleted = true;
    }

    private bool SpawnButton(GameObject button, bool spawnChecker)
    {
        if (!spawnChecker)
        {
            buttonMade = Instantiate(button);
            GameObject canvas = GameObject.Find("Canvas");
            buttonMade.transform.SetParent(canvas.transform);
            buttonMade.transform.localScale = new Vector3(1f, 1f, 1f);
            buttonMade.transform.localPosition = new Vector3(293f, -191f, 0f);
        }
        return true;
    }

    void Update()
    {
        readySpawned = SpawnButton(readyButton, readySpawned);
        if (!readyDeleted) buttonMade.GetComponent<Button>().onClick.AddListener(SetReadyServerRpc);

        if (IsServer && StartAvailable)
        {
            startSpawned = SpawnButton(startButton, startSpawned);
            buttonMade.GetComponent<Button>().onClick.AddListener(SwitchToGame);
        }

        // LOOK AT THIS LATER
        if (SceneManager.GetActiveScene().name == "Game") this.enabled = false;
    }
}
