using UnityEngine;

public class PlayerPause : MonoBehaviour
{
    public GameControl gc;
    public GameObject menu;

    PlayerMovement pm;
    PlayerKill pk;
    PlayerLook pl;
    PlayerInteract pi;

    bool isPaused;
    AudioSource asrc;

    void Awake()
    {
        pm = GetComponent<PlayerMovement>();
        pk = GetComponent<PlayerKill>();
        pl = GetComponent<PlayerLook>();
        pi = GetComponent<PlayerInteract>();

        asrc = GetComponent<AudioSource>();
    }

    void Start()
    {
        gc.EnableCursor(false);
    }

    void Update()
    {
        if (!isPaused)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                isPaused = true;

                FreezePlayer(true);
                SetTime(0f);                

                gc.EnableCursor(true);
                menu.SetActive(true);

                asrc.Pause();
            }
        }
        else
        {
            if (Input.GetButtonDown("Cancel") && menu.transform.Find("Main").gameObject.activeSelf)
            {
                isPaused = false;

                FreezePlayer(false);
                SetTime(1f);

                gc.EnableCursor(false);
                menu.SetActive(false);

                asrc.UnPause();
            }
        }
    }

    public void FreezePlayer(bool isFrozen)
    {
        pm.enabled = !isFrozen;
        pk.enabled = !isFrozen;
        pl.enabled = !isFrozen;
        pi.enabled = !isFrozen;
    }

    public void SetTime(float scale)
    {
        Time.timeScale = scale;
    }
}
