using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outpost : MonoBehaviour
{
    [SerializeField] private float _health;
    private float _lifeTime;
    private float _currentLifetime;
    private bool _isrequest = false;
    private void Start()
    {
        _lifeTime = Random.Range(20, 80);
    }
    private void Update()
    {
        _currentLifetime += Time.deltaTime;
        if (_lifeTime<=0)
        {
            if (!_isrequest)
            {
                ResourceRequest();
            }

            _health -= Time.deltaTime;

            if (_health<=0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void ReplenishmentResources()
    {
        _lifeTime = Random.Range(20, 80);
        _isrequest = false;

    }
    public void ResourceRequest()
    {
        _isrequest = true;
    }
}
