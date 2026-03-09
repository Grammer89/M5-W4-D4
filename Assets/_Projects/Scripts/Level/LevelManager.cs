using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager Instance { get; private set; }

    [SerializeField] GameObject _teleport;
    [SerializeField] GameObject _secretZone1;
    [SerializeField] GameObject _secretZone2;
    [SerializeField] GameObject _winUI;

    private int _numberButtonMax = 4;
    private int _numberButtonPressed;
    public bool _levelCompleted;
    private NavMeshSurface _naveMeshSurface;
    public int NumberButtonPressed
    {
        get { return _numberButtonPressed; }
        set { _numberButtonPressed += value; }
    }

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

        _winUI.SetActive(false);

    }

    private void Start()
    {
        StartCoroutine(CheckWin());
    }
    // Update is called once per frame
    void Update()
    {
        if (_numberButtonMax == _numberButtonPressed)
        {
            _teleport.SetActive(true);
        }
    }

    public void ActivateSecretZone(int numberDoor)
    {
        Debug.Log("Viene Attivata la mesh dinamica");
        if (numberDoor == 1)
        {
            _naveMeshSurface = _secretZone1.GetComponent<NavMeshSurface>();
        }
        else
        {
            _naveMeshSurface = _secretZone2.GetComponent<NavMeshSurface>();
        }
        if (_naveMeshSurface != null)
        {
            Debug.Log("Attivo la mesh dinamica");
            _naveMeshSurface.BuildNavMesh();
        }

    }

    public IEnumerator CheckWin()
    {
        WaitForSeconds wfs = new WaitForSeconds(10f);
        while (true)
        {
            yield return wfs;
            if(_levelCompleted)
            {
                Time.timeScale = 1;
                _winUI.SetActive(true);
            }
        }
      
    }
}



