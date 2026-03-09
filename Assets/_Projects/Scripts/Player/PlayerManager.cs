using UnityEngine;

public  class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance {  get; private set; }
    [SerializeField] GameObject _positionPlayer;
    [SerializeField] GameObject _pointToRespawn;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void RespawnPlayaer()
    {
        Debug.Log("Teletrasportiamo il player");

        _positionPlayer.transform.position = _pointToRespawn.transform.position;
    }

}
