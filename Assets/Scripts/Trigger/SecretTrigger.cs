using UnityEngine;

public class SecretTrigger : MonoBehaviour
{
    public int index;

    public GameControl gc;
    public GameObject particle;

    void Start()
    {
        gameObject.SetActive(GameControl.data.secrets[index]);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameControl.data.secrets[index] = false;
            gc.SaveGame();

            gameObject.SetActive(GameControl.data.secrets[index]);
            Instantiate(particle, transform.position, transform.rotation);
        }
    }
}
