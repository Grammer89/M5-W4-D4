using UnityEngine;

public class PlayerHandlerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
    }
    public void SetIdle()
    {
        _anim.SetBool("Run", false);
    }

    public void SetRun()
    {
        _anim.SetBool("Run", true);
    }

}
