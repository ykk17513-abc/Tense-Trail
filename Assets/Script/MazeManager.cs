using UnityEngine; 
using TMPro; // TextMeshProf를 사용하기 위한 네임스페이스

public class MazeManager : MonoBehaviour
{
    [SerializeField] private TMP_Text feedbackText; // 피드백을 표시할 TMP_Text
    [SerializeField] private TMP_Text progressText; // 진행 상황을 표시할 TMP_Text

    private string[] correctOrder = { "Take", "Took", "Taken" }; //배열(ARRAY); 정답 순서
    private int currentIndex = 0; // 처음에 "Take"를 맞춰야 하므로 0으로 초기화 
    private float startTime; // 게임 시작 시간
    private int wrongCount = 0; // 오답 횟수 카운트

    private void Start()
    {
        startTime = Time.time; // 게임 시작 시간 기록
    }

    public bool CheckAnswer(string selectedWord) // 다른스크립트에서 호출 가능, true/false 반환, CheckAnswer 클래스, selectedWord 매개변수
    {
        // 모든 정답을 이미 찾았으면 배열을 확인하지 않음 
        if (currentIndex >= correctOrder.Length) // take, took, taken 다 맞춤 ("=="로 써도 되긴함)
        {
            return false; // 더 이상 확인할 필요 없음
        }
        // 선택한 단어가 현재 목표 단어와 같으면 정답
        if (selectedWord == correctOrder[currentIndex])
        {
            Debug.Log("Correct!");
            if (feedbackText != null) // 목적: 게임 화면에 피드백 표시 
            {
                feedbackText.text = "Correct!";
            }
            currentIndex++; // 다음 정답 순서로 이동 
            return true;
        }

        wrongCount = wrongCount + 1; // 오답일 때마다 1씩 증가

        // 현재 순서에 맞지 않는 단어를 선택한 경우 오답
        Debug.Log("Try again");
        if (feedbackText != null)  // 목적: 게임 화면에 피드백 표시 
        {
            feedbackText.text = "Try again!";
        }
        return false;
    }
    // Take, Took, Taken 순서대로 맞췄는지 확인
    public bool IsCompleted()
    {
        return currentIndex >= correctOrder.Length;
    }

    public int GetWrongCount() // 오답 횟수 반환
    {
        return wrongCount;
    }

    public float GetElapsedTime() // 경과 시간 반환
    {
        return Time.time - startTime;
    }
}