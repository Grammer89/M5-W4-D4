using UnityEngine;

public class SimpleButton : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] private GameObject _level;
    [SerializeField] private GameObject _canvasObject;

    private bool _isOnTrigger;
    private bool _isActive;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _canvasObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (_isOnTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!_isActive)
            {
                PushButton();
                _isActive = true;
                LevelManager.Instance.NumberButtonPressed = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("è entrato nell'area di competenza");
            _isOnTrigger = true;
            _canvasObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            _isOnTrigger = false;
            _canvasObject.SetActive(false);
        }
    }
    public void PushButton()
    {
        _audioSource.Play();
    }
}
