using UnityEngine;
using System; // environment.newline 사용하기 위해 필요 
using TMPro;
public class Exit : MonoBehaviour
{
    // Take → Took → Taken 완료 여부를 확인
    [SerializeField] private MazeManager mazeManager;
    [SerializeField] private TMP_Text feedbackText;
    [SerializeField] private GameObject feedbackPanel;
    private void OnTriggerEnter(Collider other)
    {
        // Exit 영역에 들어온 물체가 Player인지 확인
        if (other.CompareTag("Player"))
        {
            // take, took, taken을 모두 맞혔는지 확인 
            if (mazeManager.IsCompleted())
            {
                float elapsedTime = mazeManager.GetElapsedTime();
                int wrongCount = mazeManager.GetWrongCount();
                string feedbackMessage = GetFeedbackMessage(wrongCount);

                if (feedbackText != null)
                {
                    feedbackPanel.SetActive(true);
                    feedbackText.text = "YOU ESCAPED!" + Environment.NewLine + Environment.NewLine +
                                        "Time: " + mazeManager.GetElapsedTime() + "s" + Environment.NewLine +
                                        "Mistakes: " + mazeManager.GetWrongCount() + Environment.NewLine +
                                        feedbackMessage;
                }
                Debug.Log("You escaped!");
            }
            else
            {
                Debug.Log("Find all correct words first!");
                if (feedbackText != null)
                {
                    feedbackText.text = "Find all correct words first!";
                }
            }
        }
    }
    private string GetFeedbackMessage (int wrongCount)
    {
        if (wrongCount == 0)
        {
            return "Perfect! Let's go to the next level!";
        }
        else if (wrongCount >= 1 && wrongCount <= 2)
        {
            return "Good effort! Let's try to improve next time!";
        }
        else
        {
            return "Review the tense order: Take -> Took -> Taken.";
        }
    }
}