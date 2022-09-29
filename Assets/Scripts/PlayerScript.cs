using UnityEngine;
using System.Collections;
using UnityEngine.AI;


public class PlayerScript : MonoBehaviour{

    private NavMeshAgent nav;
    [SerializeField] private PathScript path;
    [SerializeField] private Transform tr;
    [SerializeField] private Animator anim;
    [SerializeField] private GunScript gun;
    Coroutine coroutineMoveOnPath;
    void Awake()
    {
        tr  = base.transform; 
        nav = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        path.RegisterOnStageFinish(NextStage);
        tr.position = path.GetStartPoint.position;
    }

    public void StartGame()
    {
        NextStage();
        gun.enabled = true;
    }



    Transform targetPoint;
    private void MovingToNextStage(Transform targetPoint)
    {
        this.targetPoint = targetPoint;
        anim.SetBool("Speed", true);
        nav.SetDestination(targetPoint.position);
        StartCoroutine(WaitFinishMove());
    }
    IEnumerator WaitFinishMove()
    {
        while(Distance(tr.position, targetPoint.position) > 0.5f)
        {
            yield return new WaitForSeconds(0.1f); 
        }
        anim.SetBool("Speed", false);
    }
    private float Distance(Vector3 a, Vector3 b){ return (a - b).sqrMagnitude; }
    [ContextMenu("NextStage")]
    private void NextStage()
    {
        if(path.IsFinish == false)
        {
            MovingToNextStage(path.GetNextPoint());
        }else
        {
            GameUIScript.Instance.StartRestartLevel();
        }
    }

}