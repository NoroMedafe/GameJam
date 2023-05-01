using System.Collections.Generic;
using UnityEngine;

public class MissionArrowsManager : MonoBehaviour
{

    [SerializeField] private MissionIndicator _indicatorPrefab;
    private List<MissionIndicator> _indicators = new List<MissionIndicator>();

    public void AddMission(Vector2 outpostPosition)
    {
        MissionIndicator missionIndicator = Instantiate(_indicatorPrefab, transform);
        missionIndicator.SetTarget(outpostPosition);
    }
}
