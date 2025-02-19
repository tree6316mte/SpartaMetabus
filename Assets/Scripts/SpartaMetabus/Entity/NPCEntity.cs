
using TMPro;
using UnityEngine;

public class NPCEntity : MonoBehaviour
{
    public AreaEventHandler areaEventHandler;
    public GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        areaEventHandler.Init(ShowText, HideText);
    }

    void ShowText()
    {
        text.SetActive(true);
    }
    void HideText()
    {
        text.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
