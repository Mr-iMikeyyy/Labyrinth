using UnityEngine;

public class MinotaurAI : MonoBehaviour {
    public float minotaurSpeed = 5.5f;

    // TODO: Need to create methods, variables, and classes to handle any logic that would relate to the Minotaur programmed behaviour
    // Not sure on the best approach yet.

    private void Update() {
        if (IsPlayerInSight()) {
            ChasePlayer();
        }
    }

    private void ChasePlayer() {
        // The Minotaur should be slightly faster than the player
    }

    // Return true if the player is in sight, false otherwise
    private bool IsPlayerInSight() {
        // raycasting?

        return true;
    }
}
