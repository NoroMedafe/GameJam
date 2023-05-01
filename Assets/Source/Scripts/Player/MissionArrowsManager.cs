using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MissionArrowsManager : MonoBehaviour
{
    [SerializeField] private MissionIndicator _indicatorPrefab;
    private List<MissionIndicator> _indicators = new List<MissionIndicator>();


    public void AddMission(Vector2 outpostPosition, Sprite resourceIcon, int id)
    {
        MissionIndicator missionIndicator = Instantiate(_indicatorPrefab, transform);
        missionIndicator.SetTarget(outpostPosition);
        missionIndicator.SetResource(resourceIcon);
        missionIndicator.Id = id;
        _indicators.Add(missionIndicator);
    }

    public void RemoveMission(int id)
    {
        int listId = -1;
        int i = 0;
        foreach (MissionIndicator indicator in _indicators)
        {
            if (indicator.Id == id)
            {
                listId = i;
                break;
            }
            i++;
        }

        if (listId != -1)
        {
            Destroy(_indicators[listId]);
            _indicators.RemoveAt(listId);
        }
    }
}