using UnityEngine;
using TMPro;
using JetBrains.Annotations;

public class MazeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text feedbackText; // 피드백을 표시할 TMP_Text

    private string[] correctOrder = { "Take", "Took", "Taken" };
    private int currentIndex = 0;

    public bool CheckAnswer(string selectedWord)
    {
        // 모든 정답을 이미 찾았으면 배열을 확인하지 않음 
        if (currentIndex >= correctOrder.Length)
        {
            return false;
        }

        // 선택한 단어가 현재 목표 단어와 같으면 정답
        if (selectedWord == correctOrder[currentIndex])
        {
            Debug.Log("Correct!");
            if (feedbackText != null)
            {
                feedbackText.text = "Correct!";
            }
            currentIndex++; // 다음 정답 순서로 이동 
            return true;
        }

        // 현재 순서에 맞지 않는 단어를 선택한 경우 오답
        Debug.Log("Try again");
        if (feedbackText != null)
        {
            feedbackText.text = "Try again!";
        }

        return false;
    }
    public bool IsCompleted()
    {
        return currentIndex >= correctOrder.Length;
    }
}