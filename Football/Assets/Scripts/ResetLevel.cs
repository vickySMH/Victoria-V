using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    public BallController ball;

    public List<GameObject> playerList = new List<GameObject>();
    public List<Vector3> playerPositionsList = new List<Vector3>();

    public PlaySoundEffect refereeWhistleSfx;
    public PlaySoundEffect cheerSfx;

    public void ResetFail()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            Player player = playerList[i].GetComponent<Player>();
            player.enabled = false;
            player.gameObject.transform.position = playerPositionsList[i];
            StartCoroutine(ReenablePlayerCoroutine(player, 0.5f));
        }

        ball.ResetTorqueAndVelocity();
        ball.transform.position = new Vector3(0, 0.5f, 0);

        refereeWhistleSfx.PlaySound();
    }

    public void ResetGoal()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            Player player = playerList[i].GetComponent<Player>();
            player.enabled = false;
            player.gameObject.transform.position = playerPositionsList[i];
            StartCoroutine(ReenablePlayerCoroutine(player, 0.5f));
        }

        ball.ResetTorqueAndVelocity();
        ball.transform.position = new Vector3(0, 0.5f, 0);

        cheerSfx.PlaySound();
    }

    private IEnumerator ReenablePlayerCoroutine(Player player, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Reenable the player
        ReenablePlayer(player);
    }

    private void ReenablePlayer(Player player)
    {
        player.enabled = true;
    }
}
