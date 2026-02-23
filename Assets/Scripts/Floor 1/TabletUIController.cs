using UnityEngine;

public class TabletUIController : MonoBehaviour
{
    public GameObject tabletUI;
    public bool hasTablet = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasTablet)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            tabletUI.SetActive(!tabletUI.activeSelf);
        }
    }

    public void GiveTablet()
    {
        hasTablet = true;
    }
}
