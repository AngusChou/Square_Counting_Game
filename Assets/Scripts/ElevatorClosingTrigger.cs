using UnityEngine;

public class ElevatorClosingTrigger : MonoBehaviour
{

    public ElevatorController elevatorController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            elevatorController.PlayerExit();
        }
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
