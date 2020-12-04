using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	// general
	public int m_NumRoundsToWin = 5;            // The number of rounds a single player has to win to win the game.
	public Text m_MessageText;                  // Reference to the overlay Text to display winning text, etc.

	// game refrences
	public CameraControl m_CameraControl;       // Reference to the CameraControl script for control during different phases.

	// scene timing
	private float m_StartDelay = 0.5f;             // The delay between the start of RoundStarting and RoundPlaying phases.
	private float m_EndDelay = 0.5f;               // The delay between the end of RoundPlaying and RoundEnding phases.	
	private WaitForSeconds m_StartWait;         // Used to have a delay whilst the round starts.
	private WaitForSeconds m_EndWait;           // Used to have a delay whilst the round or game ends.

	// ai/ml
	public TankThinker m_TankPrefab;             // Reference to the prefab the players will control.
	private List<GameObject> m_Tanks = new List<GameObject>(); 
/*
	private void Start()
	{
		// Create the delays so they only have to be made once.
		m_StartWait = new WaitForSeconds (m_StartDelay);
		m_EndWait = new WaitForSeconds (m_EndDelay);

		SpawnAllTanks(); // Spawn tanks and corresponding scripts
		SetCameraTargets();

		// Once the tanks have been created and the camera is using them as targets, start the game.
		StartCoroutine (GameLoop ());
	}
*/
	public void StartSimulation(){
		//StartCoroutine (GameLoop ());
	}

	public void SetCameraTargets(TankFlock[] tankFlocks, int[] flockSize)
	{
		int tankCounts = flockSize[0] + flockSize[1];

		// Create a collection of transforms the same size as the number of tanks.
		m_CameraControl.m_Targets = new Transform[tankCounts];

		int counter = 0;
		for (int i = 0; i < flockSize[0]; i++)
		{
			// ... set it to the appropriate tank transform.
			m_CameraControl.m_Targets[counter] = tankFlocks[0].getTank(i).transform;
			counter += 1;
		}

		for (int i = 0; i < flockSize[1]; i++)
		{
			// ... set it to the appropriate tank transform.
			m_CameraControl.m_Targets[counter] = tankFlocks[1].getTank(i).transform;
			counter += 1;
		}
	}

	// This is called from start and will run each phase of the game one after another.
	private IEnumerator GameLoop ()
	{
		GameSettings.Instance.OnBeginRound();

		print("a");
		// Start off by running the 'RoundStarting' coroutine but don't return until it's finished.
		yield return StartCoroutine (RoundStarting ());

		print("b");
		// Once the 'RoundStarting' coroutine is finished, run the 'RoundPlaying' coroutine but don't return until it's finished.
		yield return StartCoroutine (RoundPlaying());

		print("c");
		// Once execution has returned here, run the 'RoundEnding' coroutine, again don't return until it's finished.
		yield return StartCoroutine (RoundEnding());

		/*
		// This code is not run until 'RoundEnding' has finished.  At which point, check if a game winner has been found.
		if (GameSettings.Instance.ShouldFinishGame())
		{
			SceneManager.LoadScene (2);
		}
		else
		{
			SceneManager.LoadScene(1, LoadSceneMode.Single);
		}
		*/
	}


	private IEnumerator RoundStarting ()
	{
		// As soon as the round starts reset the tanks and make sure they can't move.
		DisableTankControl ();

		// Snap the camera's zoom and position to something appropriate for the reset tanks.
		m_CameraControl.SetStartPositionAndSize ();

		// Increment the round number and display text showing the players what round it is.
		m_MessageText.text = "ROUND " + GameState.Instance.RoundNumber;

		// Wait for the specified length of time until yielding control back to the game loop.
		yield return m_StartWait;
	}


	private IEnumerator RoundPlaying ()
	{
		// As soon as the round begins playing let the players control the tanks.
		EnableTankControl ();

		// Clear the text from the screen.
		m_MessageText.text = string.Empty;

		// While there is not one tank left...
		while (!GameSettings.Instance.ShouldFinishRound())
		{
			// ... return on the next frame.
			yield return null;
		}
	}


	private IEnumerator RoundEnding ()
	{
		// Stop tanks from moving.
		DisableTankControl ();

		var winner = GameSettings.Instance.OnEndRound();

		// Get a message based on the scores and whether or not there is a game winner and display it.
		string message = EndMessage (winner);
		m_MessageText.text = message;

		// Wait for the specified length of time until yielding control back to the game loop.
		yield return m_EndWait;
	}

	// Returns a string message to display at the end of each round.
	private string EndMessage(TankThinker winner)
	{
		return winner != null ? winner.player.PlayerInfo.GetColoredName() + " WINS THE ROUND!" : "DRAW!";
	}

	private void EnableTankControl()
	{
		for (int i = 0; i < m_Tanks.Count; i++)
		{
			//if (m_Tanks[i])
				//m_Tanks[i].enabled = true;
		}
	}


	private void DisableTankControl()
	{
		for (int i = 0; i < m_Tanks.Count; i++)
		{
			//if (m_Tanks[i])
				//m_Tanks[i].enabled = false;
		}
	}
}