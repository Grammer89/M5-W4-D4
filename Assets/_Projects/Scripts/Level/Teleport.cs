using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] GameObject _winUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            _winUI.SetActive(true);
        }
    }
}
