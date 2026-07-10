using UnityEngine;
using TMPro;

public class Exit : MonoBehaviour
{
    [SerializeField] private MazeManager mazeManager;
    [SerializeField] private TMP_Text feedbackText;

    private void OnTriggerEnter(Collider other)
    {
        // Exit 영역에 들어온 물체가 Player인지 확인
        if (other.CompareTag("Player"))
        {
            // take, took, taken을 모두 맞힌 경우
            if (mazeManager.IsCompleted())
            {
                Debug.Log("You escaped!");
                feedbackText.text = "You escaped!";
            }
            else
            {
                Debug.Log("Find all correct words first!");
                feedbackText.text = "Find all correct words first!";
            }
        }
    }
}