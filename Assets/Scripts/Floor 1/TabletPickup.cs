using UnityEngine;

public class TabletPickup : Interactable
{

    public GameObject tabletWorldModel;
    public GameObject tabletUI;
    public PlayerInputReader inputReader;

    private bool pickedUp = false;

    public override void Interact()
    {
        if (pickedUp)
        {
            return;
        }

        pickedUp = true;
        tabletWorldModel.SetActive(false);
        tabletUI.SetActive(true);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
