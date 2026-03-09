using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void OpenDoor()
    {
        _anim.SetTrigger("Open");
    }
}
