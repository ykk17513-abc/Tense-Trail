using UnityEngine; // namespace unity engine 안에 있는 모든 클래스,함수,변수들을 사용할 수 있게해주는 코드.
using UnityEngine.InputSystem;// 이게 없으면 unityengine.inputsystem.keyboard 라고 써야함. 

public class WordCard : MonoBehaviour // 상속(INHERITANCE), lifecycle (awake, (start), onenable, disable, update, (lateupdate), etc)
{
    [SerializeField] private string word;  // 문자열 변수 생성 
    [SerializeField] private MazeManager mazeManager; // (type + instance) ; GameManager의 MazeManager 연결
    [SerializeField] private Material wrongMaterial; 

    private bool playerNearby = false; // 변수 초기화(initialization);
                                       // playerNearby라는 이름의 bool 변수를 만들고, 시작할때값은 false로
                                       // '게임이 시작되는 순간, 플레이어는 아직 카드 근처에 없다'라는 상태표현
    private Renderer cardRenderer; // 오브젝트의 색깔, 재질 

    private void Awake() // 게임이 실행될 때, 가장 먼저 딱 한번만 실행되는 함수 (unity 함수, C# 문법 x)
    {
        cardRenderer = GetComponent<Renderer>();
        // 제네릭(generic); 오브젝트에 붙어있는 컴포넌트 중에, 
        // Renderer 타입인 걸 찾아서 가져와라. (카드의 색깔 변경을 위함) 
    }
    private void OnTriggerEnter(Collider other) // 이벤트 함수; 영역 체크용 ; 내 영역
    {
        if (other.CompareTag("Player")) // 들어온 물체가 플레이어인지 확인
        {
            playerNearby = true;
            Debug.Log("카드 근처!"); 
        }
    }
    private void OnTriggerExit(Collider other) //플레이어가 카드 영역 밖으로 나갔을 때 실행
    {
        if (other.CompareTag("Player")) // 나간 물체가 플레이어인지 확인
        {
            playerNearby = false;
            Debug.Log("카드에서 멀어짐!"); 
        }
    } 
    private void Update()
    {
        if (playerNearby && Keyboard.current.enterKey.wasPressedThisFrame)
        // 플레이어가 카드 근처에 있고 Enter 키를 눌렀다면 코드 실행
        {
            bool isCorrect = mazeManager.CheckAnswer(word);// 함수 호출 + 반환값 저장
            if (!isCorrect) // 부정 연산자: IScORRECT이 false이면 !isCorrect은 true가 됨. 
            {
                cardRenderer.material = wrongMaterial;
                // 정답이 아니라면, 카드의 색깔을 wrongMaterial로 변경 
            }
        }
    }
}