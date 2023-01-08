using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthbarController : MonoBehaviour
{
    [SerializeField] private Transform hpBar;
    [SerializeField] private Transform noHPBarTransform;

    private float noHPBarX;
    void Awake()
    {
        noHPBarX = noHPBarTransform.localPosition.x;
    }

    /// <summary>
    /// Sets the HP bar visual based on the passed in percent (value between 0 and 1)
    /// </summary>
    /// <param name="_percent"></param>
    public void SetHPPercentage(float _percent)
    {
        float newBarXPos = Utils.RemapPercent(_percent, noHPBarX, 0);
        hpBar.localPosition = new Vector3(newBarXPos, 0, 0);
    }



    private float startTime;





    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        SetHPPercentage(((Time.time - startTime) / 5) % 1);
    }
}
