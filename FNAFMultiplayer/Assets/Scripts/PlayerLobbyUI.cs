using UnityEngine;

public class PlayerLobbyUI : MonoBehaviour
{
    private GameObject[] startingUIElements;
    private GameObject[] lobbyUIElements;
    private GameObject canvas;

    void SwitchOutUI()
    {
        int index = 0;
        for (int i = 0; i < 2; ++i)
        {
            canvas.transform.GetChild(i).gameObject.SetActive(false);
            index = i;
        }
        canvas.transform.GetChild(index + 1).gameObject.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        SwitchOutUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas != null) 
        {
            if (Input.GetKey(KeyCode.Tab))
            {
                canvas.transform.GetChild(3).gameObject.SetActive(true);
            }
            else canvas.transform.GetChild(3).gameObject.SetActive(false);
        }
    }
}
