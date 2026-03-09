using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private UnityEvent[] _eventDoor;
    [SerializeField] private GameObject[] _secretZone;
    [SerializeField] private GameObject  _level;
    [SerializeField] private int _numberOfSecretZone;
    [SerializeField] private GameObject _canvasObject;
    private bool _isOnTrigger;
    private bool _isAtivated;

  
    void Awake()
    {
        _anim = GetComponentInChildren<Animator>();

        _canvasObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (_isOnTrigger && Input.GetKeyDown(KeyCode.E))
        {
            if (!_isAtivated)
            {
                _isAtivated = true;
                PushButton();
                SecretZone();
                LevelManager.Instance.NumberButtonPressed = 1;
                LevelManager.Instance.ActivateSecretZone(_numberOfSecretZone);
            }

        }

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            _canvasObject.SetActive(true);
            Debug.Log("è entrato nell'area di competenza");
            _isOnTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            _canvasObject.SetActive(false);
            _isOnTrigger = false;
        }
    }
    public void PushButton()
    {
        _anim.SetTrigger("Pressed");
    }

    public void SecretZone()
    {
        for (int i = 0; i < _secretZone.Length; i++)
        {
            _secretZone[i].SetActive(true);
        }
        for (int i = 0; i < _eventDoor.Length; i++)
        {
            _eventDoor[i]?.Invoke();
        }
    }
}
