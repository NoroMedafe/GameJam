using System.Collections.Generic;
using UnityEngine;

public class Outpost : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private float _health;
    [SerializeField] private List<ResourceData> _resources;
    [SerializeField] private QuestionsManager _questionsManager;


    private float _lifeTime;
    private float _currentLifetime;
    private bool _isrequest = false;
    private int _idResources;

    private void Start()
    {       
        _lifeTime = Random.Range(30, 120);
        _currentLifetime = _lifeTime;
    }

    private void Update()
    {
        _currentLifetime -= Time.deltaTime;

        if (_currentLifetime<= 20)
        {
            if (!_isrequest)
            {
                ResourceRequest();
            }

            if (_currentLifetime <= 0)
            {
                _health -= Time.deltaTime;

                if (_health <= 0)
                {
                    Destroy(gameObject);
                    Debug.Log($"OUTPOST {_id} IS DESTROYYYYYED!");
                }
            }
        }
    }

    public void ReplenishmentResources(int idResource)
    {
        Debug.Log(idResource + " = " + _idResources);
        if (idResource == _idResources)
        {
            _lifeTime = Random.Range(20, 80);
            _currentLifetime = _lifeTime;
            _isrequest = false;

            _questionsManager.ComptiteQuestion(_id, _resources[_idResources].Name);


            Debug.Log("YAY!");
        }
        else
        {
            Debug.Log("�� �� �������");
        }
    }

    public void ResourceRequest()
    {
        _isrequest = true;
        RandomizeResources();
        Debug.Log("��� ����� " + _resources[_idResources].Name);

        _questionsManager.CreateQuestion(_id, _resources[_idResources].Name, _resources[_idResources].Icon, transform.position);
    }

    private void RandomizeResources()
    {
        _idResources = Random.Range(0, _resources.Count);
        
    }
}
