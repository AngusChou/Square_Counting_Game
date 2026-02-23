using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ElevatorController : MonoBehaviour
{

    public Transform doorLeft;
    public Transform doorRight;

    public Vector3 leftOriginalPosition;
    public Vector3 rightOriginalPosition;

    public float doorOpenDistance = 1.2f;
    public float doorOpenSpeed = 2f;

    public bool opening = false;
    public bool closing = false;

    public void PlayerEntered()
    {
        opening = true;
        closing = false;
    }

    public void PlayerExit()
    {
        closing = true;
        opening = false;
    }

    public void SelectingScene(string sceneName)
    {
        Debug.Log("SelectingScene CALLED with: " + sceneName);
        StartCoroutine(LoadNextScene(sceneName));
    }

    IEnumerator LoadNextScene(string sceneName)
    {
        yield return new WaitForSeconds(2f);
        FadeController.Instance.FadeOut();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    public void OpeningDoor()
    {
        Debug.Log("OpeningDoor");
        Vector3 targetLeft = leftOriginalPosition + new Vector3(doorOpenDistance, 0, 0);
        Vector3 targetRight = rightOriginalPosition + new Vector3(-doorOpenDistance, 0, 0);

        doorLeft.position = Vector3.Lerp(doorLeft.position, targetLeft, Time.deltaTime * doorOpenSpeed);
        doorRight.position = Vector3.Lerp(doorRight.position, targetRight, Time.deltaTime * doorOpenSpeed);

        if (Vector3.Distance(doorLeft.position, targetLeft) < 0.01f)
        {
            opening = false;
        }

    }

    public void ClosingDoor()
    {
        Debug.Log("ClosingDoor");
        Vector3 a = doorLeft.position;
        Vector3 b = doorRight.position;
        doorLeft.position = Vector3.Lerp(a, leftOriginalPosition, Time.deltaTime * doorOpenSpeed);
        doorRight.position = Vector3.Lerp(b, rightOriginalPosition, Time.deltaTime * doorOpenSpeed);
        if (Vector3.Distance(doorLeft.position, leftOriginalPosition) < 0.01f)
        {
            closing = false;
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        leftOriginalPosition = doorLeft.position;
        rightOriginalPosition = doorRight.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            OpeningDoor();
        }
        if (closing)
        {
            ClosingDoor();
        }
    }
}
