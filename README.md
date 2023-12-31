# GatherLike

### 내일배움캠프 - Unity 게임개발 입문 개인과제 (2023.09.05) 
 
# 과제 개요
- Unity를 이용해 게더를 모방해 만드는 과제
- 타일맵을 이용해 배경을 꾸밉니다.
- 기본 UI 들을 활용해 적용하는 연습이 포함됩니다.


# 구현 내용

## UI
- 플레이어의 닉네임을 설정할 수 있습니다.
- 글자 수는 2자에서 8자로 제한됩니다.
- 이후 메인 게임에서 플레이어의 닉네임을 표시합니다.

## 캐릭터
- 캐릭터는 플레이어와 몬스터로 구분됩니다.
- 모든 캐릭터는 각자 애니매이션을 반복하며, 서 있을 때, 이동할 때, 피격당했을 때 애니매이션을 구분지었습니다. 메인 Animator Controller를 만들고 Animator Overried Controller를 통해 나머지 애니매이션을 만들었습니다.

## 플레이어
- Input System Asset을 이용해 플레이어의 입력을 제어합니다.
- 키보드 방향키 또는 WASD를 이용해 캐릭터가 이동합니다. 플레이어가 이동함에 따라 카메라가 따라 움직입니다.
- 플레이어와 무기는 마우스의 방향을 바라봅니다.
- 마우스 휠로 카메라 줌인과 줌아웃을 할 수 있습니다.
- 마우스 왼쪽 클릭으로 공격을 할 수 있습니다. 공격은 쿨타임이 있으며 인스펙터에서 값을 수정할 수 있습니다.
- 플레이어의 공격인 화살은 생성과 동시에 앞으로 날아가며, 벽이나 몬스터와의 충돌을 감지합니다. 벽에 맞으면 일정 시간이 지난 후 제거되고, 몬스터에 맞으면 몬스터의 체력을 감소시킵니다.

## 몬스터
- Wizard, Lizard, Pumpkin 3 종류가 있습니다.
- MonsterSpawner를 통해 시간에 따라 랜덤하게 반복 생성됩니다.
- 종류에 따라 이동속도, 체력이 다르게 설정했습니다.
- 플레이어의 위치를 파악해 플레이어로 다가가게 만들었습니다.
- 공격에 맞으면 체력이 줄어들고, 피격 애니매이션 효과를 만들었습니다.
- 체력이 0이 되면 서서히 사라지는 효과와 함께 오브젝트를 파괴합니다.

## 타일맵
- 타일 맵을 이용해 맵을 만들었습니다.
- Tilemap Collider를 통해 캐릭터가 벽을 통과하지 못합니다.