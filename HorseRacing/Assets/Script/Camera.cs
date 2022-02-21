using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    //  카메라가 1등에게  따라 붙게 한다.
    //  필요한 것
    // 1. 카메라 자체의 Transform 컴포넌트
    // 2. 경주말들의 Transform 컴포넌트

    // 어떤것을 해야하나?
    // 경주말들의 등수를 실시간으로 체크한다.
    // 1등말의 위치를 가져온다.
    // 카메라의 위치를 1등말의 위치에다가 특정 거리만큼 떨어뜨린다.
    Transform tr;
    Transform target;
    int targetIndex;
    public Vector3 offset;
    private void Start()
    {
        tr = this.gameObject.GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetKeyDown("tab"))
            SwitchNextTarget();

        if (target == null)
            SwitchNextTarget();
        else
            tr.position = target.position + offset;
    }
    // 다음 플레이어로 타겟을 변경하는 기능
    public void SwitchNextTarget()
    {
        targetIndex++;
        if (targetIndex > RacingPlay.instance.GetTotalPlayerNumber() - 1)
            targetIndex = 0;
        target = RacingPlay.instance.GetPlayer(targetIndex);
    }

    public void SwitchTargetTo1Grade()
    {
        target = RacingPlay.instance.Get1GradePlayer();
    }

}
