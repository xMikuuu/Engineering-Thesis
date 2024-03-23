using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endingScreen : MonoBehaviour
{
    [SerializeField] private List<Sprite> endingscreenList;
    [SerializeField] public GameObject endingScreenObject;

    private Sprite endingscreen;
    private bool stop;
    private float stopValue;

    private void Start()
    {
        stop = true;
    }

    private void Update()
    {
        if (GameObjects.Instance.StateManager.currentState.aiHealth <= 0)
        {
            endingscreen = endingscreenList[0];
            stopValue = 1.3f;
        }
        if (GameObjects.Instance.StateManager.currentState.playerHealth <= 0)
        {
            endingscreen = endingscreenList[1];
            stopValue = 1f;
        }


        if (endingScreenObject.active)
        {
            endingScreenObject.GetComponent<SpriteRenderer>().sprite = endingscreen;
            if (stop)
            {
                endingScreenObject.transform.localScale += new Vector3(0.001f, 0.001f, 0);
            }
            if (endingScreenObject.transform.localScale.x >= stopValue)
            {
                stop = false;
                SceneManager.LoadScene("MainScene");
            }
        }
    }
}
