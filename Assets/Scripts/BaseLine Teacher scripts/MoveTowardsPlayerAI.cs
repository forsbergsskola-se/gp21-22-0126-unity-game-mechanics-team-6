using UnityEngine;

public class MoveTowardsPlayerAI : MonoBehaviour
{
    [SerializeField] private CommandContainer commandContainer;
    [SerializeField] private Transform playerTransform;

    private void Start()
    {
        //There are cases when it's fine to use these. But I generally prefer to hook up references through the inspector, as long as it's practical to do so.
        //If you need to use FindObjectWithType/FindWithTag/Find, try to do it in a centralised script that can the pass that reference along to other components/GameObjects.
        //Example: EnemySpawningScript finds a reference to the Player, and passes that along to the enemies when they are spawned.

        //Different ways of getting a reference to the player.
        // playerTransform = GameObject.FindWithTag("Player").transform; //Uses the "Player" tag.
        // playerTransform = GameObject.Find("Player").transform; //Looks for a GameObject with the name "Player".
        // playerTransform = ((PlayerIdentifierComponent)FindObjectOfType(typeof(PlayerIdentifierComponent))).transform; //Looks for a component of type PlayerIdentifierComponent.
        // playerTransform = FindObjectOfType<PlayerInputController>().transform; //Looks for a component of type PlayerIdentifierComponent. This time using generics.
    }

    private void Update()
    {
        var directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.Normalize();
        var horizontalDirectionToPlayer = directionToPlayer.x;
        // var horizontalDirectionToPlayer = Mathf.Sign(directionToPlayer.x); //This will always keep our enemy at max speed.

        commandContainer.walkCommand = horizontalDirectionToPlayer;
    }
}