using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorPanel : Interactable
{
    public ElevatorController elevatorController;
    public string sceneToLoad = "Floor 1";
    public override void Interact()
    {
        Debug.Log("ElevatorPanel.Interact() CALLED");
        elevatorController.SelectingScene(sceneToLoad);
    }
}
