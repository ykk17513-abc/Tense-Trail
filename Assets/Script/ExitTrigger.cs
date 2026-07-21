using UnityEngine;
using TMPro;
public class Exit : MonoBehaviour
{
    // Take → Took → Taken 완료 여부를 확인
    [SerializeField] private MazeManager mazeManager;

    // GameView 문구 표시용
    [SerializeField] private TMP_Text feedbackText;

    private void OnTriggerEnter(Collider other)
    {
        // Exit 영역에 들어온 물체가 Player인지 확인
        if (other.CompareTag("Player"))
        {
            // take, took, taken을 모두 맞혔는지 확인 
            if (mazeManager.IsCompleted())
            {
                Debug.Log("You escaped!");
                feedbackText.text = "You escaped!";

                if(feedbackText != null)
                {
                    feedbackText.text = "You escaped!";
                }
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
}