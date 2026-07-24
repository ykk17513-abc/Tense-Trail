# Tense Trail: Esacape the Grammar Maze (4차 시험 07.24) 
## 1. 입력 처리
- Input System의 Keyboard.current로 키 입력을 받아옴
- 이동은 W/A/S/D 키가 눌려있는지(isPressed)를 매 프레임 체크하는 방식으로 구현함
- 정답 확인은 Enter 키가 그 순간에 딱 눌렸는지(wasPressedThisFrame)를 체크하는 방식으로 구분해서 씀
  
## 2. 조작 구현
- 캐릭터 이동: WASD 입력값을 방향 벡터로 만들고, Rigidbody.MovePosition()으로 캐릭터를 물리적으로 이동시킴
- 카드 반응: Enter 키를 누르면 근처에 있는 카드(오브젝트)의 정답 여부에 따라 색깔이 바뀌게 만듦 (정답: 초록, 오답: 빨강)
  
## 3. 상태 처리
- 카드마다 "플레이어가 근처에 있냐 없냐"(playerNearby) 상태를 트리거로 체크함
- 오답 카드를 선택한 경우, 카드 색깔이 연두색에서 빨강색으로 바뀌었다가 2초 뒤 다시 원래 색(연두)으로 돌아오도록 하기 위해 코루틴 사용함 
- 전체 진행 상태는 currentIndex(몇 번째 단어 맞췄는지), wrongCount(틀린 횟수) 변수로 내부적으로 관리함
  
## 4. Cinemachine 활용
- 카메라는 미로 전체를 위에서 내려다보는 탑다운 구도로 세팅됨
- CinemachineCamera에 Tracking Target은 지정되어 있지만 Position/Rotation Control이 "None"으로 설정되어 있어 플레이어를 실시간으로 따라다니는 게 아니라 고정된 탑다운 시점으로 미로 전체를 보여주는 방식으로 구현됨
  
## 5. 상호작용
- 카드에 가까이 가면(Trigger) 반응 가능 상태가 되고, Enter 누르면 정답 체크됨
- 결과에 따라 카드 색이 바뀌고, 콘솔창에는 "Correct!" / "Try again!" 텍스트가 뜸
- Exit도 상호작용 대상이며, 플레이어가 도착하면 완료 여부에 따라 다른 반응(결과창 표시 또는 "다 못 맞췄다" 메시지)이 일어남

## 6. 게임 흐름
- Take → Took → Taken 순서대로 카드를 밟아야 하는 목표가 정해져 있음
- 진행 중엔 화면에 "Progress: 1/3" 이런 식으로 몇 개 맞췄는지 실시간으로 보여줌
- 다 맞추고 Exit에 도착하면 결과창에: 1) 정답을 맞추는데에 총 걸린 시간, 2) 오류 횟수 3) 피드백을 정리해서 보여줌.
  단, 오류 횟수에 따라 다른 피드백이 제공됨. 
  (예. 오류 횟수 0회: Perfect! Let's go to the next level! / 오류 횟수 1~2회: Good effort! Let's try to improve next time!
   / 오류 횟수 3회 이상: Review the tense order: Take -> Took -> Taken)
  
## 7. 플레이 루프 
- 시작: Start 버튼 누르면 시작 화면이 꺼지고 게임이 시작됨 (버튼 On Click에 SetActive 연결되어 있음) (GameView 04_0724 참고)
- 진행: WASD로 미로 돌아다니면서 enter키로 카드를 밟아 정답 맞추는 과정 (GameView 05_0724 참고)
- 종료: Exit 도착 시 결과창이 뜨며 Exit버튼을 누르면 게임이 종료됨(걸린 시간, 실수 횟수, 피드백) 뜨면서 게임 끝 (GameView 06_0724 참고)
