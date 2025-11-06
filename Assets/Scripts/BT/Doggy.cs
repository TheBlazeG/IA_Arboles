using UnityEngine;
using UnityEngine.AI;
namespace BehaviourTrees 
{ 
public class Doggy : MonoBehaviour
{
    BehaviourTree doggy;
    [SerializeField] GameObject player;
    [SerializeField] GameObject home;
        public NavMeshAgent agent;
        float doggyPatience = 10;
    private void Awake()
    {
            doggy = new BehaviourTree("Doggy :D");
            agent = GetComponent<NavMeshAgent>();

            var foo = new Condition(() => checkDistance());
             Leaf isPlayerClose= new Leaf("isPlayerClose", foo);
             Leaf followPlayer= new Leaf("followPlayer", new ActionStrategy(()=>agent.SetDestination(player.transform.position)));

            Sequence checkForPlayer = new Sequence("checkForPlayer");
            checkForPlayer.SetstoXD(isPlayerClose);
            checkForPlayer.SetstoXD(followPlayer);

            Selector baseSelector = new Selector("Base Selector");

            ReturnHome returnHome = new ReturnHome(gameObject.transform, player.transform, agent, doggyPatience, home.transform);
            Leaf wasIAbandoned = new Leaf("wasIAbandoned", returnHome);

            baseSelector.SetstoXD(checkForPlayer);
            baseSelector.SetstoXD(wasIAbandoned);

            doggy.SetstoXD(baseSelector);


        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool checkDistance()
    {
            Debug.Log("CheckingDistance");
            if (Vector3.Distance(gameObject.transform.position, player.transform.position)<2)
            {
                Debug.Log("ownerClose");
            } 
            return Vector3.Distance(gameObject.transform.position, player.transform.position) < 2;
    }


    // Update is called once per frame
    void Update()
    {

            Debug.Log(doggy.Process());
    }
}
}

